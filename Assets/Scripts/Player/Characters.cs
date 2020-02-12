using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    [SerializeField]
    private string characterName;// variable that hold character name
    [SerializeField]
    private bool lockStatus; // variable that hold character lock status  true for locked and false for unlocked 
    public abstract int IncreaseSpeed();// the method that improves the player speed
    public abstract int IncreaseAgility();// the method that improves the player agility
    public abstract int IncreasePatience();// the method that improves the player patience
    public abstract int GetCurrentSpeed();// the method that improves the player patience
    public abstract int GetCurrentAgility();// the method that improves the player patience
    public abstract int GetCurrentPatience();// the method that improves the player patience
    public abstract int GetUnlockAmount();// the method that improves the player patience
    public abstract string GetSpecialMove();// the method that returns the special move

    [SerializeField]
    GameObject characterBody; // variable that hold character body

    public string GetCharacterName()
    {
        return characterName;
    }

    public void SetCharacterName(string value )
    {
        characterName = value;
    }

    public bool GetLockStatus()
    {
        return lockStatus;
    }

    public void SetLockStatus(bool flag)
    {
        lockStatus = flag;
    }
}
