using ClientLUIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeSearch;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ClientLUIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> Request(Request request)
        {
            List<VideoInformation> result = new List<VideoInformation>();
            int querypages = 1;
            if (!string.IsNullOrWhiteSpace(request.TextRequest))
            {
                request.luisResult = await LuisRequest(request.TextRequest);
                VideoSearch videoSearch = new VideoSearch();

                if (request.luisResult.Entities != null)
                {
                    if (request.luisResult.Entities.Count > 0)
                    {
                        string song = request.luisResult.Entities.FirstOrDefault().Entity;
                        request.Videos = videoSearch.SearchQuery(song, querypages);
                    }
                }

            }
            return View("Index", request);
        }
        #region private
        private async Task<LuisResult> LuisRequest(string query)
        {
            var endpointPredictionkey = "YOUR_KEY";
            var credentials = new ApiKeyServiceClientCredentials(endpointPredictionkey);
            var luisClient = new LUISRuntimeClient(credentials, new System.Net.Http.DelegatingHandler[] { });
            luisClient.Endpoint = "https://westus.api.cognitive.microsoft.com/";

            // public Language Understanding Home Automation app
            var appId = "YOUR_APP_ID";

            // query specific to home automation app


            // common settings for remaining parameters
            Double? timezoneOffset = null;
            var verbose = true;
            var staging = false;
            var spellCheck = false;
            String bingSpellCheckKey = null;
            var log = false;

            // Create prediction client
            var prediction = new Prediction(luisClient);

            // get prediction
            return await prediction.ResolveAsync(appId, query, timezoneOffset, verbose, staging, spellCheck, bingSpellCheckKey, log, CancellationToken.None);
        }
        #endregion
    }
}