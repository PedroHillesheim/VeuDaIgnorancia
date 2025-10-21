using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector3 correctPosition;
    public float snapDistance = 0.5f;
    public bool IsPlaced { get; private set; } = false;

    private Vector3 offset;
    private bool dragging = false;

    private Collider2D col2D;
    private Collider col3D;

    void Awake()
    {
        col2D = GetComponent<Collider2D>();
        col3D = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        if (IsPlaced) return; 

        dragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseUp()
    {
        if (IsPlaced) return; 

        dragging = false;

        if (Vector3.Distance(transform.position, correctPosition) <= snapDistance)
        {
            transform.position = correctPosition;
            IsPlaced = true;
            LockPiece();
            PuzzleManager.Instance.CheckCompletion();
        }
    }
    void Update()
    {
        if (dragging && !IsPlaced)
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

    void LockPiece()
    {
        // Impede qualquer movimento futuro
        dragging = false;

        // Opcional: desativa o collider pra não receber mais cliques
        if (col2D != null) col2D.enabled = false;
        if (col3D != null) col3D.enabled = false;
    }
}
