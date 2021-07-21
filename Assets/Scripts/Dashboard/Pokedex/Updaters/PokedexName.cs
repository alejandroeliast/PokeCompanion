using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexName : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI nameText;
        public void UpdateItem(PokedexEntry entry)
        {
            if (entry.pkOrigin == "Original")
                nameText.SetText(entry.pkName);
            else
                nameText.SetText(entry.pkVariantNames[0]);
        }
    }
}