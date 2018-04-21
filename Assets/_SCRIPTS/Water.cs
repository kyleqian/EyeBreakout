using UnityEngine;

public class Water : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        GameManager.instance.LoseLife();
    }
}
