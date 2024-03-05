using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;
    public GameObject redOverlay;

    [SerializeField] Text TextFPS;
    private float _FPS;

    void Start()
    {
        playerHealth = 100;
        gameOver = false;
    }

    void Update()
    {
        playerHealthText.text = "" + playerHealth;

        if(gameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }

        _FPS += (Time.deltaTime - _FPS) * 0.1f;
        float fps = 1.0f / _FPS;
        TextFPS.text = Mathf.Ceil(fps).ToString();

        if (fps < 20)
        {
            TextFPS.color = Color.red;
        }

        if (fps > 60)
        {
            TextFPS.color = Color.green;
        }

    }
    
    public IEnumerator Damage (int damageCount)
    {
        playerHealth -= damageCount;
        redOverlay.SetActive(true);

        if(playerHealth <= 0)
        {
            gameOver = true;
        }
        yield return new WaitForSeconds(0.5f);
        redOverlay.SetActive(false);
    }
}
