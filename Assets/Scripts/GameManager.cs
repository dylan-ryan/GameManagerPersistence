using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Instance for the Singleton pattern
    public static GameManager manager;

    public float health;
    public float xp;

    void Awake()
    {
        //If GameManager doesnt exist set this as the manager and dont destruction on load
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        //If GameManager already exists destroy the dupe
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

    //Displays health and XP at the center of the screen
    void OnGUI()
    {
        float labelWidth = 100;
        float labelHeight = 30;
        float screenWidth = Screen.width;

        //Centers the labels horizontally
        float position = (screenWidth - labelWidth) / 2;

        GUI.Label(new Rect(position, 10, labelWidth, labelHeight), "Health: " + health);
        GUI.Label(new Rect(position, 40, labelWidth, labelHeight), "XP: " + xp);
    }

    //Save the players health and XP to a file using binary
    public void Save()
    {
        BinaryFormatter bf  = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.xp = xp;

        //Serialize the playerdata and write it to the file
        bf.Serialize(file, data);
        file.Close();
    }

    //Load the players health and XP from the save file
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Set the players health and XP to the load values
            health = data.health;
            xp = data.xp;
        }
    }
}

[Serializable]
class PlayerData
{
    //Stores health and XP
    public float health;
    public float xp;
}
