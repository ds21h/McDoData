using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDoData
{
    class RestoBE : Resto
    {
        internal RestoBE(JObject pResto) : base()
        {
            bCountry = CountryBE;
            sProcessResto(pResto);
        }

        internal void xProcesDetails(JObject pDetails)
        {
            JValue lValue;
            object lObject;
            JObject lResto;
            String lResult;
            string lStreet = "";
            string lNumber = "";
            string lOpeningHours;

            lValue = (JValue)pDetails["istatus"];
            if (lValue != null)
            {
                lResult = (String)lValue;
                if (lResult.Equals("success", StringComparison.Ordinal))
                {
                    lObject = pDetails["resto"];
                    if (lObject != null)
                    {
                        lResto = (JObject)lObject;

                        lValue = (JValue)lResto["postal_code"];
                        if (lValue != null)
                        {
                            bPostalCode = (String)lValue;
                        }

                        lValue = (JValue)lResto["city_nl"];
                        if (lValue != null)
                        {
                            bCity = (String)lValue;
                        }

                        lValue = (JValue)lResto["street_nl"];
                        if (lValue != null)
                        {
                            lStreet = (String)lValue;
                        }
                        lValue = (JValue)lResto["no"];
                        if (lValue != null)
                        {
                            lNumber = (String)lValue;
                        }
                        if (lStreet.Length > 0 || lNumber.Length > 0)
                        {
                            bAddress = lStreet + " " + lNumber;
                        }

                        lValue = (JValue)lResto["opening_hours_nl"];
                        if (lValue != null)
                        {
                            lOpeningHours = (String)lValue;
                            sProcessOpeningHours(lOpeningHours);
                        }
                    }
                }
            }
        }

        private void sProcessOpeningHours(String pOpeningHours)
        {
            List<string> lPars;

            lPars = sSplitOpening(pOpeningHours);
            if (lPars.Count > 0)
            {
                bHoursMonday = lPars.ElementAt(0);
                if (lPars.Count > 1)
                {
                    bHoursTuesday = lPars.ElementAt(1);
                    if (lPars.Count > 2)
                    {
                        bHoursWednesday = lPars.ElementAt(2);
                        if (lPars.Count > 3)
                        {
                            bHoursThursday = lPars.ElementAt(3);
                            if (lPars.Count > 4)
                            {
                                bHoursFriday = lPars.ElementAt(4);
                            }
                        }
                    }
                }
            }
        }

        private void sProcessResto(JObject pResto)
        {
            JValue lValue;

            lValue = (JValue)pResto["id"];
            if (lValue != null)
            {
                bID = (String)lValue;
            }

            lValue = (JValue)pResto["title"];
            if (lValue != null)
            {
                bName = (String)lValue;
            }

            lValue = (JValue)pResto["lng"];
            if (lValue != null)
            {
                bLongitude = (double)lValue;
            }

            lValue = (JValue)pResto["lat"];
            if (lValue != null)
            {
                bLatitude = (double)lValue;
            }
        }

        private List<string> sSplitOpening(string pOpeningHours)
        {
            const string cStartPar = "<p>";
            const string cEndPar = "</p>";
            List<string> lPars;
            int lStart;
            int lBegin;
            int lEnd;
            string lPar;

            lPars = new List<string>();

            lStart = 0;
            while (lStart < pOpeningHours.Length)
            {
                lBegin = pOpeningHours.IndexOf(cStartPar, lStart, StringComparison.OrdinalIgnoreCase);
                if (lBegin >= 0)
                {
                    lBegin += cStartPar.Length;
                    lEnd = pOpeningHours.IndexOf(cEndPar, lBegin, StringComparison.OrdinalIgnoreCase);
                    if (lEnd >= 0)
                    {
                        if (lEnd > lBegin)
                        {
                            lPar = pOpeningHours.Substring(lBegin, lEnd - lBegin);
                            lPar = sCleanPar(lPar);
                            if (lPar.Length > 0)
                            {
                                lPars.Add(lPar);
                            }
                        }
                        lStart = lEnd + cEndPar.Length;
                    } else
                    {
                        lStart = pOpeningHours.Length;
                    }
                } else
                {
                    lStart = pOpeningHours.Length;
                }
            }

            return lPars;
        }

        private string sCleanPar(string pPar)
        {
            string lPar;
            int lStart = 0;
            int lBegin;
            int lEnd;
            string lPart1;
            string lPart2;
            bool lReady = false;

            lPar = pPar;
            do
            {
                if (lPar.Length == 0)
                {
                    lReady = true;
                } else
                {
                    lBegin = lPar.IndexOf('<');
                    if (lBegin < 0)
                    {
                        lReady = true;
                    }
                    else
                    {
                        lPart1 = lPar.Substring(0, lBegin);
                        lEnd = lPar.IndexOf('>', lBegin + 1);
                        if (lEnd < 0)
                        {
                            lPart2 = "";
                        }
                        else
                        {
                            lPart2 = lPar.Substring(lEnd + 1);
                        }
                        if (lPart2.Length > 0)
                        {
                            lPar = lPart1 + " " + lPart2;
                        }
                        else
                        {
                            lPar = lPart1;
                        }
                    }
                }
            } while (!lReady);

            lReady = false;
            do
            {
                lPart1 = lPar.Replace("&nbsp;", " ");
                if (lPar.Equals(lPart1, StringComparison.Ordinal))
                {
                    lReady = true;
                } else
                {
                    lPar = lPart1;
                }
            } while (!lReady);

            lReady = false;
            do
            {
                lPart1 = lPar.Replace("  ", " ");
                if (lPar.Equals(lPart1, StringComparison.Ordinal))
                {
                    lReady = true;
                }
                else
                {
                    lPar = lPart1;
                }
            } while (!lReady);

            return lPar.Trim();
        }
    }
}
