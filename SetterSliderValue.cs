using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class SetterSliderValue : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;
    private float _targetValue;
    private float _speedChange = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.ChandedHealth += Change;
    }

    private void OnDisable()
    {
        _player.ChandedHealth -= Change;
    }

    public void SetTargetValue(float value)
    {
        _targetValue = value;
    }

    private void Change()
    {
        if (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speedChange * Time.deltaTime);
        }
    } 
}
