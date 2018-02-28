using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class ChosenSoundPlayer : SimpleSoundPlayer
{
    public override void playSound(int clipNum)
    {
        if(clipNum > clipsSize - 1)
        {
            clipNum = 0;
            Debug.LogError("Number to high");
        }

        clip = clips[clipNum];

        base.playSound();
    }

    
}
