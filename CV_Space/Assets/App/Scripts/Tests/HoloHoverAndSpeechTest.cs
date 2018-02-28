using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

//Creator: Brian Boersen

public class HoloHoverAndSpeechTest : MonoBehaviour, IFocusable, ISpeechHandler,IInputClickHandler
{
    public Color normalCol;
    public Color highlightCol;
    private Renderer rend;
    private Material myMatInstance;
    private bool canRotate = false;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
        myMatInstance = rend.material;
        myMatInstance.color = normalCol;
    }

    private void Update()
    {
        if (canRotate)
        {
            this.gameObject.transform.localRotation *= Quaternion.Euler(0, 1, 0);
        }
    }

    public void OnFocusEnter()
    {
        myMatInstance.color = highlightCol;
    }

    public void OnFocusExit()
    {
        myMatInstance.color = normalCol;
    }

    private void OnDestroy()
    {
        Destroy(myMatInstance);
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText)
        {
            case "go":
                TogleRotate();
                break;
        }
    }

    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        TogleRotate();
    }

    private void TogleRotate()
    {
        canRotate = !canRotate;
    }
}
