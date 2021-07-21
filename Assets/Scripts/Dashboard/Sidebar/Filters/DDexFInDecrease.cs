using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDexFInDecrease : MonoBehaviour
{

    private enum Sort
    {
        Height,
        Weight
    }

    [SerializeField] private DDexFManager manager;
    [SerializeField] private DDexFManager.State state = DDexFManager.State.None;
    [SerializeField] private Sort sort;
    [SerializeField] private Image image;
    [SerializeField] private Sprite spIncrease;
    [SerializeField] private Sprite spDecrease;
    [SerializeField] private Color colorOn;
    [SerializeField] private Color colorOff;
    

    public void PassValue()
    {
        UpdateState();

        if(sort == Sort.Height)
        {
            manager.SortHeight(state);
        }
        else if(sort == Sort.Weight)
        {
            manager.SortWeight(state);
        }
    }

    public void UpdateState()
    {
        if (state == DDexFManager.State.None)
        {
            state = DDexFManager.State.Increase;
            image.sprite = spIncrease;
            image.color = colorOn;
        }
        else if (state == DDexFManager.State.Increase)
        {
            state = DDexFManager.State.Decrease;
            image.sprite = spDecrease;
            image.color = colorOn;
        }
        else if (state == DDexFManager.State.Decrease)
        {
            state = DDexFManager.State.None;
            image.sprite = spIncrease;
            image.color = colorOff;
        }
    }

    public void SetState(DDexFManager.State setState)
    {
        if (setState == DDexFManager.State.None)
        {
            state = DDexFManager.State.None;
            image.sprite = spIncrease;
            image.color = colorOff;

        }
        else if (setState == DDexFManager.State.Increase)
        {
            state = DDexFManager.State.Increase;
            image.sprite = spIncrease;
            image.color = colorOn;
        }
        else if (setState == DDexFManager.State.Decrease)
        {
            state = DDexFManager.State.Decrease;
            image.sprite = spDecrease;
            image.color = colorOn;
        }
    }
}
