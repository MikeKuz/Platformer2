using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Health health;

    private void Awake()
    {
        health.HealthChanged += OnHealthChanged;
    }
    private void OnHealthChanged(float valueAsPercantage)
    {
        healthBarImage.fillAmount= valueAsPercantage;
    }


}
