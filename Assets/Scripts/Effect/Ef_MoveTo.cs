using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_MoveTo : MonoBehaviour
{
    private GameObject goldCollect;
    private void Start()
    {
        goldCollect = GameObject.Find("GoldCollect");

    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goldCollect.transform.position,20*Time.deltaTime);
    }
}
