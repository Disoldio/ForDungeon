using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float sens;
    [SerializeField] float speed;
    [SerializeField] float shiftSpeed;
    [SerializeField] Animator animator;
    [SerializeField] CharacterController controller;
    [SerializeField] float Gravity;
    [SerializeField] GameMenu gameMenu;

    float currentSpeed;
    float bodyY = 0;
    float cameraX = 0;
    Vector3 Velocity;

    private void Update()
    {
        if (!gameMenu.isCheel)
        {
            cameraX -= Input.GetAxis("Mouse Y") * sens;
            cameraX = Mathf.Clamp(cameraX, -40, 40);
            camera.transform.localRotation = Quaternion.Euler(cameraX, 0, 0);

            bodyY += Input.GetAxis("Mouse X") * sens;
            transform.rotation = Quaternion.Euler(0, bodyY, 0);
            currentSpeed = speed + (Input.GetAxis("Fire3") * shiftSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (!gameMenu.isCheel)
        {
            if (controller.isGrounded)
                {
                    Velocity.y = -1;
                }
                else
                {
                    Velocity.y -= Gravity * -2f;
                }

            Vector3 directionVector = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

            animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
            controller.Move(Vector3.ClampMagnitude(directionVector, 1) * currentSpeed / 20);
            controller.Move(Velocity);

            //animator.SetFloat("Speed", currentSpeed * (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
            

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BodyPidor"))
            {
                animator.speed = (currentSpeed * (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))) * 4;
            }
            else
            {
                animator.speed = 1;
            }
        
        }
    }
}
