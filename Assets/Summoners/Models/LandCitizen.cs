using System;
using System.Collections.Generic;
using Summoners.Memewars;
using Summoners.RealtimeNetworking.Client;

namespace Summoners.Models {
    public class LandCitizen {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long LandId { get; set; }
    }
}