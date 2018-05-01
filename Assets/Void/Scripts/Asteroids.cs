using UnityEngine;

public class Asteroids : MonoBehaviour 
{
	public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
	{
        if (other.collider.name.IndexOf("GravityBall") >= 0)
        {
		    Instantiate (brickParticle, transform.position, Quaternion.identity);
		    spawnAsteroids.instance.DestroyAsteroids(); 
		    Destroy (gameObject);
        }
	}

    void Update()
    {
        float rotateX = Random.Range(20, 40);
        float rotateY = Random.Range(20, 40);
        float rotateZ = Random.Range(20, 40);
        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
    }
}
