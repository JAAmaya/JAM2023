using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int numVelas = 0, numViales = 0, numVelasS = 0;
    public static bool pag1 = false, pag2 = false, pag3 = false, tiza = false, tizaS = false, vialP = false, rosario = false;
    public Canvas Libro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pag1 && !Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).gameObject.activeInHierarchy) 
        {
            Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
        if (pag2 && !Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).gameObject.activeInHierarchy)
        {
            Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(true);
        }
        if (pag3 && !Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).gameObject.activeInHierarchy)
        {
            Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).gameObject.SetActive(true);
        }

        if (pag2 && rosario && numVelas>0 && !Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {
             
            Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

        if ((pag1 && rosario && tiza) && !Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {
            
            Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

        if ((pag3 && numViales>0) && !Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {

            Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

    }
}
