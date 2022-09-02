using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

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
        _player.ChandedHealth += StartChangeCoroutine;
    }

    private void OnDisable()
    {
        _player.ChandedHealth -= StartChangeCoroutine;
    }

    public void SetTargetValue(float value)
    {
        _targetValue = value;
    }

    private void StartChangeCoroutine()
    {
        if (Change() != null)
        {
            StartCoroutine(Change());
        }
    }
    
    private IEnumerator Change()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speedChange * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(Change());
    }
}
