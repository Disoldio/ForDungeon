using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEnemy : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float maxDistanceRay;

    private void Ray()
    {
        ray = new Ray(transform.position + transform.forward + new Vector3(0, 1.2f, 0), transform.forward);
    }

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void DrawRay()
    {
        if (Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
        }

        if (hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
        }
    }

    private void Interact()
    {
        if (hit.transform != null && hit.transform.GetComponent<MoveDoor>())
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
            if (!hit.transform.GetComponent<MoveDoor>().IsOpen())
            {
                hit.transform.GetComponent<MoveDoor>().ToggleOpen();
            }
        }
    }
}
