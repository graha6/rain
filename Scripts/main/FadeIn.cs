using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    public float speed;
    float alpha = 1;        //ìßñæìxíl(0=trueèÛë‘,1=falseèÛë‘)

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

