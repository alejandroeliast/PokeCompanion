using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Pokedex Entry", menuName = "Assets/Resources/New Pokedex Entry")]
public class PokedexEntry : ScriptableObject
{
    public enum Types
    {
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy,
        None
    }
    public enum Rank
    {
        Starter,
        Beginner,
        Amateur,
        Ace,
        Pro,
        Master,
        Champion,
        None
    }
    public enum EvoMethod
    {
        Fast,
        Medium,
        Slow,
        ThunderStone,
        MoonStone,
        FireStone,
        LeafStone,
        Happiness,
        WaterStone,
        IceStone,
        MaxSTR,
        MaxVIT,
        Trade,
        TradeItem,
        DifferentMethods,
        None
    }

    // --- Base Info ---
    public int      pkID;
    public int      pkNumber;
    public string   pkName;
    public string   pkSpecies;
    public Types    pkType1;
    public Types    pkType2;

    // --- About ---
    public float    pkHeight;
    public float    pkWeight;
    public string   pkAbility1;
    public string   pkAbility2;
    public string   pkEvoStage;
    public int      pkEvoQty;
    public string   pkEvoName1;
    public string   pkEvoName2;
    public string   pkEvoName3;
    public EvoMethod pkEvoMethod;

    // --- Stats ---
    public int pkMinStrength;
    public int pkMaxStrength;
    public int pkMinDexterity;
    public int pkMaxDexterity;
    public int pkMinVitality;
    public int pkMaxVitality;
    public int pkMinSpecial;
    public int pkMaxSpecial;
    public int pkMinInsight;
    public int pkMaxInsight;
    public int pkBaseHP;
    public Rank pkRank;

    // --- Origin ---
    public string pkOrigin;
    public int pkVariantAmount;
    public List<string> pkVariantNames;
    //public string varName1;
    //public string varName2;
    //public string varName3;

    // --- Moves ---
    //public MovedexEntry moveData1;
    //public Rank moveRank1;
    //public MovedexEntry moveData2;
    //public Rank moveRank2;

    //public List<MovedexEntry> moves;

    public List<moveClass> pkMoves;
}
[Serializable]
public class moveClass
{
    public MovedexEntry moveData;
    public PokedexEntry.Rank moveRank;

    public moveClass(MovedexEntry _moveData, PokedexEntry.Rank _moveRank)
    {
        moveData = _moveData;
        moveRank = _moveRank;
    }
}