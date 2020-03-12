using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    // First time loading
    // Player Settings Preferences
    /*
     * Volume
     * Brightness
     * Key Bindings
     * Resolution
     * Windowed vs Fullscreen
     * Quality Settings 
     */



    public Stats.BaseStats playerStats;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("Loaded"))
        {
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            Save();
        }
        else
        {
            Load();
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            Save();
        }
    }
    void FirstLoad()
    {
        for (int i = 0; i < playerStats.characterStatus.Length; i++)
        {
            playerStats.characterStatus[i].maxValue = 100;
            playerStats.characterStatus[i].currentValue = 100;
            playerStats.transform.position = new Vector3(307, 1, 533);
            playerStats.transform.rotation = new Quaternion(0, 0, 0, 0);
            playerStats.checkPoint = GameObject.Find("First CheckPoint").GetComponent<Transform>();

        }
    }

    public void Save()
    {
        PlayerBinary.SavePlayerData(playerStats);
    }

    public void Load()
    {
        PlayerData data = PlayerBinary.LoadPlayerData(playerStats);
        playerStats.name = data.playerName;
        playerStats.checkPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        playerStats.level = data.level;
        for (int i = 0; i < playerStats.characterStatus.Length; i++)
        {
            playerStats.characterStatus[i].currentValue = data.statusCurrentValues[i];
            playerStats.characterStatus[i].maxValue = data.statusMaxValues[i];
        }
        playerStats.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        playerStats.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        playerStats.currentExp = data.currentExp;
        playerStats.maxExp = data.maxExp;
        playerStats.neededExp = data.neededExp;
    }
}
