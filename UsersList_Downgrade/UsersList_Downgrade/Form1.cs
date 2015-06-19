using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.TeamFoundation.Proxy;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;

//Third party free 
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

//Excel
using Excel = Microsoft.Office.Interop.Excel;

namespace UsersList
{
    /// <summary>
    /// frmTFSView
    /// </summary>
    public partial class frmTFSView : Form
    {
        //private TfsTeamProjectCollection _server;
        //public ProjectInfo[] SelectedProjects { get; }
        private TeamFoundationServer _server;
        private VersionControlServer _versionControl;
        private IGroupSecurityService _securityService;
        UserDetails _userDetail;
        Hashtable _glUsers = new Hashtable();
        TeamProject[] teamProjects = null;
        BackgroundWorker bgw = new BackgroundWorker();    

        /// <summary>
        /// 
        /// </summary>
        public frmTFSView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dp_Click(object sender, EventArgs e)
        {
            /*Code for picking from Server Picker TFS control
            DomainProjectPicker dp = new DomainProjectPicker(DomainProjectPickerMode.AllowMultiSelect);
            if (dp.ShowDialog() != DialogResult.Cancel)
            { 
             
            }*/

            //bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            //bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            //bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            //bgw.WorkerReportsProgress = true;
            //bgw.RunWorkerAsync();
            //pbrProgress.Visible = true; 

            string serverChecked; 
            if(rtnGIRMS27.Checked)
                serverChecked= "GIRMS27";
            else
                serverChecked= "GIRMSC9";

            _server = new TeamFoundationServer("http://"+serverChecked+":8080");

            _server.EnsureAuthenticated();
            _versionControl = (VersionControlServer)_server.GetService(typeof(VersionControlServer));
            _securityService = (IGroupSecurityService)_server.GetService(typeof(IGroupSecurityService));
            
            teamProjects = _versionControl.GetAllTeamProjects(false);
              
            int i = 0;
            lstProjects.Items.Clear();
            lstProjects.Items.Add("All TFS Projects");
            lstProjects.Items.Add("");
            dtView.DataSource = null;
            dtView.Rows.Clear();
            _glUsers.Clear(); 

            foreach (TeamProject tp in teamProjects)
            {
                lstProjects.Items.Add(tp.Name);
                Identity[] appGroups = _securityService.ListApplicationGroups(tp.ArtifactUri.AbsoluteUri);
                foreach (Identity group in appGroups)
                {
                    Identity[] groupMembers = _securityService.ReadIdentities(SearchFactor.Sid, new string[] { group.Sid }, QueryMembership.Expanded);
                    if (groupMembers.Length == 0) break;
                    foreach (Identity member in groupMembers)
                    {
                        if (member.Members.Length == 0) break;
                        if (member.Members != null)
                        {
                            foreach (string memberSid in member.Members)
                            {
                                Identity memberInfo = _securityService.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.None);
                                if (memberInfo.Type != IdentityType.WindowsUser) continue;

                                if (_glUsers.Contains(memberInfo.Sid))
                                    _userDetail = (UserDetails)_glUsers[memberInfo.Sid];
                                else
                                    _userDetail = new UserDetails(memberInfo);


                                //update the project and permission
                                _userDetail.TeamProject = tp.Name;
                                _userDetail.Permission = group.DisplayName;
                                _userDetail.UpdateProjectAndPermission(tp.Name, group.DisplayName);
                                if (_glUsers.ContainsKey(memberInfo.Sid))
                                    _glUsers.Remove(memberInfo.Sid);

                                _glUsers.Add(memberInfo.Sid, _userDetail);

                            }
                        }
                    }
                }


            }
            int sn = 0;
            dtView.Rows.Add(_glUsers.Count + 1);
            foreach (UserDetails userIdentity in _glUsers.Values)
            {                    
                dtView.Rows[sn].Cells[0].Value = userIdentity.UserName;
                dtView.Rows[sn].Cells[1].Value = userIdentity.ADId;
                dtView.Rows[sn].Cells[2].Value = userIdentity.EmailAdd;
                dtView.Rows[sn].Cells[3].Value = userIdentity.Domain;
                string v = string.Empty;
                Hashtable ht = userIdentity.PaR;
                foreach (string str in userIdentity.PaR.Values)
                {
                    v = string.Format("{0}{1}", v, str);
                }
                dtView.Rows[sn].Cells[4].Value = v;
                dtView.Rows[sn].Cells[5].Value = userIdentity.Status;
                sn++;
            }
            
