using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace Pokedex
{
    public class PokedexPreviewUpdater : MonoBehaviour
    {
        private GameObject _blur;
        private GameObject _entryGO;
        private PokedexEntry _entry;
        private IPreviewRenamer _renamer;
        private List<IItemUpdater> _itemUpdaters = new List<IItemUpdater>();

        public static event Action<string> OnAnyPreviewPressed;

        private void Awake()
        {
            _blur = GameObject.FindWithTag("Blur");
            _entryGO = GameObject.FindWithTag("Entry");
            _renamer = GetComponent<IPreviewRenamer>();

            foreach (var item in GetComponents<IItemUpdater>())
            {
                _itemUpdaters.Add(item);
            }
        }

        public void UpdatePreview(PokedexEntry entry, GameObject prefab)
        {
            _entry = entry;
            _renamer.RenamePreview(_entry, prefab);

            foreach (var item in _itemUpdaters)
            {
                item.UpdateItem(_entry);
            }
        }

        public void ActivateEntry()
        {
            _blur.GetComponent<Image>().enabled = true;
            _blur.transform.GetChild(0).gameObject.SetActive(true);
            _entryGO.transform.GetChild(0).gameObject.SetActive(true);
            OnAnyPreviewPressed?.Invoke(_entry.pkName);
        }
    }
}

//PokedexEntry  entry = Resources.Load<PokedexEntry>($"Scriptable Objects/Pokedex Entries/{name}");
//PokedexEntry  entry = (PokedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Resources/Scriptable Objects/Pokedex Entries/{name}.asset", typeof(PokedexEntry));