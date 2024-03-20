using System;
using System.Collections.Generic;
using Summoners.RealtimeNetworking;

namespace Summoners.Models {
    public class ForumComment {

        public long Id { get; set; }
        public long ForumPostId { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public ForumComment() {}
    }
}