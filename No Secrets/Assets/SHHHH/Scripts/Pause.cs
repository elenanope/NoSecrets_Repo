using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject panelPausa;
    private bool isPaused;


    // Update is called once per frame
    void Update()
    {
        if(!panelPausa.activeInHierarchy)
        {
            isPaused = false;
            Time.timeScale = 1f;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            UpdateGameState();
            

        }
    }

    private void UpdateGameState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;panelPausa.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; panelPausa.gameObject.SetActive(false);
        }
    }
}
