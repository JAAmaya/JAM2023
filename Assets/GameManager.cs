using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static int numVelas = 0, numViales = 0, numVelasS = 0;
    public static bool pag1 = false, pag2 = false, pag3 = false, tiza = false, tizaS = false, vialP = false, rosario = false, win= false, ritual = true;
    public Canvas Libro;
    public GameObject penta1, penta2, penta3,penta4;
    public GameObject vela1, vela2, vela3;

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

        if (pag2 && rosario && numVelas > 0 && !Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {

            Libro.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

        if ((pag1 && rosario && tiza) && !Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {

            Libro.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

        if ((pag3 && numViales > 0) && !Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).Find("Create").GetComponent<Button>().interactable)
        {

            Libro.transform.GetChild(0).GetChild(0).GetChild(4).GetChild(1).Find("Create").GetComponent<Button>().interactable = true;
        }

        if (tizaS == true && !vialP && !penta2.gameObject.activeInHierarchy)
        {
            penta1.gameObject.SetActive(false);
            penta2.gameObject.SetActive(true);
        }

        if (tizaS == true && vialP && !penta3.gameObject.activeInHierarchy)
        {
            penta2.gameObject.SetActive(false);
            penta3.gameObject.SetActive(true);
        }

        if (numVelasS > 0 && numVelasS < 2) 
        {
            vela1.gameObject.SetActive(true);
        }

        if (numVelasS > 1 && numVelasS < 3)
        {
            vela2.gameObject.SetActive(true);
        }

        if (numVelasS > 2 && numVelasS < 4)
        {
            vela3.gameObject.SetActive(true);
        }

        if (vialP && tizaS && numVelasS >= 3) 
        {
            penta4.gameObject.SetActive(true);
        }
        if (win) 
        {

        }

    }
}
