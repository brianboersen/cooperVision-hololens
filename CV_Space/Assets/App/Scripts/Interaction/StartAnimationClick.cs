using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

//Creator: Brian Boersen
public class StartAnimationClick : MonoBehaviour, IInputClickHandler
{
    //control the animation
    [SerializeField]
    private AnimationController animationController;

    private void Awake()
    {
        if(animationController == null)
        {
            Debug.LogError("no animation controller");
        }
    }

    //get gesture pinch input
    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        animationController.triggerAnimation();
    }


}
