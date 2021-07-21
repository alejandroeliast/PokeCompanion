using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexHeight : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI heightText;

        public void UpdateItem(PokedexEntry entry)
        {
            heightText.SetText(entry.pkHeight.ToString() + "m");
        }
    }
}