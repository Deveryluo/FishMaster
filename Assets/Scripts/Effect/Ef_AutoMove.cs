

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ef_AutoMove : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 dir = Vector3.right;
    // Start is called before the first frame update 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
