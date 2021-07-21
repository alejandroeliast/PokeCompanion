using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDexFButtonType : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private DDexFManager filter;

    private Image image;
    private ColorSwatch swatchType;
    private Color colorType;

    [SerializeField] private Color offColor;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        swatchType = Resources.Load<ColorSwatch>($"Scriptable Objects/Color Swatches/Types");

        for (int i = 0; i < swatchType.swatchEntry.Count; i++)
        {
            if(gameObject.name == swatchType.swatchEntry[i].colorName)
            {
                colorType = swatchType.swatchEntry[i].colorValue;
            }
        }
    }

    public void FilterType()
    {
        if (!isActive)
        {
            isActive = true;
            image.color = colorType;
            filter.TypeAdd(gameObject.name);
        }
        else
        {
            isActive = false;
            image.color = offColor;
            filter.TypeRemove(gameObject.name);
        }
    }
}
