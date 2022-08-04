using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountStart : MonoBehaviour
{
    public TextMeshProUGUI warningtext = null;
    public TextMeshProUGUI counttext = null;

    float wTime;

    // Start is called before the first frame update
    void Start()
    {
        warningtext.GetComponent<Text>();
        counttext.GetComponent<Text>();
        wTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        wTime += Time.deltaTime;
        if (wTime > 2)
        {
            warningtext.text = "フラッシュ注意!\nFlash　warning!";
        }
        if (wTime > 4)
        {
            warningtext.color = Color.Lerp(warningtext.color, Color.clear, 0.09f);
            
            counttext.text = "3";
        }
        if (wTime > 5)
        {
            counttext.text = "2";
        }
        if (wTime > 6)
        {
            counttext.text = "1";
        }
        if (wTime > 7)
        {
            counttext.text = "start!";
            Big();

        }
        if (wTime > 8.2f)
        {
            warningtext.gameObject.SetActive(false);
            counttext.gameObject.SetActive(false);

        }
    }
    void Big()
    {
        if (counttext.fontSize < 122.0f)
        {
            counttext.fontSize += 0.8f;
        }
    }
}
