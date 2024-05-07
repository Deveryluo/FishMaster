using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;

public class FishMaker : MonoBehaviour
{
    public Transform fishHolder;
    public Transform[] genPositions;
    public GameObject[] fishPrefabs;

    public float waveGenWaitTime =0.3f;
    public float fishGenWaitTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFishes", 0, waveGenWaitTime);
    }  

    void MakeFishes()
    {
        int genPosIndex = Random.Range(0, genPositions.Length);
        int fishPreIndex = Random.Range(0, fishPrefabs.Length);
        int maxNum = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxNum;
        int maxSpeed = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxSpeed;
        int num = Random.Range((maxNum / 2) + 1, maxNum);
        int speed = Random.Range(maxSpeed / 2, maxSpeed);
        int moveType =Random.Range(0, 2);  //0:直走， 1:转弯
        int angOffset;                      //仅直走生效，直走的倾斜角
        int angSpeed;                        //仅转弯生效，转弯的角速度
        if(moveType==0)
        {
            //TODO  直走鱼群的生成
            angOffset = Random.Range(-22,22);
            StartCoroutine(GenStraightFish(genPosIndex, fishPreIndex, num, speed, angOffset));
        }
        else
        {
            //TODO  转弯鱼群的生成
            if (Random.Range(0, 2) == 0)  //是否取负的角速度
            {
                angSpeed = Random.Range(-15, -9);
            }
            else
            {
                angSpeed = Random.Range(9,15); 
            }
            StartCoroutine(GenTurnFish(genPosIndex, fishPreIndex, num, speed, angSpeed));
        }
    }
    IEnumerator GenTurnFish(int genPosIndex, int fishPreIndex, int num, int speed, int angSpeed)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish=Instantiate(fishPrefabs[fishPreIndex]);
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            //保证生成的鱼方向和当前位置的x轴一致
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.AddComponent<Ef_AutoRotate>().speed = angSpeed;
            //每条鱼生成时，图层加1级
            fish.GetComponent<SpriteRenderer>().sortingOrder+=i;
            fish.AddComponent<Ef_AutoMove>().speed=speed;
            int count = GetComponent<GameController>().count;
            if (count != 0)
            {
                fish.AddComponent<Ef_AutoMove>().speed = speed+1;
            }
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }
    IEnumerator GenStraightFish(int genPosIndex, int fishPreIndex, int num, int speed, int angOffset)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(fishPrefabs[fishPreIndex]);
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            //保证生成的鱼方向和当前位置的x轴一致
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angOffset);
            //每条鱼生成时，图层加1级
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }
}
