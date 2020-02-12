using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : Characters
{
    [SerializeField]
    private int speedValue; // Speed attribute of the character
    [SerializeField]
    private int agilityValue; // Agility attribute of the character
    [SerializeField]
    private int patienceValue; // patience attribute of the character
    [SerializeField]
    private string specialMove; // specialMove attribute of the character
    [SerializeField]
    private int unlockPrice; // unlock price of the character

    public Bob(int speedValue, int agilityValue, int patienceValue, string specialMove, int unlockPrice) // constructor to initialize the character attributes
    {
        this.speedValue = speedValue;
        this.agilityValue = agilityValue;
        this.patienceValue = patienceValue;
        this.specialMove = specialMove;
        this.unlockPrice = unlockPrice;
       // characterName = "Bob";
    }

    public override int IncreaseSpeed() // Improving the  speed of the character by spending the cash..
    {
        if (speedValue < 3)
            speedValue++;
        else
            speedValue = 3;
        return speedValue;
    }

    public override int IncreaseAgility()// Improving the  agility of the character by spending the cash..
    {
        if (agilityValue < 3)
            agilityValue++;
        else
            agilityValue = 3;
        return agilityValue;
    }

    public override int IncreasePatience()// Improving the  patience of the character by spending the cash..
    {
        if (patienceValue < 3)
            patienceValue++;
        else
            patienceValue = 3;
        return patienceValue;
    }

    public override int GetCurrentSpeed() // returning the current speed value 
    {
        return speedValue;
    }

    public override int GetCurrentAgility() // returning the current agility value 
    {
        return agilityValue;
    }

    public override  int GetCurrentPatience() // returning the current patience value 
    {
        return patienceValue;
    }

    public override string GetSpecialMove()
    {
        return specialMove;
    }
    public override int GetUnlockAmount()
    {
        return unlockPrice;
    }
}
