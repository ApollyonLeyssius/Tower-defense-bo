using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void startgame()
    { 
        SceneManager.LoadScene(1);
    }

    public void quitgame()
    { 
        Debug.Log("QUIT!");
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
