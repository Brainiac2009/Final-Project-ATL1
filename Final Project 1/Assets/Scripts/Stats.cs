using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public bool canFire;
    public int MaxHealth = 100;

    public Slider HealthBar;
    [Range(1,10)] public float cooldown = 4.5f;

    public IEnumerator Cooldown()
    {
        canFire = false;

        yield return new WaitForSeconds(cooldown);

        canFire = true;
    }

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = MaxHealth;
        GetComponent<AttributesManager>().health = MaxHealth;
        StartCoroutine(Cooldown());
    }

    private void Update()
    {
        HealthBar.value = GetComponent<AttributesManager>().health;
    }
}
