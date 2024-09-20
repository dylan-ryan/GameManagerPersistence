using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour
{
    void OnGUI()
    {
        float buttonWidth = 100;
        float buttonHeight = 30;
        float screenWidth = Screen.width;

        //Center the buttons horizontally
        float position = (screenWidth - buttonWidth) / 2;

        if (GUI.Button(new Rect(position, 100, buttonWidth, buttonHeight), "Health Up"))
        {
            GameManager.manager.health += 10;
        }
        if (GUI.Button(new Rect(position, 140, buttonWidth, buttonHeight), "Health Down"))
        {
            GameManager.manager.health -= 10;
        }
        if (GUI.Button(new Rect(position, 180, buttonWidth, buttonHeight), "XP Up"))
        {
            GameManager.manager.xp += 10;
        }
        if (GUI.Button(new Rect(position, 220, buttonWidth, buttonHeight), "XP Down"))
        {
            GameManager.manager.xp -= 10;
        }
        if (GUI.Button(new Rect(position, 260, buttonWidth, buttonHeight), "Save"))
        {
            GameManager.manager.Save();
        }
        if (GUI.Button(new Rect(position, 300, buttonWidth, buttonHeight), "Load"))
        {
            GameManager.manager.Load();
        }
    }
}
