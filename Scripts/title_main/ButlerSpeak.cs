using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlerSpeak : MonoBehaviour
{
    private void Awake()
    {
        //�V�[���𒴂��Ă����̂܂܈����p��
        DontDestroyOnLoad(this.gameObject);
    }
}