            lblConnectedServer.Visible = true;
            lblServer.Text = serverChecked;
            frmTFSView.ActiveForm.Text = "Team Foundation Server - Projects & Users" + " : Connected To (" + serverChecked + ")";
            //pbrProgress.Visible = true; 
        }

        /// <summary>
        /// GetTfsUsers Method Definition
        /// </summary>
        /// <param name="server"></param>
        private void GetTfsUsers(TeamFoundationServer server)
        {
            IGroupSecurityService gss = (IGroupSecurityService)server.GetService(typeof(IGroupSecurityService));
            Identity SIDS = gss.ReadIdentity(SearchFactor.AccountName, "Project Collection Valid Users", QueryMembership.Expanded);
            Identity[] UserId = gss.ReadIdentities(SearchFactor.Sid, SIDS.Members, QueryMembership.None);
        }

        /// <summary>
        /// GetLIstOfUserNames Method Definition
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public Boolean GetListOfUserNames(string projectName)
        {            
            dtView.DataSource = null;
            dtView.Rows.Clear();
            _glUsers.Clear();

            if (projectName == "ALL")
            {
                lstProjects.Items.Clear();
                lstProjects.Items.Add("All TFS Projects");
                lstProjects.Items.Add("");
                teamProjects = _versionControl.GetAllTeamProjects(false);
                foreach (TeamProject tp in teamProjects)
                {                    
                    lstProjects.Items.Add(tp.Name);
                    Identity[] appGroups = _securityService.ListApplicationGroups(tp.ArtifactUri.AbsoluteUri);
                    foreach (Identity group in appGroups)
                    {
                        Identity[] groupMembers = _securityService.ReadIdentities(SearchFactor.Sid, new string[] { group.Sid }, QueryMembership.Expanded);
                        if (groupMembers.Length == 0) break;
                        foreach (Identity member in groupMembers)
                        {
                            if (member.Members.Length == 0) break;
                            if (member.Members != null)
                            {
                                foreach (string memberSid in member.Members)
                                {
                                    Identity memberInfo = _securityService.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.None);
                                    if (memberInfo.Type != IdentityType.WindowsUser) continue;

                                    if (_glUsers.Contains(memberInfo.Sid))
                                        _userDetail = (UserDetails)_glUsers[memberInfo.Sid];
                                    else
                                        _userDetail = new UserDetails(memberInfo);


                                    //update the project and permission
                                    _userDetail.TeamProject = tp.Name;
                                    _userDetail.Permission = group.DisplayName;
                                    _userDetail.UpdateProjectAndPermission(tp.Name, group.DisplayName);
                                    if (_glUsers.ContainsKey(memberInfo.Sid))
                                        _glUsers.Remove(memberInfo.Sid);

                                    _glUsers.Add(memberInfo.Sid, _userDetail);

                                }
                            }
                        }
                    }


                }
            }
            else if (projectName == "")
            { 
            
            }
            else
            {
                TeamProject teamproject = _versionControl.GetTeamProject(projectName);
                Identity[] appGroups = _securityService.ListApplicationGroups(teamproject.ArtifactUri.AbsoluteUri);
                List<Identity> usernames = new List<Identity>();

                foreach (Identity group in appGroups)
                {
                    Identity[] groupMembers = _securityService.ReadIdentities(SearchFactor.Sid, new string[] { group.Sid }, QueryMembership.Expanded);

                    foreach (Identity member in groupMembers)
                    {
                        if (member.Members != null)
                        {

                            foreach (string memberSid in member.Members)
                            {
                                Identity memberInfo = _securityService.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.None);
                                if (memberInfo.Type != IdentityType.WindowsUser) continue;

                                if (usernames.Contains(memberInfo))
                                    _userDetail = (UserDetails)_glUsers[memberInfo.Sid];
                                else
                                    _userDetail = new UserDetails(memberInfo);


                                //update the project and permission
                                _userDetail.TeamProject = teamproject.Name;
                                _userDetail.Permission = group.DisplayName;
                                _userDetail.UpdateProjectAndPermission(teamproject.Name, group.DisplayName);
                                if (_glUsers.ContainsKey(memberInfo.Sid))
                                    _glUsers.Remove(memberInfo.Sid);

                                _glUsers.Add(memberInfo.Sid, _userDetail);

                            }
                        }
                    }
                }
            }

            int sn = 0;
            dtView.Rows.Add(_glUsers.Count + 1);
            foreach (UserDetails userIdentity in _glUsers.Values)
            {
                dtView.Rows[sn].Cells[0].Value = userIdentity.UserName;
                dtView.Rows[sn].Cells[1].Value = userIdentity.ADId;
                dtView.Rows[sn].Cells[2].Value = userIdentity.EmailAdd;
                dtView.Rows[sn].Cells[3].Value = userIdentity.Domain;
                string v = string.Empty;
                Hashtable ht = userIdentity.PaR;
                foreach (string str in userIdentity.PaR.Values)
                {
                    v = string.Format("{0}{1}", v, str);
                }
                dtView.Rows[sn].Cells[4].Value = v;
                dtView.Rows[sn].Cells[5].Value = userIdentity.Status;
                sn++;
            }
            return true; 
            
        }

        /// <summary>
        /// Export Excel Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpXL_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNameExcel = string.Empty;
                dlgSave.Filter = "Excel Files|*.xls*";
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(dlgSave.FileName))
                        fileNameExcel = dlgSave.FileName;

                }
                else
                    return;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[1];

                int i = 0;
                int j = 0;

                foreach (DataGridViewColumn dc in dtView.Columns)
                {
                    DataGridViewCell cell = dtView.Columns[dc.Index].HeaderCell;
                    xlWorkSheet.Cells[1, 1 + dc.Index] = cell.Value;
                }

                xlWorkSheet.get_Range("A1", "AG1").Font.Bold = true;
                Excel.Range oRng = xlWorkSheet.get_Range("A1", "AG1");
                oRng.EntireColumn.AutoFit();
                oRng.Interior.Color = System.Drawing.Color.Gray;
                xlWorkSheet.get_Range("A1", "AG1").Font.Background = true;


                for (i = 0; i <= dtView.RowCount - 1; i++)
                {
                    for (j = 0; j <= dtView.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dtView[j, i];
                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs(fileNameExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
        
        /// <summary>
        /// Release Object
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        
        /// <summary>
        /// Export PDF Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string fileNamePDF = string.Empty;
                dlgSave.Filter = "PDF File|*.pdf";

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(dlgSave.FileName))
                        fileNamePDF = dlgSave.FileName;

                }
                else
                    return;

                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

                PdfWriter wri = PdfWriter.GetInstance(pdfDoc, new FileStream(fileNamePDF, FileMode.Create));
                pdfDoc.Open();

                PdfPTable pdfTable = new PdfPTable(dtView.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                foreach (DataGridViewColumn dc in dtView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dc.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                foreach (DataGridViewRow dr in dtView.Rows)
                {
                    if (dr.Cells[0].Value == null) break;
                    foreach (DataGridViewCell drc in dr.Cells)
                    {
                        pdfTable.AddCell(drc.Value.ToString());
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// On lstProjects Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProjects.SelectedItem.ToString()=="All TFS Projects")
                GetListOfUserNames("ALL"); 
            else
                GetListOfUserNames(lstProjects.SelectedItem.ToString()); 
        }

        //void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //do the code when bgv completes its work
        //}
        
        //void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    pbrProgress.Value = e.ProgressPercentage;            
        //}
        
        //void bgw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    int total = 57; 

        //    for (int i = 0; i <= total; i++)  
        //    {
        //        System.Threading.Thread.Sleep(100);
        //        int percents = (i * 100) / total;
        //        bgw.ReportProgress(percents, i);                
        //    }
        //}
       
    }
}