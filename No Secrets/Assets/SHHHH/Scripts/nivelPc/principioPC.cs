using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class principioPC : MonoBehaviour
{
    
    
    private int currentStep = 0; // Controla el paso actual del dialogo
    public GameObject timerr;
    public GameObject player;
    public GameObject panelAyuda;
    
    public Image[] images;

    public int imageIndex = 0;
    public bool storyOver = false;
   
    public bool didSecuenceStart = false;

    public Camera cameraComponent;
    public float targetSize = 9;
    public float transitionSpeed=2;

    public Vector3 targetPosition = new Vector3(-11.3000002f, 12.1000004f, -10);
    principioPC principioPCccc;


    private void Start()
    {
        timerr.gameObject.SetActive(false);
        player.SetActive(false);
        
    }


    // Update is called once per frame
    void Update()
    {

        // Verifica si el script existe
        if (storyOver)
        {
            
            cameraComponent.transform.position = Vector3.Lerp(cameraComponent.transform.position, targetPosition, transitionSpeed * Time.deltaTime);
            if (cameraComponent.orthographic)
            {
                cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, targetSize, transitionSpeed * Time.deltaTime);


            }

            
            
                timerr.gameObject.SetActive(true);
                player.SetActive(true);
            

        }


        
        if ((Input.GetKeyDown(KeyCode.RightArrow)) | (Input.GetKeyDown(KeyCode.D)))
        {
            if (!didSecuenceStart)
            {
                StartMailPanels();
            }
            else
            {
                HandleMailProgression();
            }
        }
       


    }

    void StartMailPanels()
    {
        didSecuenceStart=true;
        currentStep = 0;
        ShowPanelStep();
    }




    void HandleMailProgression()
    {

        
        currentStep++;
            if (currentStep < 5) // Numero total de pasos (0 a 10)
            {
                ShowPanelStep();
            }
            else
        {
            EndDialogue();
        }
            
        

    }



    void ShowPanelStep()
    {
        switch (currentStep)
        {
            case 0:
                images[1].gameObject.SetActive(true);
                images[0].gameObject.SetActive(false);
                break;
           
            case 1:
                images[2].gameObject.SetActive(true);
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
            case 4:
                images[4].gameObject.SetActive(false);
                break;
           





        }
    }
    void EndDialogue()
    {
        storyOver = true;
        panelAyuda.SetActive(true);
    }

    
    
    
}
