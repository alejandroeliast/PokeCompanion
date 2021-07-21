using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;

public class CSVtoSO
{
    private static string pokedexCSVPath = "/Editor/CSVs/PokedexCSV.csv";
    private static string megadexCSVPath = "/Editor/CSVs/MegadexCSV.csv";
    private static string splitdexCSVPath = "/Editor/CSVs/EvoSplitCSV.csv";
    private static string movedexCSVPath = "/Editor/CSVs/MovedexCSV.csv";
    private static string typesCSVPath = "/Editor/CSVs/TypesCSV.csv";

    [MenuItem("Utilities/Generate Pokedex Entries")]
    public static void GeneratePokedexEntries()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + pokedexCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            PokedexEntry pokedexEntry = ScriptableObject.CreateInstance<PokedexEntry>();

            // --- Base Info ---
            pokedexEntry.pkID = int.Parse(splitData[0]);
            pokedexEntry.pkNumber = int.Parse(splitData[1]);
            pokedexEntry.pkName = splitData[2];
            pokedexEntry.pkSpecies = splitData[3];
            pokedexEntry.pkType1 = (PokedexEntry.Types)Enum.Parse(typeof(PokedexEntry.Types), splitData[4]);
            pokedexEntry.pkType2 = (PokedexEntry.Types)Enum.Parse(typeof(PokedexEntry.Types), splitData[5]);
            // --- About --- 
            pokedexEntry.pkHeight = float.Parse(splitData[6]);
            pokedexEntry.pkWeight = float.Parse(splitData[7]);
            pokedexEntry.pkAbility1 = splitData[8];
            pokedexEntry.pkAbility2 = splitData[9];
            pokedexEntry.pkEvoStage = splitData[10];
            pokedexEntry.pkEvoQty = int.Parse(splitData[11]);
            pokedexEntry.pkEvoName1 = splitData[12];
            pokedexEntry.pkEvoName2 = splitData[13];
            pokedexEntry.pkEvoName3 = splitData[14];
            pokedexEntry.pkEvoMethod = (PokedexEntry.EvoMethod)Enum.Parse(typeof(PokedexEntry.EvoMethod), splitData[15]);
            // --- Stats --- 
            pokedexEntry.pkMinStrength = int.Parse(splitData[16]);
            pokedexEntry.pkMaxStrength = int.Parse(splitData[17]);
            pokedexEntry.pkMinDexterity = int.Parse(splitData[18]);
            pokedexEntry.pkMaxDexterity = int.Parse(splitData[19]);
            pokedexEntry.pkMinVitality = int.Parse(splitData[20]);
            pokedexEntry.pkMaxVitality = int.Parse(splitData[21]);
            pokedexEntry.pkMinSpecial = int.Parse(splitData[22]);
            pokedexEntry.pkMaxSpecial = int.Parse(splitData[23]);
            pokedexEntry.pkMinInsight = int.Parse(splitData[24]);
            pokedexEntry.pkMaxInsight = int.Parse(splitData[25]);
            pokedexEntry.pkBaseHP = int.Parse(splitData[26]);

            pokedexEntry.pkRank = (PokedexEntry.Rank)Enum.Parse(typeof(PokedexEntry.Rank), splitData[27]);

            pokedexEntry.pkOrigin = splitData[28];
            pokedexEntry.pkVariantAmount = int.Parse(splitData[29]);

            pokedexEntry.pkVariantNames = new List<string>();
            for (int i = 30; i < pokedexEntry.pkVariantAmount + 30; i++)
            {
                pokedexEntry.pkVariantNames.Add(splitData[i]);
            }

            //pokedexEntry.moveData1 = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Movedex Entries/{splitData[27]}.asset", typeof(MovedexEntry));
            //pokedexEntry.moveRank1 = (PokedexEntry.Rank)System.Enum.Parse(typeof(PokedexEntry.Rank), splitData[28]);
            //pokedexEntry.moveData2 = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Movedex Entries/{splitData[29]}.asset", typeof(MovedexEntry));
            //pokedexEntry.moveRank2 = (PokedexEntry.Rank)System.Enum.Parse(typeof(PokedexEntry.Rank), splitData[30]);

            int toLoop = 0;
            for (int i = 33; i < splitData.Length; i++)
            {
                if(splitData[i] != "")
                {
                    toLoop++;
                }
                i++;
            }

            pokedexEntry.pkMoves = new List<moveClass>();
            int n = 33;
            int m = 34;

