using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace McDoData
{
    internal class DataNL
    {
        private static string cUrl = "https://www.mcdonalds.com/googleapps/GoogleRestaurantLocAction.do?method=searchLocation&latitude=51.9851034&longitude=5.898729600000024&radius=500&maxResults=300&country=nl&language=nl-nl&showClosed=&hours24Text=Open%2024%20hr";
        private String mResData;
        private List<RestoNL> mRestos;

        internal event EventHandler eReadComplete;

        internal List<Resto> xRestos()
        {
            List<Resto> lRestos;

            lRestos = mRestos.Cast<Resto>().ToList();
            return lRestos;
        }
 
        internal DataNL()
        {
            mRestos = new List<RestoNL>();
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


            lClient = new HttpClient();
            lRequest = new HttpRequestMessage();
            lRequest.Method = HttpMethod.Get;
            lRequest.RequestUri = new Uri(cUrl);
            try
            {
                lTask = lClient.SendAsync(lRequest);
                lResponse = await lTask.ConfigureAwait(false);
                if (lResponse.IsSuccessStatusCode)
                {
                    mResData = await lResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    sProcessData();
                }
                lResponse.Dispose();
            } catch (Exception pExc)
            {

            }
            lHandler = eReadComplete;
            lHandler.Invoke(this, null);
            lRequest.Dispose();
            lClient.Dispose();
        }

        private void sProcessData()
        {
            JObject lReply;
            JArray lRestos;
            JObject lResto;
            RestoNL lRestNl;
            int lCount;

            mRestos.Clear();
            lReply = JObject.Parse(mResData);
            lRestos = lReply.Value<JArray>("features");
            for (lCount = 0; lCount < lRestos.Count; lCount++)
            {
                lResto = (JObject)lRestos.ElementAt(lCount);
                lRestNl = new RestoNL(lResto);
                mRestos.Add(lRestNl);
            }
        }
    }
}
