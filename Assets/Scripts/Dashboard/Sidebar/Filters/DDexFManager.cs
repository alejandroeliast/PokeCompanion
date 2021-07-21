using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pokedex;

public class DDexFManager : MonoBehaviour
{
    // Name
    private string stNameSearch = null;

    // Number Range
    [SerializeField] private DDexFRange sNumMin;
    [SerializeField] private DDexFRange sNumMax;
    private float valNumMin = 0;
    private float valNumMax = 801;

    // Type
    [SerializeField] private bool isInclusiveType = false;
    [SerializeField] private List<string> fType = new List<string>();

    // Sort Order States
    public enum State
    {
        Increase,
        Decrease,
        None
    }

    // Height Range
    [SerializeField] private DDexFInDecrease sHeightInDe;
    private State heightState = State.None;
    [SerializeField] private DDexFRange sHeightMin;
    [SerializeField] private DDexFRange sHeightMax;
    private float valHeightMin = 0;
    private float valHeightMax = 999.9f;

    // Weight Range
    [SerializeField] private DDexFInDecrease sWeightInDe;
    private State weightState = State.None;
    [SerializeField] private DDexFRange sWeightMin;
    [SerializeField] private DDexFRange sWeightMax;
    private float valWeightMin = 0;
    private float valWeightMax = 999.9f;

    //List and Spawner
    [SerializeField] private PokedexIndex fTemporary;
    [SerializeField] private PokedexIndex fFiltered;
    [SerializeField] private PokedexPreviewSpawner fPrevSpawner;

    private void Start()
    {
        fTemporary = Resources.Load<PokedexIndex>($"Scriptable Objects/Filter Index/Pokedex/Temporary");
        fTemporary.fullEntries.Clear();

        fFiltered = Resources.Load<PokedexIndex>($"Scriptable Objects/Filter Index/Pokedex/Filtered");
    }

    // Name
    public void SetNameString(string s)
    {
        stNameSearch = s;
        UpdateFilterList();
    }

    // Number Range
    public void RangeNumMin(float val)
    {
        valNumMin = val;

        if (val > valNumMax)
        {
            valNumMax = valNumMin;
            sNumMax.CorrectValue(valNumMax);
        }

        UpdateFilterList();
    }
    public void RangeNumMax(float val)
    {
        valNumMax = val;

        if (val < valNumMin)
        {
            valNumMin = valNumMax;
            sNumMin.CorrectValue(valNumMin);
        }

        UpdateFilterList();
    }

    // Type
    public void TypeInclusive(bool val)
    {
        isInclusiveType = val;

        UpdateFilterList();
    }
    public void TypeAdd(string type)
    {
        fType.Add(type);

        UpdateFilterList();
    }
    public void TypeRemove(string type)
    {
        for (int i = 0; i < fType.Count; i++)
        {
            if (fType.Contains(type))
            {
                fType.Remove(type);
            }
        }
        UpdateFilterList();
    }

    // Height
    public void RangeHeightMin(float val)
    {
        valHeightMin = val;

        if (val > valHeightMax)
        {
            valHeightMax = valHeightMin;
            sNumMax.CorrectValue(valHeightMax);
        }

        UpdateFilterList();
    }
    public void RangeHeightMax(float val)
    {
        valHeightMax = val;

        if (val < valHeightMin)
        {
            valHeightMin = valHeightMax;
            sNumMin.CorrectValue(valHeightMin);
        }

        UpdateFilterList();
    }

    // Weight
    public void RangeWeightMin(float val)
    {
        valWeightMin = val;

        if (val > valWeightMax)
        {
            valWeightMax = valWeightMin;
            sNumMax.CorrectValue(valWeightMax);
        }

        UpdateFilterList();
    }
    public void RangeWeightMax(float val)
    {
        valWeightMax = val;

        if (val < valWeightMin)
        {
            valWeightMin = valWeightMax;
            sNumMin.CorrectValue(valWeightMin);
        }

        UpdateFilterList();
    }

