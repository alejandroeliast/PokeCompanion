using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexHealth : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI healthText;

        public void UpdateItem(PokedexEntry entry)
        {
            healthText.SetText(entry.pkBaseHP.ToString());
        }
    }
}