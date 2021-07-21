using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pokedex
{
    public class PokedexEvolution : MonoBehaviour, IItemUpdater
    {
        [SerializeField] private TextMeshProUGUI stageText;
        [SerializeField] private TextMeshProUGUI methodText;

        public void UpdateItem(PokedexEntry entry)
        {
            stageText.SetText(entry.pkEvoStage);

            if (entry.pkEvoMethod == PokedexEntry.EvoMethod.ThunderStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.LeafStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.WaterStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.FireStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.MoonStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.IceStone || entry.pkEvoMethod == PokedexEntry.EvoMethod.TradeItem)
                switch (entry.pkEvoMethod)
                {
                    case PokedexEntry.EvoMethod.ThunderStone:
                        methodText.SetText("Thunder Stone");
                        break;
                    case PokedexEntry.EvoMethod.MoonStone:
                        methodText.SetText("Moon Stone");
                        break;
                    case PokedexEntry.EvoMethod.FireStone:
                        methodText.SetText("Fire Stone");
                        break;
                    case PokedexEntry.EvoMethod.LeafStone:
                        methodText.SetText("Leaf Stone");
                        break;
                    case PokedexEntry.EvoMethod.WaterStone:
                        methodText.SetText("Water Stone");
                        break;
                    case PokedexEntry.EvoMethod.IceStone:
                        methodText.SetText("Ice Stone");
                        break;
                    case PokedexEntry.EvoMethod.TradeItem:
                        methodText.SetText("Trade with Item");
                        break;
                    default:
                        break;
                }
            else if (entry.pkEvoMethod != PokedexEntry.EvoMethod.None)
                methodText.SetText(entry.pkEvoMethod.ToString());
            else
                methodText.SetText("-");
        }
    }
}