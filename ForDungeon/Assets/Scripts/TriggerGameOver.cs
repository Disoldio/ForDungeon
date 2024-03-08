using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameMenu gameMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerMove>())
        {
            return;
        }
        Time.timeScale = 0;
        obj.SetActive(true);
        Cursor.visible = true;
    }
}
