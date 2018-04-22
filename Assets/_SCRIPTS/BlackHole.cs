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
        active = Input.GetMouseButton(0);
        mr.enabled = active;
        col.enabled = active;

        if (active)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = depth;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}
