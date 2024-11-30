using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraTimer1 : MonoBehaviour
{
    public GameObject panelFinal;
    public GameObject timerContainer;

    // Update is called once per frame
    void Update()
    {
        if(panelFinal.gameObject.activeInHierarchy)
        {
            timerContainer.SetActive(false);
        }
    }
}
