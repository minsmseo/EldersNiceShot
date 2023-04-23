using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
[Serializable]
public class PlayerData
{
    public string name;
    public int Easy;
    public int Normal;
    public int Hard;
    public PlayerData()
    {

    }
    public PlayerData(PlayerData p)
    {
        name = p.name;
        Easy = p.Easy;
        Normal = p.Normal;
        Hard = p.Hard;
    }
    public PlayerData SetNewData()
    {
        Easy = 0;
        Normal = 0;
        Hard = 0;
        name = "new P";
        return this;
    }
}
public class DataHandler : MonoBehaviour
{
    PlayerData player;
    
    public static DataHandler Instance;
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/ElderPlayer";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public PlayerData Load()
    {
        string path = Application.persistentDataPath + "/ElderPlayer";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            PlayerData p = new PlayerData();
            p.SetNewData();
            return player;
        }
    }
}
