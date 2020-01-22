using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDoData
{
    internal class Resto
    {
        internal const String CountryNL = "NL";
        internal const String CountryBE = "BE";
        private const char lDel = ';';

        protected string bCountry { get; set; }

        protected double bLongitude { get; set; }
        internal double xLongitude { get { return bLongitude; } }
        protected double bLatitude { get; set; }
        internal double xLatitude { get { return bLatitude; } }

        protected String bName { get; set; }
        internal String xName { get { return bName; } }
        protected String bDescr { get; set; }
        internal String xDescr { get { return bDescr; } }
        protected String bID { get; set; }
        internal String xID { get { return bID; } }
        protected String bAddress { get; set; }
        internal String xAddress { get { return bAddress; } }
        protected String bPostalCode { get; set; }
        internal String xPostalCode { get { return bPostalCode; } }
        protected String bCity { get; set; }
        internal String xCity { get { return bCity; } }
        protected String bHoursMonday { get; set; }
        internal String xHoursMonday { get { return bHoursMonday; } }
        protected String bHoursTuesday { get; set; }
        internal String xHoursTuesday { get { return bHoursTuesday; } }
        protected String bHoursWednesday { get; set; }
        internal String xHoursWednesday { get { return bHoursWednesday; } }
        protected String bHoursThursday { get; set; }
        internal String xHoursThursday { get { return bHoursThursday; } }
        protected String bHoursFriday { get; set; }
        internal String xHoursFriday { get { return bHoursFriday; } }
        protected String bHoursSaturday { get; set; }
        internal String xHoursSaturday { get { return bHoursSaturday; } }
        protected String bHoursSunday { get; set; }
        internal String xHoursSunday { get { return bHoursSunday; } }
        protected String bDriveHoursMonday { get; set; }
        internal String xDriveHoursMonday { get { return bDriveHoursMonday; } }
        protected String bDriveHoursTuesday { get; set; }
        internal String xDriveHoursTuesday { get { return bDriveHoursTuesday; } }
        protected String bDriveHoursWednesday { get; set; }
        internal String xDriveHoursWednesday { get { return bDriveHoursWednesday; } }
        protected String bDriveHoursThursday { get; set; }
        internal String xDriveHoursThursday { get { return bDriveHoursThursday; } }
        protected String bDriveHoursFriday { get; set; }
        internal String xDriveHoursFriday { get { return bDriveHoursFriday; } }
        protected String bDriveHoursSaturday { get; set; }
        internal String xDriveHoursSaturday { get { return bDriveHoursSaturday; } }
        protected String bDriveHoursSunday { get; set; }
        internal String xDriveHoursSunday { get { return bDriveHoursSunday; } }
        internal readonly string[] bServiceNames = { "Wifi", "Drive", "Play", "Parking", "BreakfastLight", "Terrace", "DebitCard", "E-cheque", "EasyOrder", "LateOpen", "EVCharge", "BreakfastFull", "Wheelchair", "TableService", "Delivery" };
        internal bool[] bServices;

        internal Resto()
        {
            bCountry = "";
            bLongitude = 0;
            bLatitude = 0;
            bName = "";
            bDescr = "";
            bID = "";
            bAddress = "";
            bPostalCode = "";
            bCity = "";
            bHoursMonday = "";
            bHoursTuesday = "";
            bHoursThursday = "";
            bHoursWednesday = "";
            bHoursThursday = "";
            bHoursFriday = "";
            bHoursSaturday = "";
            bHoursSunday = "";
            bDriveHoursMonday = "";
            bDriveHoursTuesday = "";
            bDriveHoursThursday = "";
            bDriveHoursWednesday = "";
            bDriveHoursThursday = "";
            bDriveHoursFriday = "";
            bDriveHoursSaturday = "";
            bDriveHoursSunday = "";

            sInitServices();
        }

        private void sInitServices()
        {
            int lCount;

            bServices = new bool[bServiceNames.Length];
            for (lCount = 0; lCount < bServices.Length; lCount++)
            {
                bServices[lCount] = false;
            }
        }

        internal string xCsvValues()
        {
            StringBuilder lResult;
            int lCount;

            lResult = new StringBuilder();
            lResult.Append(bID);
            lResult.Append(lDel);
            lResult.Append(bName);
            lResult.Append(lDel);
            lResult.Append(bDescr);
            lResult.Append(lDel);
            lResult.Append(bAddress);
            lResult.Append(lDel);
            lResult.Append(bPostalCode);
            lResult.Append(lDel);
            lResult.Append(bCity);
            lResult.Append(lDel);
            lResult.Append(bLongitude);
            lResult.Append(lDel);
            lResult.Append(bLatitude);
            lResult.Append(lDel);
            lResult.Append(bHoursMonday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursMonday);
            lResult.Append(lDel);
            lResult.Append(bHoursTuesday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursTuesday);
            lResult.Append(lDel);
            lResult.Append(bHoursWednesday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursWednesday);
            lResult.Append(lDel);
            lResult.Append(bHoursThursday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursThursday);
            lResult.Append(lDel);
            lResult.Append(bHoursFriday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursFriday);
            lResult.Append(lDel);
            lResult.Append(bHoursSaturday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursSaturday);
            lResult.Append(lDel);
            lResult.Append(bHoursSunday);
            lResult.Append(lDel);
            lResult.Append(bDriveHoursSunday);
            for (lCount = 0; lCount < bServices.Length; lCount++)
            {
                lResult.Append(lDel);
                lResult.Append(bServices[lCount]);
            }

            return lResult.ToString();
        }

        internal static string xCsvHeader()
        {
            String lResult;

            lResult = "ID;" +
                "Name;" +
                "Descr.;" +
                "Address;" +
                "bPostalCode;" +
                "City;" +
                "Longitude;" +
                "Latitude;" +
                "Monday;" +
                "DriveMonday;" +
                "Tuesday;" +
                "DriveTuesday;" +
                "Wednesday;" +
                "DriveWednesday;" +
                "Thursday;" +
                "DriveThursday;" +
                "Friday;" +
                "DriveFriday;" +
                "Saturday;" +
                "DriveSaturday;" +
                "Sunday;" +
                "DriveSunday;" +
                "Wifi;" +
                "Drive;" +
                "Play;" +
                "Parking;" +
                "BreakfastLight;" +
                "Terrace;" +
                "DebitCard; " +
                "E-cheque;" +
                "EasyOrder;" +
                "LateOpen;" +
                "EVCharge;" +
                "BreakfastFull;" +
                "Wheelchair;" +
                "TableService;" +
                "Delivery";

            return lResult;
        }
    }
}
