using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] public int cost = 0;

    // cache passable state instead of checking 'cost < 0' every time it is queried
    private bool cachedPassable = false;

    // for tile visuals
    private SpriteRenderer spriteRenderer;

    #region For Square Grid & Pathfinding

    public Vector2Int Coordinate { get; private set; }

    // Cell can be set as non-passable (cost < 0)
    // This is provided as a syntactic sugar, improving readability
    //      if(cell.IsPassable)
    // as opposed to
    //      if(cell.Cost < 0)
    public bool IsPassable
    {
        get => cachedPassable;
    }

    // C# properties allow you to do additional tasks when get/set values!
    // In this case, setting cost to be < 0 makes the IsPassable be set as false
    // and then tile visuals can also be updated!
    public int Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost = value;

            // cache whether the tile can be walked on or not, instead of checking every time IsPassable is called.
            cachedPassable = cost >= 0;

            // update visuals according to cost.
            UpdateVisuals(false);
        }
    }

    #endregion For Square Grid & Pathfinding


    [Header("TempData")]
    [SerializeField] private int gold = 1000;
    [SerializeField] private int elixer = 1000;
    [SerializeField] private int darkElixer = 1000;
    [SerializeField] private int gems = 1000;

    private bool Active = false;
    private float activeTimer = 0;

    private void OnMouseDown()
    {
        Active = true;
    }
    private void OnMouseUp()
    {
        Active = false;
        if (activeTimer < 0.1f)
        {
            Transform UI = GameObject.Find("OverworldUI").transform.GetChild(0);
            UI.gameObject.SetActive(true);
            switch (cost)
            {
                case 1: UI.GetChild(2).GetComponent<Image>().sprite = guild1; break;
                case 2: UI.GetChild(2).GetComponent<Image>().sprite = guild2; break;
                case 3: UI.GetChild(2).GetComponent<Image>().sprite = guild3; break;
                default: UI.GetChild(2).GetComponent<Image>().sprite = questionMark; break;
            }
            Transform data = UI.GetChild(4);
            data.GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = gems.ToString();
            data.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = darkElixer.ToString();
            data.GetChild(3).GetChild(2).GetComponent<TMP_Text>().text = elixer.ToString();
            data.GetChild(4).GetChild(2).GetComponent<TMP_Text>().text = gold.ToString();
        }
        activeTimer = 0;

    }
    [SerializeField] private Sprite guild1, guild2, guild3, box, questionMark;
    private Camera cam;
    private float size;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;
        size = transform.localScale.x;
    }


    public int neighbourCount;
    
    public void UpdateVisuals(bool zoomedIn)
    {
        if (zoomedIn)
        {
            spriteRenderer.color = Color.white;
            switch (cost)
            {
                case 1: spriteRenderer.sprite = guild1; break;
                case 2: spriteRenderer.sprite = guild2; break;
                case 3: spriteRenderer.sprite = guild3; break;
                default: break;
            }
        }
        else
        {
            spriteRenderer.sprite = box;
            switch (cost)
            {
                case 1: spriteRenderer.color = neighbourCount == 4 ? Color.yellow * 0.9f : Color.yellow; break;
                case 2: spriteRenderer.color = neighbourCount == 4 ? Color.cyan * 0.9f : Color.cyan; break;
                case 3: spriteRenderer.color = neighbourCount == 4 ? Color.red * 0.9f: Color.red; break;
                default: break;
            }
        }
    }

    private void Update()
    {
        UpdateVisuals(cam.orthographicSize < 8);

        if (Active) activeTimer += Time.deltaTime;
    }

    public void Initialize(Vector2Int coordinate, int tileCost)
    {
        // Name the gameObject for easier debugging/viewing in Unity editor
        gameObject.name = $"Cell ({coordinate.x}, {coordinate.y})";

        // Set the data
        Coordinate = coordinate;

        // Note that instead of setting the field 'cost' we set the property 'Cost'

        Cost = tileCost;

        // place the cell at that coordinate in world space.
        // Vector2Int cannot be implicitly cast to Vector3, therefore need to manually
        // create and assign the values.
        transform.position = new Vector3((coordinate.x - 22.8f) / 1.3f, (coordinate.y - 2.1f) / 1.3f, 0.0f);
    }
}
