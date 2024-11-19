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
        if ((Input.GetKeyDown (KeyCode.Mouse0)))
        {
            if(other == gift1)
            {
                primergift.gameObject.SetActive(false);
            }
            else if (other == gift2)
            {
                segundogift.gameObject.SetActive(false);
            }
            else if(other == gift3)
            {
                tercerogift.gameObject.SetActive(false);
            }

            //no va
            
        }
    }


}
