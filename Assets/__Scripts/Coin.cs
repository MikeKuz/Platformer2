using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private string Tag = "Player";
    public event Action<int> CoinChanged;
    [SerializeField] private CoinCounter coinCounter;
    int i = 1;

    private void Awake()
    {
        int addCoin = 1;

        CoinChanged?.Invoke(addCoin);
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
        {
            coinCounter.Add(i);
            Debug.Log("Монета собрана");
        }

        Destroy(gameObject);
    }


}
