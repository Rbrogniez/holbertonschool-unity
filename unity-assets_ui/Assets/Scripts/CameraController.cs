using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool isInverted = false;
    public float smooth = 0.5f;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = true;
    public float rotationSpeedX = 2.0f;
    public float rotationSpeedY = 0.5f;
    private float mouseY;
    private float mouseX;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = player.position + offset;
        isInverted = PlayerPrefs.GetInt("isInverted") == 1;
    }
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y") * rotationSpeedY;
        if (isInverted)
            mouseY *= -1;

        mouseX = Input.GetAxis("Mouse X") * rotationSpeedX;

        if (rotateAroundPlayer)
        {
            if (mouseX != 0)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(mouseX, Vector3.up);
                player.Rotate(Vector3.up, mouseX);
                offset = camTurnAngle * offset;
            }

            if (mouseY != 0)
            {

                Quaternion camTurnAngle = Quaternion.AngleAxis(mouseY, transform.right);
                offset = camTurnAngle * offset;
            }

        }


        Vector3 newPos = player.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smooth);



        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(player);
        }
    }
}

