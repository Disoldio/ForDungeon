using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public bool isCheel = false;
    public bool isLevel = false;
    [SerializeField] GameObject obj;

    private void Start()
    {
        Cursor.visible = !isLevel;
    }
    public void IsThisCheel(bool newChil)
    {
        isCheel = newChil;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeChill();
        }
    }

    public void ChangeChill()
    {
        isCheel = !isCheel;
        obj.SetActive(isCheel);
        Time.timeScale = isCheel ? 0 : 1;
        Cursor.visible = isCheel;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void TimeSetScale()
    {
        Time.timeScale = 1;
    }
}
