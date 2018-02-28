using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class SwitchTwoObjects : MonoBehaviour
{
    [SerializeField]
    private float switchTime = 0.4f;

    [SerializeField]
    private GameObject[] switchObjects;

    private int counter = 0;
    private int switchSize;

    private void Start ()
	{
        switchSize = switchObjects.Length;
        
        if(switchSize < 2)
        {
            Debug.LogError("not enough objects");
        }
        else
        {
            for (int i = 1; i < switchSize; i++)
            {
                hideObject(i);
            }
        }

        StartCoroutine("switchIt");
    }

    //ads one to the counter
    private void updateCounter()
    {
        counter++;

        if (counter > switchSize - 1)
        {
            counter = 0;
        }

    }

    //sets object false
    private void hideObject(int number)
    {
        switchObjects[number].SetActive(false);
    }

    // sets objet true
    private void showObject(int number)
    {
        switchObjects[number].SetActive(true);
    }

    IEnumerator switchIt()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchTime);
            hideObject(counter);
            updateCounter();
            showObject(counter);
        }
    }
}
