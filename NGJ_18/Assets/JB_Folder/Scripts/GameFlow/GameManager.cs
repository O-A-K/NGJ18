using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Camera mainCamera;
    // Fader
    [SerializeField]
    RectTransform zoomer;

    [SerializeField]
    Image fadeBlack;

    [SerializeField]
    float fadeOutLength;

    [SerializeField]
    float fadeInLength;

    float fadeTime;
    bool hasFadedIn = false;
    bool inTransition = false;
    Vector3 startSize;
    Vector3 endSize;
    float fadeLength;

    // Scene Changing
    int currentScene = 0;
    AsyncOperation asyncLoad;
    [SerializeField]
    float minimumLoadingScreenTime;

    // PCs
    public JC_Move blobbyPrefab;
    //[HideInInspector]
    public JC_Move PlayerOne;
    //[HideInInspector]
    public JC_Move PlayerTwo;

    // Audio
    [Header("Audio")]
    public AudioSource screenFadeSFX;
    public AudioSource arrivingLevelSFX;

    void Awake()
    {
        if (gm)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
        }

        DontDestroyOnLoad(gameObject);

        inTransition = true;
        StartCoroutine(FadeScreen());
    }




    public void GoToScene(int sceneIndex)
    {
        // Go to loading Screen
        // Start async loading
        // Once done / after 2 seconds go to new scene
        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        inTransition = true;
        StartCoroutine(FadeScreen());
        fadeTime = 0;

        while (inTransition)                            // wait for last level fade out
        {
            fadeTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1);                      // go to loading screen
        currentScene = 1;

        inTransition = true;
        StartCoroutine(FadeScreen());                   // fade in to loading screen
        while (inTransition)                            // wait for loading to screen fade in then begin checking progress of level load
        {
            fadeTime += Time.deltaTime;
            yield return null;
        }

        asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        inTransition = true;
        while (!asyncLoad.isDone)                       // wait for level to load or wait for minimum time in level
        {
            fadeTime += Time.deltaTime;
            if (fadeTime >= minimumLoadingScreenTime && asyncLoad.progress >= .9f)
            {
                StartCoroutine(FadeScreen());           // once level is loaded, fade out of loading screen
                while (inTransition)                    // wait for loading screen to fade out then go to new scene
                {
                    yield return null;
                }
                asyncLoad.allowSceneActivation = true;  // can now go to new scene
            }
            yield return null;
        }

        //SceneManager.LoadScene(sceneIndex);
        //inTransition = true;
        //StartCoroutine(FadeScreen());           // once level is loaded, fade out of loading screen
        //while (inTransition)                    // wait for loading screen to fade out then go to new scene
        //{
        //    yield return null;
        //}

        currentScene = sceneIndex;

        if (currentScene > 1)
        {
            //AudioSource sfx = Instantiate(arrivingLevelSFX, transform);
            //Destroy(sfx.gameObject, 10);

            PlayerOne = Instantiate(blobbyPrefab, Spawner.spawner.spawnPointPlayerOne.transform.position, Quaternion.identity);
            PlayerOne.playerNumber = 1;
            PlayerTwo = Instantiate(blobbyPrefab, Spawner.spawner.spawnPointPlayerTwo.transform.position, Quaternion.identity);
            PlayerOne.playerNumber = 2;
        }
        inTransition = true;                            // fade into new scene
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        AudioSource fade = Instantiate(screenFadeSFX, transform);
        fade.PlayDelayed(hasFadedIn ? 0 : .2f);
        Destroy(fade.gameObject, 1);
        float progress = fadeTime = 0;
        fadeLength = hasFadedIn ? fadeOutLength : fadeInLength;
        startSize = hasFadedIn ? new Vector3(0, 0, 1) : new Vector3(75, 75, 1);
        endSize = hasFadedIn ? new Vector3(75, 75, 1) : new Vector3(0, 0, 1);
        if (hasFadedIn) zoomer.gameObject.SetActive(true);

        while (progress < 1)
        {
            fadeTime += Time.deltaTime;
            progress = fadeTime / fadeLength;

            zoomer.localScale = Vector3.Lerp(startSize, endSize, progress);

            yield return null;
        }

        hasFadedIn = !hasFadedIn;
        if (hasFadedIn) zoomer.gameObject.SetActive(false);

        inTransition = false;
    }

    IEnumerator LoadingScreenStuff(int sceneIndex)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        float progress = fadeTime = 0;

        while (progress < 1)
        {
            fadeTime += Time.deltaTime;
            if (fadeTime >= minimumLoadingScreenTime && asyncLoad.progress >= .9f)
            {
                progress = 2;
            }
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
        GoToScene(sceneIndex);
    }
}
