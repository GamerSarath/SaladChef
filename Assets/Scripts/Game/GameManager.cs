using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance; // SingleTon  private instance
    private Characters currentCharacter;
    private int currentCharacterIndex;
    [SerializeField]
    Characters[] characters;
    GameObject characterHolder;
    Text characterNameHolder;
    #region Singleton
    public static GameManager Instance
    {
        get
        {
            //logic to create the instance 
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                go.tag = "GameManager";
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    #endregion

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        if (scene.name == "CharacterSelectionScene")
        {
            GameObject.FindGameObjectWithTag("NextButton").GetComponent<Button>().onClick.AddListener(OnClickNextButton);// Assigning the event OnClickNext to the button NextButton.
            GameObject.FindGameObjectWithTag("PreviousButton").GetComponent<Button>().onClick.AddListener(OnClickPreviousButton);// Assigning the event OnClickPrevious to the button PreiousButton.
            characterHolder = GameObject.FindGameObjectWithTag("CharacterHolder");
            characterNameHolder = GameObject.FindGameObjectWithTag("CharacterNameHolder").GetComponent<Text>();
            UIManager.Instance.speedStarImages = GameObject.FindGameObjectsWithTag("SpeedStar");
            UIManager.Instance.agilityStarImages = GameObject.FindGameObjectsWithTag("AgilityStar");
            UIManager.Instance.patienceStarImages = GameObject.FindGameObjectsWithTag("PatienceStar");
            UIManager.Instance.specialMoveText = GameObject.FindGameObjectWithTag("SpecialMoveText").GetComponent<Text>();
            UIManager.Instance.unlockAmountText = GameObject.FindGameObjectWithTag("UnlockAmountText").GetComponent<Text>();
        }
    }

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        // InitializeCharacters if required
        currentCharacterIndex = 0;
        currentCharacter = characters[currentCharacterIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Initializing Characters
    private void InitializeCharacters() // To Initialize characters with the attribute values when required
    {
        Bob bob = new Bob(1, 1, 3, "Jump", 1000);
        Shannon shannon = new Shannon(2, 2, 1, "Run", 3000);
        Jasper jasper = new Jasper(3, 3, 3, "Big Jump", 10000);
        characters = new Characters[] { bob, shannon,  jasper };
    }
    #endregion

    #region Method called when the Next character button is clicked
    void OnClickNextButton() // Method called when the next button is clicked . next character will be displayed and the attributes wil be shown
    {
        Debug.Log("Next Character button is clicked");
        if(currentCharacterIndex < characters.Length-1) // Check if currenctCharacterIndex is less than  total characters array length
        {
            #region Changing Character Model and Name For Next Character
            currentCharacter = characters[++currentCharacterIndex]; //If the count is less than characters total count, increment the character index and change the character
            Destroy(characterHolder.transform.GetChild(0).gameObject);
            Characters go = Instantiate(characters[currentCharacterIndex], new Vector3(-455.49f, -238.68f, 632.43f), Quaternion.Euler(0, 149, 0), characterHolder.transform);
            go.transform.localScale = new Vector3(334, 334, 334);
            characterNameHolder.text = currentCharacter.GetCharacterName();
            Debug.Log("current character name is " + currentCharacter.GetCharacterName());
            #endregion

            #region  Assinging Stars to Speed Attribute 
            //Assigning the number of stars for the Speed attribute for the previous player 
            for (int i = 0; i < 3; i++)
            {
                if (i < currentCharacter.GetCurrentSpeed())
                {
                    UIManager.Instance.speedStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.speedStarImages[i].GetComponent<Image>().enabled = false;
                }

            }
            #endregion

            #region  Assinging Stars to Agility Attribute
            //Assigning the number of stars for the Agility attribute for the previous player 
            for (int i = 0; i < 3; i++)
            {
                if (i < currentCharacter.GetCurrentAgility())
                {
                    UIManager.Instance.agilityStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.agilityStarImages[i].GetComponent<Image>().enabled = false;
                }

            }
            #endregion

            #region  Assinging Stars to Patience Attribute
            //Assigning the number of stars for the Patience attribute for the previous player 
            for (int i = 0; i < 3; i++)
            {
                if (i < currentCharacter.GetCurrentPatience())
                {
                    UIManager.Instance.patienceStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.patienceStarImages[i].GetComponent<Image>().enabled = false;
                }

            }
            #endregion

            UIManager.Instance.specialMoveText.text = currentCharacter.GetSpecialMove(); // Displays special move of the next player
            
            // if locked show the price else show unlocked 
            if (!currentCharacter.GetLockStatus())
                UIManager.Instance.unlockAmountText.text = currentCharacter.GetUnlockAmount().ToString();
            else
                UIManager.Instance.unlockAmountText.text = "UnLocked";
        }



    }
    #endregion

    #region Method called when the Previous character button is clicked
    void OnClickPreviousButton() // Method called when the previous button is clicked . previous character will be displayed and the attributes wil be shown
    {
        Debug.Log("Previous Character Button is Clicked");
        if (currentCharacterIndex > 0) // Check if currenctCharacterIndex is less than  zero
        {
            #region Changing the Character Model and Name For Previous Character
            currentCharacter = characters[--currentCharacterIndex]; //If the count is less than characters total count, decrement the character index and change the character
            Destroy(characterHolder.transform.GetChild(0).gameObject);// Destroy the previous character model
            Characters go = Instantiate(characters[currentCharacterIndex], new Vector3(-455.49f, -238.68f, 632.43f), Quaternion.Euler(0, 149, 0), characterHolder.transform); // Instantiate the new chracter model in the required location and rotation with character holder as parent
            go.transform.localScale = new Vector3(334, 334, 334); // scale the character model prefab to the given vector
            characterNameHolder.text = currentCharacter.GetCharacterName(); //the name of the character is printed
            Debug.Log("current character name is " + currentCharacter.GetCharacterName()); // name of character is debbugged 
            #endregion

            #region  Assinging Stars to Speed Attribute 
            //Assigning the number of stars for the Speed attribute for the previous player 
            for (int i = 0; i <3 ;i++)
            {
                if(i < currentCharacter.GetCurrentSpeed())
                {
                    UIManager.Instance.speedStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.speedStarImages[i].GetComponent<Image>().enabled = false;
                }
                
            }
            #endregion

            #region  Assinging Stars to Agility Attribute
            //Assigning the number of stars for the Agility attribute for the previous player 
            for (int i = 0; i < 3; i++)
            {
                if (i < currentCharacter.GetCurrentAgility())
                {
                    UIManager.Instance.agilityStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.agilityStarImages[i].GetComponent<Image>().enabled = false;
                }

            }
            #endregion

            #region  Assinging Stars to Patience Attribute
            //Assigning the number of stars for the Patience attribute for the previous player 
            for (int i = 0; i < 3; i++)
            {
                if (i < currentCharacter.GetCurrentPatience())
                {
                    UIManager.Instance.patienceStarImages[i].GetComponent<Image>().enabled = true;
                }
                else
                {
                    UIManager.Instance.patienceStarImages[i].GetComponent<Image>().enabled = false;
                }

            }
            #endregion
            UIManager.Instance.specialMoveText.text = currentCharacter.GetSpecialMove(); // Displays the special move of the previous player
           
            //if locked show the price else show unlocked 
            if (!currentCharacter.GetLockStatus())
                UIManager.Instance.unlockAmountText.text = currentCharacter.GetUnlockAmount().ToString();
            else
                UIManager.Instance.unlockAmountText.text = "UnLocked";
        }
    }
    #endregion
}
