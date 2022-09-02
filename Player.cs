using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private UnityEvent _chandedHealth;
    private float _health;
    private float _maxHealth = 100;
    private float _minHealth = 0;

    private void Start()
    {
        _health = _maxHealth;
        SendValueHealthToBar();
    }

    public event UnityAction ChandedHealth
    {
        add => _chandedHealth.AddListener(value);
        remove => _chandedHealth.RemoveListener(value);
    }

    private void SendValueHealthToBar()
    {
        _healthBar.GetComponent<SetterSliderValue>().SetTargetValue(_health);
    }

    public void Heal(float value)
    {
        _health -= value;
        
        if (_health < _minHealth)
            _health = _minHealth;

        SendValueHealthToBar();
    }

    public void Damage(float value)
    {
        _health += value;

        if (_health >= _maxHealth)
            _health = _maxHealth;

        SendValueHealthToBar();
    }
}
