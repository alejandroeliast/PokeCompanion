using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pokedex
{
    public class PokedexStats : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private Stat stat = Stat.Strength;

        [SerializeField] private List<Sprite> statSprites = new List<Sprite>();
        [SerializeField] private List<Image> statDots = new List<Image>();

        public enum Stat
        {
            Strength,
            Dexterity,
            Vitality,
            Special,
            Insight
        }

        public void UpdateItem(PokedexEntry entry)
        {
            switch (stat)
            {
                case Stat.Strength:
                    UpdateStat(entry.pkMinStrength, entry.pkMaxStrength);
                    break;
                case Stat.Dexterity:
                    UpdateStat(entry.pkMinDexterity, entry.pkMaxDexterity);
                    break;
                case Stat.Vitality:
                    UpdateStat(entry.pkMinVitality, entry.pkMaxVitality);                 
                    break;
                case Stat.Special:
                    UpdateStat(entry.pkMinSpecial, entry.pkMaxSpecial);
                    break;
                case Stat.Insight:
                    UpdateStat(entry.pkMinInsight, entry.pkMaxInsight);
                    break;
                default:
                    break;
            }
        }

        public void UpdateStat(int min, int max)
        {
            for (int i = 0; i < statDots.Count; i++)
            {
                statDots[i].sprite = statSprites[0];
            }
            for (int i = 0; i < max; i++)
            {
                statDots[i].sprite = statSprites[1];
            }
            for (int i = 0; i < min; i++)
            {
                statDots[i].sprite = statSprites[2];
            }
        }
    }
}