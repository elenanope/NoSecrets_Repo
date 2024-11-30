using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public Animator creditos;
    public int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (creditos.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !creditos.IsInTransition(0))
        {
            Debug.Log("Puedes pasar de escena!");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
