using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Making this object not be destroyed on scene change.

        GameObject.FindGameObjectWithTag("CareerButton").GetComponent<Button>().onClick.AddListener(OnClickCareerButton);// Assigning the event OnClickCareerButton to the button CareerButton.
        GameObject.FindGameObjectWithTag("MultiPlayerButton").GetComponent<Button>().onClick.AddListener(OnClickMultiplayerButton);// Assigning the event OnClickMultiplayer to the button MultiplayerButton.
        GameObject.FindGameObjectWithTag("SettingsButton").GetComponent<Button>().onClick.AddListener(OnClickSettingsButton);// Assigning the event OnClickSettingsButton to the button SettingsButton.
        GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Button>().onClick.AddListener(OnClikcExitButton);// Assigning the event OnClickExit to the button ExitButton.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region MajorButtons four major buttons in the title scene of the game. they are career, multiplayer, settings and exit // Self explainable
    void OnClickCareerButton()
    {
        Debug.Log("Career Button is Clicked");
    } // Event called when the career button is clicked

    void OnClickMultiplayerButton()
    {
        Debug.Log("Multiplayer Button is Clicked");
    } // Event called when the multiplayer button is clicked

    void OnClickSettingsButton()
    {
        Debug.Log("Settings Button is Clicked");
    } // Event called when the settings button is clicked

    void OnClikcExitButton()
    {
        Debug.Log("Exit Button is Clicked");
        Application.Quit();
    } // Event called when the Exit button is clicked
    #endregion

   


}
