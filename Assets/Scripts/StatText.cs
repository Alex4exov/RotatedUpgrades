using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    private string _text;
    
    public void SetValue(int value)
    {
        if (_text == null)
            _text = textField.text;
        textField.text = String.Format(_text, value);
    }

    public void SetText(string text) => textField.text = text;
}
