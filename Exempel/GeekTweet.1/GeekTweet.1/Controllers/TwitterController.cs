﻿using System;
using System.Web.Mvc;
using GeekTweet.Models.Webservices;
using GeekTweet.ViewModels;

namespace GeekTweet.Controllers
{
    public class TwitterController : Controller
    {
        //
        // GET: /Twitter/

        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // POST: /Twitter/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var webservice = new TwitterWebservice();
                    model.Tweets = webservice.GetUserTimeLine(model.ScreenName);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("Index", model);
        }

    }
}
