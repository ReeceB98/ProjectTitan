using UnityEngine;
using UnityEngine.UI;
public class Oxygen : MonoBehaviour
{
    public float maxOxygen = 100.0f; //Starting oxygen level
    public float currentOxygen = 0.0f;
    public float oxygenDepletionRate = 1; //Rate of depletion of oxygen
    public Image oxygenBar;
    public Text oxygenText;

    void Start()
    {
        currentOxygen = maxOxygen;
    }

    public void LoseOxygen(float amount)
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= amount;
        }
        else if(currentOxygen < 0.05f)
        {
            currentOxygen = 0;
            //DEAD
            //GAMEOVER
            Debug.Log("You are dead!");
        }
        else
        {
            Debug.Log("Something is wrong!");
        }
    }

    public void ReplenishOxygen(int amount)
    {
        //currentOxygen += amount * Time.deltaTime;

        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
        else
        {
            currentOxygen += amount * Time.deltaTime;
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
            //currentOxygen -= oxygenDepletionRate * Time.deltaTime;
            LoseOxygen(0.05f);
        }

        else
        {
            //DEAD
        }
    }
}
