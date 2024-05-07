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
        int moveType =Random.Range(0, 2);  //0:ֱ�ߣ� 1:ת��
        int angOffset;                      //��ֱ����Ч��ֱ�ߵ���б��
        int angSpeed;                        //��ת����Ч��ת��Ľ��ٶ�
        if(moveType==0)
        {
            //TODO  ֱ����Ⱥ������
            angOffset = Random.Range(-22,22);
            StartCoroutine(GenStraightFish(genPosIndex, fishPreIndex, num, speed, angOffset));
        }
        else
        {
            //TODO  ת����Ⱥ������
            if (Random.Range(0, 2) == 0)  //�Ƿ�ȡ���Ľ��ٶ�
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
            //��֤���ɵ��㷽��͵�ǰλ�õ�x��һ��
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.AddComponent<Ef_AutoRotate>().speed = angSpeed;
            //ÿ��������ʱ��ͼ���1��
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
            //��֤���ɵ��㷽��͵�ǰλ�õ�x��һ��
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angOffset);
            //ÿ��������ʱ��ͼ���1��
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }
}
