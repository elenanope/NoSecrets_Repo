using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinHistoria : MonoBehaviour
{



    public GameObject panelDialogoFinal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panelDialogoFinal.gameObject.SetActive(true);
        }
    }
}
