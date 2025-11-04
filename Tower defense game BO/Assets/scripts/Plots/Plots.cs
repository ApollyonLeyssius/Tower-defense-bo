using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plots : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject Towersobj;
    public Tower Tower;
    private Color originalColor;

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = originalColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        if (Towersobj != null)
        { 
            Tower.OpenUpgradeUI();
            return;
        }

        tower towersToBuild = buildManager.main.GetTowerSel();

        if (towersToBuild.cost > MoneyUpdate.main.money)
        {
            Debug.Log("WHAT?! NO MONEY?!");
            return;
        }

        MoneyUpdate.main.SpendMoney(towersToBuild.cost);

        Towersobj = Instantiate(towersToBuild.prefab, transform.position, Quaternion.identity);
        Tower = Towersobj.GetComponent<Tower>();
    }

    public void SetSelected()
    {
    
    }
    // Start is called before the first frame update
    void Start()
    {
        originalColor = sr.color;
    }
}
