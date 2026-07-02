using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PacLife : MonoBehaviour
{

    void DoSceneReload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DoSceneReload();
        }
    }





}
