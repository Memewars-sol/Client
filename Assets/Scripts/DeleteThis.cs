namespace Summoners.Memewars
{
    using NUnit.Framework;
    using Summoners.Models;
    using UnityEngine;
    using System.Collections.Generic;
    using Summoners.RealtimeNetworking.Client;

    public class DeleteThis : MonoBehaviour
    {
        public static List<Guild> guilds = new List<Guild>();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("pressed");
                Guild.GetAll();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (guilds.Count > 0)
                {
                    for (int i = 0; i < guilds.Count; i++)
                    {
                        Debug.Log(guilds[i].Name);
                    }    
                }
                else
                {
                    guilds.Add(new Guild());
                    Debug.Log("empty");
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D Pressed");
                Packet packet = new Packet((int)Player.RequestsID.EDITCLAN);
                Sender.TCP_Send(packet);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F Pressed");
                Packet packet = new Packet((int)Player.RequestsID.LEAVECLAN);
                Sender.TCP_Send(packet);
            }
        }
    }
}


