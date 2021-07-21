using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color Swatch", menuName = "Assets/Resources/New Color Swatch")]
public class ColorSwatch : ScriptableObject
{
    public List<ColorData> swatchEntry;
}

[Serializable]
public class ColorData
{
    public string colorName;
    public Color colorValue;

    public ColorData(string _colorName, Color _colorValue)
    {
        colorName = _colorName;
        colorValue = _colorValue;
    }
}