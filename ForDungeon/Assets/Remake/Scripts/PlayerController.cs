using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remake
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float sensitivity = 1;

        [SerializeField]
        private float movementSpeed = 1;

        [SerializeField]
        private float runningSpeed = 2;

        [SerializeField]
        private float rotationSpeed = 1;

        [SerializeField]
        private Vector3 cameraOffset = Vector3.zero;

        [SerializeField]
        private float cameraToObstacleDistance = 5;

        [SerializeField]
        private float cameraFromObstacleDistance = 2;

        private Camera _camera;
        private Transform _model;
        private Rigidbody _rigidbody;
        private Vector3 _defaultCameraPos;
        private Vector3 _lookDirection = Vector3.zero;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _rigidbody = GetComponent<Rigidbody>();
            _camera = GetComponentInChildren<Camera>();
            _defaultCameraPos = _camera.transform.localPosition;
            _model = transform.Find("Model");
        }

        private void Update()
        {
            bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
            bool movesDiagonal = Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0;

            float currentMovementSpeed = Input.GetAxisRaw("Fire3") > 0 ? runningSpeed : movementSpeed;
            currentMovementSpeed = movesDiagonal ? currentMovementSpeed / 1.5f : currentMovementSpeed;

            _rigidbody.velocity = 
                (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")) * currentMovementSpeed;

            if (isMoving) {
                if (_camera.transform.localRotation != new Quaternion(0, 0, 0, 1)) {
                    transform.rotation = _camera.transform.rotation;
                }

                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0));
                _camera.transform.localRotation = new Quaternion(0, 0, 0, 1);
                _camera.transform.localPosition = _defaultCameraPos;
                _lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                Quaternion lookRotation = Quaternion.LookRotation(_lookDirection);
                _model.localRotation = Quaternion.Slerp(
                    _model.localRotation,
                    lookRotation,
                    Time.deltaTime * rotationSpeed);
            }
            else {
                _camera.transform.RotateAround(
                    transform.position, 
                    Vector3.up, 
                    Input.GetAxis("Mouse X") * sensitivity);
            }

            PlaceCameraAtRay();
            DebugCameraRay();

        }
        private void PlaceCameraAtRay()
        {
            Ray ray = new Ray(transform.position + cameraOffset, -_camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, cameraToObstacleDistance))
            {
                _camera.transform.position = hit.point + _camera.transform.forward * cameraFromObstacleDistance;
            }
        }
        private void DebugCameraRay()
        {
            Debug.DrawRay(transform.position + cameraOffset, -_camera.transform.forward * cameraToObstacleDistance, Color.green);
        }
    }
}