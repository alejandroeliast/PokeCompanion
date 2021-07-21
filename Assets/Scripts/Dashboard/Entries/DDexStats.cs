using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDexStats : MonoBehaviour
{
    [SerializeField] private List<Sprite> statSprites = new List<Sprite>();
    [SerializeField] private List<Image>  statDots    = new List<Image>();

    public void UpdateStat(int min, int max)
    {
        for (int i = 0; i < statDots.Count; i++)
        {
            statDots[i].sprite = statSprites[0];
        }
        for (int i = 0; i < max; i++)
        {
            statDots[i].sprite = statSprites[1];
        }
        for (int i = 0; i < min; i++)
        {
            statDots[i].sprite = statSprites[2];
        }
    }
}
