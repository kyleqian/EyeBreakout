using UnityEngine;

public class Asteroids : MonoBehaviour 
{
	public GameObject brickParticle;
    public AudioClip[] bounce;
    private AudioSource bounceSource;

    void OnCollisionEnter(Collision other)
	{
        if (other.collider.name.IndexOf("GravityBall") >= 0)
        {
            playBounceAudio();
            Instantiate (brickParticle, transform.position, Quaternion.identity);
		    spawnAsteroids.instance.DestroyAsteroids(); 
		    Destroy (gameObject, 1.0f);
        }
	}

    void Start()
    {
        bounceSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float rotateX = Random.Range(20, 40);
        float rotateY = Random.Range(20, 40);
        float rotateZ = Random.Range(20, 40);
        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
    }

    void playBounceAudio()
    {
        bounceSource.Play();
    }
}
