using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private static int _counter;
    [SerializeField] private TMP_Text _text;

    public static int counter
    {
        get => _counter; 
        
        private set
        {
            _counter = value;

        }
    }


    public void Add(int coin)
    {
        counter += coin;
        _text.text = counter.ToString();
    }




    //private void Awake()
    //{
    //    coin.CoinChanged += OnHealthChanged;
        
    //}

    //private void OnCoinChanged(float valueAsPercantage)
    //{
    //    healthBarImage.fillAmount = valueAsPercantage;
    //}
}


