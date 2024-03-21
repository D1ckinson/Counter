using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private MouseButton _triggerButton = MouseButton.Left;
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private float _countStep = 1f;
    [SerializeField] private float _delay = 0.5f;

    private float _elapsedTime = 0;
    private float _triggerTime = 0;
    private bool _isCounting = false;

    private void Start()
    {
        _textMeshPro.text = "0";

        StartCoroutine(Ñount());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)_triggerButton))
            _isCounting = _isCounting == false;
    }

    private IEnumerator Ñount()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            if (Time.time >= _triggerTime && _isCounting)
            {
                _elapsedTime += _countStep;
                _triggerTime = Time.time + _delay;

                _textMeshPro.text = _elapsedTime.ToString();

                yield return wait;
            }

            yield return null;
        }
    }

    private void OnDestroy() =>
        StopCoroutine(Ñount());
}
