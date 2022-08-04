using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Messeage : MonoBehaviour
{
    public float speed;
    float alpha = 0;        //透明度値

    // Start is called before the first frame update
    void Start()
    {
        //始めは透明にさせる
        GetComponent<CanvasGroup>().alpha = 0;
    }

    //徐々に表示
    public void FadeIn()
    {
        alpha += speed * Time.deltaTime;
        GetComponent<CanvasGroup>().alpha = alpha;

    }
}
