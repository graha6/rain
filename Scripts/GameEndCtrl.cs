using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndCtrl : MonoBehaviour
{
    public Image messeage, messeage1;
    public float speed;

    public int scene;                    //0:クリアシーン
                                         //1:クリアシーン続き
                                         //2:ゲームオーバーシーン

    // Start is called before the first frame update
    void Start()
    {
        //messeage.transform.localScale = new Vector3(1, 0.15f, 1);
        //messeage1.transform.position = new Vector2(0, 450f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;

        switch (scene)
        {
            case 0:
                pos = messeage.transform.localScale;
                pos.y = pos.y + speed;
                if (pos.y > 1.6f)
                {
                    scene = 1;
                }
                messeage.transform.localScale = pos;
                break;

            case 1:
                pos = messeage.transform.localScale;
                pos.y = pos.y - speed;
                if (pos.y < 1f)
                {
                    pos.y = 1f;
                }
                messeage.transform.localScale = pos;
                break;
            case 2:
                pos = messeage1.transform.position;
                pos.y = pos.y - speed;
                if (pos.y < 0)
                {
                    pos.y = 0f;
                }
                messeage1.transform.position = pos;
                Invoke("Rota", 3f);
                break;

        }
    }

    void Rota()
    {
        messeage1.transform.eulerAngles = new Vector3(0, 0, -5f);
    }
}