            for (int i = 0; i < toLoop; i++)
            {

                MovedexEntry _move = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Movedex Entries/{splitData[n]}.asset", typeof(MovedexEntry));
                PokedexEntry.Rank _rank = (PokedexEntry.Rank)Enum.Parse(typeof(PokedexEntry.Rank), splitData[m]);

                moveClass _temp = new moveClass(_move, _rank);                
                pokedexEntry.pkMoves.Add(_temp);

                n += 2;
                m += 2;
            }
            AssetDatabase.CreateAsset(pokedexEntry, $"Assets/Resources/Scriptable Objects/Pokedex Entries/{pokedexEntry.pkName}.asset");
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Megadex Entries")]
    public static void GenerateMegadexEntries()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + megadexCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            PokedexEntry megadexEntry = ScriptableObject.CreateInstance<PokedexEntry>();

            // --- Base Info ---
            megadexEntry.pkNumber = int.Parse(splitData[0]);
            megadexEntry.pkName = splitData[1];
            megadexEntry.pkSpecies = splitData[2];
            megadexEntry.pkType1 = (PokedexEntry.Types)Enum.Parse(typeof(PokedexEntry.Types), splitData[3]);
            megadexEntry.pkType2 = (PokedexEntry.Types)Enum.Parse(typeof(PokedexEntry.Types), splitData[4]);
            // --- About --- 
            megadexEntry.pkHeight = float.Parse(splitData[5]);
            megadexEntry.pkWeight = float.Parse(splitData[6]);
            megadexEntry.pkAbility1 = splitData[7];
            megadexEntry.pkAbility2 = splitData[8];
            megadexEntry.pkEvoStage = splitData[9];
            megadexEntry.pkEvoQty = int.Parse(splitData[10]);
            megadexEntry.pkEvoName1 = splitData[11];
            megadexEntry.pkEvoName2 = splitData[12];
            megadexEntry.pkEvoName3 = splitData[13];
            megadexEntry.pkEvoMethod = (PokedexEntry.EvoMethod)Enum.Parse(typeof(PokedexEntry.EvoMethod), splitData[14]);
            // --- Stats --- 
            megadexEntry.pkMinStrength = int.Parse(splitData[15]);
            megadexEntry.pkMaxStrength = int.Parse(splitData[16]);
            megadexEntry.pkMinDexterity = int.Parse(splitData[17]);
            megadexEntry.pkMaxDexterity = int.Parse(splitData[18]);
            megadexEntry.pkMinVitality = int.Parse(splitData[19]);
            megadexEntry.pkMaxVitality = int.Parse(splitData[20]);
            megadexEntry.pkMinSpecial = int.Parse(splitData[21]);
            megadexEntry.pkMaxSpecial = int.Parse(splitData[22]);
            megadexEntry.pkMinInsight = int.Parse(splitData[23]);
            megadexEntry.pkMaxInsight = int.Parse(splitData[24]);
            megadexEntry.pkBaseHP = int.Parse(splitData[25]);

            megadexEntry.pkRank = (PokedexEntry.Rank)Enum.Parse(typeof(PokedexEntry.Rank), splitData[26]);

            megadexEntry.pkOrigin = splitData[27];
            megadexEntry.pkVariantAmount = int.Parse(splitData[28]);

            megadexEntry.pkVariantNames = new List<string>();
            for (int i = 29; i < megadexEntry.pkVariantAmount + 29; i++)
            {
                megadexEntry.pkVariantNames.Add(splitData[i]);
            }

            //pokedexEntry.moveData1 = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Movedex Entries/{splitData[27]}.asset", typeof(MovedexEntry));
            //pokedexEntry.moveRank1 = (PokedexEntry.Rank)System.Enum.Parse(typeof(PokedexEntry.Rank), splitData[28]);
            //pokedexEntry.moveData2 = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Movedex Entries/{splitData[29]}.asset", typeof(MovedexEntry));
            //pokedexEntry.moveRank2 = (PokedexEntry.Rank)System.Enum.Parse(typeof(PokedexEntry.Rank), splitData[30]);

            int toLoop = 0;
            for (int i = 32; i < splitData.Length; i++)
            {
                if (splitData[i] != "")
                {
                    toLoop++;
                }
                i++;
            }

            megadexEntry.pkMoves = new List<moveClass>();
            int n = 32;
            int m = 33;

