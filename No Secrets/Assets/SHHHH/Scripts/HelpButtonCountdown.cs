using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HelpButtonCountdown : MonoBehaviour
{
    public int timesClicked;
    public Button HelpButton;



    private void Update()
    {
        PlayerHelp();
    }

    public void ButtonClicked()
    {
        timesClicked +=1;
    }


    public void PlayerHelp()
    {
        if(timesClicked == 3)
        {
            HelpButton.gameObject.SetActive(false);
        }
    }

}
