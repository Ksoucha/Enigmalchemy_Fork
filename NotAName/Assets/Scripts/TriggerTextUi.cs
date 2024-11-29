using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTextUi : MonoBehaviour
{

    [SerializeField] private Text messageText; // Référence au composant Text
    [SerializeField] private string[] messages; // Liste des messages
    [SerializeField] private float delayBetweenMessages; // Délai entre les messages
    [SerializeField] private Collider player; // Collider du player

    public bool alreadyLaunch = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyLaunch == false)
        {
            if (messageText == null)
            {
                Debug.LogError("Le champ 'messageText' n'est pas assigné.");
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
            messageText.text = message; // Mettre à jour le texte
            yield return new WaitForSeconds(delayBetweenMessages); // Attendre le délai
        }

        messageText.text = ""; // Nettoyer le texte après la fin des messages
    }

}
