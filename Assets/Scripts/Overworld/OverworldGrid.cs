using System.Collections.Generic;
using UnityEngine;

public class OverworldGrid : MonoBehaviour
{
    public class RegionData
    {
        private int Owner;
        private int Gold;
        private int Elixer;
        private int DarkElixer;
        private int Gems;

        public RegionData(int owner, int gold, int elixer, int darkElixer, int gems)
        {
            Owner = owner;
            Gold = gold;
            Elixer = elixer;
            DarkElixer = darkElixer;
            Gems = gems;
        }
        public int GetOwner() {  return Owner; }
        public int GetGold() {  return Gold; }
        public int GetElixer() {  return Elixer; }
        public int GetDarkElixer() { return DarkElixer; }
        public int GetGems() {  return Gems; }
    }
    private List<RegionData> mapData = new List<RegionData>
    {
        new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 5000, 5000, 5000, 5000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000),
        new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000),
        new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
        new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000)
    };

    [SerializeField] Transform overworld;
    [SerializeField] public Sprite[] GuildSprite = new Sprite[3];
    [SerializeField] public Sprite questionMark;
    [SerializeField] private int GuildCount = 3;
    private Camera cam;
    private GameObject[] Guilds = new GameObject[3];
    [SerializeField] private GameObject logoPrefab;
    private void Awake()
    {
        cam = Camera.main;

        for (int j = 0; j < GuildCount; j++)
        {
            Guilds[j] = Instantiate(logoPrefab, overworld);
            Guilds[j].SetActive(false);
            Guilds[j].GetComponent<SpriteRenderer>().sortingOrder = 1;
            Guilds[j].GetComponent<SpriteRenderer>().sprite = GuildSprite[j];
        }

        int i = 0;
        foreach (Transform child in transform)
        {
            Region data = child.GetComponent<Region>();
            data.Owner = mapData[i].GetOwner();
            data.Gold = mapData[i].GetGold();
            data.Elixer = mapData[i].GetElixer();
            data.DarkElixer = mapData[i].GetDarkElixer();
            data.Gems = mapData[i].GetGems();
            i++;
        }
    }
    public void UpdateVisuals(bool zoomedIn)
    {
        for (int i = 0; i < GuildCount; i++)
            Guilds[i].SetActive(!zoomedIn);

        for (int j = 0; j < GuildCount; j++)
        {
            Vector3 position = new Vector3();
            int count = 0;
            foreach (Transform child in transform)
            {
                Region data = child.GetComponent<Region>();
                if (data.Owner == j + 1)
                {
                    position += child.transform.position;
                    count++;
                }
            }
            Guilds[j].transform.position = position / count;
        }
    }
    private void Update()
    {
        UpdateVisuals(cam.orthographicSize < 8);
        
    }

}
