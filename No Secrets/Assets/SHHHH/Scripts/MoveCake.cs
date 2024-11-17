using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCake : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cake;
    public float cakeSpeed;


    public void HintCake()
    {
        Cake.transform.position = Vector3.MoveTowards(Cake.transform.position, Player.transform.position, cakeSpeed);
    }


}
