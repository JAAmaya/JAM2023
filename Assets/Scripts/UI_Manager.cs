using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas UIPerma;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Item"))
        {
            UIPerma.transform.Find("Interact").GetComponent<TextMeshProUGUI>().SetText("E coger");
            UIPerma.transform.Find("Interact").gameObject.SetActive(true);
        }

        if (other.CompareTag("door"))
        {
            UIPerma.transform.Find("Interact").GetComponent<TextMeshProUGUI>().SetText("E entrar en las catacumbas");
            UIPerma.transform.Find("Interact").gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
            UIPerma.transform.Find("Interact").gameObject.SetActive(false);
        
    }
}
