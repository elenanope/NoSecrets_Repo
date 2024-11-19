using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImagenesManager : MonoBehaviour
{
    [SerializeField, TextArea] private string[] dialogueLinesMan2;
    [SerializeField] private GameObject dialoguePanelMan2;
    [SerializeField] private TMP_Text dialogueManText2;

    public Image[] images;

    [SerializeField, TextArea] private string[] dialogueLinesGey;
    [SerializeField] private GameObject dialoguePanelGey;
    [SerializeField] private TMP_Text dialogueTextGey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si la imagen 1 se ha encendido (dialogo 1 acabado), se van cambiando los paneles con clicks
        // gestionar tmb otro dialogo
    }
}
