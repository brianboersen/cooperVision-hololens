using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creator: Brian Boersen

public class ReturnRealSize : MonoBehaviour
{
	private void Start ()
	{
        Debug.Log(gameObject.GetComponent<MeshRenderer>().bounds.size);
    }
}
