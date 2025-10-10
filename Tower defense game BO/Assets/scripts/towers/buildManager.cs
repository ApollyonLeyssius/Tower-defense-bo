using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour
{

    public static buildManager main;
    [SerializeField] private GameObject[] towerPrefabs;

    private int SelectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetTowerSel()
    {
        return towerPrefabs[SelectedTower];
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
