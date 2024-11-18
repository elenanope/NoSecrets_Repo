using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea] private string[] dialogueLinesMan;
    [SerializeField] private GameObject dialoguePanelMan;
    [SerializeField] private TMP_Text dialogueManText;

    
    [SerializeField, TextArea] private string[] dialogueLinesWoman;
    [SerializeField] private GameObject dialoguePanelWoman;
    [SerializeField] private TMP_Text dialogueWomanText;


    private int currentStep = 0; // Controla el paso actual del diálogo
    private float typingTime = 0.05f;
    private bool isTyping = false; // Controla si se está escribiendo la línea actualmente
    private bool didDialogueStart = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else
            {
                HandleDialogueProgression();
            }
        }
    }

    void StartDialogue()
    {
        didDialogueStart = true;
        currentStep = 0;
        ShowDialogueStep();
    }

    void HandleDialogueProgression()
    {
        if (isTyping)
        {
            StopAllCoroutines(); // Completa la línea actual inmediatamente
            CompleteCurrentLine();
        }
        else
        {
            currentStep++;
            if (currentStep < 6) // Número total de pasos (0 a 5)
            {
                ShowDialogueStep();
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void ShowDialogueStep()
    {
        switch (currentStep)
        {
            case 0: // Hombre línea 0
                ShowManDialogue(0);
                break;
            case 1: // Hombre línea 1
                ShowManDialogue(1);
                break;
            case 2: // Mujer línea 0
                ShowWomanDialogue(0);
                break;
            case 3: // Hombre línea 2
                ShowManDialogue(2);
                break;
            case 4: // Mujer línea 1
                ShowWomanDialogue(1);
                break;
            case 5: // Hombre línea 3 (final)
                ShowManDialogue(3);
                break;
        }
    }

    void ShowManDialogue(int lineIndex)
    {
        dialoguePanelMan.SetActive(true);
        dialoguePanelWoman.SetActive(false);
        StartCoroutine(TypeLine(dialogueManText, dialogueLinesMan[lineIndex]));
    }

    void ShowWomanDialogue(int lineIndex)
    {
        dialoguePanelMan.SetActive(false);
        dialoguePanelWoman.SetActive(true);
        StartCoroutine(TypeLine(dialogueWomanText, dialogueLinesWoman[lineIndex]));
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
        if (currentStep == 0) // Pasos pares: hombre
        {
            dialogueManText.text = dialogueLinesMan[0];
        }
        else if (currentStep == 1) // Pasos pares: hombre
        {
            dialogueManText.text = dialogueLinesMan[1];
        }
        else if (currentStep == 3) // Pasos pares: hombre
        {
            dialogueManText.text = dialogueLinesMan[2];
        }
        else if (currentStep == 5) // Pasos pares: hombre
        {
            dialogueManText.text = dialogueLinesMan[3];
        }
        else if (currentStep == 0) // Pasos pares: hombre
        {
            dialogueWomanText.text = dialogueLinesWoman[0];
        }
        else // Pasos impares: mujer
        {
            dialogueWomanText.text = dialogueLinesWoman[1];
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanelMan.SetActive(false);
        dialoguePanelWoman.SetActive(false);
        didDialogueStart = false;
        Debug.Log("Diálogo terminado.");
    }
}