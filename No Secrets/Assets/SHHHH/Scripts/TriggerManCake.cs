using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerManCake : MonoBehaviour
{

    public GameObject dialoguito;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cake"))
        {
            Debug.Log("Cómo? me estaba haciendo una fiesta?!");

            
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
