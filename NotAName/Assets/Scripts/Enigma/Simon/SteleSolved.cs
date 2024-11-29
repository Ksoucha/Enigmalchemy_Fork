using System;
using System.Collections.Generic;
using UnityEngine;

public class SteleSolved : MonoBehaviour
{
    [SerializeField]
    private List<ResolverStele> allSteles;
    private bool solved = false;

    void Update()
    {
        if (AreAllStelesSolved() && !solved)
        {
            ResolvedLogic();
            solved = true;
        }
    }

    public virtual void ResolvedLogic()
    {
        
    }

    private bool AreAllStelesSolved()
    {
        if(!solved)
        {
            foreach (ResolverStele stele in allSteles)
            {
                if (!stele.hasCheckedCorrect) 
                {
                    return false;
                }
            }
        }

        return true; 
    }
}
