using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [Tooltip ("Tiempo en segundos")]public float timerTime;
    
    
    private int minutes, seconds, cents;

    public TMP_Text timerText;
    public GameObject failurePanel;
    public GameObject player;
    // Busca el componente PlayerScript dentro del GameObject referenciado como "player"
    PlayerController playerScript;



    // Update is called once per frame
    void Update()
    {

        playerScript = player.GetComponent<PlayerController>();

        timerTime -= Time.deltaTime;

        if(timerTime < 0)timerTime = 0;

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);
        cents= (int)((timerTime-(int)timerTime)*100f);

        timerText.text = string.Format("{0:00}:{1:00}", seconds, cents);


        if (timerTime==0 )
        {
            failurePanel.SetActive(true);
        }

        if(failurePanel.activeInHierarchy)
        {
            // Desactiva el script
            playerScript.enabled = false;
        }
    }

    public void SceneLoader(int sceneToLoad)
    {

        SceneManager.LoadScene(sceneToLoad);
    }

}



