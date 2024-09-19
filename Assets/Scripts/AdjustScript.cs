using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health Up"))
        {
            GameManager.manager.health += 10;
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Health Down"))
        {
            GameManager.manager.health -= 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "XP Up"))
        {
            GameManager.manager.xp += 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "XP Down"))
        {
            GameManager.manager.xp -= 10;
        }
        if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameManager.manager.Save();
        }
        if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameManager.manager.Load();
        }
    }
}
