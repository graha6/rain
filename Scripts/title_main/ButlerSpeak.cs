using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlerSpeak : MonoBehaviour
{
    private void Awake()
    {
        //シーンを超えてもそのまま引き継ぐ
        DontDestroyOnLoad(this.gameObject);
    }
}
