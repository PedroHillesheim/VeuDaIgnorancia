using UnityEngine;

public class TransicaodeTela : MonoBehaviour
{
    [SerializeField] GameObject virifica��o;
    Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        player = FindFirstObjectByType(typeof(Player)) as Player;
    }
}
