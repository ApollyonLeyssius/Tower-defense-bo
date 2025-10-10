using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{

    public void restartgame()
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void quitgame()
    { 
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void mainmenu()
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
