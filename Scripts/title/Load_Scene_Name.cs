using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene_Name : MonoBehaviour
{
    [SerializeField]
    private string load_scenename;//ÉVÅ[ÉìñºéwíË

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(load_scenename);
        }
    }
}
