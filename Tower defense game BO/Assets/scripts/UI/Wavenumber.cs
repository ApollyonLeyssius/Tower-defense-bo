using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wavenumber : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI waveText;
    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        EnemeySpawner.Waveincreased += () => waveNumber++;
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + waveNumber;


    }
}
