using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private Image topShadow;
    [SerializeField] private Image bottomShadow;

    public void EnableShadows()
    {
        if (scrollRect.verticalNormalizedPosition < 1f && scrollRect.verticalNormalizedPosition > 0f)
        {
            topShadow.enabled = true;
            bottomShadow.enabled = true;
        }
        else if (scrollRect.verticalNormalizedPosition == 0f)
        {
            topShadow.enabled = true;
            bottomShadow.enabled = false;
        }
        else if(scrollRect.verticalNormalizedPosition == 1f)
        {
            topShadow.enabled = false;
            bottomShadow.enabled = true;
        }
    }
}
