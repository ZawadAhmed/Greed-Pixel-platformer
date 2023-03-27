using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minX, maxX, minY, maxY;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 centerPoint = (player1.position + player2.position) / 2f;
        Vector3 desiredPosition = centerPoint + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.5f;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.5f;
        minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 0.5f;
        maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 0.5f;

       
        player1.position = new Vector3(
            Mathf.Clamp(player1.position.x, minX, maxX),
            Mathf.Clamp(player1.position.y, minY, maxY),
            player1.position.z
        );

       
        player2.position = new Vector3(
            Mathf.Clamp(player2.position.x, minX, maxX),
            Mathf.Clamp(player2.position.y, minY, maxY),
            player2.position.z
        );
    }
}