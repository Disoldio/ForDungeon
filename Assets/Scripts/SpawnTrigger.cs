using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPosition;
    [SerializeField] GameObject skeletPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerMove>())
        {
            return;
        }
        for(int i = 0; i < spawnPosition.Count; i++)
        {
            
            GameObject currentSkelet = Instantiate(skeletPrefab);
            currentSkelet.transform.position = spawnPosition[i].position;
            currentSkelet.transform.rotation = spawnPosition[i].rotation;
            print(currentSkelet.transform.position);
        }
        gameObject.SetActive(false);
    }
}
