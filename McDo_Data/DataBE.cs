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
        private static string cRestosKey = "var restos = ";
        private String mResData;
        private List<RestoBE> mRestos;

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
//                    sProcessData();
                }
                lResponse.Dispose();
                lHandler = eReadComplete;
                lHandler.Invoke(this, null);
            }
            catch (Exception pExc)
            {

            }
            lRequest.Dispose();
            lClient.Dispose();
        }

        private void sGetRestos(String pResData)
        {
            int lKeyStart;

            lKeyStart = pResData.IndexOf(cRestosKey);
            if (lKeyStart >= 0)
            {

            }
        }
    }
}
