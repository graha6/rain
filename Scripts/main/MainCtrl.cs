using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCtrl : MonoBehaviour
{

    public GameObject cloud,
                      flash,
                      bg,
                      mob, mob1,
                      car, car1;

    public float speed;              //cloud速度

    Image imgflash;                  //flashオブジェクトImage

    Image imgbg;                     //bgオブジェクトSprite

    float wTime;
    bool isStart = false;            //Update処理が始まるか
    bool isMob,
         isCar;                      //mobの生成中であるか

    public RainCtrl rainCtrl;        //RainCtrlスクリプト内の変数取得


    public GameObject lady;

    public GameObject fo;            //あらゆるプレイ終了時のフェードアウト
    float alpha;

    [SerializeField]
    private string load_scenename;//シーン名指定


    // Start is called before the first frame update
    void Start()
    {
        cloud.transform.position = new Vector2(-651.3f, 340.0f);
        imgflash = flash.GetComponent<Image>();
        imgflash.color = Color.clear;   //false状態

        imgbg = bg.GetComponent<Image>();

        wTime = 0.0f;
        isMob = false;
        isCar = false;

        lady.GetComponent<Lady>().enabled = false;

        Invoke("Standby", 8.6f);         //スタートプレイ(countstartに順列)
    }

    void Standby()
    {
        isStart = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isStart) { return; }

        lady.GetComponent<Lady>().enabled = true;

        Vector2 pos;
        pos = cloud.transform.position;
        pos.x = pos.x + speed;

        ////フェーズ2突入
        if (pos.x < -185.5f && pos.x > -186)
        {
            //雷を表現(flash)
            imgflash.color = new Color(185, 185, 185, 1);

            //天候悪化を表現(暗くなる)
            imgbg.color = new Color(0.7f, 0.7f, 0.7f, 1);

            rainCtrl.phase = 1;
        }
        if (pos.x < 100.5f && pos.x > 100.0f)
        {
            rainCtrl.phase = 2;
        }

        ////フェーズ3突入
        if (pos.x < 205.5f && pos.x > 205)
        {

            imgflash.color = new Color(1, 1, 1, 1);

            imgbg.color = new Color(0.6f, 0.6f, 0.6f, 1);
        }
        if (pos.x < 363.5f && pos.x > 363.0f)
        {
            rainCtrl.phase = 1;
        }

        else
        {
            imgflash.color = Color.Lerp(imgflash.color, Color.clear, Time.deltaTime);
        }

        //ゲームセット!
        if (pos.x > 651.0f)
        {
            pos.x = 651.0f;
            lady.GetComponent<CapsuleCollider2D>().enabled = false;   //これ以上作動しないように判定を非アクティブ化

            fo.GetComponent<FadeIn>().enabled = false;
            alpha += 3f * Time.deltaTime;
            fo.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            Invoke("Toscene", 2);
        }

        ////トラップのON,OFF
        if (pos.x > 46.0f)
        {
            isMob = true;
        }

        if (pos.x > 205.0f)
        {
            isMob = false;
        }
        if (pos.x > 303.0f)
        {
            isCar = true;
        }

        if (pos.x > 444.0f)
        {
            isCar = false;
        }

        cloud.transform.position = pos;

        //フェーズ2のトラップ
        if (isMob)
        {
            wTime += Time.deltaTime;
            if (wTime > 1)
            {
                Instantiate(mob, new Vector2(-813.2f, -158.0f), transform.rotation);
                wTime = 0.0f;
            }
            wTime += Time.deltaTime;
            if (wTime > 1)
            {
                Instantiate(mob1, new Vector2(800.0f, -158.0f), transform.rotation);
                wTime = 0.0f;
            }
        }
        if (isCar)
        {
            wTime += Time.deltaTime;
            if (wTime > 4.5f)
            {
                Instantiate(car, new Vector2(-973.0f, -194.0f), transform.rotation);
                wTime = 0.0f;
            }
            wTime += Time.deltaTime;
            if (wTime > 4.5f)
            {
                Instantiate(car1, new Vector2(978.0f, -194.0f), transform.rotation);
                wTime = 0.0f;
            }
        }

    }
    void Toscene()
    {
        SceneManager.LoadScene(load_scenename);

    }
}