using Remake;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text swordLabel;
    [SerializeField]
    private TMP_Text strengthLabel;
    [SerializeField]
    private TMP_Text attackSpeedLabel;
    [SerializeField]
    private TMP_Text maxDistanceLabel;
    [SerializeField]
    private Button playButton;

    public void Init(int id, string name, float strength, float attackSpeed, float maxDistance)
    {
        swordLabel.text = $"Name: {name}";
        strengthLabel.text = $"Strenght: {strength}";
        attackSpeedLabel.text = $"Attack speed: {attackSpeed}";
        maxDistanceLabel.text = $"Max distance: {maxDistance}";

        playButton.onClick.AddListener(() =>
        {
            SwordManager.SaveSwordById(id);
            SceneLoader.LoadScene("Remake/Test");
        });
    }
}
