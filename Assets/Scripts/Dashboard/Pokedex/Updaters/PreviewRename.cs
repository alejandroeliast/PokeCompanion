using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class PreviewRename : MonoBehaviour, IPreviewRenamer
    {
        public void RenamePreview(PokedexEntry entry, GameObject prefab)
        {
            if (entry.pkNumber < 10)
                prefab.name = "00" + entry.pkNumber.ToString() + " " + entry.name;
            else if (entry.pkNumber < 100 && entry.pkNumber > 9)
                prefab.name = "0" + entry.pkNumber.ToString() + " " + entry.name;
            else
                prefab.name = entry.pkNumber.ToString() + " " + entry.name;
        }
    }
}

