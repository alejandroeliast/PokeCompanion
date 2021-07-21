using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IndexManager : MonoBehaviour
{
    [SerializeField] private PokedexIndex pDexFull;
    [SerializeField] private List<PokedexIndex> pDexTypes = new List<PokedexIndex>();

    [SerializeField] private List<PokedexEntry> pDexTemp = new List<PokedexEntry>();
    [SerializeField] private PokedexIndex pDexHeight;
    [SerializeField] private PokedexIndex pDexWeight;
    void Start()
    {
        pDexFull = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");

        CIndexPType(0, PokedexEntry.Types.Normal);
        CIndexPType(1, PokedexEntry.Types.Fire);
        CIndexPType(2, PokedexEntry.Types.Water);
        CIndexPType(3, PokedexEntry.Types.Electric);
        CIndexPType(4, PokedexEntry.Types.Grass);
        CIndexPType(5, PokedexEntry.Types.Ice);
        CIndexPType(6, PokedexEntry.Types.Fighting);
        CIndexPType(7, PokedexEntry.Types.Poison);
        CIndexPType(8, PokedexEntry.Types.Ground);
        CIndexPType(9, PokedexEntry.Types.Flying);
        CIndexPType(10, PokedexEntry.Types.Psychic);
        CIndexPType(11, PokedexEntry.Types.Bug);
        CIndexPType(12, PokedexEntry.Types.Rock);
        CIndexPType(13, PokedexEntry.Types.Ghost);
        CIndexPType(14, PokedexEntry.Types.Dragon);
        CIndexPType(15, PokedexEntry.Types.Dark);
        CIndexPType(16, PokedexEntry.Types.Steel);
        CIndexPType(17, PokedexEntry.Types.Fairy);

        CIndexPHeight();
        CIndexPWeight();
    }

    void CIndexPType(int id, PokedexEntry.Types type)
    {
        if(pDexTypes[id].fullEntries.Count <= 0)
        {
            for (int i = 0; i < pDexFull.fullEntries.Count; i++)
            {
                if (pDexFull.fullEntries[i].pkType1 == type || pDexFull.fullEntries[i].pkType2 == type)
                {
                    pDexTypes[id].fullEntries.Add(pDexFull.fullEntries[i]);
                }
            }
        }
    }

    void CIndexPHeight()
    {
        if (pDexHeight.fullEntries.Count <= 0)
        {
            pDexTemp.Clear();
            for (int i = 0; i < pDexFull.fullEntries.Count; i++)
            {
                pDexTemp.Add(pDexFull.fullEntries[i]);
            }
            pDexHeight.fullEntries = pDexTemp.OrderBy(o => o.pkHeight).ToList();
        }
    }

    void CIndexPWeight()
    {
        if (pDexWeight.fullEntries.Count <= 0)
        {
            pDexTemp.Clear();
            for (int i = 0; i < pDexFull.fullEntries.Count; i++)
            {
                pDexTemp.Add(pDexFull.fullEntries[i]);
            }
            pDexWeight.fullEntries = pDexTemp.OrderBy(o => o.pkWeight).ToList();
        }
    }

}
