using UnityEngine;

public class RotatingRing : MonoBehaviour {

    float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(20, 40);

        if (name == "Inner Ring")
        {
            rotationSpeed = -rotationSpeed;
        }
    }

    void Update() {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
