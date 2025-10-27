using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector3 correctPosition; // Posição correta da peça
    public float snapDistance = 0.5f; // Distância para encaixar
    private bool isPlaced = false;
    private Vector3 offset;
    private bool dragging = false;

    public bool IsPlaced { get; internal set; }

    void Start()
    {
        // Inicializa o correto para o lugar que a peça deve estar
        correctPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (!isPlaced)
        {
            dragging = true;
            offset = transform.position - GetMouseWorldPos();
        }
    }

    void OnMouseUp()
    {
        if (!isPlaced)
        {
            dragging = false;
            // Verifica se a peça está próxima da posição correta
            if (Vector3.Distance(transform.position, correctPosition) <= snapDistance)
            {
                transform.position = correctPosition;
                isPlaced = true;
                PuzzleManager.Instance.CheckCompletion();
            }
        }
    }

    void Update()
    {
        if (dragging && !isPlaced)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
