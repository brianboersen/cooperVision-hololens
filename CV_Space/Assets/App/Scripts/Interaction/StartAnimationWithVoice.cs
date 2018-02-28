using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
//Creator: Brian Boersen

public class StartAnimationWithVoice : MonoBehaviour, ISpeechHandler
{
    //all keywords to activate animation
    [SerializeField]
    private string[] keyWords;

    private int keyWordsLenght;

    //control the animation
    [SerializeField]
    private AnimationController animationController;

    private void Awake()
    {
        keyWordsLenght = keyWords.Length;
        if (keyWordsLenght == 0)
        {
            Debug.LogError("key words missing");
        }

        if (animationController == null)
        {
            Debug.LogError("no animation controller");
        }
    }

    //when keyword is recognised   
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        //go trough all keywords
        for (int i = 0; i < keyWordsLenght; i++)
        {
            if (eventData.RecognizedText.ToLower().Contains(keyWords[i]))
            {
                animationController.triggerAnimation();
            }
        }
    }
}
