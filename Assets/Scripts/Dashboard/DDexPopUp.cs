using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DDexPopUp : MonoBehaviour
{
    [SerializeField] private Image popImage;
    [SerializeField] private TextMeshProUGUI popText;

    public void ShowMarkPopUp(GameObject go)
    {
        EnableAndMove(go, 35f);

        popImage.sprite = Resources.Load<Sprite>($"Images/Marks/PopUps/PopUp");

        Image img = go.GetComponent<Image>();        
        popText.SetText(img.sprite.name);
    }

    public void ShowTypePopUp(GameObject go)
    {
        EnableAndMove(go, 35f);
        popText.enabled = false;

        Image img = go.GetComponent<Image>();
        popImage.sprite = Resources.Load<Sprite>($"Images/Types/PopUps/{img.sprite.name}");        
    }

    void EnableAndMove(GameObject go,float y)
    {
        popImage.enabled = true;
        popText.enabled = true;

        popImage.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + y, 0);
    }

    public void HidePopUp()
    {
        popImage.enabled = false;
        popText.enabled = false;
    }
}
