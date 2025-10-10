using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthPoints : MonoBehaviour
{
    [SerializeField] private int health = 40;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            health -= 2;
            Destroy(other.gameObject);
            EnemeySpawner.onEnemyDestroy?.Invoke();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        healthText.text = "Health: " + health.ToString();
    }
}
