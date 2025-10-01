using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPleacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject[] towerSlots;
    [SerializeField] private int towerSlotIndex;
    // Start is called before the first frame update

    void Start()
    {
 
    }
    private void PlaceTower(int slotIndex)
    {
        Instantiate(towerPrefab, towerSlots[slotIndex].transform.position, Quaternion.identity, towerSlots[slotIndex].transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (towerSlotIndex != -1)
            { PlaceTower(towerSlotIndex); }
            if (hit.collider != null)
            {
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.gameObject);
                if (towerSlotIndex != -1)
                {
                    PlaceTower(towerSlotIndex);
                }

                foreach (GameObject slot in towerSlots)
                {
                    if (hit.collider.gameObject == slot && slot.transform.childCount == 0)
                    {
                        Instantiate(towerPrefab, slot.transform.position, Quaternion.identity, slot.transform);
                    }
                }
            }


        }



    }
}
