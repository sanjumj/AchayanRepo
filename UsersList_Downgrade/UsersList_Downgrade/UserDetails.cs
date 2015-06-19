using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.TeamFoundation.Server;
using System.Collections;

namespace UsersList
{
    class UserDetails
    {
        private string _userName = string.Empty;
        private string _domain = string.Empty;
        private string _adId = string.Empty;
        private string _email = string.Empty;
        private string _status = string.Empty;
        private Hashtable _hsVals = new Hashtable();
        private ArrayList _prjs = new ArrayList();
        private ArrayList _fstr = new ArrayList();
                
        string _prjNameAndPerTmplateOne = @"{0} {1} {2} {3} {4} {5}";
        string _prjNameAndPerTmplateTwo = @"{0} {1} {2} {3} {4} {5} {6} {7}";
        string _prjNameAndPerUpdateVal = string.Empty;

        public UserDetails()
        {
        }
        public UserDetails(Identity mbrInfo)
        {
            //_mbrInfo = mbrInfo;
            _userName = mbrInfo.DisplayName;
            _domain = mbrInfo.Domain;
            _adId = mbrInfo.AccountName;
            _email = mbrInfo.MailAddress;
            _status = mbrInfo.Deleted ? "INACTIVE" : "ACTIVE";
        }

        public void UpdateProjectAndPermission(string prjName, string permission)
        {
            if (_hsVals.Contains(prjName))
            {
                _prjNameAndPerUpdateVal = string.Format(_prjNameAndPerTmplateOne, (string)_hsVals[prjName], Environment.NewLine, "\t", "\t", "\t", permission);
                _hsVals.Remove(prjName);
                _hsVals.Add(prjName, _prjNameAndPerUpdateVal);
            }
            else
            {
                _prjNameAndPerUpdateVal = string.Format(_prjNameAndPerTmplateTwo, Environment.NewLine, prjName, Environment.NewLine, "\t", "\t", "\t", permission, Environment.NewLine);
                _hsVals.Add(prjName, _prjNameAndPerUpdateVal);
            }
        }

        public string UserName
        {
            get { return _userName; }
        }
        public string Domain
        {
            get { return _domain; }
        }
        public string ADId
        {
            get { return _adId; }
        }
        public string EmailAdd
        {
            get { return _email; }
        }
        public string Status
        {
            get { return _status; }
        }

        public Hashtable PaR
        {
            get { return _hsVals; }
        }
        public string Permission
        {
            set
            {
                if (!_fstr.Contains(value)) 
                    _fstr.Add(value);
            }
            get
            {
                return string.Join(",", _fstr.ToArray());
            }
        }
        public string TeamProject
        {
            set
            {
                if (!_prjs.Contains(value))
                    _prjs.Add(value);
            }
            get
            {
                return string.Join(",", _prjs.ToArray());
            }
        }
    }
}
