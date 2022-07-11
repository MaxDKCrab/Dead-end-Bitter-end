using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    public float speed;
    public float sprintSpeed;
    private Vector3 velocity;
    public bool jumpOn;
    [SerializeField] private float jumpForce;
    [SerializeField] private float descendForce;

    
    void Update()
    {
   
        
        

        if (Input.GetButtonDown("Jump") && jumpOn)
        {
            velocity.y += jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            velocity.y -= descendForce;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        
        

        controller.Move(velocity * Time.deltaTime);
    }
}
