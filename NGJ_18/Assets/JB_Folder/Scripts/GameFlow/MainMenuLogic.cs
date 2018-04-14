using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public RectTransform playerOneReady;
    public RectTransform playerTwoReady;

    public int firstSceneIndex = 2;

    bool readyPlayerOne = false;
    bool readyPlayerTwo = false;
    bool sceneChanged;
    // Use this for initialization
    void Start()
    {
        if (!sceneChanged && readyPlayerOne && readyPlayerTwo)
        {
            Invoke("SwitchScene", .5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A1"))
        {
            readyPlayerOne = true;
            playerOneReady.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("A2"))
        {
            readyPlayerOne = true;
            playerOneReady.gameObject.SetActive(true);
        }
    }

    void SwitchScene()
    {
        GameManager.gm.GoToScene(firstSceneIndex);
    }
}
