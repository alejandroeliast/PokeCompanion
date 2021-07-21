using UnityEngine;

namespace Pokedex
{
    public interface IPreviewRenamer
    {
        void RenamePreview(PokedexEntry entry, GameObject prefab);
    }

}
