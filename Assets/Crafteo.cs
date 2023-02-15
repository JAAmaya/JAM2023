using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafteo : MonoBehaviour
{
    public Button crafTiza, crafVela, crafVial;
    public GameObject tizaS, velaS, vialP;
    Inventario inventario;
    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CraftT() 
    {
        Debug.Log("hice una tiza");
        GameManager.tiza = false;
        GameManager.tizaS = true;
        crafTiza.interactable = false;
    }
    public void CraftVeS()
    {
        Debug.Log("hice una vela");
        GameManager.numVelas -= 1; 
        
        GameManager.numVelasS += 1;
        
        crafVela.interactable = false;
    }
    public void CraftViS()
    {
        Debug.Log("hice un vial");
        GameManager.numViales -= 1;
        GameManager.vialP = true;
        crafVial.interactable = false;
    }
}
