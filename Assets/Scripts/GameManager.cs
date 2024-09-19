using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public float health;
    public float xp;

    // Start is called before the first frame update
    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0); // press 1
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1); // press 2
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2); // press 3
        if (Input.GetKeyDown(KeyCode.Alpha4)) SceneManager.LoadScene(3); // press 4
    }

    void OnGUI()
    {
       GUI.Label(new Rect(10,10,100,30), "Health: " +  health);
       GUI.Label(new Rect(10, 40, 100, 30), "XP: " + xp);
    }

    public void Save()
    {
        BinaryFormatter bf  = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.xp = xp;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            xp = data.xp;
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float xp;
}
