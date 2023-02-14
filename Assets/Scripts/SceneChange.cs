using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public int SceneNumber;
    // Start is called before the first frame update
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("Puerta");
                SceneManager.LoadScene(SceneNumber);
            }
        }
    }
}
