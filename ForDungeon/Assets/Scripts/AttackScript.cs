using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    int attackId = -1;
    [SerializeField] Animator animator;
    void Start()
    {
        /*animator = GetComponent<Animator>();*/
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            if (attackId == -1)
            {
                attackId = Random.Range(0, 2);
            }
            animator.SetBool("Attack", true);
        }
        else if (Input.GetButtonUp("Fire1")) 
        {
            animator.SetBool("Attack", false);
            attackId = -1;
        }
        animator.SetInteger("AttackId", attackId);
    }
}
