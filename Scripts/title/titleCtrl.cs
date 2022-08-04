using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleCtrl : MonoBehaviour
{
    public GameObject chara, chara1;     //butler,lady+butler                          
    public float speed;                  // 移動速度

    private GameObject charaObj;          // キャラクタ制御用
    private GameObject charaObj1;         // キャラクタ制御用
    private float wTime;                 // 時間計算用

    private int state;                   // 0:wait(2s) & butler移動準備
                                         // 1:butler移動
                                         // 2:wait(20s) & lady+butler移動準備
                                         // 3:lady+butler移動
    public GameObject titlename;
    private int title;

    // Start is called before the first frame update
    void Start()
    {
        charaObj = Instantiate(chara, new Vector2(-813.2f, -112.1f), transform.rotation);    // オブジェクト生成
        charaObj.SetActive(false);                       // 表示OFF
        charaObj1 = Instantiate(chara1, new Vector2(800.0f, -163.5f), transform.rotation);   // オブジェクト生成
        charaObj1.SetActive(false);                      // 表示OFF
        wTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;

        ////無限ループ
        switch (state)
        {
            case 0:                                     // wait(2s) & butler移動準備
                wTime += Time.deltaTime;                // 経過時間計算
                if (wTime > 4.0f)                       // 待ち時間チェック
                {
                    state = 1;                          // 次ステータスへ遷移
                    wTime = 0.0f;                       // 経過時間クリア
                    charaObj.SetActive(true);            // 表示ON
                }
                break;
            case 1:                                     // butler移動
                pos = charaObj.transform.position;       // Position取得
                pos.x = pos.x + speed;                  // 位置計算
                if (pos.x > 800.0f)                     // 終端チェック
                {
                    charaObj.SetActive(false);           // 表示OFF
                    pos.x = -813.2f;                    // 初期位置に戻る
                    state = 2;                          // 次ステータスへ遷移
                }
                charaObj.transform.position = pos;       // Position設定
                break;
            case 2:                                     // wait(20s) & lady+butler移動準備 
                wTime += Time.deltaTime;                // 経過時間計算
                if (wTime > 10.0f)                      // 待ち時間チェック
                {
                    state = 3;                          // 次ステータスへ遷移
                    wTime = 0.0f;                       // 経過時間クリア
                    charaObj1.SetActive(true);           // 表示ON
                }
                break;
            case 3:                                     // lady+butler移動
                pos = charaObj1.transform.position;      // Position取得
                pos.x = pos.x - speed;                  // 位置計算
                if (pos.x < -813.2f)                    // 終端チェック
                {
                    charaObj1.SetActive(false);          // 表示OFF
                    pos.x = 800.0f;                     // 初期位置に戻る
                    state = 0;                          // 始めに返る
                }
                charaObj1.transform.position = pos;      // Position設定
                break;
        }
        switch (title)
        {
            case 0:
                pos = titlename.transform.position;
                pos.y = pos.y - 0.5f;
                if (pos.y < -3.0f)
                {
                    title = 1;
                }
                titlename.transform.position = pos;
                break;
            case 1:
                pos = titlename.transform.position;
                pos.y = pos.y + 0.5f;
                if (pos.y > 3.0f)
                {
                    title = 0;
                }
                titlename.transform.position = pos;
                break;
        }
    }
}