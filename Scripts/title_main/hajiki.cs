using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hajiki : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Show");
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }

}