    // Sort Order Height/Weight
    public void SortHeight(State state)
    {
        heightState = state;
        weightState = State.None;
        sWeightInDe.SetState(State.None);

        UpdateFilterList();
    }
    public void SortWeight(State state)
    {
        weightState = state;
        heightState = State.None;
        sHeightInDe.SetState(State.None);

        UpdateFilterList();
    }


    // Update Filter
    public void UpdateFilterList()
    {
        // Reset Filters
        fFiltered.fullEntries.Clear();
        fTemporary.fullEntries.Clear();

        // Type Filter
        if (fType.Count > 0)
            FilterByType();

        // Organize filtered entries by ID number
        fFiltered.fullEntries = fFiltered.fullEntries.OrderBy(o => o.pkNumber).ToList();

        // Name Filter
        if(stNameSearch != null)
        if(stNameSearch.Length > 0)
            FilterByName();

        // Number Filter
        FilterByNumber();

        // Height & Weight Filter
        FilterByHeight();
        FilterByWeight();

        // Sort Height & Weight
        if (heightState == State.Decrease)
            fFiltered.fullEntries = fFiltered.fullEntries.OrderByDescending(o => o.pkHeight).ToList();
        else if (heightState == State.Increase)
            fFiltered.fullEntries = fFiltered.fullEntries.OrderBy(o => o.pkHeight).ToList();
        else if (weightState == State.Decrease)
            fFiltered.fullEntries = fFiltered.fullEntries.OrderByDescending(o => o.pkWeight).ToList();
        else if (weightState == State.Increase)
            fFiltered.fullEntries = fFiltered.fullEntries.OrderBy(o => o.pkWeight).ToList();


        // If no filter is active, reset the list
        if (fType.Count <= 0 && string.IsNullOrEmpty(stNameSearch) && (valNumMin == 0 && valNumMax == 801) && (valHeightMin == 0 && valHeightMax == 999.9) && (valWeightMin == 0 && valWeightMax == 999.9))
        {
            fFiltered.fullEntries.Clear();
            fTemporary.fullEntries.Clear();
            fPrevSpawner.ResetPreviews();
        }
        else
            fPrevSpawner.FilterPreviews(fFiltered);
    }

    public void FilterByName()
    {
        PokedexIndex _temp;
        if (fType.Count <= 0)
        {
            Debug.Log("Empty");
            //fFiltered.fullEntries.Clear();
            _temp = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");
            fTemporary.fullEntries.Clear();
            for (int i = 0; i < _temp.fullEntries.Count; i++)
                fTemporary.fullEntries.Add(_temp.fullEntries[i]);

            fFiltered.fullEntries.Clear();
            for (int i = 0; i < fTemporary.fullEntries.Count; i++)
            {
                if (fTemporary.fullEntries[i].pkName.ToLower().Contains(stNameSearch.ToLower()))
                {
                    fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
                }
            }
        }
        else
        {
            Debug.Log("Full");
            FilteredToTemporary();
        
            fFiltered.fullEntries.Clear();
            for (int i = 0; i < fTemporary.fullEntries.Count; i++)
            {
                if (fTemporary.fullEntries[i].pkName.ToLower().Contains(stNameSearch.ToLower()))
                {
                    fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
                }
            }
        }

    }

