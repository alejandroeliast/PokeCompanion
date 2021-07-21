using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSidebar : MonoBehaviour
{
    [SerializeField] private GameObject sbBody;
    [SerializeField] private GameObject sbHeader;
    [SerializeField] private GameObject sbNameSearch;
    [SerializeField] private GameObject sbFilters;
    [SerializeField] private GameObject sbButton;

    private bool isOpen = false;

    public void Move()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    private void Open()
    {
        sbHeader.SetActive(true);
        sbNameSearch.SetActive(true);
        sbFilters.SetActive(true);

        MoveComponent(sbBody, -330f);
        MoveComponent(sbHeader, -330f);
        MoveComponent(sbNameSearch, -330f);
        MoveComponent(sbFilters, -330f);
        MoveComponent(sbButton, -330f);
        isOpen = true;
    }

    private void Close()
    {
        MoveComponent(sbBody, 330f);
        MoveComponent(sbHeader, 330f);
        MoveComponent(sbNameSearch, 330f);
        MoveComponent(sbFilters, 330f);
        MoveComponent(sbButton, 330f);
        isOpen = false;

        sbHeader.SetActive(false);
        sbNameSearch.SetActive(false);
        sbFilters.SetActive(false);
    }

    private void MoveComponent(GameObject go, float mag)
    {
        go.transform.position = new Vector3(go.transform.position.x + mag, go.transform.position.y);
    }
}
