using UnityEngine;

[CreateAssetMenu(fileName = "New Movedex Entry", menuName = "Assets/Resources/New Movedex Entry")]
public class MovedexEntry : ScriptableObject
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
    public enum Category
    {
        Physical,
        Special,
        Support
    }
    public enum Range
    {
        Melee,
        Ranged,
        Self
    }
    public enum Attributes
    {
        Strength,
        Dexterity,
        Vitality,
        Special,
        Insight,
        Tough,
        Cool,
        Beauty,
        Cute,
        Clever,
        Brawl,
        Channel,
        Clash,
        Evasion,
        Alert,
        Athletic,
        Nature,
        Stealth,
        Allure,
        Etiquette,
        Intimidate,
        Perform,
        Will,
        None
    }
    public enum Effects
    {
        ChanceDice,
        AccuracyLow,
        AccuracyAllyUp,
        AccuracyAllyDown,
        AccuracyFoeUp,
        AccuracyFoeDown,
        Target,
        StrengthAllyUp,
        DexterityAllyUp,
        DefenseAllyUp,
        SpecialAllyUp,
        SpDefenseAllyUp,
        StrengthAllyDown,
        DexterityAllyDown,
        DefenseAllyDown,
        SpecialAllyDown,
        SpDefenseAllyDown,
        StrengthFoeUp,
        DexterityFoeUp,
        DefenseFoeUp,
        SpecialFoeUp,
        SpDefenseFoeUp,
        StrengthFoeDown,
        DexterityFoeDown,
        DefenseFoeDown,
        SpecialFoeDown,
        SpDefenseFoeDown,
        DamageUp,
        DamageDown,
        DamageInflict,
        Block,
        Charge,
        FistBased,
        HealBasic,
        HealComplete,
        HealFixedBasic,
        HealFixedComplete,
        HighCrit,
        Lethal,
        Recharge,
        NeverFail,
        Priority,
        PriorityLow,
        Rampage,
        Recoil,
        Shield,
        Sound,
        Paralysis,
        Burn1,
        Burn2,
        Burn3,
        Sleep,
        Poison,
        Poison2,
        Frozen,
        Flinch,
        Love,
        Confuse,
        Disable,
        CureStatus,
        Succesive,
        Switch,
        Weather,
        None
    }
    public enum Modifier
    {   
        Value1,
        Value2,
        Value3,
        Value4,
        Value5,
        Value6,
        CD1,
        CD2,
        CD3,
        CD4,
        CD5,
        Never,
        Always,
        User,
        Ally,
        AllyAll,
        Foe,
        FoeRandom,
        FoeAll,
        Area,
        Battlefield,
        Attack2,
        Attack5,
        Sunny,
        SunnyHarsh,
        Rain,
        Typhoon,
        Sandstorm,
        StrongWinds,
        Hail,
        None
    }

    public int moveID;
    public string moveName;
    public Types moveType;
    public int movePower;
    public Category moveCategory;
    public Range moveRange;
    public Attributes moveAccuracy1;
    public Attributes moveAccuracy2;
    public Attributes moveDamage;

    public Effects  moveEff1;
    public Modifier moveMod1;
    public Effects  moveEff2;
    public Modifier moveMod2;
    public Effects  moveEff3;
    public Modifier moveMod3;
    public Effects  moveEff4;
    public Modifier moveMod4;
    public Effects  moveEff5;
    public Modifier moveMod5;
    public Effects  moveEff6;
    public Modifier moveMod6;


}
