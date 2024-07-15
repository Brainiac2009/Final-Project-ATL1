using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int MaxHealth = 100;

    public Slider HealthBar;

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = MaxHealth;
        GetComponent<AttributesManager>().health = MaxHealth;
    }

    private void Update()
    {
        HealthBar.value = GetComponent<AttributesManager>().health;
    }
}
