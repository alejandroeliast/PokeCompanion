using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexEntryHide : MonoBehaviour
    {
        [SerializeField] private Image blurImage;
        [SerializeField] private GameObject blurButton;
        [SerializeField] private GameObject entryGroup;

        public void HideEntry()
        {
            blurImage.enabled = false;
            blurButton.SetActive(false);
            entryGroup.SetActive(false);
        }
    }
}