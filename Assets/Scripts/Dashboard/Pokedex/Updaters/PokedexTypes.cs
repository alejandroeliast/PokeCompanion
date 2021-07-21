using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexTypes : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private Image type1Image;
        [SerializeField] private Image type2Image;
        public void UpdateItem(PokedexEntry entry)
        {
            type1Image.sprite = Resources.Load<Sprite>($"Images/Types/{entry.pkType1}");
            if (entry.pkType2 != PokedexEntry.Types.None)
                type2Image.sprite = Resources.Load<Sprite>($"Images/Types/{entry.pkType2}");
            else
                type2Image.sprite = null;
        }
    }
}