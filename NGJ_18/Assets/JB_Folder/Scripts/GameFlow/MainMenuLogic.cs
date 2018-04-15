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


    void Update()
    {
        if (Input.GetButtonDown("A1"))
        {
            readyPlayerOne = true;
            playerOneReady.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("A2"))
        {
            readyPlayerTwo = true;
            playerTwoReady.gameObject.SetActive(true);
            //GameManager.gm.PlayerTwo = Instantiate(GameManager.gm.blobbyPrefab, GameManager.gm.transform);
            //GameManager.gm.PlayerOne = Instantiate(GameManager.gm.blobbyPrefab, GameManager.gm.transform);
        }

        if (!sceneChanged && readyPlayerOne && readyPlayerTwo)
        {
            sceneChanged = true;
            Invoke("SwitchScene", .5f);
        }
    }

    void SwitchScene()
    {
        GameManager.gm.GoToScene(firstSceneIndex);
    }
}
