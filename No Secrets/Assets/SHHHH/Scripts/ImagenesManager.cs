using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImagenesManager : MonoBehaviour
{
    [SerializeField, TextArea] private string[] dialogueLinesMan2;
    [SerializeField] private GameObject dialoguePanelMan2;
    [SerializeField] private TMP_Text dialogueManText2;
    [SerializeField, TextArea] private string[] dialogueLinesGey;
    [SerializeField] private GameObject dialoguePanelGey;
    [SerializeField] private TMP_Text dialogueTextGey;

    public GameObject nuevaImagen;
    public bool dialogueCanStart= false;
    private int currentStep = 0; // Controla el paso actual del diálogo
    private float typingTime = 0.05f;
    private bool isTyping = false; // Controla si se está escribiendo la línea actualmente

    private bool didDialogueStart = false;

   

    public Image displayImage;
    public Image[] images;

    public int imageIndex = 0;
    public bool spaceAvailable = false;
    public bool nextSceneAvailable = false;

    public int specificSceneToLoad;



    // Update is called once per frame
    void Update()
    {
        
        if (nuevaImagen.activeInHierarchy)
        {
            Debug.Log("Va bien!");
            dialogueCanStart = true;

        }
        if (((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D))) && (dialogueCanStart))
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
        //si la imagen 1 se ha encendido (dialogo 1 acabado), se van cambiando los paneles con clicks
        // gestionar tmb otro dialogo

        if ((spaceAvailable) && Input.GetKeyDown(KeyCode.Space))
        {
            images[6].gameObject.SetActive(true);
            images[5].gameObject.SetActive(false);
        }
        if ((spaceAvailable) && ((Input.GetKeyDown(KeyCode.RightArrow))|(Input.GetKeyDown(KeyCode.D))) && (images[6].gameObject.activeInHierarchy))
        {
            images[7].gameObject.SetActive(true);
            images[6].gameObject.SetActive(false);
            nextSceneAvailable= true;
            
        }
        if ((spaceAvailable)  && (nextSceneAvailable))
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D)))
            {
                SceneLoader(2);
            }
            
        

        

        





        }


    }




    public void SceneLoader(int sceneToLoad)
    {
        
        SceneManager.LoadScene(sceneToLoad);
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
            if (currentStep < 11) // Número total de pasos (0 a 10)
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
                break;
            case 1: 
                images[0].gameObject.SetActive(true);
                nuevaImagen.gameObject.SetActive(false);
                break;
            case 2: 
                images[1].gameObject.SetActive(true);
                images[0].gameObject.SetActive(false);
                ShowGeyDialogue(0);
                break;
            case 3: // Mujer línea 0
                ShowGeyDialogue(1);
                break;
            case 4: // Hombre línea 2
                ShowManDialogue(0);
                break;
            case 5: // Mujer línea 1
                ShowGeyDialogue(2);
                break;
            case 6: // Hombre línea 3 (final)
                ShowManDialogue(1);
                break;
            case 7: // Hombre línea 3 (final)
                images[2].gameObject.SetActive(true);
                images[1].gameObject.SetActive(false);
                ShowGeyDialogue(3);
                break;
            case 8:
                EndDialogue();
                images[3].gameObject.SetActive(true);
                images[2].gameObject.SetActive(false);
                break;
            case 9:
                images[4].gameObject.SetActive(true);
                images[3].gameObject.SetActive(false);
                break;
            case 10:
                images[5].gameObject.SetActive(true);
                images[4].gameObject.SetActive(false);
                //poner aqui cartel para pulsar espacio
                spaceAvailable= true;
                break;
        }
    }

    void ShowManDialogue(int lineIndex)
    {
        dialoguePanelMan2.SetActive(true);
        dialoguePanelGey.SetActive(false);
        StartCoroutine(TypeLine(dialogueManText2, dialogueLinesMan2[lineIndex]));
    }

    void ShowGeyDialogue(int lineIndex)
    {
        dialoguePanelMan2.SetActive(false);
        dialoguePanelGey.SetActive(true);
        StartCoroutine(TypeLine(dialogueTextGey, dialogueLinesGey[lineIndex]));
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
    //private IEnumerator ShowImages()
    //{
        //while (imageIndex < images.Length)
        //{
            
            //images[imageIndex].gameObject.SetActive(true);
            //images[imageIndex -1].gameObject.SetActive(false);

            
            // Avanza al siguiente índice
            //imageIndex++;
        //}

    //}
    void CompleteCurrentLine()
    {
        if (currentStep == 4) // Pasos hombre
        {
            dialogueManText2.text = dialogueLinesMan2[0];
        }
        else if (currentStep == 6) 
        {
            dialogueManText2.text = dialogueLinesMan2[1];
        }
        else if (currentStep == 2) //Pasos Gey
        {
            dialogueTextGey.text = dialogueLinesGey[0];
        }
        else if (currentStep == 3) 
        {
            dialogueTextGey.text = dialogueLinesGey[1];
        }
        else if (currentStep == 5) 
        {
            dialogueTextGey.text = dialogueLinesGey[2];
        }
        else 
        {
            dialogueTextGey.text = dialogueLinesGey[3];
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanelMan2.SetActive(false);
        dialoguePanelGey.SetActive(false);
        
        Debug.Log("Diálogo terminado.");

    }

}
