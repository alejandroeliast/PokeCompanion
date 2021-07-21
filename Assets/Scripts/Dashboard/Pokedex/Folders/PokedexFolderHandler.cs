using RotaryHeart.Lib.SerializableDictionaryPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class PokedexFolderHandler : MonoBehaviour
    {
        private Dictionary<int, PokedexFolder> _all = new Dictionary<int, PokedexFolder>();
        private Dictionary<int, PokedexFolder> _active = new Dictionary<int, PokedexFolder>();

        private SortedDictionary<int, PokedexEntry> _filtered = new SortedDictionary<int, PokedexEntry>();

        [SerializeField] private PokedexPreviewSpawner _spawner;

        private void Awake()
        {
            int key = 0;
            foreach (var go in GameObject.FindGameObjectsWithTag("Folder"))
            {
                PokedexFolder folder = go.GetComponent<PokedexFolder>();
                folder.SetID(key);
                _all.Add(key, folder);
                key++;
            }
        }

        private void OnEnable()
        {
            PokedexFolder.OnSelected += FolderSelect;
            PokedexFolder.OnShiftSelected += FolderShiftSelect;
            PokedexFolder.OnDeselected += FolderDeselect;
        }

        private void OnDisable()
        {
            PokedexFolder.OnSelected -= FolderSelect;
            PokedexFolder.OnShiftSelected -= FolderShiftSelect;
            PokedexFolder.OnDeselected -= FolderDeselect;
        }

        //public void FolderSelect(int region)
        //{
        //    if (_activeFolder == _regionFolders[region])
        //    {
        //        _activeFolder.FolderClear();
        //        _activeFolder = null;
        //    }
        //    else
        //    {
        //        _activeFolder = _regionFolders[region];

        //        foreach (var folder in _regionFolders)
        //        {
        //            if (folder != _activeFolder)
        //            {
        //                folder.IsActive = false;
        //                folder.FolderDeselect();
        //            }
        //        }

        //        _regionFolders[region].FolderSelect();
        //    }
        //}

        private void FolderSelect(int id)
        {
            foreach (var folder in _active)
            {
                folder.Value.SetDeselected();
            }
            _active.Clear();
            _active.Add(id, _all[id]);

            CreateFilteredList();
        }

        private void FolderShiftSelect(int id)
        {
            if (!_active.ContainsKey(id))
            {
                _active.Add(id, _all[id]);
            }

            CreateFilteredList();
        }

        private void FolderDeselect(int id)
        {
            if (_active.ContainsKey(id))
            {
                _active.Remove(id);
            }

            CreateFilteredList();
        }

        private void FilterFolders()
        {
            List<PokedexIndex> toFilter = new List<PokedexIndex>();

            foreach (var folder in _active)
            {
                toFilter.Add(folder.Value.Index);
            }

            _filtered.Clear();
            foreach (var index in toFilter)
            {
                foreach (var entry in index.fullEntries)
                {
                    if (!_filtered.ContainsKey(entry.pkID))
                    {
                        _filtered.Add(entry.pkID, entry);
                    }
                }
            }
        }

        private void CreateFilteredList()
        {
            if (_active.Count > 0)
            {
                FilterFolders();
                List<PokedexEntry> toPassEntries = new List<PokedexEntry>();

                foreach (var entry in _filtered)
                {
                    toPassEntries.Add(entry.Value);
                }

                PokedexIndex toPass = new PokedexIndex(toPassEntries);
                _spawner.FilterPreviews(toPass);
            }
            else
            {
                PokedexIndex toPass = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");
                _spawner.FilterPreviews(toPass);
            }
        }
    }
}