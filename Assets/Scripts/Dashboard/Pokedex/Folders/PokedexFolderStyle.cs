using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexFolderStyle : MonoBehaviour
    {
        [SerializeField] private List<Color> _colors = new List<Color>();

        private void UpdateVisual(int b, int t)
        {
            var button = GetComponentInChildren<Button>();

            var colors = button.colors;
            colors.normalColor = _colors[b];
            colors.highlightedColor = _colors[b];
            colors.pressedColor = _colors[b];
            colors.selectedColor = _colors[b];
            colors.disabledColor = _colors[b];
            button.colors = colors;

            var text = GetComponentInChildren<TextMeshProUGUI>();

            text.color = _colors[t];
        }

        public void SetActive()
        {
            UpdateVisual(1, 0);
        }

        public void SetInactive()
        {
            UpdateVisual(0, 1);
        }
    }
}