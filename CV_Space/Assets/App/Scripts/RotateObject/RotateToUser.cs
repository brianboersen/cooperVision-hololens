using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class RotateToUser : MonoBehaviour
{
    public GameObject user;

    private void Awake ()
	{
       //fail safe
       if(user == null)
        {
            Debug.LogError("camera object not atached");
        }
	}

	protected virtual void Update ()
	{
        Debug.Log("rotate to player");
        rotate();
	}

    //rotate object
    protected void rotate()
    {
        transform.LookAt(transform.position + user.transform.rotation * Vector3.forward);
    }  

}
