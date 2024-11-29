using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject panelPausa;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            panelPausa.gameObject.SetActive(true);

        }



        if(panelPausa.gameObject.activeInHierarchy)
        {
            player.gameObject.SetActive(false);

        }
        else
        {
            player.gameObject.SetActive(true );
        }
    }
}
