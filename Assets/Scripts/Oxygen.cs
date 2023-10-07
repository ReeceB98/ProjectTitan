using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    public float maxOxygen = 100; //Starting oxygen level
    public float currentOxygen;
    public float oxygenDepletionRate = 1; //Rate of depletion of oxygen
    public Image oxygenBar;
    public Text oxygenText;

    void Start()
    {
        currentOxygen = maxOxygen;
    }

    public void LoseOxygen(int amount)
    {
        currentOxygen -= amount;

        if(currentOxygen <= 0)
        {
            //DEAD
            //GAMEOVER
        }
    }

    public void ReplenishOxygen(int amount)
    {
        currentOxygen += amount;

        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }

    void OxygenBarFiller()
    {
        oxygenBar.fillAmount = currentOxygen / maxOxygen;
    }

    void ColorChanger()
    {
        Color oxygenColor = Color.Lerp(Color.red, Color.green, (currentOxygen / maxOxygen));

        oxygenBar.color = oxygenColor;
    }

    void Update()
    {
        oxygenText.text = "Oxygen";
        OxygenBarFiller();
        ColorChanger();

        //Check if there is any oxygen remaining
        if (currentOxygen > 0)
        {
            currentOxygen -= oxygenDepletionRate * Time.deltaTime;
        }

        else
        {
            //DEAD
        }
    }
}
