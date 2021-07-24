using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexFolderStyle : MonoBehaviour
    {
        [SerializeField] private List<Color> folderColors = new List<Color>();
        [SerializeField] private Image folderIcon;

        private void UpdateVisual(int b, int t)
        {
            var button = GetComponentInChildren<Button>();

            var colors = button.colors;
            colors.normalColor = folderColors[b];
            colors.highlightedColor = folderColors[b];
            colors.pressedColor = folderColors[b];
            colors.selectedColor = folderColors[b];
            colors.disabledColor = folderColors[b];
            button.colors = colors;

            var text = GetComponentInChildren<TextMeshProUGUI>();

            if (text != null)
                text.color = folderColors[t];

            if (folderIcon != null)
                folderIcon.color = folderColors[t];
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