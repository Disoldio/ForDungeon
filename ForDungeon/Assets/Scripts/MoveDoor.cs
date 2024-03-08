using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool IsLockt;
    [SerializeField] GameObject item;
    [SerializeField] private GameObject KeyLock;
    public GameObject Item {
        get 
        { 
            return item; 
        } 
    }
    private bool isOpened;

    public void ToggleOpen()
    {
        if(IsLockt)
        {
            return;
        }
        isOpened = !isOpened;
        animator.SetBool("IsOpened", isOpened);
    }

    public bool IsOpen()
    {
        return isOpened;
    }

    public bool isLockt()
    {
        return IsLockt;
    }

    public IEnumerator UnLock()
    {
        KeyLock.GetComponent<Animator>().SetBool("UnLock", true);
        yield return new WaitForSeconds(2.1f);
        KeyLock.SetActive(false);
        IsLockt = false;
    }
}
