public enum LevelUsedType
{
    SELECTING,
    TESTING
}

public enum MateType
{
    Normal = 0,
    Sword = 1,
    Bow = 2,
    Shield = 3,
    Viking = 4,
    Katana = 5
}

public enum EnemyType
{
    Normal = 0,
    Boss = 1,
    Boss2 = 2
}

public enum LineFightType
{
    Combat = 0,
    Boss = 1
}

public enum GameState
{
    Normal = 0,
    Moving = 1,
    Win = 2,
    Lose = 3,
    PrepareCombat = 5,
    Combating = 6
}

public enum SettingType
{
    Vibration,
    Music,
    Sound
}

public enum SoundType
{
    BackgroundInGame,
    BackgroundHome,
    ButtonClick,
    Win,
    Lose,
}

public enum DailyRewardType
{
    Coin,
    Diamond,
    Skin
}

public enum DailyRewardItemState
{
    Claimed,
    ReadyToClaim,
    NotClaim,
}

public enum ConsumableState
{
    Consumable,
    NonConsumable
}

public enum IAPRewardType
{
    Money,
    Skin,
    Benefit,
}

public enum SkinItemState
{
    Buyed,
    EnableToBuy,
    DisableToBuy,
    WatchVideo,
    DailyReward,
}

public enum BuyType
{
    Default,
    Money,
    DailyReward,
    WatchVideo,
    Event,
}

public enum SkinType
{
    NONE,
    WEAPON,
    HAT,
    GLOVE,
    NECKLACE,
    SHIELD,
    RING,
}