using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

//Creator: Brian Boersen

public class InteractableIndicator : MonoBehaviour, IFocusable
{
    public GameObject indicatorObject;

    private void Awake()
    {
        indicatorObject.SetActive(false);
    }

    public void OnFocusEnter()
    {
        indicatorObject.SetActive(true);
    }

    public void OnFocusExit()
    {
        indicatorObject.SetActive(false);
    }
}
