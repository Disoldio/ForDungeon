using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;
    void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0) 
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            if (GetComponent<EnemyMove>())
            {
                GetComponent<EnemyMove>().enabled = false;
            }
            if (GetComponent<SkeletMove>())
            {
                GetComponent<SkeletMove>().enabled = false;
            }
            
            
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().Sleep();
            StartCoroutine(WaitToDeath());
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    public IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
