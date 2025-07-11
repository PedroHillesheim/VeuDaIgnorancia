using UnityEngine;
using UnityEngine.Events;

public class PuzzleGameController : MonoBehaviour
{
    public int errosans = 0;
    public UnityEvent win7ErrosCondicion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(errosans == 7)
        {
            win7ErrosCondicion.Invoke();
        }
    }
}
