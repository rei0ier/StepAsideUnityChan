using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    //カメラの位置を参照する
    public Camera MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //各Tagがついたオブジェクトを取得
        GameObject[] car = GameObject.FindGameObjectsWithTag("CarTag");
        GameObject[] coin = GameObject.FindGameObjectsWithTag("CoinTag");
        GameObject[] cone = GameObject.FindGameObjectsWithTag("TrafficConeTag");

        // 各オブジェクトの位置をチェックして画面下から出たら破棄
        CheckAndDestroyItems(car);
        CheckAndDestroyItems(coin);
        CheckAndDestroyItems(cone);

    }
    private void CheckAndDestroyItems(GameObject[] items)
    {
        foreach (var item in items)
        {
            // アイテムの位置をビューポート座標に変換
            Vector3 viewportPosition = MainCamera.WorldToViewportPoint(item.transform.position);

            // 画面下から出たら破棄
            if (viewportPosition.y < 0)
            {
                Destroy(item);
            }
        }
    }
}
