using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelDialogoPared : MonoBehaviour
{


    public string dialogueLineKid;
    [SerializeField] private TMP_Text dialogueKid;
    public Image[] images;
    public GameObject panelPrimerDialogo;
    public GameObject player;

    private int currentStep = 0; // Controla el paso actual del di?logo
    private float typingTime = 0.05f;
    private bool isTyping = false; // Controla si se est? escribiendo la l?nea actualmente
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
            StopAllCoroutines(); // Completa la l?nea actual inmediatamente
            CompleteCurrentLine();
        }
        else
        {
            currentStep++;
            if (currentStep < 4) // N?mero total de pasos (0 a 10)
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
                images[1].gameObject.SetActive(true);
                images[0].gameObject.SetActive(false);
                ShowKidDialogue(0);
                break;
            case 1:
                images[2].gameObject.SetActive(true);
                dialogueKid.gameObject.SetActive(false);
                images[1].gameObject.SetActive(false);
                break;
            case 2:
                images[3].gameObject.SetActive(true);
                images[2].gameObject.SetActive(false);
                break;
            case 3:
                images[4].gameObject.SetActive(true);
                images[3].gameObject.SetActive(false);
                break;
          

        }
    }

    void ShowKidDialogue(int lineIndex)
    {

        StartCoroutine(TypeLine(dialogueKid, dialogueLineKid));
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
            dialogueKid.text = dialogueLineKid;
        }


        isTyping = false;
    }

    void EndDialogue()
    {
        panelPrimerDialogo.gameObject.SetActive(false);
        player.gameObject.SetActive(true);

        Debug.Log("Di?logo terminado.");

    }

}

