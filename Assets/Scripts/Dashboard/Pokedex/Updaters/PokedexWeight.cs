using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexWeight : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI weightText;
        
        public void UpdateItem(PokedexEntry entry)
        {
            weightText.SetText(entry.pkWeight.ToString() + "kg");
        }
    }
}