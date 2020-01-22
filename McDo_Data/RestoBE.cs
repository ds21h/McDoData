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
        private struct WordSplit
        {
            internal string Word;
            internal string Rest;
        }

        private struct RestoTimes
        {
            internal string RestoOpen;
            internal string RestoClose;
            internal string DriveClose;

            internal RestoTimes(string pInit)
            {
                RestoOpen = pInit;
                RestoClose = pInit;
                DriveClose = pInit;
            }
        }

        private readonly string[] mDays = { "maandag", "dinsdag", "woensdag", "donderdag", "vrijdag", "zaterdag", "zondag" };
        private RestoTimes[] mRestoTimes;

        internal RestoBE(JObject pResto) : base()
        {
            sInitRestoTimes();

            bCountry = CountryBE;
            sProcessResto(pResto);
        }

        private void sInitRestoTimes()
        {
            int lCount;

            mRestoTimes = new RestoTimes[mDays.Length];
            for (lCount = 0; lCount < mRestoTimes.Length; lCount++)
            {
                mRestoTimes[lCount] = new RestoTimes("");
            }
        }

        internal void xProcesDetails(JObject pDetails)
        {
            JValue lValue;
            object lObject;
            JObject lResto;
            JArray lServices;
            int lCount;
            int lService;
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
                        lObject = lResto["services"];
                        if (lObject != null)
                        {
                            lServices = (JArray)lObject;
                            for (lCount = 0; lCount < lServices.Count; lCount++)
                            {
                                lService = (int)lServices[lCount];
                                if (lService <= bServices.Length)
                                {
                                    bServices[lService - 1] = true;
                                }
                            }
                        }
                        sFillOpeningHours();
                    }
                }
            }
        }

        private void sFillOpeningHours()
        {
            string lDriveClose;

            bHoursMonday = mRestoTimes[0].RestoOpen + " - " + mRestoTimes[0].RestoClose;
            bHoursTuesday = mRestoTimes[1].RestoOpen + " - " + mRestoTimes[1].RestoClose;
            bHoursWednesday = mRestoTimes[2].RestoOpen + " - " + mRestoTimes[2].RestoClose;
            bHoursThursday = mRestoTimes[3].RestoOpen + " - " + mRestoTimes[3].RestoClose;
            bHoursFriday = mRestoTimes[4].RestoOpen + " - " + mRestoTimes[4].RestoClose;
            bHoursSaturday = mRestoTimes[5].RestoOpen + " - " + mRestoTimes[5].RestoClose;
            bHoursSunday = mRestoTimes[6].RestoOpen + " - " + mRestoTimes[6].RestoClose;
            if (bServices[1])
            {
                if (mRestoTimes[0].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[0].DriveClose;
                } else
                {
                    lDriveClose = mRestoTimes[0].RestoClose;
                }
                bDriveHoursMonday = mRestoTimes[0].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[1].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[1].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[1].RestoClose;
                }
                bDriveHoursTuesday = mRestoTimes[1].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[2].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[2].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[2].RestoClose;
                }
                bDriveHoursWednesday = mRestoTimes[2].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[3].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[3].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[3].RestoClose;
                }
                bDriveHoursThursday = mRestoTimes[3].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[4].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[4].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[4].RestoClose;
                }
                bDriveHoursFriday = mRestoTimes[4].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[5].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[5].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[5].RestoClose;
                }
                bDriveHoursSaturday = mRestoTimes[5].RestoOpen + " - " + lDriveClose;

                if (mRestoTimes[6].DriveClose.Length > 0)
                {
                    lDriveClose = mRestoTimes[6].DriveClose;
                }
                else
                {
                    lDriveClose = mRestoTimes[6].RestoClose;
                }
                bDriveHoursSunday = mRestoTimes[6].RestoOpen + " - " + lDriveClose;
            }
        }

        private void sProcessOpeningHours(String pOpeningHours)
        {
            List<string> lLines;

            lLines = sSplitOpening(pOpeningHours);
            foreach (String lLine in lLines)
            {
                if (lLine.Length > 0)
                {
                    sProcessLine(lLine);
                }
            }
        }

        private void sProcessLine(string pLine)
        {
            WordSplit lSplit;
            string lSave;
            int lStart;
            int lEnd;
            RestoTimes lTimes;
            int lDay;

            lSplit = sGetWord(pLine);
            if (!lSplit.Word.Equals("ontbijt", StringComparison.OrdinalIgnoreCase))
            {
                lStart = sTestDay(lSplit.Word);
                if (lStart >= 0)
                {
                    lSave = lSplit.Rest;
                    lSplit = sGetWord(lSplit.Rest);
                    if (sTestConnect(lSplit.Word))
                    {
                        lSplit = sGetWord(lSplit.Rest);
                        lEnd = sTestDay(lSplit.Word);
                        if (lEnd >= 0)
                        {
                            lTimes = sGetTimes(lSplit.Rest);
                        } else
                        {
                            lTimes = new RestoTimes("");
                        }
                    } else
                    {
                        lEnd = lStart;
                        lTimes = sGetTimes(lSave);
                    }
                    if (lStart > lEnd)
                    {
                        for (lDay = lStart; lDay < mRestoTimes.Length; lDay++)
                        {
                            mRestoTimes[lDay] = lTimes;
                        }
                        for (lDay = 0; lDay <= lEnd; lDay++)
                        {
                            mRestoTimes[lDay] = lTimes;
                        }

                    } else
                    {
                        for (lDay = lStart; lDay <= lEnd; lDay++)
                        {
                            mRestoTimes[lDay] = lTimes;
                        }
                    }
                }
            }
        }

        private RestoTimes sGetTimes(string pLine)
        {
            RestoTimes lTimes;
            WordSplit lSplit;

            lTimes = new RestoTimes("");

            lSplit = sGetWord(pLine);
            if (sTestTime(lSplit.Word))
            {
                lTimes.RestoOpen = lSplit.Word;
                lSplit = sGetWord(lSplit.Rest);
                if (lSplit.Word.Equals("pm", StringComparison.OrdinalIgnoreCase))
                {
                    lTimes.RestoOpen = sPmTime(lTimes.RestoOpen);
                }
                lSplit = sGetWord(lSplit.Rest);
                lSplit = sGetWord(lSplit.Rest);
                if (sTestTime(lSplit.Word))
                {
                    lTimes.RestoClose = lSplit.Word;
                    lSplit = sGetWord(lSplit.Rest);
                    if (lSplit.Word.Equals("pm", StringComparison.OrdinalIgnoreCase))
                    {
                        lTimes.RestoClose = sPmTime(lTimes.RestoClose);
                    }
                    if (lSplit.Rest.Length > 0)
                    {
                        lSplit = sGetWord(lSplit.Rest);
                        if (lSplit.Word.Equals("drive", StringComparison.OrdinalIgnoreCase))
                        {
                            lSplit = sGetWord(lSplit.Rest);
                            lSplit = sGetWord(lSplit.Rest);
                            if (sTestTime(lSplit.Word))
                            {
                                lTimes.DriveClose = lSplit.Word;
                                lSplit = sGetWord(lSplit.Rest);
                                if (lSplit.Word.Equals("pm", StringComparison.OrdinalIgnoreCase))
                                {
                                    lTimes.DriveClose = sPmTime(lTimes.DriveClose);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (sTest24(lSplit.Word))
                {
                    lTimes.RestoOpen = "07:00";
                    lTimes.RestoClose = "06:59";
                }
            }

            return lTimes;
        }
        private string sPmTime(string pTime)
        {
            int lTime;
            string lResult;

            if (int.TryParse(pTime.Substring(0, 2), out lTime))
            {
                lTime += 12;
                if (lTime >= 24) { lTime -= 24; }
                lResult = lTime.ToString("D2") + pTime.Substring(2);
            }
            else
            {
                lResult = pTime;
            }
            return lResult;
        }

        private int sTestDay(string pDay)
        {
            int lCount;
            int lResult;

            lResult = -1;
            for (lCount = 0; lCount < mDays.Length; lCount++)
            {
                if (pDay.Equals(mDays[lCount], StringComparison.OrdinalIgnoreCase))
                {
                    lResult = lCount;
                    break;
                }
            }
            return lResult;
        }

        private bool sTestConnect(string pConnect)
        {
            string[] lConnector = { "t.e.m.", "tem", "tot", "en" };
            bool lResult;
            int lCount;

            lResult = false;
            for (lCount = 0; lCount < lConnector.Length; lCount++)
            {
                if (pConnect.Equals(lConnector[lCount], StringComparison.OrdinalIgnoreCase))
                {
                    lResult = true;
                    break;
                }
            }
            return lResult;
        }

        private bool sTest24(string p24)
        {
            string[] l24Markers = { "24/24", "24u/24u", "24h/24h" };
            bool lResult;
            int lCount;

            lResult = false;
            for (lCount = 0; lCount < l24Markers.Length; lCount++)
            {
                if (p24.Equals(l24Markers[lCount], StringComparison.OrdinalIgnoreCase))
                {
                    lResult = true;
                    break;
                }
            }
            return lResult;
        }

        private bool sTestTime(string pTime)
        {
            bool lResult;

            lResult = false;
            if (pTime.Length == 5)
            {
                if (pTime.ElementAt(0) >= '0' && pTime.ElementAt(0) <= '9')
                {
                    if (pTime.ElementAt(1) >= '0' && pTime.ElementAt(1) <= '9')
                    {
                        if (pTime.ElementAt(2) == ':')
                        {
                            if (pTime.ElementAt(3) >= '0' && pTime.ElementAt(3) <= '9')
                            {
                                if (pTime.ElementAt(4) >= '0' && pTime.ElementAt(4) <= '9')
                                {
                                    lResult = true;
                                }
                            }
                        }
                    }
                }
            }
            return lResult;
        }

        private WordSplit sGetWord(string pIn)
        {
            WordSplit lResult;
            string lWord;

            int lDelBlank;
            int lDelComma;
            int lLength;

            if (pIn.Length > 0)
            {
                lDelBlank = pIn.IndexOf(' ');
                lDelComma = pIn.IndexOf(',');
                if (lDelBlank < 0)
                {
                    if (lDelComma < 0)
                    {
                        lLength = pIn.Length;
                    }
                    else
                    {
                        lLength = lDelComma;
                    }
                }
                else
                {
                    if (lDelComma < 0)
                    {
                        lLength = lDelBlank;
                    }
                    else
                    {
                        if (lDelBlank < lDelComma)
                        {
                            lLength = lDelBlank;
                        }
                        else
                        {
                            lLength = lDelComma;
                        }
                    }
                }
                lResult.Word = pIn.Substring(0, lLength);
                if (lResult.Word.Length < pIn.Length)
                {
                    lResult.Rest = pIn.Substring(lResult.Word.Length + 1).TrimStart();
                }
                else
                {
                    lResult.Rest = "";
                }
            }
            else
            {
                lResult.Word = "";
                lResult.Rest = "";
            }
            return lResult;
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
            List<string> lLines;
            int lStart;
            int lBegin;
            int lEnd;
            string lLine;

            lLines = new List<string>();

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
                            lLine = pOpeningHours.Substring(lBegin, lEnd - lBegin);
                            lLine = sCleanLine(lLine);
                            if (lLine.Length > 0)
                            {
                                lLines.Add(lLine);
                            }
                        }
                        lStart = lEnd + cEndPar.Length;
                    }
                    else
                    {
                        lStart = pOpeningHours.Length;
                    }
                }
                else
                {
                    lStart = pOpeningHours.Length;
                }
            }

            return lLines;
        }

        private string sCleanLine(string pLine)
        {
            string lLine;
            int lBegin;
            int lEnd;
            string lPart1;
            string lPart2;
            bool lReady = false;

            lLine = pLine;
            do
            {
                if (lLine.Length == 0)
                {
                    lReady = true;
                }
                else
                {
                    lBegin = lLine.IndexOf('<');
                    if (lBegin < 0)
                    {
                        lReady = true;
                    }
                    else
                    {
                        lPart1 = lLine.Substring(0, lBegin);
                        lEnd = lLine.IndexOf('>', lBegin + 1);
                        if (lEnd < 0)
                        {
                            lPart2 = "";
                        }
                        else
                        {
                            lPart2 = lLine.Substring(lEnd + 1);
                        }
                        if (lPart2.Length > 0)
                        {
                            lLine = lPart1 + " " + lPart2;
                        }
                        else
                        {
                            lLine = lPart1;
                        }
                    }
                }
            } while (!lReady);

            lLine = lLine.Replace("&nbsp;", " ");

            lReady = false;
            do
            {
                lPart1 = lLine.Replace("  ", " ");
                if (lLine.Equals(lPart1, StringComparison.Ordinal))
                {
                    lReady = true;
                }
                else
                {
                    lLine = lPart1;
                }
            } while (!lReady);

            return lLine.Trim();
        }
    }
}
