using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSearch;

namespace ClientLUIS.Models
{
    public class Request
    {
        public string TextRequest { get; set; }
        public List<VideoInformation> Videos { get; set; }
        public LuisResult luisResult { get; set; }
    }
}