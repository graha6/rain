using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Messeage : MonoBehaviour
{
    public float speed;
    float alpha = 0;        //�����x�l

    // Start is called before the first frame update
    void Start()
    {
        //�n�߂͓����ɂ�����
        GetComponent<CanvasGroup>().alpha = 0;
    }

    //���X�ɕ\��
    public void FadeIn()
    {
        alpha += speed * Time.deltaTime;
        GetComponent<CanvasGroup>().alpha = alpha;

    }
}
