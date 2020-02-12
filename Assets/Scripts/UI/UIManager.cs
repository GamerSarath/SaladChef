using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager _instance; // SingleTon  private instance
    public GameObject[] speedStarImages;
    public GameObject[] agilityStarImages;
    public GameObject[] patienceStarImages;
    public Text specialMoveText ;
    public Text unlockAmountText;
    #region Singleton
    public static UIManager Instance
    {
        get
        {
            //create logic to create the instance 
            if (_instance == null)
            {
                GameObject go = new GameObject("UIManager");
                go.tag = "UIManager";
                go.AddComponent<UIManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    #endregion
    void Awake()
    {
        _instance = this; // Assinging this object to the _instance 
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("CareerButton").GetComponent<Button>().onClick.AddListener(OnClickCareerButton);// Assigning the event OnClickCareerButton to the button CareerButton.
        GameObject.FindGameObjectWithTag("MultiPlayerButton").GetComponent<Button>().onClick.AddListener(OnClickMultiplayerButton);// Assigning the event OnClickMultiplayer to the button MultiplayerButton.
        GameObject.FindGameObjectWithTag("SettingsButton").GetComponent<Button>().onClick.AddListener(OnClickSettingsButton);// Assigning the event OnClickSettingsButton to the button SettingsButton.
        GameObject.FindGameObjectWithTag("ExitButton").GetComponent<Button>().onClick.AddListener(OnClikcExitButton);// Assigning the event OnClickExit to the button ExitButton.        }
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region MajorButtons four major buttons in the title scene of the game. they are career, multiplayer,info, settings and exit // Self explainable
    void OnClickCareerButton()
    {
        Debug.Log("Career Button is Clicked");
        SceneLoadingManager.Instance.LoadCharacterSelectionScene();
        
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
