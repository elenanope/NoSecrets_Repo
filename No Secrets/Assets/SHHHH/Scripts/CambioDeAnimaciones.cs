using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeAnimaciones : MonoBehaviour
{
    public Animator animatorchico;
    public Animator animatorchica;

    private void Start()
    {
        animatorchico.SetTrigger("GiftBreaker"); 
        animatorchica.SetTrigger("GiftBreaker");
    }
}
