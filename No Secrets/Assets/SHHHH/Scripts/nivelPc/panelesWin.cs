using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelesWin : MonoBehaviour
{
    public GameObject panelEnvio;
    public GameObject panelWin;
    public GameObject player;
    // Busca el componente PlayerScript dentro del GameObject referenciado como "player"
    PlayerController playerScript;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelEnvio.gameObject.SetActive(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        playerScript = player.GetComponent<PlayerController>();
        if ((panelEnvio.activeInHierarchy) && ((Input.GetKeyDown(KeyCode.D)) | (Input.GetKeyDown(KeyCode.RightArrow))))
        {
            panelWin.SetActive(true);
            panelEnvio.SetActive(false);
            
        }
        if ((panelWin.activeInHierarchy) && ((Input.GetKeyDown(KeyCode.D)) | (Input.GetKeyDown(KeyCode.RightArrow))))
        {
            
            SceneLoader(5);
        }
        // Verifica si el script existe
        if ((playerScript != null) && ((panelEnvio.activeInHierarchy)||(panelWin.activeInHierarchy)))
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



