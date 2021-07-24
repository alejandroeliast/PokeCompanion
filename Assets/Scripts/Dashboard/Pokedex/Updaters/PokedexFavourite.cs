using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexFavourite : MonoBehaviour, IItemUpdater
    {
        [SerializeField] PokedexIndex favouriteIndex;
        [SerializeField] Image buttonImage;
        private Color activeColor = new Color(1f, 0.84f, 0f);
        private PokedexEntry currentEntry;
        private bool isActive;

        public void UpdateItem(PokedexEntry entry)
        {
            currentEntry = entry;

            if (favouriteIndex.fullEntries.Contains(currentEntry))
                SetActive();
            else
                SetInactive();
        }

        private void SetActive()
        {
            isActive = true;
            buttonImage.color = activeColor;

            if (!favouriteIndex.fullEntries.Contains(currentEntry))
                favouriteIndex.fullEntries.Add(currentEntry);

            SortList();
        }

        private void SetInactive()
        {
            isActive = false;
            buttonImage.color = new Color(1f, 1f, 1f);

            if (favouriteIndex.fullEntries.Contains(currentEntry))
                favouriteIndex.fullEntries.Remove(currentEntry);

            SortList();
        }

        private void SortList()
        {
            var temp = favouriteIndex.fullEntries.OrderBy(e => e.pkID).ToList();
            favouriteIndex.fullEntries.Clear();
            favouriteIndex.fullEntries = temp;
        }

        public void OnClickFavourite()
        {
            if (isActive)
                SetInactive();
            else
                SetActive();
        }
    }
}