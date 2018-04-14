using UnityEngine;
using System.Collections;

public class PlayIn : MonoBehaviour
{
    public AudioSource audioSource;

    public float delay = .2f;

    void Start()
    {
        audioSource.PlayDelayed(delay);
    }
}
