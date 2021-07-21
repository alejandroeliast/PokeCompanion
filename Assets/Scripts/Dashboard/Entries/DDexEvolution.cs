using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Pokedex;

public class DDexEvolution : MonoBehaviour
{
    [SerializeField] private Image evoSlot;
    [SerializeField] private TextMeshProUGUI evoID;
    [SerializeField] private Image evoImage;
    [SerializeField] private Button evoButton;

    [SerializeField] private PokedexEntryUpdater evoEntryUpdater;
    [SerializeField] private PokedexEntry evoEntry;

    [SerializeField] private DDexEvoSplit evoSplit;
    [SerializeField] private Image evoIDBG;

    public void UpdateEvoSlot(string name)
    {
        if(name == "Split")
        {
            evoSlot.enabled = true;
            evoButton.enabled = true;

            evoSlot.sprite = Resources.Load<Sprite>($"Images/Evolution/Split");
        }
        else
        {
            evoEntry = Resources.Load<PokedexEntry>($"Scriptable Objects/Pokedex Entries/{name}");

            evoSlot.enabled = true;
            evoID.enabled = true;
            evoImage.enabled = true;
            evoButton.enabled = true;

            evoSlot.sprite = Resources.Load<Sprite>($"Images/Evolution/Slot");
            evoImage.sprite = Resources.Load<Sprite>($"Images/Minis/{evoEntry.pkName}");

            UpdateID();
            ResizeMiniDouble();
        }
    }

    public void UpdateSplitSlot(string name)
    {
        evoEntry = Resources.Load<PokedexEntry>($"Scriptable Objects/Pokedex Entries/{name}");

        evoSlot.enabled = true;
        evoID.enabled = true;
        evoImage.enabled = true;
        evoButton.enabled = true;
        evoIDBG.enabled = true;

        evoImage.sprite = Resources.Load<Sprite>($"Images/Minis/{evoEntry.pkName}");

        UpdateID();
        ResizeMiniDouble();
    }
    public void UpdateID()
    {
        if (evoEntry.pkNumber < 10)
        {
            evoID.SetText("00" + evoEntry.pkNumber.ToString());
        }
        else if (evoEntry.pkNumber < 100 && evoEntry.pkNumber > 9)
        {
            evoID.SetText("0" + evoEntry.pkNumber.ToString());
        }
        else
        {
            evoID.SetText(evoEntry.pkNumber.ToString());
        }
    }

    public void ResizeMiniDouble()
    {
        RectTransform rt = evoImage.transform.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(evoImage.sprite.rect.width * 2, evoImage.sprite.rect.height * 2);
    }

    public void HideEvoSlot()
    {
        evoSlot.enabled = false;
        evoID.enabled = false;
        evoImage.enabled = false;
        evoButton.enabled = false;
        if (evoIDBG != null)
            evoIDBG.enabled = false;
    }

    public void EvoButton()
    {
        if(evoSlot.sprite.name == "Split")
        {
            evoSplit.UpdateSplit(evoEntryUpdater.entry.pkName);
            evoSplit.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 100f ,0f);
        }
        else
            evoEntryUpdater.UpdateEntry(evoEntry.pkName);
    }

    public void SplitButton()
    {
        evoEntryUpdater.UpdateEntry(evoEntry.pkName);
        evoSplit.HideSplit();
    }
}
