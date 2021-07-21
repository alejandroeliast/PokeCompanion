using System;
using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class NumberRange : MonoBehaviour
    {
        public TMP_InputField inputField;

        [HideInInspector] public float valueMin;
        [HideInInspector] public float valueMax;
        private float _value;

        public bool _isMin;

        public static event Action<float, bool> OnValueNumberChanged;

        public void UpdateValue()
        {
            if (inputField.text != "")
                _value = float.Parse(inputField.text);

            _value = ClampValue(_value);

            UpdateText();
            OnValueNumberChanged?.Invoke(_value, _isMin);
        }

        private float ClampValue(float value)
        {
            float min = valueMin;
            float max = valueMax;

            return Mathf.Clamp(value, min, max);
        }

        private void UpdateText()
        {
            if (_value == 0)
                inputField.text = "";
            else
                inputField.text = _value.ToString();
        }

        public void CorrectText(float value)
        {
            _value = value;
            inputField.text = value.ToString();
        }
    }
}