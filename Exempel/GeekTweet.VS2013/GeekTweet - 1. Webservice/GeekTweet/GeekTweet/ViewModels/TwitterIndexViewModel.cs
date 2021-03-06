﻿using GeekTweet.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeekTweet.ViewModels
{
    public class TwitterIndexViewModel
    {
        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string ScreenName { get; set; }

        public bool HasTweets
        {
            get { return Tweets != null && Tweets.Any(); }
        }

        public string Name
        {
            get
            {
                return HasTweets ? Tweets.First().Name : "[Unknown]";
            }
        }
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}