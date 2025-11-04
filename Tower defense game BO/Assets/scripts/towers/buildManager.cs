using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour
{

    public static buildManager main;
    //[SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private tower[] towers;

    private int SelectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public tower GetTowerSel()
    {
        return towers[SelectedTower];
    }

    public void SetTowerSel(int _SelectedTower)
    {
        SelectedTower = _SelectedTower;
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
