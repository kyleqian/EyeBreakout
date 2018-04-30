using UnityEngine;

public class Boundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.name.IndexOf("GravityBall") >= 0)
        {
            spawnAsteroids.instance.LoseLife();
        }
    }
}
