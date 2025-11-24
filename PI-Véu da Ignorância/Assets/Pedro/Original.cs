using UnityEngine;

public class Original : MonoBehaviour
{
    public GameObject arteOriginal;
    void Start()
    {
        arteOriginal.SetActive(false);
    }
    public void buttonOpen()
    {
        arteOriginal.SetActive(true);
    }
    public void buttonClose()
    {
        arteOriginal.SetActive(false);
    }
}
