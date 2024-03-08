using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] Collider collider;
    public int damageCount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collider.enabled = true;
            StartCoroutine(FindObjectOfType<PlayerManager>().Damage(damageCount));
            print("aboba");
            
            // Выключать коллайдер который дамажит
        }
        
    }

}
