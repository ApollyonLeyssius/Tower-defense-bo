using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Animator anim;

    private bool IsMenuOpen = true;


    private void OnGUI()
    {
        moneyText.text = "Money: " + MoneyUpdate.main.money;
    }

    public void ToggleMenu()
    {
        IsMenuOpen = !IsMenuOpen;
        anim.SetBool("MenuOpen", IsMenuOpen);
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
