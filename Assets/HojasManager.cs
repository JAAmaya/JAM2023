using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HojasManager : MonoBehaviour
{
    public int numPg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                switch (numPg) 
                {
                    case 1:
                        Debug.Log("a");
                        GameManager.pag1 = true;
                        Destroy(this.gameObject);
                        break;
                    case 2:
                        GameManager.pag2 = true;
                        Destroy(this.gameObject);
                        break;
                    case 3:
                        GameManager.pag3 = true;
                        Destroy(this.gameObject);
                        break;
                }
            }
        }
        
    }
}
