using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class PokedexCustomFolder : PokedexFolder
    {
        protected override void Start()
        {
            Index = Resources.Load<PokedexIndex>($"Scriptable Objects/Folders/{transform.name}");
            print(Index);
            base.Start();
        }
    }
}