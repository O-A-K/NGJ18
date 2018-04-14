using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JB_DoorOpening : MonoBehaviour
{
    bool isMoving;
    [Header("Lerping")]
    [SerializeField]
    public AnimationCurve openingMotion;
    [SerializeField]
    float openingLength;
    [SerializeField]
    public AnimationCurve closingMotion;
    [SerializeField]
    float closingLength;

    [Header("Positioning")]
    [SerializeField]
    bool isOpen;
    [SerializeField]
    Transform openPosition;
    [SerializeField]
    Transform closedPosition;

    void Start()
    {
        transform.position = isOpen ? openPosition.position : closedPosition.position;
    }

    public void DoorInteract()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveDoor());
        }
    }

    IEnumerator MoveDoor()
    {
        float progress = 0;
        float timer = 0;

        while (isMoving)
        {
            timer += Time.deltaTime;
            progress = timer / (isOpen ? closingLength : openingLength);

            if (isOpen)
            {
                transform.position = Vector3.LerpUnclamped(openPosition.position, closedPosition.position, closingMotion.Evaluate(progress));
            }
            else
            {
                transform.position = Vector3.LerpUnclamped(closedPosition.position, openPosition.position, openingMotion.Evaluate(progress));
            }

            if (timer >= (isOpen ? closingLength : openingLength))
            {
                isOpen = !isOpen;
                isMoving = false;
            }

            yield return null;
        }
    }
}
