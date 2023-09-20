using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //unityちゃん
    private GameObject unitychan;

    //carPrefab
    public GameObject carPrefab;

    //CoinPrefab
    public GameObject coinPrefab;

    //cornPrefab
    public GameObject conePrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //unityちゃんのオブジェクト取得
        unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //unityちゃんの位置
        float unitychanPosZ = unitychan.transform.position.z;

        if(unitychanPosZ + 40 > startPos && unitychanPosZ < 310)
        {
            GenerateItems(startPos, startPos + 15);
            startPos += 15;
        }
    }
    //アイテム生成
    private void GenerateItems(int startPos,int endPos)
    {
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < endPos; i += 15)

        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムをおくz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);

                    }
                }
            }
        }
    }
}