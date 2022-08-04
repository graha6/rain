using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainCtrl : MonoBehaviour
{

    private float time;　        //rainの出現タイム

    public GameObject rain, rain2;

    private float x, xx;

    public float Range_x;
    public float Range_x2;


    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //前フレームから加算していく
        time += Time.deltaTime;
        //ランダム生成範囲
        x = Random.Range(Range_x, Range_x2);

        //1秒置きに呼ばれる
        if (time > 1)
        {
            Instantiate(rain, new Vector2(x, 490), transform.rotation);

            time = 0f;      //経過時間リセット
        }

        ////上記に並べると同じ位置に生成されるので、も一個作った       
        time += Time.deltaTime;
        xx = Random.Range(Range_x, Range_x2);

        if (time > 1)
        {

            Instantiate(rain2, new Vector2(xx, 490), transform.rotation);

            time = 0f;
        }
    }
}
