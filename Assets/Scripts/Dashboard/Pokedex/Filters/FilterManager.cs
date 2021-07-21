using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class FilterManager : MonoBehaviour
    {

        [SerializeField] private PokedexIndex _filtered;
        [SerializeField] private PokedexPreviewSpawner _previewSpawner;
        private void Start()
        {

        }

        private void OnEnable()
        {
            NumberRangeManager.OnNumberRangeUpdated += NumberFilter;
        }

        private void OnDisable()
        {
            NumberRangeManager.OnNumberRangeUpdated -= NumberFilter;
        }

        private void NumberFilter(SortedDictionary<int, PokedexEntry> index)
        {

            // Check if active, if yes do, if no reset and ignore
            _filtered.fullEntries.Clear();
            foreach (var kvp in index)
            {
                _filtered.fullEntries.Add(kvp.Value);
            }

            UpdateFilterList();
        }

        private void UpdateFilterList()
        {
            _previewSpawner.FilterPreviews(_filtered);
        }
    }
}