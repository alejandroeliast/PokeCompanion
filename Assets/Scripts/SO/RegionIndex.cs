using UnityEngine;

[CreateAssetMenu(fileName = "New Pokedex Region", menuName = "Assets/Resources/New Pokedex Region")]
public class RegionIndex : ScriptableObject
{
    public string   regionName;
    public int      regionStart;
    public int      regionEnd;
}
