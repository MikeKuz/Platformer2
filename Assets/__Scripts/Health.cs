using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealh =100;
    public float currentHealth;
    public bool isAlive=true;
    public GameObject go;
    public MenuManager menuManager;

    public event Action<float> HealthChanged;


    private void Awake()
    {
        currentHealth = maxHealh;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;
        float currentHealthAsPercantage = currentHealth / maxHealh;
        HealthChanged?.Invoke(currentHealthAsPercantage);
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {

            isAlive = true;
            Animator animator = GetComponent<Animator>();

            if (gameObject.CompareTag("Enemy"))
            {
                animator.Play("SlimeHurt");
            }
        }

        else
        {
            Dead();
            isAlive = false;
        }
    }


    public void Dead()
    {
        if(gameObject.CompareTag("Enemy"))
        {
            GetComponent<Animator>().Play("SlimeDeath");
            Transform position = GetComponent<Transform>();
            Vector3 pos = position.position;
            Quaternion quat = position.rotation;
            Instantiate(go, pos, quat);
            Destroy(gameObject);
        }

        if(gameObject.CompareTag("Player"))
        {
            menuManager.ShowLosePanel();
        }
    }

    
}
