using UnityEngine;
using UnityEngine.Audio;

public class Boundary : MonoBehaviour
{
    public AudioClip[] death;
    public AudioSource deathSource;

    void OnTriggerExit(Collider other)
    {
        if (other.name.IndexOf("GravityBall") >= 0)
        {
            playDeathAudio();
            VoidGameManager.Instance.LoseLife();
            //playDeathAudio();
        }
    }

    void playDeathAudio()
    {
        deathSource.clip = death[0];
        deathSource.Play();
    }
}
