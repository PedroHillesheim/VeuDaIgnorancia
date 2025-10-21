using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ReconstrucaoCodigo : MonoBehaviour
{
    public int totalItems = 3;
    private int collectedItems = 0;
    private GameObject currentItem = null;
    private GameObject victoryZone = null;
    public TMP_Text collectItemText;
    public UnityEvent victoryPanel;
    private bool isNearVictoryZone = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            collectItemText.text = collectedItems.ToString();
            if (currentItem != null)
            {
                collectedItems++;
                Destroy(currentItem);
                currentItem = null;
                Debug.Log("Item coletado! (" + collectedItems + "/" + totalItems + ")");
            }
            else if (isNearVictoryZone && collectedItems >= totalItems)
            {
                ShowVictory();
            }
        }
    }

    void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            currentItem = other.gameObject;
        }
        else if (other.CompareTag("VictoryZone"))
        {
            isNearVictoryZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") && currentItem == other.gameObject)
        {
            currentItem = null;
        }
        else if (other.CompareTag("VictoryZone"))
        {
            isNearVictoryZone = false;
            Debug.Log("Você saiu da zona de vitória.");
        }
    }
}
