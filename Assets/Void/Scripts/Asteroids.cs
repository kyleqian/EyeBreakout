using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour 
{
	public GameObject brickParticle;

	void OnCollisionEnter(Collision other)
	{
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		spawnAsteroids.instance.DestroyAsteroids(); 
		Destroy (gameObject);
	}
}
