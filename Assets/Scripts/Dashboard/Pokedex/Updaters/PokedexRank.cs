using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexRank : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private Image rankImage;
        [SerializeField] private TextMeshProUGUI rankText;

        public void UpdateItem(PokedexEntry entry)
        {
            rankImage.sprite = Resources.Load<Sprite>($"Images/Ranks/Minis/{entry.pkRank}");
            rankText.SetText(entry.pkRank.ToString());
        }
    }
}