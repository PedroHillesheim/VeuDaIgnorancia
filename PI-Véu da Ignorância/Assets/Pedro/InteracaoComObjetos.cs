using TMPro;
using UnityEngine;

public class InteracaoComObjetos : MonoBehaviour
{
    public string dialogText;

    public float interactionRange = 3f;

    private Transform player;
    private bool isInRange = false;
    private bool isDialogVisible = false;

    public GameObject dialogPanel;
    public TMP_Text dialogUIText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (dialogPanel != null)
            dialogPanel.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        isInRange = distance <= interactionRange;

        // Mostrar o diálogo ao pressionar F
        if (isInRange && Input.GetKeyDown(KeyCode.F) && !isDialogVisible)
        {
            ShowDialog();
        }

        // Fechar o diálogo ao pressionar Enter
        if (isDialogVisible && Input.GetKeyDown(KeyCode.Return))
        {
            HideDialog();
        }
    }

    void ShowDialog()
    {
        if (dialogPanel != null && dialogUIText != null)
        {
            dialogPanel.SetActive(true);
            dialogUIText.text = dialogText;
            isDialogVisible = true;
        }
    }

    void HideDialog()
    {
        if (dialogPanel != null)
        {
            dialogPanel.SetActive(false);
            isDialogVisible = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
