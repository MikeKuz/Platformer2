using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealh;
    private float currentHealth;
    private bool isAlive;

    private void Awake()
    {
        currentHealth = maxHealh;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth >0)
            isAlive = true;
        else isAlive = false;
    }
}