            for (int i = 0; i < toLoop; i++)
            {

                MovedexEntry _move = (MovedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Movedex Entries/{splitData[n]}.asset", typeof(MovedexEntry));
                PokedexEntry.Rank _rank = (PokedexEntry.Rank)Enum.Parse(typeof(PokedexEntry.Rank), splitData[m]);

                moveClass _temp = new moveClass(_move, _rank);
                megadexEntry.pkMoves.Add(_temp);

                n += 2;
                m += 2;
            }
            AssetDatabase.CreateAsset(megadexEntry, $"Assets/Resources/Scriptable Objects/Pokedex Entries/{megadexEntry.pkName}.asset");
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Evolution Split")]
    public static void GenerateEvolutionSplits()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + splitdexCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            EvoSplit evoSplit = ScriptableObject.CreateInstance<EvoSplit>();

            // --- Base Info ---
            evoSplit.splitName = (PokedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Pokedex Entries/{splitData[0]}.asset", typeof(PokedexEntry));
            evoSplit.splitQuantity = int.Parse(splitData[1]);

            evoSplit.splitEvos = new List<PokedexEntry>();
            for (int i = 2; i < evoSplit.splitQuantity + 2; i++)
            {
                PokedexEntry _temp = (PokedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Pokedex Entries/{splitData[i]}.asset", typeof(PokedexEntry));
                evoSplit.splitEvos.Add(_temp);
            }

            AssetDatabase.CreateAsset(evoSplit, $"Assets/Resources/Scriptable Objects/Evolution Splits/{evoSplit.splitName.pkName}.asset");
        }
        AssetDatabase.SaveAssets();
    }


    [MenuItem("Utilities/Generate Movedex Entries")]
    public static void GenerateMovedexEntries()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + movedexCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            MovedexEntry movedexEntry = ScriptableObject.CreateInstance<MovedexEntry>();

            // --- Base Info ---
            movedexEntry.moveID = int.Parse(splitData[0]);
            movedexEntry.moveName = splitData[1];
            movedexEntry.moveType = (MovedexEntry.Types)System.Enum.Parse(typeof(PokedexEntry.Types), splitData[2]);
            movedexEntry.movePower = int.Parse(splitData[3]);
            movedexEntry.moveCategory = (MovedexEntry.Category)System.Enum.Parse(typeof(MovedexEntry.Category), splitData[4]);
            movedexEntry.moveRange = (MovedexEntry.Range)System.Enum.Parse(typeof(MovedexEntry.Range), splitData[5]);
            movedexEntry.moveAccuracy1 = (MovedexEntry.Attributes)System.Enum.Parse(typeof(MovedexEntry.Attributes), splitData[6]);
            movedexEntry.moveAccuracy2 = (MovedexEntry.Attributes)System.Enum.Parse(typeof(MovedexEntry.Attributes), splitData[7]);
            movedexEntry.moveDamage = (MovedexEntry.Attributes)System.Enum.Parse(typeof(MovedexEntry.Attributes), splitData[8]);

            // --- Effects & Modifiers --- 
            movedexEntry.moveEff1 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[9]);
            movedexEntry.moveMod1 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[10]);
            movedexEntry.moveEff2 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[11]);
            movedexEntry.moveMod2 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[12]);
            movedexEntry.moveEff3 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[13]);
            movedexEntry.moveMod3 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[14]);
            movedexEntry.moveEff4 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[15]);
            movedexEntry.moveMod4 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[16]);
            movedexEntry.moveEff5 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[17]);
            movedexEntry.moveMod5 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[18]);
            movedexEntry.moveEff6 = (MovedexEntry.Effects)System.Enum.Parse(typeof(MovedexEntry.Effects), splitData[19]);
            movedexEntry.moveMod6 = (MovedexEntry.Modifier)System.Enum.Parse(typeof(MovedexEntry.Modifier), splitData[20]);

            AssetDatabase.CreateAsset(movedexEntry, $"Assets/Resources/Scriptable Objects/Movedex Entries/{movedexEntry.moveName}.asset");
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Pokedex Index")]
    public static void GeneratePokedexIndex()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + pokedexCSVPath);

        PokedexIndex pokedexFull = ScriptableObject.CreateInstance<PokedexIndex>();
        pokedexFull.fullEntries = new List<PokedexEntry>();

        for (int i = 0; i < allLines.Length; i++)
        {
            string[] splitData = allLines[i].Split(',');

            pokedexFull.fullEntries.Add((PokedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Pokedex Entries/{splitData[2]}.asset", typeof(PokedexEntry)));
        }

        AssetDatabase.CreateAsset(pokedexFull, $"Assets/Resources/Scriptable Objects/Pokedex Index/Pokedex Full.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Pokedex Regions")]
    public static void GeneratePokedexRegions()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + pokedexCSVPath);

        List<RegionIndex> regions = new List<RegionIndex>();

        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Kanto.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Johto.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Hoenn.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Sinnoh.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Unova.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Kalos.asset", typeof(RegionIndex)));
        regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Alola.asset", typeof(RegionIndex)));
        //regions.Add((RegionIndex)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Region Index/Galar.asset", typeof(RegionIndex)));

        for (int i = 0; i < regions.Count; i++)
        {
            PokedexIndex pokedexFull = ScriptableObject.CreateInstance<PokedexIndex>();
            pokedexFull.fullEntries = new List<PokedexEntry>();

            int start = regions[i].regionStart - 1;
            int end = regions[i].regionEnd;

            for (int s = start; s < end; s++)
            {
                string[] splitData = allLines[s].Split(',');
                pokedexFull.fullEntries.Add((PokedexEntry)AssetDatabase.LoadAssetAtPath($"Assets/Resources/Scriptable Objects/Pokedex Entries/{splitData[2]}.asset", typeof(PokedexEntry)));
            }
            AssetDatabase.CreateAsset(pokedexFull, $"Assets/Resources/Scriptable Objects/Pokedex Index/{"Pokedex " + regions[i].regionName}.asset");
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Types")]
    public static void GenerateTypes()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + typesCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            Type type = ScriptableObject.CreateInstance<Type>();

            // --- Base Info ---
            //pokedexEntry.moves = new List<moveClass>();
            type.typeName = splitData[0];

            type.typeNormal = new int[2];
            type.typeNormal[0] = int.Parse(splitData[1]);
            type.typeNormal[1] = int.Parse(splitData[2]);

            type.typeFighting = new int[2];
            type.typeFighting[0] = int.Parse(splitData[3]);
            type.typeFighting[1] = int.Parse(splitData[4]);

            type.typeFlying = new int[2];
            type.typeFlying[0] = int.Parse(splitData[5]);
            type.typeFlying[1] = int.Parse(splitData[6]);

            type.typePoison = new int[2];
            type.typePoison[0] = int.Parse(splitData[7]);
            type.typePoison[1] = int.Parse(splitData[8]);

            type.typeGround = new int[2];
            type.typeGround[0] = int.Parse(splitData[9]);
            type.typeGround[1] = int.Parse(splitData[10]);

            type.typeRock = new int[2];
            type.typeRock[0] = int.Parse(splitData[11]);
            type.typeRock[1] = int.Parse(splitData[12]);

            type.typeBug = new int[2];
            type.typeBug[0] = int.Parse(splitData[13]);
            type.typeBug[1] = int.Parse(splitData[14]);

            type.typeGhost = new int[2];
            type.typeGhost[0] = int.Parse(splitData[15]);
            type.typeGhost[1] = int.Parse(splitData[16]);

            type.typeSteel = new int[2];
            type.typeSteel[0] = int.Parse(splitData[17]);
            type.typeSteel[1] = int.Parse(splitData[18]);

            type.typeFire = new int[2];
            type.typeFire[0] = int.Parse(splitData[19]);
            type.typeFire[1] = int.Parse(splitData[20]);

            type.typeWater = new int[2];
            type.typeWater[0] = int.Parse(splitData[21]);
            type.typeWater[1] = int.Parse(splitData[22]);

            type.typeGrass = new int[2];
            type.typeGrass[0] = int.Parse(splitData[23]);
            type.typeGrass[1] = int.Parse(splitData[24]);

            type.typeElectric = new int[2];
            type.typeElectric[0] = int.Parse(splitData[25]);
            type.typeElectric[1] = int.Parse(splitData[26]);

            type.typePsychic = new int[2];
            type.typePsychic[0] = int.Parse(splitData[27]);
            type.typePsychic[1] = int.Parse(splitData[28]);

            type.typeIce = new int[2];
            type.typeIce[0] = int.Parse(splitData[29]);
            type.typeIce[1] = int.Parse(splitData[30]);

            type.typeDragon = new int[2];
            type.typeDragon[0] = int.Parse(splitData[31]);
            type.typeDragon[1] = int.Parse(splitData[32]);

            type.typeDark = new int[2];
            type.typeDark[0] = int.Parse(splitData[33]);
            type.typeDark[1] = int.Parse(splitData[34]);

            type.typeFairy = new int[2];
            type.typeFairy[0] = int.Parse(splitData[35]);
            type.typeFairy[1] = int.Parse(splitData[36]);

            AssetDatabase.CreateAsset(type, $"Assets/Resources/Scriptable Objects/Types/{type.typeName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}