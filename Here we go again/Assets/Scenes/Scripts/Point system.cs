using UnityEngine;

public class Pointsystem : MonoBehaviour
{
    public int points = 0;
    public string pointsText;
   


    void Start()
    {   // This code just make sure that points is zero at the start of the game
        PlayerPrefs.SetInt("points", 0);
    }

    public void increment(int i)
    {
        points += i;
      
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
