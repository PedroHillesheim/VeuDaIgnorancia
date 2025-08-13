using UnityEngine;

public class CheckDeReconstrucao : MonoBehaviour
{
    public bool check = false;
    public bool sePegou = false;
    public GameObject material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (check == false)
        {
            check = true;
            sePegou = true;
            Destroy(material);
            Debug.Log($"Check = {check} sePegou = {sePegou}");
        }
    }
}
