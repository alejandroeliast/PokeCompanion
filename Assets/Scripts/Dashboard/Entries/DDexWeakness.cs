using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDexWeakness : MonoBehaviour
{
    [SerializeField] private Type weakType1; 
    [SerializeField] private Type weakType2; 

    [SerializeField] private TextMeshProUGUI weakNormal;
    [SerializeField] private TextMeshProUGUI weakFire;
    [SerializeField] private TextMeshProUGUI weakWater;
    [SerializeField] private TextMeshProUGUI weakElecric;
    [SerializeField] private TextMeshProUGUI weakGrass;
    [SerializeField] private TextMeshProUGUI weakIce;
    [SerializeField] private TextMeshProUGUI weakFighting;
    [SerializeField] private TextMeshProUGUI weakPoison;
    [SerializeField] private TextMeshProUGUI weakGround;
    [SerializeField] private TextMeshProUGUI weakFlying;
    [SerializeField] private TextMeshProUGUI weakPsychic;
    [SerializeField] private TextMeshProUGUI weakBug;
    [SerializeField] private TextMeshProUGUI weakRock;
    [SerializeField] private TextMeshProUGUI weakGhost;
    [SerializeField] private TextMeshProUGUI weakDragon;
    [SerializeField] private TextMeshProUGUI weakDark;
    [SerializeField] private TextMeshProUGUI weakSteel;
    [SerializeField] private TextMeshProUGUI weakFairy;

    public void UpdateWeakness(PokedexEntry.Types t1, PokedexEntry.Types t2)
    {
        weakType1 = Resources.Load<Type>($"Scriptable Objects/Types/{t1}");
        weakType2 = Resources.Load<Type>($"Scriptable Objects/Types/{t2}");

        SetValue(weakType1.typeNormal[1], weakType2.typeNormal[1], weakNormal);
        SetValue(weakType1.typeFire[1], weakType2.typeFire[1], weakFire);
        SetValue(weakType1.typeWater[1], weakType2.typeWater[1], weakWater);
        SetValue(weakType1.typeElectric[1], weakType2.typeElectric[1], weakElecric) ;
        SetValue(weakType1.typeGrass[1], weakType2.typeGrass[1], weakGrass);
        SetValue(weakType1.typeIce[1], weakType2.typeIce[1], weakIce);
        SetValue(weakType1.typeFighting[1], weakType2.typeFighting[1], weakFighting);
        SetValue(weakType1.typePoison[1], weakType2.typePoison[1], weakPoison);
        SetValue(weakType1.typeGround[1], weakType2.typeGround[1], weakGround);
        SetValue(weakType1.typeFlying[1], weakType2.typeFlying[1], weakFlying);
        SetValue(weakType1.typePsychic[1], weakType2.typePsychic[1], weakPsychic);
        SetValue(weakType1.typeBug[1], weakType2.typeBug[1], weakBug);
        SetValue(weakType1.typeRock[1], weakType2.typeRock[1], weakRock);
        SetValue(weakType1.typeGhost[1], weakType2.typeGhost[1], weakGhost);
        SetValue(weakType1.typeDragon[1], weakType2.typeDragon[1], weakDragon);
        SetValue(weakType1.typeDark[1], weakType2.typeDark[1], weakDark);
        SetValue(weakType1.typeSteel[1], weakType2.typeSteel[1], weakSteel);
        SetValue(weakType1.typeFairy[1], weakType2.typeFairy[1], weakFairy);
    }

    private void SetValue(int x, int y, TextMeshProUGUI text)
    {
        int val = x + y;

        if (val < -2)
            text.SetText("x0");
        else if (val == -2)
            text.SetText("x0.25");
        else if (val == -1)
            text.SetText("x0.5");
        else if (val == 1)
            text.SetText("x2");
        else if (val == 2)
            text.SetText("x4");
        else
            text.SetText("x1");
    }
}
