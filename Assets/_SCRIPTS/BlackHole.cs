﻿using Tobii.Gaming;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public static BlackHole Instance;

    public bool active { get; private set; }
    public AudioClip[] death;
    public AudioSource deathSource;

    MeshRenderer mr;
    Collider col;
    float depth;

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
    }

    void Update()
    {
        if (VoidGameManager.Instance.UseEyeTracker)
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
