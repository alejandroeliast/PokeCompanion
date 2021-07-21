using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Pokedex Index", menuName = "Assets/Resources/New Pokedex Index")]
public class PokedexIndex : ScriptableObject
{
    public List<PokedexEntry> fullEntries;

    public PokedexIndex(List<PokedexEntry> entries)
    {
        fullEntries = entries;
    }
}
