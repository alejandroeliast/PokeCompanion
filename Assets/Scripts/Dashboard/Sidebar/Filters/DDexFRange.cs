using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDexFRange : MonoBehaviour
{
    public enum Range
    {
        Number,
        Height,
        Weight
    }

    [SerializeField] private Range rRange;
    [SerializeField] private bool isMin = false;
    [SerializeField] private TMP_InputField rInput;
    [SerializeField] private float rValue;
    [SerializeField] private float maxValue;
    [SerializeField] private DDexFManager rFManager;

    public void UpdateValue()
    {
        if (rInput.text != "")
            rValue = float.Parse(rInput.text);
        else
            rValue = 0;

        ClampValue();
        UpdateText();

        if (rRange == Range.Number)
        {
            if (isMin)
            {
                rFManager.RangeNumMin(rValue);
            }
            else if (!isMin)
            {
                if(rValue == 0)
                    rValue = maxValue;

                rFManager.RangeNumMax(rValue);
            }
        }
        else if(rRange == Range.Height)
        {
            if (isMin)
            {
                rFManager.RangeHeightMin(rValue);
            }
            else if (!isMin)
            {
                if (rValue == 0)
                    rValue = maxValue;

                rFManager.RangeHeightMax(rValue);
            }
        }
        else if (rRange == Range.Weight)
        {
            if (isMin)
            {
                rFManager.RangeWeightMin(rValue);
            }
            else if (!isMin)
            {
                if (rValue == 0)
                    rValue = maxValue;

                rFManager.RangeWeightMax(rValue);
            }
        }
    }

    public void ClampValue()
    {
        if (rValue < 0)
        {
            rValue = 0;
        }
        else if (rValue > maxValue)
        {
            rValue = maxValue;
        }
    }

    public void UpdateText()
    {
        if (rValue == 0)
            rInput.text = "";
        else
            rInput.text = rValue.ToString();
    }

    public void CorrectValue(float val)
    {
        rValue = val;
        UpdateText();
    }
}
