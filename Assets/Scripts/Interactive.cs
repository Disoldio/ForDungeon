using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float maxDistanceRay;
    public List<GameObject> inventory;
    [SerializeField] private TMP_Text text;

private void Ray()
    {
        ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void DrawRay()
    {
        if(Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
        }

        if(hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
        }
    }

    private void Interact()
    {

        if (hit.transform != null && hit.transform.GetComponent<MoveDoor>())
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hit.transform.GetComponent<MoveDoor>().isLockt() && inventory.Contains(hit.transform.GetComponent<MoveDoor>().Item))
                {
                    StartCoroutine(hit.transform.GetComponent<MoveDoor>().UnLock());           
                }
                hit.transform.GetComponent<MoveDoor>().ToggleOpen();
            }

            if (hit.transform.GetComponent<MoveDoor>().isLockt())
            {
                text.text = "Door is lockt.\nNeed key";
            }
            else
            {
                text.text = "Press E to use door";
            }
        }
        
        if(hit.transform == null)
        {
            text.text = "";
        }

        if(hit.transform != null && hit.transform.CompareTag("Item"))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.magenta);
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.Add(hit.transform.gameObject);
                hit.transform.gameObject.SetActive(false);
            }
            text.text = "Press E to pick up item";
        }
        
    }
}
