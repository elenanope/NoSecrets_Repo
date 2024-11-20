using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelAndNextScene : MonoBehaviour
{

    
    public GameObject panelFinal;
    public GameObject player;
    // Busca el componente PlayerScript dentro del GameObject referenciado como "player"
    PlayerController playerScript;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelFinal.gameObject.SetActive(true);
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        playerScript = player.GetComponent<PlayerController>();
        if ((panelFinal.activeInHierarchy) && ((Input.GetKeyDown(KeyCode.D)) | (Input.GetKeyDown(KeyCode.RightArrow))))
        {
            Debug.Log("Que si vaaaaaaa");
            SceneLoader(4);
        }
        // Verifica si el script existe
        if ((playerScript != null) && (panelFinal.activeInHierarchy))
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

