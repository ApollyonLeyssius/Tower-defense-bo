using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpdate : MonoBehaviour
{
    public static MoneyUpdate main;
    [SerializeField] public int money;
    [SerializeField] private TMPro.TMP_Text moneytext;
    // Start is called before the first frame update

    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        money = 200;
        EnemyHealth.OnDeath += () => money += 20;
    }

    // Update is called once per frame
    void Update()
    {
       moneytext.text = "Money: " + money;
    }

    public void IncreaseAmount(int amount)
    {
        money += amount;
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= money) 
        {
            //spendmoen
            money -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
