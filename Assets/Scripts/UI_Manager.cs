using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas UIPerma;
    public GameObject llave;
    public GameObject wp;
    void Start()
    {
        wp = GameObject.FindGameObjectWithTag("WeaponManager");
        llave = wp.transform.Find("llave").gameObject;
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

        if (other.CompareTag("valla"))
        {
            UIPerma.transform.Find("Interact").GetComponent<TextMeshProUGUI>().SetText("Necesitas una llave");
            UIPerma.transform.Find("Interact").gameObject.SetActive(true);
        }
        Debug.Log(llave);
        if (other.CompareTag("valla") && llave.activeInHierarchy)
        {
            UIPerma.transform.Find("Interact").GetComponent<TextMeshProUGUI>().SetText("F abrir");
            UIPerma.transform.Find("Interact").gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
            UIPerma.transform.Find("Interact").gameObject.SetActive(false);
        
    }
}
