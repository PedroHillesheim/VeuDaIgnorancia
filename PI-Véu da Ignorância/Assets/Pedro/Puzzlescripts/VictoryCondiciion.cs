using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VictoryCondiciion : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private UnityEvent onVictory;
    private bool hasWon = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasWon && other.CompareTag(playerTag))
        {
            hasWon = true;
            Debug.Log("oi");
            onVictory.Invoke();
        }
    }
}
