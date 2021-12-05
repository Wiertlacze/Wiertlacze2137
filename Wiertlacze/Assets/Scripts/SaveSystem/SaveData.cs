using System;

[Serializable]
public class SaveData
{
    public float[] playerPosition;
    public float maxFuel;
    public float fuel;
    public float health;
    public float money;
    public float armor;

    public float lowestReached;
    public int blocksCount;
    public int[] blockTypes;
    public float[] blockPositions;
}