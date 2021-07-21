using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexAbilities : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI ability1Text;
        [SerializeField] private TextMeshProUGUI ability2Text;

        public void UpdateItem(PokedexEntry entry)
        {
            ability1Text.SetText(entry.pkAbility1);
            if (entry.pkAbility2 != "-")
                ability2Text.SetText(entry.pkAbility2);
            else
                ability2Text.SetText("-");
        }
    }
}