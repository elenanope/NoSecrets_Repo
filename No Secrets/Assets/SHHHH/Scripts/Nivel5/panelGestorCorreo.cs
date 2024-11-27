using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class PanelGestorCorreo : MonoBehaviour
{

    [SerializeField, TextArea] private string[] dialogueLinesMan;
    [SerializeField] private GameObject dialoguePanelMan;
    [SerializeField] private TMP_Text dialogueManText;
    [SerializeField, TextArea] private string[] dialogueLinesMaya;
    [SerializeField] private GameObject dialoguePanelMaya;
    [SerializeField] private TMP_Text dialogueTextMaya;

    

    private int currentSteps = 0; // Controla el paso actual del dialogo
    public GameObject elTimer;
    public GameObject timerPanel;
    public GameObject cluePanel;
    //public GameObject elPlayer;

    public Image[] images;

    public int imageIndex = 0;
    public bool MailOver = false;
    public bool Mail2Over = false;

    public bool didMailStart = false;
    public bool did2MailStart = false;


    private float typingTime = 0.05f;
    private bool isTyping = false; // Controla si se est� escribiendo la l�nea actualmente
    public bool dialogueCanStart = false;
    //private bool didDialogueStart = false;



    principioPC principioPCccc;


    private void Start()
    {
        elTimer.gameObject.SetActive(false);
        //elPlayer.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (images[1].gameObject.activeInHierarchy)
        {
            Debug.Log("Va bien!");
            dialogueCanStart = true;

        }
        
        // Verifica si el script existe
        if (MailOver)
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D)))
            {
                if (!did2MailStart)
                {
                    Start2PicturesPanels();
                }
                else
                {
                    Handle2PicturesProgression();
                }
            }
            

        }



        if ((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D)))
        {
            if (!didMailStart)
            {
                StartPicturesPanels();
            }
            else if (currentSteps<5)
            {
                HandlePicturesProgression();
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (currentSteps >= 5)
            {
                
                HandlePicturesProgression();    
            }
            
            
        }



    }

    void StartPicturesPanels()
    {
        didMailStart = true;
        currentSteps = 0;
        ShowMailStep();
    }
    void Start2PicturesPanels()
    {
        did2MailStart = true;
        currentSteps = 0;
        Show2MailStep();
    }
    void Handle2PicturesProgression()
    {


        currentSteps++;
        if (currentSteps < 6) // Numero total de pasos (0 a 10)
        {
            Show2MailStep();
        }
        else
        {
            End2Mail();
        }



    }
    void Show2MailStep()
    {
        switch (currentSteps)
        {
            case 0:
                images[6].gameObject.SetActive(true);
                images[5].gameObject.SetActive(false);
                break;

            case 1:
                images[7].gameObject.SetActive(true);
                images[6].gameObject.SetActive(false);
                break;

                
            case 2:
                images[8].gameObject.SetActive(true);
                images[7].gameObject.SetActive(false);
                break;
            case 3:
                images[9].gameObject.SetActive(true);
                images[8].gameObject.SetActive(false);
                break;
            case 4:
                images[10].gameObject.SetActive(true);
                images[9].gameObject.SetActive(false);
                break;
            case 5:
                images[11].gameObject.SetActive(true);
                images[10].gameObject.SetActive(false);
                break;




        }
    }
    void End2Mail()
    {
        Mail2Over = true;
    }

void HandlePicturesProgression()
    {
        if (isTyping)
        {
            StopAllCoroutines(); // Completa la l�nea actual inmediatamente
            CompleteCurrentLine();
        }
        else
        {
            currentSteps++;
            if (currentSteps < 10) // N�mero total de pasos (0 a 10)
            {
                ShowMailStep();
            }
            else
            {
                EndMail();
            }
        }



    }



    void ShowMailStep()
    {
        switch (currentSteps)
        {
            case 0:
                images[1].gameObject.SetActive(true);
                images[0].gameObject.SetActive(false);
                
                break;  

            case 1:
                ShowManDialogue(0);
                break;
            case 2:
                ShowManDialogue(1);
                break;
            case 3:
                ShowMayaDialogue(0);
                break;
            case 4:
                ShowManDialogue(2);
                break;
            case 5:
                dialoguePanelMan.SetActive(false);
                dialoguePanelMaya.SetActive(false);
                cluePanel.SetActive(true);
                elTimer.gameObject.SetActive(true);
                timerPanel.gameObject.SetActive(true);
                break;
            case 6:
                images[2].gameObject.SetActive(true);
                images[1].gameObject.SetActive(false);
                break;
            case 7:
                images[3].gameObject.SetActive(true);
                images[2].gameObject.SetActive(false);
                break;
            case 8:
                images[4].gameObject.SetActive(true);
                images[3].gameObject.SetActive(false);

                break;
            case 9:
                images[5].gameObject.SetActive(true);
                images[4].gameObject.SetActive(false);
                elTimer.gameObject.SetActive(false);
                timerPanel.gameObject.SetActive(false);
                break;

           
              



        }
    }
    void EndMail()
    {
        MailOver = true;
    }

    void ShowManDialogue(int lineIndex)
    {
        dialoguePanelMan.SetActive(true);
        dialoguePanelMaya.SetActive(false);
        StartCoroutine(TypeLine(dialogueManText, dialogueLinesMan[lineIndex]));
    }

    void ShowMayaDialogue(int lineIndex)
    {
        dialoguePanelMan.SetActive(false);
        dialoguePanelMaya.SetActive(true);
        StartCoroutine(TypeLine(dialogueTextMaya, dialogueLinesMaya[lineIndex]));
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
        if (currentSteps == 1) // Pasos hombre
        {
            dialogueManText.text = dialogueLinesMan[0];
        }
        else if (currentSteps == 2)
        {
            dialogueManText.text = dialogueLinesMan[1];
        }
        else if (currentSteps == 3) //Pasos Gey
        {
            dialogueTextMaya.text = dialogueLinesMaya[0];
        }
        else if (currentSteps == 4)
        {
            dialogueManText.text = dialogueLinesMan[2];
        }
       

        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanelMan.SetActive(false);
        dialoguePanelMaya.SetActive(false);

        Debug.Log("Di�logo terminado.");

    }

}
