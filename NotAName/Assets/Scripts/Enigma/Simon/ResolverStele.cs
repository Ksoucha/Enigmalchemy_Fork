using System.Collections.Generic;
using UnityEngine;

public class ResolverStele : MonoBehaviour
{
    public List<ButtonStele> buttonSteleList;

    [SerializeField] bool isSphere = false;

    public bool hasCheckedCorrect;

    [SerializeField]
    private float timeToCheck = .5f;
    private float elapsedTime = 0f;

    [SerializeField]
    private AudioSource errorAudio;

    void Update()
    {
        CheckIfCorrect();
    }

    void CheckIfCorrect()
    {
        if (hasCheckedCorrect) return;

        int goodCount = 0;
        int enabledGoodCount = 0;
        int enabledCount = 0;

        foreach (var button in buttonSteleList)
        {
            if (button.isGood) goodCount++;
            if (button.isGood && button.isEnabled) enabledGoodCount++;
            if (button.isEnabled) enabledCount++;
        }

        if (enabledGoodCount == goodCount && enabledCount == enabledGoodCount)
        {
            Debug.Log("Correct");
            foreach (var button in buttonSteleList)
            {
                button.solved = true;
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
                foreach (var button in buttonSteleList)
                {
                    button.UnGlowingMethod();
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
                foreach (var button in buttonSteleList)
                {
                    button.UnGlowingMethod();
                }
                elapsedTime = 0f;
            }
        }
    }
}