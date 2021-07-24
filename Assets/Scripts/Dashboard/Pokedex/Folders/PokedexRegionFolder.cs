using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class PokedexRegionFolder : PokedexFolder
    {
        protected override void Start()
        {
            Index = Resources.Load<PokedexIndex>($"Scriptable Objects/Pokedex Index/{"Pokedex " + transform.name}");
            base.Start();
        }
    }
}