using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    [SerializeField] private GameObject enemyspawner;
    [SerializeField] private GameObject startbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startgame()
    { 
      enemyspawner.SetActive(true);
      startbutton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
