using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ResolverStele : MonoBehaviour
{
    public List<ButtonStele> buttonSteleList;
    public LinkedList<ButtonStele> buttonSteleLinkedList = new LinkedList<ButtonStele>();

    [SerializeField] bool isSphere = false;

    public bool hasCheckedCorrect;

    [SerializeField]
    private float timeToCheck = .5f;
    private float elapsedTime = 0f;

    [SerializeField]
    private AudioSource errorAudio;

    private void Awake()
    {
        if (buttonSteleList != null)
        {
            buttonSteleLinkedList = new LinkedList<ButtonStele>(buttonSteleList);
        }
    }

    void FixedUpdate()
    {
        CheckIfCorrect();
    }

    void CheckIfCorrect()
    {
        if (hasCheckedCorrect) return;

        int goodCount = 0;
        int enabledGoodCount = 0;
        int enabledCount = 0;

        LinkedListNode<ButtonStele> button = buttonSteleLinkedList.First;

        while (button != null)
        {
            if (button.Value.isGood)
                goodCount++;
            if (button.Value.isGood && button.Value.isEnabled)
                enabledGoodCount++;
            if (button.Value.isEnabled)
                enabledCount++;

            button = button.Next;
        }

        if (enabledGoodCount == goodCount && enabledCount == enabledGoodCount)
        {
            Debug.Log("Correct");
            LinkedListNode<ButtonStele> buttonToCheck = buttonSteleLinkedList.First;
            while (buttonToCheck != null)
            {
                buttonToCheck.Value.solved = true;
                buttonToCheck = buttonToCheck.Next;
            }

            hasCheckedCorrect = true;
            return;
        }

        if (isSphere && (enabledCount > enabledGoodCount || enabledCount > goodCount))
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToCheck)
            {
                errorAudio.Play();
                LinkedListNode<ButtonStele> buttonToCheck = buttonSteleLinkedList.First;
                while (buttonToCheck.Next != null && buttonToCheck.Next.Value.isEnabled)
                {
                    buttonToCheck.Value.UnGlowingMethod();
                    buttonToCheck = button.Next;
                }

                elapsedTime = 0f;
            }
        }

        if (enabledCount > goodCount || (enabledCount == goodCount && enabledGoodCount != goodCount))
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToCheck)
            {
                errorAudio.Play();
                LinkedListNode<ButtonStele> buttonToCheck = buttonSteleLinkedList.First;
                while (buttonToCheck != null && buttonToCheck.Value.isEnabled)
                {
                    buttonToCheck.Value.UnGlowingMethod();
                    buttonToCheck = buttonToCheck.Next;
                }

                elapsedTime = 0f;
            }
        }
    }
}