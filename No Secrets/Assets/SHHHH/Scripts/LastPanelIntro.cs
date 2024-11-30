using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPanelIntro : MonoBehaviour

{

    public int sceneToLoad;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.D)) | (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}


