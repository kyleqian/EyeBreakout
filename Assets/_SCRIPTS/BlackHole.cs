using Tobii.Gaming;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public static BlackHole Instance;
    public bool active;

    private MeshRenderer mr;
    private Collider col;
    private float depth;

    private void Awake()
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
    }

    private void Update()
    {
        //active = Input.GetMouseButton(0);
        active = TobiiAPI.GetUserPresence().IsUserPresent();
        //mr.enabled = active;
        col.enabled = active;

        if (active)
        {
            transform.position = GazePlotter.publicGazePoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.IndexOf("GravityBall") >= 0)
        {
            spawnAsteroids.instance.LoseLife();
        }
    }
}
