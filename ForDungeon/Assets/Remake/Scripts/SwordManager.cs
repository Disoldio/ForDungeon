using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> swords;

    public GameObject GetSwordById(int id)
    {
        return swords[id];
    }
}
