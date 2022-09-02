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
        _textField.text = _slider.value.ToString();
    }

    public void Change()
    {
        _textField.text = Mathf.Round(_slider.value).ToString();
    }
}
