using System;
using System.Collections.Generic;
using Summoners.Memewars;
using Summoners.RealtimeNetworking.Client;

namespace Summoners.Models {
    public class Land {
        public long Id { get; set; }
        public string MintAddress { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Level { get; set; }
        public int CitizenCap { get; set; }
        public float GemsPerBlock { get; set; } // gems per block
        public string OwnerAddress { get; set; }
        public long GuildId { get; set; }
        public bool IsBooked { get; set; } // for land sale
        public DateTime MintedAt { get; set; }
        public int CitizenCount { get; set; }
        public List<LandCitizen> Citizens { get; set; }

        // all callbacks are processed in Player.cs
        public static void Get(long land_id) {
            var packet = new Packet((int)Player.RequestsID.GET_LAND);
            packet.Write(land_id);
            Sender.TCP_Send(packet);
        }

        public static void GetMap() {
            var packet = new Packet((int)Player.RequestsID.GET_MAP);
            Sender.TCP_Send(packet);
        }

        public static void Buy(long land_id) {
            var packet = new Packet((int)Player.RequestsID.BUY_LAND);
            packet.Write(land_id);
            // need to prompt buy transaction
            Sender.TCP_Send(packet);
        }
    }
}