using UnityEngine;
using System.Collections.Generic;

namespace Pokedex
{
    public class PokedexEntryUpdater : MonoBehaviour
    {
        [HideInInspector] public PokedexEntry entry;

        [SerializeField] private List<PokedexStats> entryStats = new List<PokedexStats>();
        [SerializeField] private List<PokedexEvolutions> entryEvolutions = new List<PokedexEvolutions>();
        [SerializeField] private PokedexEvolutionSplits entryEvolutionSplit;
        [SerializeField] private PokedexMoveSpawner entryMoveSpawner;

        private List<IItemUpdater> _itemUpdaters = new List<IItemUpdater>();

        private void Awake()
        {
            foreach (var item in GetComponentsInChildren<IItemUpdater>())
            {
                _itemUpdaters.Add(item);
            }
        }
        private void OnEnable()
        {
            PokedexPreviewUpdater.OnAnyPreviewPressed += UpdateEntry;
        }
        private void OnDisable()
        {
            PokedexPreviewUpdater.OnAnyPreviewPressed -= UpdateEntry;
        }
        public void UpdateEntry(string name)
        {
            entry = Resources.Load<PokedexEntry>($"Scriptable Objects/Pokedex Entries/{name}");

            // Information
            foreach (var item in _itemUpdaters)
            {
                item.UpdateItem(entry);
            }

            // Stats
            foreach (PokedexStats item in entryStats)
            {
                item.UpdateItem(entry);
            }

            // Evo Line
            for (int i = 0; i < 3; i++)
            {
                entryEvolutions[i].HideEvoSlot();
            }
            for (int i = 0; i < entry.pkEvoQty; i++)
            {
                if (i == 0)
                    entryEvolutions[i].UpdateEvoSlot(entry.pkEvoName1);
                else if (i == 1)
                    entryEvolutions[i].UpdateEvoSlot(entry.pkEvoName2);
                else if (i == 2)
                    entryEvolutions[i].UpdateEvoSlot(entry.pkEvoName3);
            }

            entryEvolutionSplit.HideSplit();

            // Moves
            entryMoveSpawner.ClearMoves();
            entryMoveSpawner.CreateMoves(entry.pkMoves);
        }
    }
}