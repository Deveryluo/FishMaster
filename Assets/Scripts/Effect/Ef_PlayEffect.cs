using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_PlayEffect : MonoBehaviour
{
    public GameObject[] effectprefabs;
    public void PlayEffect()
    {
        foreach (GameObject effectPrefab in effectprefabs)
        {
            GameObject eff=Instantiate(effectPrefab);
        }
    }
}
