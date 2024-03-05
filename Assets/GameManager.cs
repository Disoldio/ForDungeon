using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    bool isStarted;
    bool isChil;
    public void startGame()
    {
        Time.timeScale= 1;
        isStarted = true;
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isStarted){
            isChil = !isChil;
            Time.timeScale = isChil ? 0 : 1;
            panel.SetActive(isChil);

        }
        
    }
    public void changeChil(bool newChil)
    {
        isChil = newChil;
    }
}
