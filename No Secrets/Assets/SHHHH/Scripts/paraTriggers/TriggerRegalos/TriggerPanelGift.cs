using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPanelGift : MonoBehaviour
{
    
    public GameObject gift1;
    public GameObject gift2;
    public GameObject gift3;
    public GameObject timer;
    public GameObject panelAyuda;

    public GameObject triggerFinal;
    

    // Update is called once per frame
    void Update()
    {
        if((!gift1.gameObject.activeInHierarchy)&&(!gift2.gameObject.activeInHierarchy)&&(!gift3.gameObject.activeInHierarchy))
        {
            triggerFinal.gameObject.SetActive(true);
            timer.SetActive(false);
        }
        if((!gift1.gameObject.activeInHierarchy)||(!gift2.gameObject.activeInHierarchy)||(!gift3.gameObject.activeInHierarchy))
        {
            panelAyuda.gameObject.SetActive(false);
        }
    }
}
