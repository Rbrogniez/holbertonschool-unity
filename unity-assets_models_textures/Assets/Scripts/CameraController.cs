using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Le transform du joueur
    public Vector3 offset; // L'écart entre la caméra et le joueur
    public float smoothSpeed = 0.125f; // Fluidité du mouvement de la caméra

    // Nouvelles variables pour la rotation de la caméra
    public float rotationSpeed = 2.0f; // Vitesse de rotation de la caméra
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void LateUpdate()
    {
        // Mouvement de la caméra
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Regarder le joueur
        transform.LookAt(target);

        // Rotation de la caméra avec le clic droit de la souris
        if (Input.GetMouseButton(1)) // Le clic droit est enfoncé
        {
            rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            rotationY += Input.GetAxis("Mouse X") * rotationSpeed;

            // Limiter la rotation verticale pour éviter le retournement de la caméra
            rotationX = Mathf.Clamp(rotationX, -90, 90);

            // Appliquer la rotation à la caméra
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
}
