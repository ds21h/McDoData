using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDoData
{
    internal class RestoNL : Resto
    {
        internal RestoNL(JObject pResto) : base()
        {
            bCountry = CountryNL;
            sProcessGeo(pResto);
            sProcessProperties(pResto);
            sProcessHours(pResto);
        }

        private void sProcessGeo(JObject pResto)
        {
            object lJObject;
            JObject lGeo;
            JArray lCoor;

            lJObject = pResto["geometry"];
            if (lJObject != null)
            {
                lGeo = (JObject)lJObject;
                lJObject = lGeo["coordinates"];
                if (lJObject != null)
                {
                    lCoor = (JArray)lJObject;
                    if (lCoor.Count > 0)
                    {
                        bLongitude = (double)lCoor[0];
                        if (lCoor.Count > 1)
                        {
                            bLatitude = (double)lCoor[1];
                        }
                    }
                }
            }
        }

        private void sProcessProperties(JObject pResto)
        {
            object lJObject;
            JObject lProp;
            JValue lValue;

            lJObject = pResto["properties"];
            if (lJObject != null)
            {
                lProp = (JObject)lJObject;

                lValue = (JValue)lProp["name"];
                if (lValue != null)
                {
                    bName = (String)lValue;
                }

                lValue = (JValue)lProp["longDescription"];
                if (lValue != null)
                {
                    bDescr = (String)lValue;
                }

                lValue = (JValue)lProp["id"];
                if (lValue != null)
                {
                    bID = (String)lValue;
                }

                lValue = (JValue)lProp["addressLine1"];
                if (lValue != null)
                {
                    bAddress = (String)lValue;
                }
                lValue = (JValue)lProp["addressLine3"];
                if (lValue != null)
                {
                    bCity = (String)lValue;
                }
                lValue = (JValue)lProp["postcode"];
                if (lValue != null)
                {
                    bPostalCode = (String)lValue;
                }
            }
        }

        private void sProcessHours(JObject pResto)
        {
            object lJObject;
            JObject lProp;
            JObject lHours;
            JValue lValue;

            lJObject = pResto["properties"];
            if (lJObject != null)
            {
                lProp = (JObject)lJObject;
                lJObject = lProp["restauranthours"];
                if (lJObject != null)
                {
                    lHours = (JObject)lJObject;

                    lValue = (JValue)lHours["hoursMonday"];
                    if (lValue != null)
                    {
                        bHoursMonday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursTuesday"];
                    if (lValue != null)
                    {
                        bHoursTuesday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursWednesday"];
                    if (lValue != null)
                    {
                        bHoursWednesday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursThursday"];
                    if (lValue != null)
                    {
                        bHoursThursday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursFriday"];
                    if (lValue != null)
                    {
                        bHoursFriday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursSaturday"];
                    if (lValue != null)
                    {
                        bHoursSaturday = (String)lValue;
                    }
                    lValue = (JValue)lHours["hoursSunday"];
                    if (lValue != null)
                    {
                        bHoursSunday = (String)lValue;
                    }
                }

                lJObject = lProp["drivethruhours"];
                if (lJObject != null)
                {
                    bServices[1] = true;

                    lHours = (JObject)lJObject;

                    lValue = (JValue)lHours["driveHoursMonday"];
                    if (lValue != null)
                    {
                        bDriveHoursMonday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursTuesday"];
                    if (lValue != null)
                    {
                        bDriveHoursTuesday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursWednesday"];
                    if (lValue != null)
                    {
                        bDriveHoursWednesday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursThursday"];
                    if (lValue != null)
                    {
                        bDriveHoursThursday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursFriday"];
                    if (lValue != null)
                    {
                        bDriveHoursFriday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursSaturday"];
                    if (lValue != null)
                    {
                        bDriveHoursSaturday = (String)lValue;
                    }
                    lValue = (JValue)lHours["driveHoursSunday"];
                    if (lValue != null)
                    {
                        bDriveHoursSunday = (String)lValue;
                    }
                }
            }
        }
    }
}
