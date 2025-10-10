using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpdate : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private TMPro.TMP_Text moneytext;
    // Start is called before the first frame update
    void Start()
    {
        money = 100;
        projectile.OnEnemyHit += () => money += 100;
    }

    // Update is called once per frame
    void Update()
    {
       moneytext.text = "Money: " + money;
    }
}
