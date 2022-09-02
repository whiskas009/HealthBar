using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SendValueToTextField : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        SetValue();
    }

    public void Change()
    {
        SetValue();
    }

    private void SetValue()
    {
        _textField.text = Mathf.Round(_slider.value).ToString();
    }
}
