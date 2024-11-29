using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCake : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cake;
    public GameObject panelAyuda;
    public float cakeSpeed;


    public void HintCake()
    {
        Cake.transform.position = Vector3.MoveTowards(Cake.transform.position, Player.transform.position, cakeSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            panelAyuda.SetActive(false);
        }
    }

}
