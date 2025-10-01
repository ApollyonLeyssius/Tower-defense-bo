using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootInterval = 1;
    float nearestDistance = 100;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0) 
        {
            return;
        }
        Transform firepoint = targets[0].transform;
        Vector3 dir = firepoint.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        nearestDistance = 100;
        for (int i = 0; i < targets.Length; i++) 
        {
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if (distance < nearestDistance) 
            {
                nearestDistance = distance;
                firepoint = targets[i].transform;
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
            if (targets.Length > 0)
            {
                GameObject projectileGameObject = Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
                projectile projectile = projectileGameObject.GetComponent<projectile>();
                projectile.target = targets[0].transform;
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
