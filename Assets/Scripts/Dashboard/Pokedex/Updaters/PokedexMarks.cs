using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexMarks : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private Image markStarter;

        [SerializeField] private List<Image> markVariants;
        [SerializeField] private List<PokedexEntry> markEntries;

        [SerializeField] private PokedexEntryUpdater markEntryUpdater;

        public void UpdateItem(PokedexEntry entry)
        {
            CheckStarterMark(entry.pkEvoStage);
            CheckVariantMark(entry);
            SetActiveMark(entry.pkVariantAmount, entry.pkOrigin);
        }
        private void CheckStarterMark(string stage)
        {
            if (stage == "First")
                markStarter.enabled = true;
            else
                markStarter.enabled = false;
        }

        private void CheckVariantMark(PokedexEntry entry)
        {
            markEntries.Clear();

            for (int i = 0; i < markVariants.Count; i++)
            {
                markVariants[i].enabled = false;
            }

            for (int i = 0; i < entry.pkVariantAmount; i++)
            {
                markVariants[i].enabled = true;
                markEntries.Add(Resources.Load<PokedexEntry>($"Scriptable Objects/Pokedex Entries/{entry.pkVariantNames[i]}"));

                markVariants[i].sprite = Resources.Load<Sprite>($"Images/Marks/{markEntries[i].pkOrigin}");
            }
        }

        private void SetActiveMark(int x, string origin)
        {
            for (int i = 0; i < x; i++)
            {
                if (origin == markEntries[i].pkOrigin)
                {
                    var temp = markVariants[i].color;
                    temp.a = 1f;
                    markVariants[i].color = temp;
                }
                else
                {
                    var temp = markVariants[i].color;
                    temp.a = 0.2f;
                    markVariants[i].color = temp;
                }
            }
        }

        public void MarkButton(int x)
        {
            markEntryUpdater.UpdateEntry(markEntries[x].pkName);
        }
    }
}