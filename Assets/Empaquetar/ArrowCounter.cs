using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int arrowYesCounter = 0;
    private int maxCounter = 10;
    public float baseSpeed = 2.0f;
    public float speedIncreaseFactor = 0.5f;

    public AudioClip freezeSound;
    public float freezeDuration = 6f;
    private float timeCounter = 0f;
    private bool isFrozen = false;

    private RawImage freezeImage; // Reference to the RawImage component

    void Start()
    {
        AutoMove autoMoveScript = GetComponent<AutoMove>();
        if (autoMoveScript != null)
        {
            autoMoveScript.SetSpeed(baseSpeed);
        }
    }

    public void IncreaseArrowYesCounter()
    {
        arrowYesCounter++;
        arrowYesCounter = Mathf.Clamp(arrowYesCounter, 0, maxCounter);
        counterText.text = arrowYesCounter + " / " + maxCounter;

        if (arrowYesCounter >= maxCounter)
        {
            if (!isFrozen)
            {
                Debug.Log("Counter reached 10. Freezing screen for 3 seconds.");
                StartCoroutine(FreezeScreen());
            }
        }
        else
        {
            float newSpeed = baseSpeed + arrowYesCounter * speedIncreaseFactor;
            Debug.Log("New Speed: " + newSpeed);

            AutoMove autoMoveScript = GetComponent<AutoMove>();
            if (autoMoveScript != null)
            {
                autoMoveScript.SetSpeed(newSpeed);
            }
        }
    }

    public void ResetCounter()
    {
        arrowYesCounter = 0;
        counterText.text = arrowYesCounter + " / " + maxCounter;
    }

    public void SetFreezeImage(RawImage rawImage)
    {
        freezeImage = rawImage;
    }

    public void DisplayFreezeImage(Texture imageTexture)
    {
        if (freezeImage != null && imageTexture != null)
        {
            freezeImage.texture = imageTexture;
        }
    }

    IEnumerator FreezeScreen()
    {
        isFrozen = true;
        Time.timeScale = 0f;

        // Display the freeze image using the public function
        DisplayFreezeImage(freezeImage.texture);

        if (GetComponent<AudioSource>() != null && freezeSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(freezeSound);
        }

        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = 1f;
        isFrozen = false;

        TransitionToScene("MainMenuV2Final");
    }

    void TransitionToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}