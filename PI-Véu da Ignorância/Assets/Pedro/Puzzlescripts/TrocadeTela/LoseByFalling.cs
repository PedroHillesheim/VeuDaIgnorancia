using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseByFalling : MonoBehaviour
{
    public float triggerDistance = 3f;
    public Transform player;
    private bool isChanging = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance && !isChanging)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isChanging = true;
        }
    }
}
