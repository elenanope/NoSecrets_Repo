using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManCake : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cake"))
        {
            Debug.Log("C�mo? me estaba haciendo una fiesta?!");
            
        }

    }

}
