using UnityEngine;

public class HeroCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = -3f;
    public float yawSpeed = 100f;

    public float currentZoom = 10f;
    public float currentYaw = 0;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);

        if (Input.GetKey(KeyCode.W))
        {
            pitch++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pitch--;
        }
    }
}
