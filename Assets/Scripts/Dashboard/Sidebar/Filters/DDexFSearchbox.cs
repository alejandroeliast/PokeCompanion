using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Pokedex;

public class DDexFSearchbox : MonoBehaviour
{
    //List and Spawner
    [SerializeField] private PokedexIndex fTemporary;
    [SerializeField] private PokedexIndex fFiltered;
    [SerializeField] private PokedexPreviewSpawner fPrevSpawner;
    [SerializeField] private DDexFManager fManager;

    [SerializeField] private TMP_InputField inputField;
    private int inputLength = 0;

    public void SearchEntry()
    {
        fManager.SetNameString(inputField.text);

        //if(inputField.text.Length < inputLength)
        //    fManager.UpdateFilterList();

        //fTemporary.fullEntries.Clear();
        //for (int i = 0; i < fFiltered.fullEntries.Count; i++)
        //    fTemporary.fullEntries.Add(fFiltered.fullEntries[i]);

        //fFiltered.fullEntries.Clear();
        //for (int i = 0; i < fTemporary.fullEntries.Count; i++)
        //{
        //    if (fTemporary.fullEntries[i].namePoke.ToLower().Contains(inputField.text.ToLower()))
        //    {
        //        Debug.Log("Contains: " + inputField.text);
        //        fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
        //    }
        //}

        //if (string.IsNullOrEmpty(inputField.text))
        //    fManager.UpdateFilterList();
        //else
        //    fPrevSpawner.FilterPreviews(fFiltered);

        //inputLength = inputField.text.Length;
    }

    public void ButtonSearch()
    {
        SearchEntry();
    }
}