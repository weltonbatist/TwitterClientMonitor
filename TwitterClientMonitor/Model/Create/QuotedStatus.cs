﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClientMonitor.Model.Create
{
    class QuotedStatus
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public string source { get; set; }
        public bool truncated { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public User2 user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public bool is_quote_status { get; set; }
        public int quote_count { get; set; }
        public int reply_count { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public Entities entities { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public string filter_level { get; set; }
        public string lang { get; set; }
    }
}
