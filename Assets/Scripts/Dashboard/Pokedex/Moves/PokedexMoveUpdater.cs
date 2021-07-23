using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pokedex
{
    public class PokedexMoveUpdater : MonoBehaviour
    {
        [SerializeField] private Image dmoveRank;
        [SerializeField] private Image dmoveType;
        [SerializeField] private TextMeshProUGUI dmoveName;

        public void UpdateMove(moveClass move, GameObject prefab)
        {
            dmoveRank.sprite = Resources.Load<Sprite>($"Images/Ranks/Minis/{move.moveRank}");
            dmoveType.sprite = Resources.Load<Sprite>($"Images/Types/Minis/{move.moveData.moveType}");
            dmoveName.SetText(move.moveData.moveName);
        }
    }
}