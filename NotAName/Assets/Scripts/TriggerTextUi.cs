using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTextUi : MonoBehaviour
{

    [SerializeField] private Text messageText; // R�f�rence au composant Text
    [SerializeField] private string[] messages; // Liste des messages
    [SerializeField] private float delayBetweenMessages; // D�lai entre les messages
    [SerializeField] private Collider player; // Collider du player

    private bool alreadyLaunch = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyLaunch == false)
        {
            if (messageText == null)
            {
                return;
            }

            if (messages.Length == 0)
            {
                Debug.LogWarning("La liste des messages est vide.");
                return;
            }

            if (other == player)
            {
                alreadyLaunch = true;
                StartCoroutine(DisplayMessages());
            }
        }
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            messageText.text = message; // Mettre � jour le texte
            yield return new WaitForSeconds(delayBetweenMessages); // Attendre le d�lai
        }

        messageText.text = ""; // Nettoyer le texte apr�s la fin des messages
    }

}
