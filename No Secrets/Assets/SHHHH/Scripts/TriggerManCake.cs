using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerManCake : MonoBehaviour
{

    public GameObject dialoguito;
    public GameObject panelFinal;
    //public GameObject player;
    // Busca el componente PlayerScript dentro del GameObject referenciado como "player"
    //PlayerController playerScript;

    private void OnTriggerEnter(Collider other)
    {
        //playerScript = player.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Cake"))
        {
            Debug.Log("Cómo? me estaba haciendo una fiesta?!");
            panelFinal.gameObject.SetActive(true);


            



        }
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguito.SetActive(true);


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguito.SetActive(false);


        }
    }

}
