using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class RotateToUserWithCurve : RotateToUser
{
    [SerializeField]
    private float radius = 1;

    [SerializeField]
    private bool lockX = false;

    [SerializeField]
    private bool lockY = false;

    [SerializeField]
    private bool lockZ = false;

    private Vector3 startPosition;
    private Vector3 newPosition;

    private void Awake()
    {
        startPosition = transform.localPosition;

        //fail safe
        if (user == null)
        {
            Debug.LogError("camera object not atached");
        }
    }

    protected override void Update()
    {
        rotate();
        moveOnCurve();
    }

    //calculate the objects position on the curve
    private void moveOnCurve()
    {
        if (!lockX)
        {
            newPosition.x = startPosition.x + (transform.forward.x * radius); 
        }
        else
        {
            newPosition.x = startPosition.x;
        }

        if (!lockY)
        {
            newPosition.y = startPosition.y + (transform.forward.y * radius);
        }
        else
        {
            newPosition.y = startPosition.y;
        }

        if (!lockZ)
        {
            newPosition.z = startPosition.z + (transform.forward.z * radius);
        }
        else
        {
            newPosition.y = startPosition.y;
        }

        transform.localPosition = newPosition * -1;
    }

}