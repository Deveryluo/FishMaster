using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public RectTransform UGICanvas;
    public Camera MainCamera;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(UGICanvas,new Vector2(Input.mousePosition.x,Input.mousePosition.y),MainCamera,out mousePos);
        float z;
        if (mousePos.x > transform.position.x)
        {
            z = -Vector3.Angle(Vector3.up, mousePos - transform.position);
        }
        else
        {
            z = Vector3.Angle(Vector3.up, mousePos - transform.position);
        }
        transform.localRotation = Quaternion.Euler(0, 0, z);
    }
}
