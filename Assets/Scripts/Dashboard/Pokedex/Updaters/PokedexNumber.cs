using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexNumber : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI numberText;
        private int _number;

        public void UpdateItem(PokedexEntry entry)
        {
            _number = entry.pkNumber;

            if (_number < 10)
                numberText.SetText("00" + _number.ToString());
            else if (_number < 100 && _number > 9)
                numberText.SetText("0" + _number.ToString());
            else
                numberText.SetText(_number.ToString());
        }
    }
}