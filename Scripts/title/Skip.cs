using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    [SerializeField]
    private string load_scenename;//ÉVÅ[ÉìñºéwíË


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.M))
            {
                SceneManager.LoadScene(load_scenename);
            }
        }
    }
}
