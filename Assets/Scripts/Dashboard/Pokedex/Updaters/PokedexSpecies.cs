using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexSpecies : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI speciesText;
        public void UpdateItem(PokedexEntry entry)
        {
            speciesText.SetText(entry.pkSpecies + " Pokemon");
        }
    }
}