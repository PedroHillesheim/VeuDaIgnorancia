using UnityEngine;
using UnityEngine.Events;

public class Testar : MonoBehaviour
{
    public bool winOneTime = false;
    public int errosans = 0;
    TestarGamecontroler testarGameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testarGameController = FindFirstObjectByType(typeof(TestarGamecontroler)) as TestarGamecontroler;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void OnMouseDown()
    {
        if (winOneTime == false) 
        { 
            testarGameController.errosans++;
        }
    }
}
