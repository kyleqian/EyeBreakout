using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{
	public float planetInitialVelocity = 200f;
	private Rigidbody rb;
	private bool planetInPlay;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && (planetInPlay == false)) 
		{
			transform.parent = null;
			planetInPlay = true;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (planetInitialVelocity+100, planetInitialVelocity, 0));
		}
	}
}
