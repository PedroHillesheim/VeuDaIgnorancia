using UnityEngine;
using UnityEngine.Events;

public class TestarGamecontroler : MonoBehaviour
{
    public int errosans = 0;
    public UnityEvent win7ErrosCondicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(errosans >= 1)
        {
            win7ErrosCondicion.Invoke();
        }
    }
}
