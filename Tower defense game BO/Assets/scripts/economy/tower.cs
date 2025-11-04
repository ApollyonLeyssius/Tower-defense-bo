using UnityEngine;
using System;

[Serializable]
public class tower
{
 public string name;
    public int cost;
    public GameObject prefab;

    public tower(string _name, int _cost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
