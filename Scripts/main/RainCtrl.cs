using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCtrl : MonoBehaviour
{
    public int phase;                      //0:通常降水量
                                           //1:降水量増加
                                           //2:降水斜線

    float time;

    public GameObject rain, rain1, rain2, rain3;

    private float x, x1, x2, x3;

    public float Range_x, Range_x1, Range_x2, Range_x3;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                //前フレームから加算していく
                time += Time.deltaTime;
                //ランダム生成範囲
                x = Random.Range(Range_x, Range_x1);

                //1秒置きに呼ばれる
                if (time > 1.0f)
                {
                    Instantiate(rain, new Vector2(x, 490), transform.rotation);

                    time = 0f;      //経過時間リセット
                }

                ////上記に並べると同じ位置に生成されるので、も一個作った       
                time += Time.deltaTime;
                x1 = Random.Range(Range_x, Range_x1);

                if (time > 1.0f)
                {

                    Instantiate(rain1, new Vector2(x1, 490), transform.rotation);

                    time = 0f;
                }
                break;
            case 1:
                time = time + Time.deltaTime;
                x = Random.Range(Range_x, Range_x1);

                if (time > 0.5f)
                {
                    Instantiate(rain, new Vector2(x, 490), transform.rotation);

                    time = 0f;
                }

                time = time + Time.deltaTime;
                x1 = Random.Range(Range_x, Range_x1);

                if (time > 0.5f)
                {

                    Instantiate(rain1, new Vector2(x1, 490), transform.rotation);

                    time = 0f;
                }
                break;
            case 2:
                time = time + Time.deltaTime;
                x2 = Random.Range(Range_x2, Range_x3);

                if (time > 0.5f)
                {
                    Instantiate(rain2, new Vector2(x2, 490), transform.rotation);

                    time = 0f;
                }

                time = time + Time.deltaTime;
                x3 = Random.Range(Range_x2, Range_x3);

                if (time > 0.5f)
                {

                    Instantiate(rain3, new Vector2(x3, 370), transform.rotation);

                    time = 0f;
                }
                break;
        }
    }
}
