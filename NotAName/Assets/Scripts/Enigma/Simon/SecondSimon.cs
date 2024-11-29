using UnityEngine;

public class SecondSimon : SteleSolved
{
    public GameObject dispear;
    public GameObject appear;


    public override void ResolvedLogic()
    {
        dispear.SetActive(false);
        appear.SetActive(true);
    }
}
