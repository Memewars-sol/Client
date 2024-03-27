using System;
using System.Collections.Generic;

namespace Summoners.Models
{
    using Summoners.Memewars;
    using Summoners.RealtimeNetworking.Client;
    using UnityEngine;

    public class Guild {
        public long Id { get; set; }
        public string MintAddress { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        
        public static void Get(long guild_id) {
            Packet packet = new Packet((int)Player.RequestsID.GET_GUILD);
            packet.Write(guild_id);
            Sender.TCP_Send(packet);
        }
        
        public static void GetAll() {
            Packet packet = new Packet((int)Player.RequestsID.GET_ALL_GUILDS);
            Sender.TCP_Send(packet);

        }

        public static void Join(long guild_id) {
            Packet packet = new Packet((int)Player.RequestsID.JOIN_GUILD);
            packet.Write(guild_id);
            Sender.TCP_Send(packet);
        }
        
        public static void Change(long guild_id) {
            Packet packet = new Packet((int)Player.RequestsID.CHANGE_GUILD);
            packet.Write(guild_id);
            Sender.TCP_Send(packet);
        }
        
        public static void Exit(long guild_id) {
            Packet packet = new Packet((int)Player.RequestsID.EXIT_GUILD);
            Sender.TCP_Send(packet);
        }
    }
}