using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditorInternal;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Animator transitionAnim;

    // Specify the name of the scene you want to load
    public string sceneToLoad;

    // Function to be called when the button is clicked

    public void LoadScene()
    {
        StartCoroutine(WaitTimer());
    }

    public void NextLevel()
    {
        StartCoroutine(AnimScene());
    }

    IEnumerator AnimScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);


    }




}