using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Evo Split", menuName = "Assets/Resources/New Evo Split")]
public class EvoSplit : ScriptableObject
{
    public PokedexEntry splitName;
    public int splitQuantity;
    public List<PokedexEntry> splitEvos;
}