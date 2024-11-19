using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public bool availableToOpenGifts = false;
  
    public Collider gift1;
    public Collider gift2;
    public Collider gift3;
    public GameObject primergift;
    public GameObject segundogift;
    public GameObject tercerogift;


    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if ((other==gift1)|(other==gift2)|(other==gift3))
        //{
            //availableToOpenGifts = true;
        //}
        if (other == gift1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                primergift.gameObject.SetActive(false);
            }
         
            //no va
            
        }

        else if (other == gift2)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                segundogift.gameObject.SetActive(false);
            }
        }
        else if (other == gift3)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tercerogift.gameObject.SetActive(false);
            }
        }
    }


}
