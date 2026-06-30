using UnityEngine;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public int health;
    public int MaxHealth = 35;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
