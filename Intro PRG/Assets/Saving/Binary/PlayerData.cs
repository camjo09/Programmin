[System.Serializable]
public class PlayerData
{
    // Same variables that are already existing in game but named here so we know which ones we are saving
    public string playerName;
    public int level;
    public string checkPoint;
    public float[] statusMaxValues = new float[3];
    public float[] statusCurrentValues = new float [3];
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    public float currentExp, neededExp, maxExp;

    public PlayerData(Stats.BaseStats player)
    {
        playerName = player.name;
        level = player.level;
        checkPoint = player.checkPoint.name;
        for (int i = 0; i < statusMaxValues.Length; i++)
        {
            statusCurrentValues[i] = player.characterStatus[i].currentValue;
            statusMaxValues[i] = player.characterStatus[i].maxValue;

        }
        //Position
        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;

        //Rotation
        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;

    }

    
}
