using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    
    private UnityEvent _healthChanged = new UnityEvent();
    private float Health;
    private float maxHealth = 100;
    private float minHealth = 0;

    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    private void Start()
    {
        Health = maxHealth;
        SendValueHealthToBar();
    }

    private void OnEnable()
    {
        HealthChanged += SendValueHealthToBar;
    }

    private void OnDisable()
    {
        HealthChanged -= SendValueHealthToBar;
    }

    private void SendValueHealthToBar()
    {
        _healthBar.GetComponent<ChangeSliderValue>().SetTargetValue(Health);
    }

    public void ReduceHealth(float value)
    {
        Health -= value;
        
        if (Health < minHealth)
            Health = minHealth;

        _healthChanged?.Invoke();
    }

    public void IncreaseHealth(float value)
    {
        Health += value;

        if (Health >= maxHealth)
            Health = maxHealth;

        _healthChanged?.Invoke();
    }
}
