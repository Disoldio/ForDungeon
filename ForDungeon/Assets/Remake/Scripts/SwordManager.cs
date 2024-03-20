using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> swords;

    [SerializeField]
    private GameObject defaultSword;

    public GameObject GetSwordByHashCode(int hashCode)
    {
        return swords.Find(sword => sword.GetHashCode() == hashCode);
    }

    public GameObject GetDefaultSword()
    {
        return defaultSword;
    }

    public void SaveSword(GameObject sword)
    {
        PlayerPrefs.SetInt("swordHashCode", sword.GetHashCode());
        PlayerPrefs.Save();
    }
}
