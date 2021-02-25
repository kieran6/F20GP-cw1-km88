using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
	
	public Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void FixedUpdate()
    {
       if(Input.GetKey(KeyCode.Mouse0))
		{
			anim.Play("Sword swing");
		} 
    }

    
}
