using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
	private GameObject trap;
	
    // Start is called before the first frame update
    void Start()
    {
        trap = GameObject.Find("Rotating trap");
    }

    void FixedUpdate()
    {
        trap.transform.Rotate(0f, 4f, 0f);
    }
}
