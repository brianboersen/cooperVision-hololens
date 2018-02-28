using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class ParticleSwitch : MonoBehaviour
{
    //ask if you want to start with the base particles off
    [SerializeField]
    private bool startWithBaseOn = false;

    private bool baseOn = true;

    private bool switched = false;

    //your main/first particles
    [SerializeField]
    private GameObject[] baseParticles;

	private void Start ()
	{
        if (startWithBaseOn == false)
        {
            baseParticlesOff();
        }
        else
        {
            baseParticlesOn();
        }        
    }

    //turn base on
    public void baseParticlesOn(bool switchBacktoBaseInTime = false, float waitTime = 1f)
    {
        if (!baseOn)
        {
            foreach (GameObject particle in baseParticles)
            {
                particle.SetActive(true);
            }
            baseOn = true;

            if (switchBacktoBaseInTime)
            {
                StartCoroutine(switchBack(waitTime));
            }
        }
    }

    //turn base on
    public void baseParticlesOnn()
    {
        baseParticlesOn();
    }

    //turn base off
    public void baseParticlesOff()
    {
        if (baseOn)
        {
            foreach (GameObject particle in baseParticles)
            {
                particle.SetActive(false);
            }
            baseOn = false;
        }
    }

    private IEnumerator switchBack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        baseParticlesOff();
        StopCoroutine("switchBack");
    }

}
