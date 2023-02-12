using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (other.tag == "Item")
        {
            Debug.Log("a");
            UIPerma.transform.Find("Interact").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log("a");
            UIPerma.transform.Find("Interact").gameObject.SetActive(false);
        }
    }
}
