using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class IconRemover : MonoBehaviour
{
    [SerializeField] GameObject overworld;
    [SerializeField] GameObject[] DisableThis;

    public void Refresh()
    {
        for (int i = 0; i < DisableThis.Length; i++)
        {
            DisableThis[i].SetActive(overworld.activeInHierarchy);
        }
    }
}
