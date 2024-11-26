using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJuntis : MonoBehaviour
{
    public GameObject dialoguitomujer;
    public GameObject dialoguitohombre;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            dialoguitomujer.SetActive(true);
            dialoguitohombre.SetActive(true);


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguitomujer.SetActive(false);
            dialoguitohombre.SetActive(false);


        }
    }



}
