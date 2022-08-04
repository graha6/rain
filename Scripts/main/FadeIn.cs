using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    public float speed;
    float alpha = 1;        //透明度値(0=true状態,1=false状態)

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {

        alpha += speed * Time.deltaTime;
        GetComponent<Image>().color = new Color(0, 0, 0, alpha);

    }

}

