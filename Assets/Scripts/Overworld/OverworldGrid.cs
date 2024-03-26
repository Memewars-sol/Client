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
        public int GetOwner() { return Owner; }
        public int GetGold() { return Gold; }
        public int GetElixer() { return Elixer; }
        public int GetDarkElixer() { return DarkElixer; }
        public int GetGems() { return Gems; }
    }
    //private List<RegionData> mapData = new List<RegionData>
    //{
    //    new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 5000, 5000, 5000, 5000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000),
    //    new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (2, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000),
    //    new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (1, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000), new RegionData (3, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000),
    //    new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000), new RegionData (0, 1000, 1000, 1000, 1000)
    //};
    private List<int> map = new List<int>
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1
    };
    //GenerateGrid
    private Vector2Int mapSize = new Vector2Int(50, 50);
    private Dictionary<Vector2Int, Tile> cellDictionary;
    [SerializeField] private Tile tilePrefab;
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
        GenerateGrid();
        SolveConnections();
        //for (int j = 0; j < GuildCount; j++)
        //{
        //    Guilds[j] = Instantiate(logoPrefab, overworld);
        //    Guilds[j].SetActive(false);
        //    Guilds[j].GetComponent<SpriteRenderer>().sortingOrder = 1;
        //    Guilds[j].GetComponent<SpriteRenderer>().sprite = GuildSprite[j];
        //}

        //int i = 0;
        //foreach (Transform child in transform)
        //{
        //    Region data = child.GetComponent<Region>();
        //    data.Owner = mapData[i].GetOwner();
        //    data.Gold = mapData[i].GetGold();
        //    data.Elixer = mapData[i].GetElixer();
        //    data.DarkElixer = mapData[i].GetDarkElixer();
        //    data.Gems = mapData[i].GetGems();
        //    i++;
        //}
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
    private void GenerateGrid()
    {
        cellDictionary = new Dictionary<Vector2Int, Tile>();

        int rows = mapSize.y, cols = mapSize.x;

        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = 0; j < cols; j++)
            {
                int tileIndex = (i * rows) + j;

                int tileCost = map[tileIndex];
                Vector2Int coordinate = new(j, i);

                Tile cell = Instantiate(tilePrefab, transform);
                cell.Initialize(coordinate, tileCost);

                cellDictionary.Add(coordinate, cell);
            }
        }
    }
    private Dictionary<Vector2Int, List<Tile>> connectionDictionary;

    // Pass grid coordinate to get Cell object
    // This method may return null if there is no Cell for the given coordinate!
    public Tile GetCell(Vector2Int gridCoordinate)
    {
        cellDictionary.TryGetValue(gridCoordinate, out Tile cell);
        return cell;
    }
    private static readonly List<Vector2Int> NeighbourDirections = new List<Vector2Int>
    {
        new Vector2Int(1,0),    // E
        new Vector2Int(0,-1),   // S
        new Vector2Int(-1,0),   // W
        new Vector2Int(0,1),    // N

    };

    public void SolveConnections()
    {
        connectionDictionary = new Dictionary<Vector2Int, List<Tile>>();

        foreach (KeyValuePair<Vector2Int, Tile> kvp in cellDictionary)
        {
            if (kvp.Value.Cost > 0)
            {
                var coord = kvp.Key;

                List<Tile> connections = new();

                foreach (Vector2Int direction in NeighbourDirections)
                {
                    var relativeCoord = coord + direction;
                    if (cellDictionary.TryGetValue(relativeCoord, out Tile neighbour))
                    {
                        if (GetCell(relativeCoord).Cost != kvp.Value.Cost)
                            continue;
                        connections.Add(neighbour);
                        
                        kvp.Value.neighbourCount = connections.Count;
                    }
                }
                connectionDictionary.Add(coord, connections);
            }
        }
    }
    private void Update()
    {
        UpdateVisuals(cam.orthographicSize < 8);

    }
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        foreach (var kvp in connectionDictionary)
        {
            var list = kvp.Value;

            var cell = GetCell(kvp.Key);

            if (cell == null || !cell.IsPassable) continue;

            foreach (var c in list)
            {
                var start = new Vector3(kvp.Key.x, kvp.Key.y);
                var end = new Vector3(c.Coordinate.x, c.Coordinate.y);

                if (c.IsPassable)
                {
                    Debug.DrawLine(start, end, Color.blue);
                }
            }
        }
    }

#endif

}

