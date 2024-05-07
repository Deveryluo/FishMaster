using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishAttr : MonoBehaviour
{
    public int hp;
    public int expe; 
    public int gold;
    public int maxNum;
    public int maxSpeed;
    public GameObject diePrefab;
    public GameObject goldPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
    void TakeDamage(int value)
    {
        //TODO
        hp -= value;
        if (hp < 0)
        {
            GameController.Instance.gold += gold;
            GameController.Instance.exp += expe;
            GameObject die=Instantiate(diePrefab);
            die.transform.SetParent(gameObject.transform.parent, false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;
            GameObject goldGo = Instantiate(goldPrefab);
            goldGo.transform.SetParent(gameObject.transform.parent, false);
            goldGo.transform.position = transform.position;
            goldGo.transform.rotation = transform.rotation;
            Destroy(gameObject);
            Destroy(die,0.5f);
            if (gameObject.GetComponent<Ef_PlayEffect>() != null)
            {
                gameObject.GetComponent<Ef_PlayEffect>().PlayEffect();
            }
        }
    }
}

