using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forum : MonoBehaviour
{
    [System.Serializable]
    public class ForumData
    {
        public string description;
        public string playerName;
        public float yesVoters;
        public float noVoters;
    }
    [SerializeField] private ForumData[] forumDatas = null;
    [SerializeField] private GameObject forumPrefab = null;
    [SerializeField] private Transform forumPath = null;
    [SerializeField] private Transform votePath = null;

    private void Awake()
    {
        for (int i = 0; i < forumDatas.Length; i++)
        {
            var prefab = Instantiate(forumPrefab, forumPath);
            Transform infoPath = prefab.transform.GetChild(0);
            infoPath.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].description;
            infoPath.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = forumDatas[i].playerName;
            infoPath.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { OpenVoteScreen(prefab.transform.GetSiblingIndex()); });
        }
    }
    private void OpenVoteScreen(int i)
    {
        Transform data = votePath.GetChild(2);
        data.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].description;
        data.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
        data.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
        data.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { Vote(i, true); });
        data.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { Vote(i, false); });
        data.GetChild(3).GetComponent<Slider>().maxValue = forumDatas[i].noVoters + forumDatas[i].yesVoters;
        data.GetChild(3).GetComponent<Slider>().value = forumDatas[i].yesVoters;
        data.GetChild(4).GetComponent<TMP_Text>().text = (forumDatas[i].noVoters / (forumDatas[i].noVoters + forumDatas[i].yesVoters) * 100).ToString();
        data.GetChild(5).GetComponent<TMP_Text>().text = (forumDatas[i].yesVoters / (forumDatas[i].noVoters + forumDatas[i].yesVoters) * 100).ToString();
        votePath.gameObject.SetActive(true);
    }
    private void Vote(int i, bool yes)
    {
        if (yes) { forumDatas[i].yesVoters++; }
        else { forumDatas[i].noVoters++; }
        Transform data = votePath.GetChild(2);
        data.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].description;
        data.GetChild(3).GetComponent<Slider>().value = forumDatas[i].yesVoters;
        data.GetChild(3).GetComponent<Slider>().maxValue = forumDatas[i].noVoters + forumDatas[i].yesVoters;
        data.GetChild(4).GetComponent<TMP_Text>().text = (forumDatas[i].noVoters / (forumDatas[i].noVoters + forumDatas[i].yesVoters) * 100).ToString();
        data.GetChild(5).GetComponent<TMP_Text>().text = (forumDatas[i].yesVoters / (forumDatas[i].noVoters + forumDatas[i].yesVoters) * 100).ToString();
    }
}
