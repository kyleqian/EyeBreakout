using UnityEngine;

public class Asteroids : MonoBehaviour 
{
	public GameObject brickParticle;
    public AudioClip[] bounce;

    AudioSource bounceSource;
    float rotateX;
    float rotateY;
    float rotateZ;

    void Awake()
    {
        float scaleFactor = Random.Range(0.6f, 1.2f);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        rotateX = Random.Range(-100, 100) * 2;
        rotateY = Random.Range(-100, 100) * 2;
        rotateZ = Random.Range(-100, 100) * 2;
    }

    void Start()
    {
        bounceSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime));
    }

    void OnCollisionEnter(Collision other)
	{
        if (other.collider.name.IndexOf("Destroyer") >= 0)
        {
            playBounceAudio();
            Instantiate(brickParticle, transform.position, Quaternion.identity);
		    VoidGameManager.Instance.DestroyAsteroid(GetInstanceID());
		    Destroy(gameObject, 0.5f);
        }
	}

    void playBounceAudio()
    {
        bounceSource.Play();
    }
}
