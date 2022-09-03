using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using TMPro;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textField;

    private Slider _slider;
    private float _speedChange = 100;
    private Coroutine _changeCoroutineIsWork;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        ChangeBarText();
    }

    private void OnEnable()
    {
        _player.ChandedHealth += OnStartChangeCoroutine;
    }

    private void OnDisable()
    {
        _player.ChandedHealth -= OnStartChangeCoroutine;
    }

    public void ChangeBarText()
    {
        _textField.text = Mathf.Round(_slider.value).ToString();
    }

    private void OnStartChangeCoroutine()
    {
        StopChangeCoroutine();
        _changeCoroutineIsWork = StartCoroutine(Change(_player.Health));
    }

    private void StopChangeCoroutine()
    {
        if (_changeCoroutineIsWork != null)
        {
            StopCoroutine(_changeCoroutineIsWork);
        }
    }

    private IEnumerator Change(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}
