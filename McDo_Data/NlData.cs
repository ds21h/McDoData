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
    internal class NlData
    {
        private static string cUrl = "https://www.mcdonalds.com/googleapps/GoogleRestaurantLocAction.do?method=searchLocation&latitude=51.9851034&longitude=5.898729600000024&radius=500&maxResults=300&country=nl&language=nl-nl&showClosed=&hours24Text=Open%2024%20hr";
        private bool mComplete;
        private String mResData;
        private List<RestoNl> mRestos;

        internal event EventHandler eReadComplete;

        internal NlData()
        {
            mComplete = false;
            mRestos = new List<RestoNl>();
        }

        internal void xInit()
        {
            mComplete = false;
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
                    mComplete = true;
                }
                lResponse.Dispose();
                lHandler = eReadComplete;
                lHandler.Invoke(this, null);
            } catch (Exception pExc)
            {

            }
            lRequest.Dispose();
            lClient.Dispose();
        }

        internal void xProcessData()
        {
            JObject lReply;
            JArray lRestos;
            JObject lResto;
            RestoNl lRestNl;
            int lCount;

            mRestos.Clear();
            if (mComplete)
            {
                lReply = JObject.Parse(mResData);
                lRestos = lReply.Value<JArray>("features");
                for (lCount = 0; lCount < lRestos.Count; lCount++)
                {
                    lResto = (JObject)lRestos.ElementAt(lCount);
                    lRestNl = new RestoNl(lResto);
                    mRestos.Add(lRestNl);
                }
            }
        }
    }
}
