using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    Camera cam;

    public float minus;     //���̃T�C�Y��������l
    public float plus;      //�����l

    public float speed;
    float wTime;

    bool isFollow, isStop;      //�Ǐ]���ł��邩
                                //stop���ł��邩
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();

        //butler�t�H�[�J�X+�Ǐ]
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

            //������
            if (pos.x < 400 && pos.x > -385)
            {
                speed = 4.0f;
            }
            //��������
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
        
        //2�L�������f��
        if (pos.x > -370 & isStop)
        {
            pos.x = -370;
        }

        wTime += Time.deltaTime;
        //2�L������Ǐ]
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