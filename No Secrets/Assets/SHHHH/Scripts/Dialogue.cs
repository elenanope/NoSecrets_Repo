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


    public bool didDialogueStart;
    public int lineIndex;
    public float typingTime = 0.05f;

    public bool isManSpeaking = true; // Alterna entre hombre y mujer



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueManText.text == dialogueLinesMan[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueManText.text = dialogueLinesMan[lineIndex];
            }
        }   

    }



    void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanelMan.SetActive(true);
        lineIndex = 0;
        StartCoroutine(Showline());
    }

    void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex<dialogueLinesMan.Length)
        {
            StartCoroutine(Showline());
        }
        else
        {
            didDialogueStart=false;
            dialoguePanelMan.SetActive(false);
        }
    }

    private IEnumerator Showline()
    {
        dialogueManText.text = string.Empty;

        foreach(char ch in dialogueLinesMan[lineIndex])
        {
            dialogueManText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }


  
}
