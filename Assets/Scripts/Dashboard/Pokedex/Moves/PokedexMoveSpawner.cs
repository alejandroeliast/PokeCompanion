using System.Collections.Generic;
using UnityEngine;

namespace Pokedex
{
    public class PokedexMoveSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject previewPrefab;
        [SerializeField] private GameObject container;

        public void CreateMoves(List<moveClass> toSpawn)
        {
            for (int i = 0; i < toSpawn.Count; i++)
            {
                var obj = Instantiate(previewPrefab, Vector3.zero, Quaternion.identity, container.transform);

                PokedexMoveUpdater ddex = obj.GetComponent<PokedexMoveUpdater>();
                ddex.UpdateMove(toSpawn[i], obj);
            }
        }

        public void ClearMoves()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}