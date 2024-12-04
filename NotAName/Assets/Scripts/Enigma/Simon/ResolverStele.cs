using System.Collections.Generic;
using UnityEngine;

public class ResolverStele : MonoBehaviour
{
    public List<ButtonStele> buttonSteleList;

    public bool hasCheckedCorrect;

    [SerializeField]
    private float timeToCheck = .5f;
    private float elapsedTime = 0f;

    [SerializeField]
    private AudioClip correctSound;
    [SerializeField]
    private AudioClip incorrectSound;

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

        if (enabledGoodCount == goodCount)
        {
            Debug.Log("Correct");
            foreach (var button in buttonSteleList)
            {
                button.solved = true;
            }
            hasCheckedCorrect = true;
            return;
        }

        if (enabledCount > goodCount || (enabledCount == goodCount && enabledGoodCount != goodCount))
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToCheck)
            {
                Debug.Log("Not Correct: Resetting glow.");

                this.GetComponent<AudioSource>().clip = incorrectSound;
                this.GetComponent<AudioSource>().Play();

                foreach (var button in buttonSteleList)
                {
                    button.UnGlowingMethod();
                }
                elapsedTime = 0f;
            }
        }
    }
}