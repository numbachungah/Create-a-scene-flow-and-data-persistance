using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR 
    using UnityEditor; 
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.instance.teamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.instance.teamColor);
    }

    void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

        MainManager.instance.SaveColor();
    }

    public void SaveSelectedColor()
    {
        MainManager.instance.SaveColor();
    }

    public void LoadSavedColor()
    {
        MainManager.instance.LoadColor();
        NewColorSelected(MainManager.instance.teamColor);
    }
}
