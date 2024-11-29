using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalDialogo : MonoBehaviour
{


    public string[] dialogueLineKid;
    [SerializeField] private TMP_Text dialogueKid;
    public GameObject panelKid;
    public string[] dialogueLineKid2;
    [SerializeField] private TMP_Text dialogueKid2;
    public GameObject panelKid2;

    public string[] dialogueLineGey;
    [SerializeField] private TMP_Text dialogueGey;
    public GameObject panelGey;

    public string[] dialogueLineMom;
    [SerializeField] private TMP_Text dialogueMom;
    public GameObject panelMom;

    public Image[] images;
    public GameObject ultimoTriggerOn;
    public GameObject ultimoTriggerOn2;
    public GameObject player;
    public GameObject estePanel;
    public GameObject panelAyuda;
    public BoxCollider colliderKid;


    private int currentStep = 0; // Controla el paso actual del diálogo
    private float typingTime = 0.05f;
    private bool isTyping = false; // Controla si se está escribiendo la línea actualmente
    private bool didDialogueStart = false;


    private void Start()
    {
        player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D)))
        {
            if (!didDialogueStart)
            {
                StartDialoguePanels();
            }
            else
            {
                HandlePanelsProgression();
            }
        }
    }


    void StartDialoguePanels()
    {
        didDialogueStart = true;
        currentStep = 0;
        ShowPanelStep();
    }

    void HandlePanelsProgression()
    {

        if (isTyping)
        {
            StopAllCoroutines(); // Completa la línea actual inmediatamente
            CompleteCurrentLine();
        }
        else
        {
            currentStep++;
            if (currentStep < 6) // Número total de pasos (0 a 10)
            {
                ShowPanelStep();
            }
            else
            {
                EndDialogue();
            }
        }

    }



    void ShowPanelStep()
    {
        switch (currentStep)
        {
            case 0:
                player.gameObject.SetActive(false);
                ShowKidDialogue(0);
                break;
            case 1:
                panelKid.SetActive(false);
                ShowGeyDialogue(0);
                break;
            case 2:
                images[1].gameObject.SetActive(true);
                images[0].gameObject.SetActive(false);
                ShowGeyDialogue(1);
                break;
            case 3:
                panelGey.SetActive(false);
                ShowKidDialogue(1);
                break;
            case 4:
                panelKid.SetActive(false);
                images[2].gameObject.SetActive(true);
                images[1].gameObject.SetActive(false);
                ShowMomDialogue(0);
                break;
            case 5:
                panelMom.SetActive(false);
                ShowKidDialogue2(0);
                break;


        }
    }

    void ShowKidDialogue(int lineIndex)
    {
        panelKid.SetActive(true);
        StartCoroutine(TypeLine(dialogueKid, dialogueLineKid[lineIndex]));
    }
    void ShowKidDialogue2(int lineIndex)
    {
        panelKid2.SetActive(true);
        StartCoroutine(TypeLine(dialogueKid2, dialogueLineKid2[lineIndex]));
    }
    void ShowGeyDialogue(int lineIndex)
    {
        panelGey.SetActive(true);
        StartCoroutine(TypeLine(dialogueGey, dialogueLineGey[lineIndex]));
    }
    void ShowMomDialogue(int lineIndex)
    {
        panelMom.SetActive(true);
        StartCoroutine(TypeLine(dialogueMom, dialogueLineMom[lineIndex]));
    }

    IEnumerator TypeLine(TMP_Text textComponent, string line)
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char ch in line)
        {
            textComponent.text += ch;
            yield return new WaitForSeconds(typingTime);
        }

        isTyping = false;
    }

    void CompleteCurrentLine()
    {
        if (currentStep == 0) // Pasos hombre
        {
            dialogueKid.text = dialogueLineKid[0];
        }
        else if (currentStep == 3)
        {
            dialogueKid.text = dialogueLineKid[1];
        }
        else if (currentStep == 5)
        {
            dialogueKid2.text = dialogueLineKid2[0];
        }
        else if (currentStep == 1)
        {
            dialogueGey.text = dialogueLineGey[0];
        }
        else if (currentStep == 2)
        {
            dialogueGey.text = dialogueLineGey[1];
        }
        else if (currentStep == 4)
        {
            dialogueMom.text = dialogueLineMom[0];
        }


        isTyping = false;
    }

    void EndDialogue()
    {
        
        player.SetActive(true);
        panelKid2.SetActive(false);
        ultimoTriggerOn.gameObject.SetActive(true);ultimoTriggerOn2.gameObject.SetActive(true);
        panelAyuda.SetActive(true);
        colliderKid.gameObject.SetActive(false);
        estePanel.SetActive(false);
        Debug.Log("Diálogo terminado.");

    }


}