    public void FilterByType()
    {
        // Type Filters
        PokedexIndex _temp;
        for (int x = 0; x < fType.Count; x++)
        {
            _temp = Resources.Load<PokedexIndex>($"Scriptable Objects/Filter Index/Pokedex/Types/{fType[x]}");
            if (_temp != null)
            {
                if (!isInclusiveType)
                {
                    for (int y = 0; y < _temp.fullEntries.Count; y++)
                    {
                        if (!fFiltered.fullEntries.Contains(_temp.fullEntries[y]))
                            fFiltered.fullEntries.Add(_temp.fullEntries[y]);
                    }
                }
                else if (isInclusiveType)
                {
                    if (fType.Count >= 1)
                    {
                        _temp = Resources.Load<PokedexIndex>($"Scriptable Objects/Filter Index/Pokedex/Types/{fType[0]}");
                        for (int y = 0; y < _temp.fullEntries.Count; y++)
                        {
                            if (!fFiltered.fullEntries.Contains(_temp.fullEntries[y]))
                                fFiltered.fullEntries.Add(_temp.fullEntries[y]);
                        }
                    }
                }
            }
        }

        // If inclusive, check amount of Types
        if (isInclusiveType)
        {
            // If more than 1 type, filter for entries with both types
            if (fType.Count > 1)
            {
                fTemporary.fullEntries.Clear();
                for (int a = 0; a < fFiltered.fullEntries.Count; a++)
                {
                    bool _bool = true;
                    for (int b = 0; b < fType.Count; b++)
                    {
                        if (fFiltered.fullEntries[a].pkType1.ToString() == fType[b] || fFiltered.fullEntries[a].pkType2.ToString() == fType[b])
                            _bool = true;
                        else
                            _bool = false;
                    }
                    if (_bool)
                    {
                        fTemporary.fullEntries.Add(fFiltered.fullEntries[a]);
                    }
                }

                fFiltered.fullEntries.Clear();
                for (int i = 0; i < fTemporary.fullEntries.Count; i++)
                {
                    fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
                }
            }

            // If more than 2 types, clear the filter as no entry is allowed more than 2
            if (fType.Count > 2)
            {
                fFiltered.fullEntries.Clear();
                fTemporary.fullEntries.Clear();
            }
        }
    }

    public void FilterByNumber()
    {
        PokedexIndex _temp;
        //If no types are being filtered, use the full list
        if (fType.Count <= 0 && string.IsNullOrEmpty(stNameSearch))
        {
            _temp = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");

            int lowNum = (int)(valNumMin - 20);
            int highNum = (int)(valNumMax + 20);

            if (lowNum < 0)
                lowNum = 0;
            if (highNum > 801)
                highNum = 801;

            for (int i = lowNum; i < highNum; i++)
            {
                if (_temp.fullEntries[i].pkNumber >= valNumMin && _temp.fullEntries[i].pkNumber <= valNumMax)
                    fFiltered.fullEntries.Add(_temp.fullEntries[i]);
            }
        }
        // Otherwise, use the already filtered list
        else
        {
            FilteredToTemporary();

            fFiltered.fullEntries.Clear();
            for (int i = 0; i < fTemporary.fullEntries.Count; i++)
            {
                if (fTemporary.fullEntries[i].pkNumber >= valNumMin && fTemporary.fullEntries[i].pkNumber <= valNumMax)
                    fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
            }
        }
    }

    public void FilterByHeight()
    {
        // Filter Height
        FilteredToTemporary();
        fFiltered.fullEntries.Clear();
        for (int i = 0; i < fTemporary.fullEntries.Count; i++)
        {
            if (fTemporary.fullEntries[i].pkHeight >= valHeightMin && fTemporary.fullEntries[i].pkHeight <= valHeightMax)
                fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
        }
    }

    public void FilterByWeight()
    {
        // Filter Weight
        FilteredToTemporary();

        fFiltered.fullEntries.Clear();
        for (int i = 0; i < fTemporary.fullEntries.Count; i++)
        {
            if (fTemporary.fullEntries[i].pkWeight >= valWeightMin && fTemporary.fullEntries[i].pkWeight <= valWeightMax)
                fFiltered.fullEntries.Add(fTemporary.fullEntries[i]);
        }
    }


    // Clear Temporary and repopulate it with values currently in Filtered
    public void FilteredToTemporary()
    {
        fTemporary.fullEntries.Clear();
        for (int i = 0; i < fFiltered.fullEntries.Count; i++)
            fTemporary.fullEntries.Add(fFiltered.fullEntries[i]);
    }

}
