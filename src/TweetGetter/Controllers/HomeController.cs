using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TweetGetter.Extensions;
using TweetGetter.Helper;
using TweetGetter.Models;

namespace TweetGetter.Controllers
{
    public class HomeController : Controller
    {

        private string path;
        private ILogger logger;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            path = config.GetSection("TweetConfiguration")["Path"];
            this.logger = logger;
        }

        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate)
        {
            ViewBag.Error = "";


            if (fromDate.HasValue && toDate.HasValue)
            {
                try
                {
                    Data.Tweets.ListAllTweets = await GetterTwets.GetProductAsync(path, fromDate.Value, toDate.Value);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    ViewBag.Error = ex.Message;
                }

            }

            ViewBag.FromDate = fromDate == null ? DateTime.Now.AddMonths(-5).ToUTCView() : fromDate.Value.ToUTCView();
            ViewBag.ToDate = toDate == null ? DateTime.Now.ToUTCView() : toDate.Value.ToUTCView();
            ViewBag.Visibility = Data.Tweets.ListAllTweets.Count != 0 ? true : false;
            logger.LogDebug($"Returned {Data.Tweets.ListAllTweets.Count} tweets");
            return View(Data.Tweets.ListAllTweets.Count);
        }

        public ActionResult GetPaggedData(int pageNumber = 1, int pageSize = 20)
        {
            var pagedData = Pagination.PagedResult(Data.Tweets.ListAllTweets, pageNumber, pageSize);
            return Json(pagedData);
        }

        public ActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
