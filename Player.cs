using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private float Health;
    private float maxHealth = 100;
    private float minHealth = 0;

    private void Start()
    {
        Health = maxHealth;
    }

    private void Update()
    {
        SendValueToBar(_healthBar, Health);
    }

    public void ReduceHealth(float value)
    {
        if (Health - value >= minHealth)
        {
            Health -= value;
        }
        else
        {
            Health = minHealth;
        }
    }

    public void IncreaseHealth(float value)
    {
        if (Health + value <= maxHealth)
        {
            Health += value;
        }
        else
        {
            Health = maxHealth;
        }
    }

    private void SendValueToBar(Slider bar, float targetValue)
    {
        float speedChange = 100;

        if (bar.value != targetValue)
        {
            bar.value = Mathf.MoveTowards(bar.value, targetValue, speedChange * Time.deltaTime);
        }
    }
}
