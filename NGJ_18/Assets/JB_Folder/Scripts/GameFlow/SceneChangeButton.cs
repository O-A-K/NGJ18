using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField]
    int sceneIndex;

    [SerializeField]
    Button thisButton;

    void Start()
    {
        thisButton.onClick.AddListener(GoToScene);
    }

    void GoToScene()
    {
        GameManager.gm.GoToScene(sceneIndex);
    }
}
