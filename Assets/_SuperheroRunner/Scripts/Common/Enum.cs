public enum LevelUsedType
{
    SELECTING,
    TESTING
}


public enum GameState
{
    PrepareGame,
    PlayingGame,
    EndGame,
}

public enum SettingType
{
    Vibration,
    Music,
    Sound
}

public enum SoundType
{
    BackgroundMusic,
    ClickBtn,
    CollectArmor,
    CollectGold,
    PlayerDie,
    Congrats,
    FinishLevel,
    Jump,
    Lose,
    Punch,
    WallCrush,
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