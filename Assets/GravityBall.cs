using UnityEngine;

public class GravityBall : MonoBehaviour
{
    public float forceMultiplier;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (BlackHole.Instance.active)
        {
            float distance = Vector3.Distance(BlackHole.Instance.transform.position, transform.position);
            Vector3 direction = BlackHole.Instance.transform.position - transform.position;
            rb.AddForce(Vector3.Normalize(direction) * forceMultiplier / distance);
        }
    }
}
