using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWomanPlayer : MonoBehaviour
{
    public GameObject dialoguitomujer;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguitomujer.SetActive(true);


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguitomujer.SetActive(false);


        }
    }


}
