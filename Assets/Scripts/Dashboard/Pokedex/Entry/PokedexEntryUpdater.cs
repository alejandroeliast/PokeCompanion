using UnityEngine;
using System.Collections.Generic;

namespace Pokedex
{
    public class PokedexEntryUpdater : MonoBehaviour
    {
        [HideInInspector] public PokedexEntry entry;        

        [SerializeField] private DDexMarkUpdater _entryMarks;
        [SerializeField] private List<DDexStats> entryStats = new List<DDexStats>();
        [SerializeField] private List<DDexEvolution> entryEvos = new List<DDexEvolution>();
        [SerializeField] private DDexWeakness entryWeakness;
        [SerializeField] private DDexMoveSpawner entryMoveSpawner;

        private List<IItemUpdater> _itemUpdaters = new List<IItemUpdater>();

        private void Awake()
        {
            foreach (var item in GetComponents<IItemUpdater>())
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

            // Marks
            if (_entryMarks != null) _entryMarks.UpdateMark(entry);

            // Stats
            entryStats[0].UpdateStat(entry.pkMinStrength, entry.pkMaxStrength);
            entryStats[1].UpdateStat(entry.pkMinDexterity, entry.pkMaxDexterity);
            entryStats[2].UpdateStat(entry.pkMinVitality, entry.pkMaxVitality);
            entryStats[3].UpdateStat(entry.pkMinSpecial, entry.pkMaxSpecial);
            entryStats[4].UpdateStat(entry.pkMinInsight, entry.pkMaxInsight);

            // Evo Line
            for (int i = 0; i < 3; i++)
            {
                entryEvos[i].HideEvoSlot();
            }
            for (int i = 0; i < entry.pkEvoQty; i++)
            {
                if (i == 0)
                    entryEvos[i].UpdateEvoSlot(entry.pkEvoName1);
                else if (i == 1)
                    entryEvos[i].UpdateEvoSlot(entry.pkEvoName2);
                else if (i == 2)
                    entryEvos[i].UpdateEvoSlot(entry.pkEvoName3);
            }

            // Weakness
            entryWeakness.UpdateWeakness(entry.pkType1, entry.pkType2);

            // Moves
            entryMoveSpawner.ClearMoves();
            entryMoveSpawner.CreateMoves(entry.pkMoves);
        }
    }
}