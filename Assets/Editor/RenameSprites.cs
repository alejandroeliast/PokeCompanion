using UnityEngine;
using UnityEditor;

public class RenameSprites : MonoBehaviour
{

    [MenuItem("Utilities/Rename Minis")]
    public static void RenameMinis()
    {
        PokedexIndex pFull = (PokedexIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Pokedex Full/Pokedex Full.asset", typeof(PokedexIndex));

        for (int i = 779; i < 801; i++)
        {
            int x = 17;

            if (i < 10)
            {
                AssetDatabase.RenameAsset($"Assets/Resources/Images/Portraits/{"00" + (i)}.png", $"{pFull.fullEntries[i+x].pkName}");
            }
            else if (i < 100 && i > 9)
            {
                AssetDatabase.RenameAsset($"Assets/Resources/Images/Portraits/{"0" + (i)}.png", $"{pFull.fullEntries[i+x].pkName}");
            }
            else
            {
                AssetDatabase.RenameAsset($"Assets/Resources/Images/Portraits/{(i)}.png", $"{pFull.fullEntries[i+x].pkName}");
            }
        }
    }
}
