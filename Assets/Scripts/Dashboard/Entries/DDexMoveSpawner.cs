using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDexMoveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject previewPrefab;
    [SerializeField] private GameObject container;

    public void CreateMoves(List<moveClass> toSpawn)
    {
        for (int i = 0; i < toSpawn.Count; i++)
        {
            var obj = Instantiate(previewPrefab, Vector3.zero, Quaternion.identity, container.transform);

            DDexMoveUpdater ddex = obj.GetComponent<DDexMoveUpdater>();
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
