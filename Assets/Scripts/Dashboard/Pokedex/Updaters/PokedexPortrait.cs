using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexPortrait : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private Image portraitImage;
        public void UpdateItem(PokedexEntry entry)
        {
            portraitImage.sprite = Resources.Load<Sprite>($"Images/Portraits/{entry.pkName}");
        }
    }
}