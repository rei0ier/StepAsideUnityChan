using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //carPrefab
    public GameObject carPrefab;

    //CoinPrefab
    public GameObject coinPrefab;

    //cornPrefab
    public GameObject conePrefab;

    //カメラの位置を参照する
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの位置をビューポート座標に変換
        Vector3 viewportPosition = MainCamera.WorldToViewportPoint(transform.position);

        //オブジェクトの位置がカメラのz軸方向0以下になった時、オブジェクトを破棄
        if (viewportPosition.z < 0)
        {
            Destroy(gameObject);
        }

    }
}
