using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortRomanOOP
{
    abstract class Commercialorganisation
    {
        public string LicenseNumber;
        public bool IsLicenseValid;
        public DateTime DateExpired;
        public abstract void GetLicense();
        public abstract void CancelLicense();

        public Commercialorganisation(string LicenseNumber, bool IsLicenseValid, DateTime DateExpired)
        {
            this.LicenseNumber = LicenseNumber;
            this.IsLicenseValid = IsLicenseValid;
            this.DateExpired = DateExpired;
        }
    }
}
