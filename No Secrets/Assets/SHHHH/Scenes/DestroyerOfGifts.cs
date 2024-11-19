using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOfGifts : MonoBehaviour
{
    
    private bool jugadorEnTrigger = false; // Bandera para saber si el jugador está en el trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que entra es el jugador
        {
            Debug.Log("El jugador ha entrado en el trigger.");
            jugadorEnTrigger = true; // Activa la bandera
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador sale del trigger
        {
            Debug.Log("El jugador ha salido del trigger.");
            jugadorEnTrigger = false; // Desactiva la bandera
        }
    }

    void Update()
    {
        // Si el jugador está en el trigger y presiona la tecla "E"
        if (jugadorEnTrigger && Input.GetKeyDown(KeyCode.Backspace))
        {
            
            Debug.Log("Desactivando el objeto.");
            gameObject.SetActive(false); // Desactiva el objeto actual
        }
    }
}


