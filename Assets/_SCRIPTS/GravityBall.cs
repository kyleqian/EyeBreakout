﻿using UnityEngine;

public class GravityBall : MonoBehaviour
{
    public float forceMultiplier;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (BlackHole.Instance.active)
        {
            float distance = Vector3.Distance(BlackHole.Instance.transform.position, transform.position);
            Vector3 direction = BlackHole.Instance.transform.position - transform.position;
            rb.AddForce(Vector3.Normalize(direction) * forceMultiplier / (distance / 2));
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
