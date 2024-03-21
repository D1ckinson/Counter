using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private KeyCode _triggerButton = KeyCode.Mouse0;
    [SerializeField] private float _scoreStep = 1f;
    [SerializeField] private float _delay = 0.5f;

    private float _score = 0;
    private bool _isCounting = false;

    private void Start()
    {
        _textMeshPro.text = "0";

        StartCoroutine(Ñount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(_triggerButton))
            _isCounting = _isCounting == false;
    }

    private IEnumerator Ñount()
    {
        WaitForSeconds wait = new(_delay);

        while (true)
        {
            if (_isCounting)
            {
                _score += _scoreStep;
                _textMeshPro.text = _score.ToString();

                yield return wait;
            }

            yield return null;
        }
    }
}
