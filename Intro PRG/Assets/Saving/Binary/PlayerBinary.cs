using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

    public static class PlayerBinary
{
    public static void SavePlayerData(Stats.BaseStats player)
    {
        //Reference a binary formatter 
        BinaryFormatter formatter = new BinaryFormatter();
        //Location to save to 
        string path = Application.persistentDataPath + "/" + "Connor_51.jpeg";
        // Create a file at save path
        FileStream stream = new FileStream(path, FileMode.Create);
        // What data to write to the file
        PlayerData data = new PlayerData(player);
        // Write and convert to bytes for writing to binary
        formatter.Serialize(stream, data);
        // AND Done
        stream.Close();
    }
    public static PlayerData LoadPlayerData(Stats.BaseStats player)
    {
        //Location to Load
        string path = Application.persistentDataPath + "/" + "Connor_51.jpeg";
        //if that location exists
        if(File.Exists(path))
        {
            //Get our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //Read the data from the path
            FileStream stream = new FileStream(path, FileMode.Open);
            //Set the data from what it was too usable variables
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Done nerd
            stream.Close();
            //oh yeah, maybe send that load data to the game as well
            return data;
        }
        else
        {
           return null;
        }
       
    }
}
