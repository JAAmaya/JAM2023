using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public int tipo;
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
                switch (tipo)
                {
                    case 1:
                        GameManager.tiza = true;
                        Destroy(this.gameObject);
                        break;
                    case 2:
                        GameManager.numViales += 1;
                        Destroy(this.gameObject);
                        break;
                    case 3:
                        GameManager.numVelas += 1;
                        Destroy(this.gameObject);
                        break;
                }
            }
            
                 
        }
    }
}
