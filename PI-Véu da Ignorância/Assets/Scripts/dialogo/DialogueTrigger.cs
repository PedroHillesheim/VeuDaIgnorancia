using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogue;       // diálogo que vai tocar automaticamente
    public bool triggerOnce = true;     // para tocar só uma vez
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered && triggerOnce) return;
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }
}