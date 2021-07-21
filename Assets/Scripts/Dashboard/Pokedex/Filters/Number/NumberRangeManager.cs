using System;
using System.Collections.Generic;
using UnityEngine;
//using RotaryHeart.Lib.SerializableDictionary;

namespace Pokedex
{
    public class NumberRangeManager : MonoBehaviour
    {
        private float _minValue;
        private float _maxValue;

        [SerializeField] private float _minimum;
        [SerializeField] private float _maximum;

        [SerializeField] private NumberRange _minRange;
        [SerializeField] private NumberRange _maxRange;

        private bool _isMinActive;
        private bool _isMaxActive;

        private PokedexIndex _fullIndex;
        [SerializeField] private SortedDictionary<int, PokedexEntry> _filteredDictionary = new SortedDictionary<int, PokedexEntry>();

        public static event Action<SortedDictionary<int, PokedexEntry>> OnNumberRangeUpdated;

        private void Awake()
        {
            _maxValue = _maximum;
        }
        private void Start()
        {
            _minRange.valueMin = _minimum;
            _minRange.valueMax = _maximum;

            _maxRange.valueMin = _minimum;
            _maxRange.valueMax = _maximum;

            if (_fullIndex == null)
                _fullIndex = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");

            _filteredDictionary.Clear();
            ResetDictionary();

        }
        private void OnEnable()
        {
            NumberRange.OnValueNumberChanged += UpdateValue;
        }
        private void OnDisable()
        {
            NumberRange.OnValueNumberChanged -= UpdateValue;
        }

        private void UpdateValue(float value, bool isMin)
        {
            if (isMin)
            {
                _minValue = value;

                if (_minValue > _maxValue)
                {
                    _maxValue = _minValue;
                    _maxRange.CorrectText(_maxValue);
                }
            }
            else
            {
                if (value != 0)
                    _maxValue = value;
                else
                    _maxValue = 801;

                if (_maxValue < _minValue)
                {
                    _minValue = _maxValue;
                    _minRange.CorrectText(_minValue);
                }
            }

            ResetDictionary();
            UpdateDictionary();
            CheckIfActive();
        }
        private void CheckIfActive()
        {
            _isMinActive = _minRange.inputField.text != "" ? true : false;
            _isMaxActive = _maxRange.inputField.text != "" ? true : false;

            if (_isMinActive || _isMaxActive)
            {
                OnNumberRangeUpdated?.Invoke(_filteredDictionary);
            }
        }
        private void UpdateDictionary()
        {
            List<PokedexEntry> toDelete = new List<PokedexEntry>();

            foreach (var kvp in _filteredDictionary)
            {
                if (kvp.Value.pkNumber < _minValue || kvp.Value.pkNumber > _maxValue)
                {
                    toDelete.Add(kvp.Value);
                }
            }

            foreach (var item in toDelete)
            {
                if (_filteredDictionary.ContainsKey(item.pkID))
                {
                    _filteredDictionary.Remove(item.pkID);
                }
            }
        }
        private void ResetDictionary()
        {
            foreach (var entry in _fullIndex.fullEntries)
            {
                if (!_filteredDictionary.ContainsKey(entry.pkID))
                {
                    _filteredDictionary.Add(entry.pkID, entry);
                }
            }
        }
    }
}