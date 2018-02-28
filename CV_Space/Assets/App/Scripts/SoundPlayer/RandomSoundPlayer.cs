using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class RandomSoundPlayer : SimpleSoundPlayer 
{
    public override void playSound(int DontAsign = 0)
    {
        clip = randomClip();

        base.playSound();
    }


    //get a random clip
    protected AudioClip randomClip()
    {
        return clips[Random.Range(0, clipsSize)];
    }
}
