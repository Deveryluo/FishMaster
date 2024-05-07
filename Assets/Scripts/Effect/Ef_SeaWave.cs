using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_SeaWave : MonoBehaviour
{
    private Vector3 temp;
    private void Start()
    {
        temp = -transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, temp,7*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            Destroy(collision.gameObject);
        }
    }
}
