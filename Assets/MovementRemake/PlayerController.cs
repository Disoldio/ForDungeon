using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewMovement
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float sensitivity = 1;

        [SerializeField]
        private float movementSpeed = 1;

        private Camera _camera;
        private Transform _model;
        private Rigidbody _rigidbody;
        private Vector3 _defaultCameraPos;
        private Vector3 lookDirection = Vector3.zero;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _rigidbody = GetComponent<Rigidbody>();
            _camera = GetComponentInChildren<Camera>();
            _defaultCameraPos = _camera.transform.localPosition;
            _model = transform.Find("Model");
        }

        void Update()
        {
            bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
            bool movesDiagonal = Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0;
            float currentMovementSpeed = movesDiagonal ? movementSpeed / 1.5f : movementSpeed;

            _rigidbody.velocity = 
                (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")) * currentMovementSpeed;

            if (isMoving) {
                if (_camera.transform.localRotation != new Quaternion(0, 0, 0, 1)) {
                    transform.rotation = _camera.transform.rotation;
                }

                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0));
                _camera.transform.localRotation = new Quaternion(0, 0, 0, 1);
                _camera.transform.localPosition = _defaultCameraPos;

                Vector3 nextPos = 
                    transform.forward * Input.GetAxisRaw("Vertical") +
                    transform.right * Input.GetAxisRaw("Horizontal") +
                    transform.position;

                // lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                // Quaternion lookRotation = Quaternion.LookRotation(lookDirection, transform.up);
                // _model.localRotation = Quaternion.LerpUnclamped(
                //     transform.rotation,
                //     lookRotation,
                //     1);

                _model.LookAt(nextPos, Vector3.up);

                print(nextPos);
            }
            else {
                _camera.transform.RotateAround(
                    transform.position, 
                    Vector3.up, 
                    Input.GetAxis("Mouse X") * sensitivity);
            }


        }
    }
}