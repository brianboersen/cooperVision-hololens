using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class AnimationSpeedMultiplier : AnimationController
{
    //anim[anim.clip.name].speed = 2f;
    //print(anim.clip.name);

    [SerializeField]
    private int accelerateTurns = 3;

    [SerializeField]
    private float eccelerateWaitTime = 1f;

    [SerializeField]
    private float eccelerateSpeedMultiplier = 2f;

    private int currentTurn = 0;

    private bool accelerating = false;
    
    private string clipName;
    private float animationTime;

    private void Start()
    {
        //get the animation clip name using anim from base class
        clipName = anim.clip.name;
    }

    public override void triggerAnimation()
    {
        //check if the animation clip is not already playing
        if (animationIsPlaying() == false)
        {
            //start animation
            anim.Play();
        }

        //start sound
        if (hasSound)
        {
            soundPlayer.playSound();
        }

        accelerateAnimation();
    }

    private void accelerateAnimation()
    { 
        if (!accelerating)
        {
            if (!animationIsPlaying())
            {
                triggerAnimation();
            }

            if (hasParticles)
            {
                animationTime = ((accelerateTurns * 2) - 1) * eccelerateWaitTime;
                particleController.baseParticlesOn(true, animationTime);
            }

            StartCoroutine(accelorate());
        }
    }

    private IEnumerator accelorate()
    {
        accelerating = true;

        //first acceleration without waiting first
        anim[clipName].speed *= eccelerateSpeedMultiplier;
        currentTurn++;

        //wind up
        while (currentTurn < accelerateTurns)
        {
            yield return new WaitForSeconds(eccelerateWaitTime);

            anim[clipName].speed *= eccelerateSpeedMultiplier;
            currentTurn++;

        }

        //wind down
        while(currentTurn > 0)
        {
            yield return new WaitForSeconds(eccelerateWaitTime);

            anim[clipName].speed /= eccelerateSpeedMultiplier;
            currentTurn--;

        }

        //Debug.Log(anim[clipName].speed);

        //reset
        accelerating = false;
        StopCoroutine("accelorate");
    }

}
