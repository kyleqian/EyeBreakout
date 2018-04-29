using Tobii.Gaming;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public static BlackHole Instance;
    public bool active;

    private bool _hasHistoricPoint = false;
    private Vector3 _historicPoint;
    private MeshRenderer mr;
    private Collider col;
    private float depth;
    Vector2 filteredPoint;

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
        mr.enabled = active;
        col.enabled = active;

        //Vector2 gazePoint = GazePlotter.publicPoint;

        if (active)
        {
            //var mousePos = Input.mousePosition;
            //mousePos.z = depth;
            //transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            //Vector3 point = new Vector3(gazePoint.x, gazePoint.y, depth);
            //transform.position = Camera.main.ScreenToWorldPoint(point);

            Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;

            //transform.position = GazePlotter.publicPoint;

            if (!_hasHistoricPoint)
            {
                _historicPoint = gazePoint;
                _hasHistoricPoint = true;
            }

            filteredPoint = Vector2.Lerp(filteredPoint, gazePoint, 0.5f);

            //var smoothedPoint = new Vector3(
            //    point.x * (1.0f - FilterSmoothingFactor) + _historicPoint.x * FilterSmoothingFactor,
            //    point.y * (1.0f - FilterSmoothingFactor) + _historicPoint.y * FilterSmoothingFactor,
            //    point.z * (1.0f - FilterSmoothingFactor) + _historicPoint.z * FilterSmoothingFactor);

            _historicPoint = filteredPoint;

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(filteredPoint.x, filteredPoint.y, depth));
        }

    }
}
