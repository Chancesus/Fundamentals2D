using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //Initialize variables for Scene and Delay
    [SerializeField] float delayBeforeLoading = 6f;
    [SerializeField] string sceneNameToLoad;

    //Holders for UI elements
    [SerializeField] Slider loadingSlider;
    [SerializeField] GameObject loadingCanvas;

    //Initialize Async loading
    AsyncOperation operation;

    //Trigger to call load next level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        //Turn on Canvas, start loading next scene, and prevent instant load
        loadingCanvas.gameObject.SetActive(true);
        operation = SceneManager.LoadSceneAsync(sceneNameToLoad);
        operation.allowSceneActivation = false;

        //Loop to check when loading is done
        while (operation.isDone == false)
        {
            //Added Delay and set slider progress
            yield return new WaitForSeconds(delayBeforeLoading);
            loadingSlider.value = operation.progress;

            //When loading is complete, slider is set to max and next scene is loaded
            if (operation.progress == 0.9f)
            {
                loadingSlider.value = 6f;
                operation.allowSceneActivation = true;
            }
        }
        yield return null;
    }
}
