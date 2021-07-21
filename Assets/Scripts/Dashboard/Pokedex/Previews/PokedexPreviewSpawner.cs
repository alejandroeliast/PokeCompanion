using UnityEngine;
using Lean.Pool;
using System.Collections.Generic;

namespace Pokedex
{
    public class PokedexPreviewSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject container;

        private PokedexIndex _indexFull;
        private List<GameObject> _spawned = new List<GameObject>();

        private void Start()
        {
            _indexFull = Resources.Load<PokedexIndex>("Scriptable Objects/Pokedex Index/Pokedex Full");
            SpawnPreviews(_indexFull);
        }

        private void SpawnPreviews(PokedexIndex toSpawn)
        {
            _spawned.Clear();
            foreach (var entry in toSpawn.fullEntries)
            {
                var obj = LeanPool.Spawn(prefab, Vector3.zero, Quaternion.identity, container.transform);

                _spawned.Add(obj);
                PokedexPreviewUpdater ddex = obj.GetComponent<PokedexPreviewUpdater>();
                ddex.UpdatePreview(entry, obj);
            }
        }

        public void FilterPreviews(PokedexIndex region)
        {
            ClearPreviews();
            SpawnPreviews(region);
        }

        public void ResetPreviews()
        {
            ClearPreviews();
            SpawnPreviews(_indexFull);
        }

        private void ClearPreviews()
        {
            foreach (GameObject child in _spawned)
                LeanPool.Despawn(child.gameObject);
        }
    }
}