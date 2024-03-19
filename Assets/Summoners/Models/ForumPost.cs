using System;
using System.Collections.Generic;
using Summoners.Memewars;
using Summoners.RealtimeNetworking.Client;

namespace Summoners.Models {
    public class ForumPost {
        public long Id { get; set; }
        public long GuildId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string VotingId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentCount { get; set; }
        public List<ForumComment> Comments { get; set; }
        
        public static void GetAll() {
            var packet = new Packet((int)Player.RequestsID.GET_FORUM_POSTS);
            Sender.TCP_Send(packet);
        }
        
        public static void Get(long post_id) {
            var packet = new Packet((int)Player.RequestsID.GET_FORUM_POST);
            packet.Write(post_id);
            Sender.TCP_Send(packet);
        }

        public static void Create(string title, string description, string content) {
            var packet = new Packet((int)Player.RequestsID.CREATE_FORUM_POST);
            packet.Write(title);
            packet.Write(description);
            packet.Write(content);
            Sender.TCP_Send(packet);
        }

        public static void Delete(long post_id) {
            var packet = new Packet((int)Player.RequestsID.DELETE_FORUM_POST);
            packet.Write(post_id);
            Sender.TCP_Send(packet);
        }

        public static void PushToGovernance(long post_id) {
            var packet = new Packet((int)Player.RequestsID.PUSH_FORUM_POST_TO_GOVERNANCE);
            packet.Write(post_id);
            Sender.TCP_Send(packet);
        }

        public static void Comment(long comment_id, string comment) {
            var packet = new Packet((int)Player.RequestsID.CREATE_FORUM_COMMENT);
            packet.Write(comment_id);
            packet.Write(comment);
            Sender.TCP_Send(packet);
        }

        public static void DeleteComment(long comment_id) {
            var packet = new Packet((int)Player.RequestsID.DELETE_FORUM_COMMENT);
            packet.Write(comment_id);
            Sender.TCP_Send(packet);
        }
    }
}