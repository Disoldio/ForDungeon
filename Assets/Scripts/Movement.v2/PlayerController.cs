using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float speed = 2f;
    public float rotationSpeed = 10f;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3 (h, 0, v);
        if(direction.magnitude > Mathf.Abs(0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        
        animator.SetFloat("Speed", Vector3.ClampMagnitude(direction, 1).magnitude);
        rigidbody.velocity = Vector3.ClampMagnitude(direction, 1)  * speed;


    }
}
