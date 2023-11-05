using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform cam;
    public float speed = 15f;
    public float jumpForce = 5.0f;
    public float gravity = -25.0f;
    Vector3 direction;
    public CharacterController controller;

    void Update()
    {

        if (transform.position.y <= -10.0f)
        {
            transform.position = new Vector3(0.0f, 1.25f, 0.0f);
        }
        else
        {
            float hInput = Input.GetAxisRaw("Horizontal");
            float vInput = Input.GetAxisRaw("Vertical");
            if (controller.isGrounded)
            {
                direction = new Vector3(hInput, 0f, vInput);
                direction = transform.TransformDirection(direction);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    direction.y = jumpForce;
                }
            }
            
            direction.y += gravity * Time.deltaTime;


            
            controller.Move(direction * speed * Time.deltaTime);
            
            

        }
    }
}