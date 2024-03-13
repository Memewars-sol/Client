using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRemover : MonoBehaviour
{
    [SerializeField] GameObject overworld;
    [SerializeField] GameObject Icon;

    private void Update()
    {
        Icon.SetActive(!overworld.activeInHierarchy);
    }
}
