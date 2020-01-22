using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace McDoData
{
    class DataBE
    {
        private static string cUrlList = "https://www.mcdonalds.be/nl/restaurant";
        private static string cUrlDetail = "https://www.mcdonalds.be/nl/2iufriuwlu?id=";
        private static string cRestosKey = "var restos = ";
        private List<RestoBE> mRestos;

        internal event EventHandler eListComplete;
        internal event EventHandler eReadComplete;

        internal DataBE()
        {
            mRestos = new List<RestoBE>();
        }

        internal List<Resto> xRestos()
        {
            List<Resto> lRestos;

            lRestos = mRestos.Cast<Resto>().ToList();
            return lRestos;
        }

        internal void xInit()
        {
            mRestos.Clear();
            sGetData();
        }

        private async Task sGetData()
        {
            HttpClient lClient;
            HttpRequestMessage lRequest;
            HttpResponseMessage lResponse;
            Task<HttpResponseMessage> lTask;
            EventHandler lHandler;
            string lResData;


            lClient = new HttpClient();
            lRequest = new HttpRequestMessage();
            lRequest.Method = HttpMethod.Put;
            lRequest.RequestUri = new Uri(cUrlList);
            try
            {
                lTask = lClient.SendAsync(lRequest);
                lResponse = await lTask.ConfigureAwait(false);
                if (lResponse.IsSuccessStatusCode)
                {
                    lResData = await lResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    sGetRestos(lResData);
                    lHandler = eListComplete;
                    lHandler.Invoke(this, null);
                    await sGetDetails(lClient).ConfigureAwait(false);
                }
                lResponse.Dispose();
            }
            catch (Exception pExc)
            {

            }
            lHandler = eReadComplete;
            lHandler.Invoke(this, null);
            lRequest.Dispose();
            lClient.Dispose();
        }

        private async Task sGetDetails(HttpClient pClient)
        {
            HttpRequestMessage lRequest;
            HttpResponseMessage lResponse;
            Task<HttpResponseMessage> lTask;
            string lResData;
            JObject lResDetails;


            foreach (RestoBE lResto in mRestos)
            {
                lRequest = new HttpRequestMessage();
                lRequest.Method = HttpMethod.Put;
                lRequest.RequestUri = new Uri(cUrlDetail + lResto.xID);
                try
                {
                    lTask = pClient.SendAsync(lRequest);
                    lResponse = await lTask.ConfigureAwait(false);
                    if (lResponse.IsSuccessStatusCode)
                    {
                        lResData = await lResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        lResDetails = JObject.Parse(lResData);
                        if (lResData != null)
                        {
                            lResto.xProcesDetails(lResDetails);
                        }
                    }
                    lResponse.Dispose();
                }
                catch (Exception pExc)
                {

                }
                lRequest.Dispose();
            }
        }

        private void sGetRestos(string pResData)
        {
            string lRestosString;
            JArray lRestos;
            JObject lResto;
            RestoBE lRestoBE;
            int lCount;

            mRestos.Clear();
            lRestosString = sGetRestosString(pResData);
            lRestos = JArray.Parse(lRestosString);
            if (lRestos != null)
            {
                for (lCount = 0; lCount < lRestos.Count; lCount++)
                {
                    lResto = (JObject)lRestos.ElementAt(lCount);
                    lRestoBE = new RestoBE(lResto);
                    mRestos.Add(lRestoBE);
                }
            }
        }

        private string sGetRestosString(String pResData)
        {
            int lKeyStart;
            int lPos;
            int lStart;
            int lEnd;
            int lCount;
            string lResult;

            lResult = "";
            lKeyStart = pResData.IndexOf(cRestosKey, StringComparison.Ordinal);
            if (lKeyStart >= 0)
            {
                lStart = -1;
                for (lPos = lKeyStart + cRestosKey.Length; lPos < lKeyStart + cRestosKey.Length + 10; lPos++)
                {
                    if (pResData.ElementAt(lPos).Equals('['))
                    {
                        lStart = lPos;
                        break;
                    }
                }
                if (lStart >= 0)
                {
                    lEnd = -1;
                    lCount = 0;
                    for (lPos = lStart; lPos < pResData.Length; lPos++)
                    {
                        if (pResData.ElementAt(lPos).Equals('['))
                        {
                            lCount++;
                        } else
                        {
                            if (pResData.ElementAt(lPos).Equals(']'))
                            {
                                lCount--;
                                if (lCount == 0)
                                {
                                    lEnd = lPos;
                                    break;
                                }
                            }
                        }
                    }
                    if (lEnd > lStart)
                    {
                        lResult = pResData.Substring(lStart, (lEnd - lStart) + 1);
                    }
                }
            }
            return lResult;
        }
    }
}
