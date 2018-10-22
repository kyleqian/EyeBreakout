using Tobii.Gaming;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public static BlackHole Instance;

    public bool active;
    public AudioClip[] death;
    public AudioSource deathSource;

    MeshRenderer mr;
    Collider col;
    float depth;
    bool usingEyeTracker;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        mr = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        depth = transform.position.z - Camera.main.transform.position.z;
        usingEyeTracker = TobiiAPI.GetUserPresence().IsUserPresent();
    }

    void Update()
    {
        if (usingEyeTracker)
        {
            active = TobiiAPI.GetUserPresence().IsUserPresent();
            col.enabled = active;
            if (active)
            {
                transform.position = GazePlotter.publicGazePoint;
            }
        }
        else
        {
            active = true;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 22;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.IndexOf("Destroyer") >= 0)
        {
            VoidGameManager.Instance.LoseLife();
            playDeathAudio();
        }
    }

    void playDeathAudio()
    {
        deathSource.clip = death[0];
        deathSource.Play();
    }
}
