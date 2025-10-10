using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class projectile : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 10;
    public static event Action OnEnemyHit;
    private bool IsDestroyed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !IsDestroyed)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            IsDestroyed = true;
            OnEnemyHit?.Invoke();
            EnemeySpawner.onEnemyDestroy?.Invoke();
        }


    }
    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
            if (target == null)
            {
                Destroy(gameObject, 0f);
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }
}
