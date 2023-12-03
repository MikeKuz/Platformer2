using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetCart : MonoBehaviour
{
    public GameObject cart;
    public GameObject resetZone;
    public Vector2 startPosition;
    public Transform respawnPoint;
    
    private void Awake()
    {
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RemoveCart();
        }
    }

    private void RemoveCart()
    {
        Destroy(GameObject.Find("Cart(Clone)"));
        Instantiate(cart, respawnPoint);
    }
}
