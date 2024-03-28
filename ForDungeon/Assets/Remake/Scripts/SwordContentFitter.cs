using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwordContentFitter : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPanelPrefab;

    [SerializeField]
    private SwordManager swordManager;

    void Start()
    {
        foreach (Sword sword in swordManager.GetAll())
        {
            GameObject currentSwordPanel = Instantiate(swordPanelPrefab, transform);
            currentSwordPanel.GetComponent<SwordPanel>().Init(sword.GetId(), sword.GetName(), sword.GetStrength(), sword.GetAttackSpeed(), sword.GetMaxDistance());
        }
    }
}
