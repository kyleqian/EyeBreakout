﻿using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
