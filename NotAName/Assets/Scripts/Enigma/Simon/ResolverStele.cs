using System.Collections.Generic;
using UnityEngine;

public class ResolverStele : MonoBehaviour
{
    [SerializeField]
    private List<ButtonStele> buttonSteleList;

    private bool hasCheckedCorrect;

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
            foreach(var button in buttonSteleList)
            {
                button.solved = true;
            }
            hasCheckedCorrect = true;
            return;
        }

        if (enabledCount != enabledGoodCount)
        {
            Debug.Log("Not Correct: Resetting glow.");
            foreach (var button in buttonSteleList)
            {
                button.UnGlowingMethod();
            }
        }
    }
}