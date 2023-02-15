using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PagLibro : MonoBehaviour
{
    static int pagina = 0;
    public Image libro;
    public int maxPag;
    private bool habilitado = false;
    public GameObject handBook;
    public GameObject inventario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && handBook.activeInHierarchy)
        {
            habilitado = !habilitado;
            FindObjectOfType<AudioManager>().Play("Inventario");
            this.transform.GetChild(0).gameObject.SetActive(habilitado);
            if (habilitado)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (!handBook.activeInHierarchy && !inventario.activeInHierarchy) 
        {
            habilitado = false;
            Cursor.lockState = CursorLockMode.Locked;
            this.transform.GetChild(0).gameObject.SetActive(habilitado);
        }
    }
    public void NextPage() 
    {
        if (pagina < maxPag) 
        {
            libro.transform.GetChild(pagina).gameObject.SetActive(false);
            libro.transform.GetChild(pagina + 1).gameObject.SetActive(true);
            pagina += 1;
        }
        
    }
    public void PrevPage()
    {
        if (pagina > 0)
        {
            libro.transform.GetChild(pagina).gameObject.SetActive(false);
            libro.transform.GetChild(pagina - 1).gameObject.SetActive(true);
            pagina -= 1;
        }

    }

    public bool Habilitado()
    {
        return habilitado;
    }
}
