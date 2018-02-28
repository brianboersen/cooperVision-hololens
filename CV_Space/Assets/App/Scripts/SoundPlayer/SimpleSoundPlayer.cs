using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Creator: Brian Boersen
public class SimpleSoundPlayer : MonoBehaviour
{
    public AudioSource source;

    public AudioClip[] clips;

    protected AudioClip clip;

    protected int clipsSize;

	protected void Awake ()
	{
        clipsSize = clips.Length;

        clip = clips[0];

        //check the amound of clips
        if (clipsSize == 0)
        {
            Debug.LogError("no sounds asigned");
        }
	}

    //play soundclip
	public virtual void playSound (int DontAsign = 0)
	{
        source.PlayOneShot(clip);
	}

    //stop current sound from playing
    public void stopSound()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
}
