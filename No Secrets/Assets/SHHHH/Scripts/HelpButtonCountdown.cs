using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HelpButtonCountdown : MonoBehaviour
{
    public int timesClicked;
    public Button HelpButton;
    public GameObject HelpButtonContainer;



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
            HelpButtonContainer.gameObject.SetActive(false);
        }
    }

}
