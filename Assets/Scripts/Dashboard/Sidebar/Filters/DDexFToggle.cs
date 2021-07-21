using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DDexFToggle : MonoBehaviour
{
    [SerializeField] private bool isInclusive = false;
    [SerializeField] private TextMeshProUGUI option1;
    [SerializeField] private TextMeshProUGUI option2;
    [SerializeField] private Color colorOn;
    [SerializeField] private Color colorOff;
    [SerializeField] private float toMove = 0f;

    [SerializeField] private DDexFManager rFManager;

    public void Interacted()
    {
        if(!isInclusive)
        {
            option1.color = colorOn;
            option2.color = colorOff;
            gameObject.transform.position = new Vector3(transform.position.x - toMove, transform.position.y);
            isInclusive = true;
        }
        else if (isInclusive)
        {
            option1.color = colorOff;
            option2.color = colorOn;
            gameObject.transform.position = new Vector3(transform.position.x + toMove, transform.position.y);
            isInclusive = false;
        }

        rFManager.TypeInclusive(isInclusive);
    }
}
