using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 2;
    private bool isDead = false;
    public static event Action OnDeath;


    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0 && !isDead)
        {
            EnemeySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
            OnDeath?.Invoke();
            isDead = true;
        }
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
