using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Region : MonoBehaviour
{
    [SerializeField] public int Owner;
    [SerializeField] public int Gold;
    [SerializeField] public int Elixer;
    [SerializeField] public int DarkElixer;
    [SerializeField] public int Gems;

    private bool Active = false;
    private float activeTimer = 0;

    private SpriteRenderer spriteRenderer;
    private OverworldGrid overworldGrid;
    private Camera cam;

    private void Awake()
    {
        overworldGrid = this.transform.parent.GetComponent<OverworldGrid>();
        spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }
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
            if (Owner != 0)
                UI.GetChild(2).GetComponent<Image>().sprite = overworldGrid.GuildSprite[Owner - 1];
            else
                UI.GetChild(2).GetComponent<Image>().sprite = overworldGrid.questionMark;
            Transform data = UI.GetChild(4);
            data.GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = Gems.ToString();
            data.GetChild(2).GetChild(2).GetComponent<TMP_Text>().text = DarkElixer.ToString();
            data.GetChild(3).GetChild(2).GetComponent<TMP_Text>().text = Elixer.ToString();
            data.GetChild(4).GetChild(2).GetComponent<TMP_Text>().text = Gold.ToString();
        }
        activeTimer = 0;

    }
    public void UpdateVisuals(bool zoomedIn)
    {
        spriteRenderer.enabled = zoomedIn;
        if (Owner == 0)
            spriteRenderer.enabled = false;
        else
            spriteRenderer.sprite = overworldGrid.GuildSprite[Owner - 1];
    }
    private void Update()
    {

        UpdateVisuals(cam.orthographicSize < 8);

        if (Active) activeTimer += Time.deltaTime;
    }
}
