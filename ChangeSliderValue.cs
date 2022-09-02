using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ChangeSliderValue : MonoBehaviour
{
    private Slider _slider;
    private float _targetValue;
    private float _speedChange = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        Change();
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
