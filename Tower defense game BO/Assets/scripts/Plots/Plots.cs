using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plots : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject Towers;
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
        if (Towers != null) return;

        GameObject TowersToBuild = buildManager.main.GetTowerSel();
        Towers = Instantiate(TowersToBuild, transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
