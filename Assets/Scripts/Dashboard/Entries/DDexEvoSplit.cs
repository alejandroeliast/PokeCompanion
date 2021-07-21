using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDexEvoSplit : MonoBehaviour
{
    [SerializeField] private EvoSplit            esEntry;
    [SerializeField] private Image               esBody;
    [SerializeField] private GameObject          esSlotParent;
    [SerializeField] private List<DDexEvolution> esSlots = new List<DDexEvolution>();
    [SerializeField] private Button esButton;
    [SerializeField] private Image esButtonImage;

    public void UpdateSplit(string name)
    {
        esEntry = Resources.Load<EvoSplit>($"Scriptable Objects/Evolution Splits/{name}");

        esBody.enabled = true;
        esBody.sprite = Resources.Load<Sprite>($"Images/Evolution/{esEntry.splitQuantity + "Body"}");
        esBody.SetNativeSize();

        esButton.enabled = true;
        esButtonImage.enabled = true;

        esSlotParent.SetActive(true);

        for (int i = 0; i < esSlots.Count; i++)
        {
            esSlots[i].HideEvoSlot();
        }

        if (esEntry.splitQuantity == 2)
            UpdateTwo();
        else if (esEntry.splitQuantity == 3)
            UpdateThree();
    }

    public void UpdateTwo()
    {
        List<Vector3> pos = new List<Vector3>() { new Vector3(-50, 5, 0), new Vector3(50, 5, 0) };

        for (int i = 0; i < 2; i++)
        {
            esSlots[i].gameObject.transform.localPosition = pos[i];
            esSlots[i].UpdateSplitSlot(esEntry.splitEvos[i].pkName);
        }
    }

    public void UpdateThree()
    {
        List<Vector3> pos = new List<Vector3>() { new Vector3(-100, 5, 0), new Vector3(0, 5, 0), new Vector3(100, 5, 0) };

        for (int i = 0; i < 3; i++)
        {
            esSlots[i].gameObject.transform.localPosition = pos[i];
            esSlots[i].UpdateSplitSlot(esEntry.splitEvos[i].pkName);
        }
    }

    public void HideSplit()
    {
        esBody.enabled = false;
        esButton.enabled = false;
        esButtonImage.enabled = false;
        esSlotParent.SetActive(false);
    }
}
