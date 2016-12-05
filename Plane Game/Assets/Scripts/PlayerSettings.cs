using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerSettings : MonoBehaviour
{
    public InputField levelSeedInputField;

    public Toggle joystickControlsToggle;

    public Toggle invertedJoystickToggle;

    public String levelSeed;

    public bool joystickControls;

    public bool invertedJoystick;

    void Awake()
    {
        if( GameObject.FindGameObjectWithTag( "PlayerSettings" ) != this.gameObject )
            Destroy( this.gameObject );

        DontDestroyOnLoad( this.gameObject );
    }

    void Update()
    {
        if( levelSeedInputField )
        {
            levelSeed = levelSeedInputField.textComponent.text;
        }
        else if( GameObject.FindGameObjectWithTag( "LevelSeedInputField" ) )
        {
            levelSeedInputField = GameObject.FindGameObjectWithTag( "LevelSeedInputField" ).GetComponent<InputField>();
        }

        if( joystickControlsToggle )
        {
            joystickControls = joystickControlsToggle.isOn;
        }
        else if( GameObject.FindGameObjectWithTag( "JoystickControlsToggle" ) )
        {
            joystickControlsToggle = GameObject.FindGameObjectWithTag( "JoystickControlsToggle" ).GetComponent<Toggle>();
        }

        if( invertedJoystickToggle )
        {
            invertedJoystick = invertedJoystickToggle.isOn;
        }
        else if( GameObject.FindGameObjectWithTag( "InvertedJoystickToggle" ) )
        {
            invertedJoystickToggle = GameObject.FindGameObjectWithTag( "InvertedJoystickToggle" ).GetComponent<Toggle>();
        }
    }
}
