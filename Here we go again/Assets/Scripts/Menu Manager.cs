using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        Menu();
    }

    void Menu()
    {
        SceneManager.LoadScene(1);
    }

   
    void Update()
    {
        
    }


}
