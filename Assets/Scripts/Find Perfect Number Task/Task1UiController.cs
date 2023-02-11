using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task1UiController : MonoBehaviour
{
    [SerializeField] private TMP_Text _textUi;
    [SerializeField] private TMP_InputField _inputFieldUi;

    [SerializeField] private PerfectNumberChecker _perfectNumberChecker;

    private Coroutine _activateCoroutine;

    private bool _submitted = false;

    // Start is called before the first frame update
    void Start()
    {
        _inputFieldUi.onSubmit.AddListener(SetSubmitted);

        _activateCoroutine = StartCoroutine(SetInputNumber());
    }

    void SetSubmitted(string msg)
    {
        _submitted = true;

        EnableUiComponent(false);
    }

    void EnableUiComponent(bool enabled)
    {
        _textUi.gameObject.SetActive(enabled);
        _inputFieldUi.gameObject.SetActive(enabled);
    }

    int GetInputValue()
    {
        if (string.IsNullOrEmpty(_inputFieldUi.text))
        {
            StopCoroutine(_activateCoroutine);

            _textUi.text = "Input not valid, please enter a properly value.";
            _textUi.gameObject.SetActive(true);

            return 0;
        }

        return int.Parse(_inputFieldUi.text);
    }

    IEnumerator SetInputNumber()
    {
        EnableUiComponent(true);

        _inputFieldUi.text = string.Empty;
        _textUi.text = "Masukkan jumlah anggota data input integer: (Tekan 'Enter' ketika sedang select inputfield untuk submit data)";
        yield return new WaitUntil(() => _submitted == true);

        int input_data = GetInputValue();
        _submitted = false;

        List<int> _numbers_data = new List<int>();
        for (int i = 0; i < input_data; i++)
        {
            EnableUiComponent(true);

            _inputFieldUi.text = string.Empty;
            _textUi.text = "Data indeks ke-" + i + ": (Tekan 'Enter' ketika sedang select inputfield untuk submit data)";
            yield return new WaitUntil(() => _submitted == true);

            _numbers_data.Add(GetInputValue());
            _submitted = false;
        }

        if (_numbers_data.Count > 0)
        {
            string result = _perfectNumberChecker.PerfectNumberCheck(_numbers_data);

            _textUi.text = result;
            _textUi.gameObject.SetActive(true);
        }
    }
}
