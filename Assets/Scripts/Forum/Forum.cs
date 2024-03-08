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
        public List<Comment> comments;
        public bool voteActive = false;
    }
    [System.Serializable]
    public class Comment
    {
        public string commenter;
        public string comment;

        public Comment(string commenter, string comment) { this.commenter = commenter; this.comment = comment; }
    }
    
    [Header("Forum")]
    [SerializeField] private ForumData[] forumDatas = null;
    [SerializeField] private GameObject forumPrefab = null;
    [SerializeField] private Transform forumPath = null;

    [Header("Comments")]
    [SerializeField] private GameObject commentPrefab = null;
    [SerializeField] private GameObject commentItem = null;
    [SerializeField] private Transform commentPath = null;
    [SerializeField] private TMP_Text commentTitle = null;
    [SerializeField] private Button voteButton = null;
    [SerializeField] private Button activateButton = null;
    [SerializeField] private TMP_InputField commentInput = null;
    [SerializeField] private Button enterButton = null;

    [Header("Vote")]
    [SerializeField] private Transform votePath = null;

    [Header("TempData")]
    [SerializeField] private string PlayerName = null;

    private void Awake()
    {
        for (int i = 0; i < forumDatas.Length; i++)
        {
            var prefab = Instantiate(forumPrefab, forumPath);
            Transform infoPath = prefab.transform.GetChild(0);
            infoPath.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].description;
            infoPath.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = forumDatas[i].playerName;
            infoPath.GetComponent<Button>().onClick.AddListener(delegate { OpenCommentScreen(prefab.transform.GetSiblingIndex()); });
        }
    }
    private void OpenCommentScreen(int i)
    {
        commentTitle.text = forumDatas[i].description;
        commentItem.SetActive(true);
        foreach (Transform child in commentPath)
        {
            Destroy(child.gameObject);
        }
        for (int j = 0; j < forumDatas[i].comments.Count; j++)
        {
            var prefab = Instantiate(commentPrefab, commentPath);
            Transform infoPath = prefab.transform.GetChild(0);
            infoPath.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].comments[j].comment;
            infoPath.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = forumDatas[i].comments[j].commenter;
        }
        if (PlayerName != forumDatas[i].playerName || forumDatas[i].voteActive)
            activateButton.gameObject.SetActive(false);
        else
            activateButton.gameObject.SetActive(true);
        activateButton.onClick.RemoveAllListeners();
        activateButton.onClick.AddListener(delegate { ActivateVote(i); });
        if (forumDatas[i].voteActive)
            voteButton.interactable = true;
        else 
            voteButton.interactable = false;
        voteButton.onClick.RemoveAllListeners();
        voteButton.onClick.AddListener(delegate { OpenVoteScreen(i); });
        enterButton.onClick.RemoveAllListeners();
        enterButton.onClick.AddListener(delegate { PostComment(i); });
    }
    private void PostComment(int i)
    {
        if (commentInput.text != "")
        {
            forumDatas[i].comments.Add(new Comment(PlayerName, commentInput.text));
            foreach (Transform child in commentPath)
            {
                Destroy(child.gameObject);
            }
            for (int j = 0; j < forumDatas[i].comments.Count; j++)
            {
                var prefab = Instantiate(commentPrefab, commentPath);
                Transform infoPath = prefab.transform.GetChild(0);
                infoPath.GetChild(0).GetComponent<TMP_Text>().text = forumDatas[i].comments[j].comment;
                infoPath.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = forumDatas[i].comments[j].commenter;
            }
            commentInput.text = "";
        }
        else
        {
            Debug.Log("InputData empty");
        }
    }
    private void ActivateVote(int i)
    {
        activateButton.gameObject.SetActive(false);
        forumDatas[i].voteActive = true;
        voteButton.interactable = true;
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
