using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class AnimationController : MonoBehaviour
{
    //object with animation
    [SerializeField]
    protected GameObject animatedObject;

    //the animation component
    protected Animation anim;

    //check if particles need to be played
    [SerializeField]
    protected bool hasParticles = false;

    //control particles
    protected ParticleSwitch particleController = null;

    //check if you use sound;
    [SerializeField]
    protected bool hasSound = false;

    //sound player
    [SerializeField]
    protected SimpleSoundPlayer soundPlayer;

    protected void Awake()
    {
        anim = animatedObject.GetComponent<Animation>();

        if (hasParticles)
        {
            if (GetComponent<ParticleSwitch>() != null)
            {
                particleController = GetComponent<ParticleSwitch>();
            }
            else
            {
                Debug.LogError("no particleSwitch not atached to object");
            }
        }

        if (hasSound)
        {
            if(soundPlayer == null)
            {
                if (GetComponent<SimpleSoundPlayer>() != null)
                {
                    soundPlayer = GetComponent<SimpleSoundPlayer>();
                }
                else
                {
                    Debug.LogError("no particleSwitch not atached to object");
                }
            }        
        }
    }

    //starts animation
    public virtual void triggerAnimation()
    {
        //check if the animation clip is not already playing
        if (animationIsPlaying() == false)
        {
            //start animation
            anim.Play();


            //switch particles
            if (hasParticles)
            {
                particleController.baseParticlesOn(true, animationDuration());
            }

            //start sound
            if (hasSound)
            {
                soundPlayer.playSound();
            }
        }
        else
        {
            Debug.Log("animation is already playing");
        }
    }

    //stops current animation
    public virtual void stopAnimation()
    {
        //check if the clip is playing
        if (animationIsPlaying())
        {
            //stop animation
            anim.Stop();

            //stop particles
            if (hasParticles)
            {
                particleController.baseParticlesOff();
            }

            //stop sound
            if (hasSound)
            {
                soundPlayer.stopSound();
            }
        }
        else
        {
            Debug.Log("animation not playing");
        }
    }

    //check if animation is playing
    public bool animationIsPlaying()
    {
        if (anim.isPlaying)
        {
            return true;
        }

        return false;
    }

    //get animation lenght
    public float animationDuration()
    {
        return anim.clip.length;
    }
}
