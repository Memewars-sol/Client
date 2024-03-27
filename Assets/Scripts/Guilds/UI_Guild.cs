using Summoners.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_Guild : MonoBehaviour
{
    public static List<Guild> guilds = new List<Guild>();

    [SerializeField] private GameObject UI_GuildPrefab;
    [SerializeField] private Transform guildPath;

    public void Refresh()
    {
        Guild.GetAll();
        foreach (Transform child in guildPath)
        {
            Destroy(child.gameObject);
        }
        if (guilds.Count > 0)
        {
            for (int i = 0; i < guilds.Count; i++)
            {
                var guild = Instantiate(UI_GuildPrefab, guildPath);
                var guildData = guild.GetComponent<GuildPrefab>();
                guildData.guildName.text = guilds[i].Name;
                guildData.guildAddress.text = guilds[i].MintAddress.Substring(0, 17) + "...";
                guildData.guildMemberCount.text = "10/30";
                StartCoroutine(LoadImage(guilds[i].Logo, guildData.guildImage));
            }
        }
        else
        {
            Debug.Log("empty");
        }
    }
    IEnumerator LoadImage(string link, Image image)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(link);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Image Link Not Found");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            if (texture)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                image.sprite = newSprite;
            }
        }
    }
    private void Start()
    {
        Refresh();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Refresh();
        }
    }
}
