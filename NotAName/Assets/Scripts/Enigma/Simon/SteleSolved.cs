using UnityEngine;

public class SteleSolved : MonoBehaviour
{
    [SerializeField]
    private ResolverStele myStele;
    [SerializeField]
    private ResolverStele otherStele;

    void Update()
    {
        if(myStele.hasCheckedCorrect && otherStele.hasCheckedCorrect)
        {
            myStele.gameObject.SetActive(false);
            otherStele.gameObject.SetActive(false);
        }
    }


}
