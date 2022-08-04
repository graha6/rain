using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    Camera cam;

    public float minus;     //元のサイズから引く値
    public float plus;      //足す値

    public float speed;
    float wTime;

    bool isFollow, isStop;      //追従中であるか
                                //stop中であるか
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();

        //butlerフォーカス+追従
        transform.position = new Vector3(498, -97, -10);
        cam.orthographicSize = cam.orthographicSize - minus;

        wTime = 0.0f;

        isFollow = true;
        isStop = true;
    }

    public void Follow()
    {
        pos = this.transform.position;
        if (isFollow)
        {
            pos.x = pos.x - speed;

            //早送り
            if (pos.x < 400 && pos.x > -385)
            {
                speed = 4.0f;
            }
            //ゆっくりに
            if (pos.x < -385 && pos.x > -495)
            {
                speed = 1.0f;
            }
            //stop
            if (pos.x < -495)
            {
                pos.x = -495.0f;
            }
            this.transform.position = pos;
        }
    }

    public void Focus()
    {
        isFollow = false;

        pos = this.transform.position;
        pos.x = pos.x + speed;
        
        //2キャラを映す
        if (pos.x > -370 & isStop)
        {
            pos.x = -370;
        }

        wTime += Time.deltaTime;
        //2キャラを追従
        if (wTime > 8.0f)
        {
            isStop = false;
        }
        if (wTime > 10.5f)
        {
            if (pos.x < 0 || pos.y < 0)
            {
                pos.y = pos.y + speed;
                speed = 0.8f;
            }
        }

        this.transform.position = pos;
    }


    public void Zoomout()
    {
        if (cam.orthographicSize < 384)
        {
            cam.orthographicSize = cam.orthographicSize + plus;
        }
    }

}