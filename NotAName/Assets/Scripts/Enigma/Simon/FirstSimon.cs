using UnityEngine;

public class FirstSimon : SteleSolved
{
    public GameObject dispearOne;
    public GameObject dispearTwo;


    public override void ResolvedLogic()
    {
        dispearOne.SetActive(false);
        dispearTwo.SetActive(false);
    }
}
