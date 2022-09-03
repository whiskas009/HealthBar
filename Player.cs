using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public float Health { get; private set; }
    private float _maxHealth = 100;
    private float _minHealth = 0;

    private void Start()
    {
        Health = _maxHealth;
    }

    public event UnityAction ChandedHealth;

    public void Heal(float value)
    {
        ChangeHealth(value);
    }

    public void Damage(float value)
    {
        ChangeHealth(-value);
    }

    private void ChangeHealth(float value)
    {
        Health = Mathf.Clamp(Health += value, _minHealth, _maxHealth);
        ChandedHealth?.Invoke();
    }
}
