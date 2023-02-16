using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject inventario;
    public GameObject slots;

    private GameObject[] slot;
    private bool habilitado = false;
    private int slotsTotales, slotsDisponibles;

    private void Awake()
    {
        inventario.SetActive(false);
    }

    void Start()
    {
        slotsTotales = slots.transform.childCount;
        slot = new GameObject[slotsTotales];
        for (int i = 0; i < slotsTotales; i++)
        {
            slot[i] = slots.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().vacio = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            habilitado = !habilitado;
            FindObjectOfType<AudioManager>().Play("Inventario");
            inventario.SetActive(habilitado);
            if (habilitado)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {
    //        GameObject itemRecogido = other.gameObject;
    //        Item item = itemRecogido.GetComponent<Item>();
    //        AddItem(item);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("CogerObjeto");
                GameObject itemRecogido = other.gameObject;
                Item item = itemRecogido.GetComponent<Item>();
                if (item.ID == 15) { Debug.Log("b"); GameManager.rosario = true; }
                if (item.ID == 14) { Debug.Log("c"); GameManager.numVelas += 1; }
                if (item.ID == 13) { Debug.Log("e"); GameManager.numViales += 1; }
                if (item.ID == 12) { Debug.Log("f"); GameManager.tiza = true; }
                AddItem(item);
            }
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < slotsTotales; i++)
        {
            if (slot[i].GetComponent<Slot>().vacio)
            {
                item.recogido = true;
                slot[i].GetComponent<Slot>().item = item;
                item.gameObject.transform.parent = slot[i].transform;
                item.gameObject.SetActive(false);

                slot[i].GetComponent<Slot>().ActualizarSlot();

                slot[i].GetComponent<Slot>().vacio = false;

                return;
            }
        }
    }

    public bool Habilitado()
    {
        return habilitado;
    }

    public void DesecharObj(int id)
    {
        for (int i = 0; i < slotsTotales; i++)
        {
            slot[i] = slots.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item != null)
            {
                if (slot[i].GetComponent<Slot>().item.ID == id)
                {
                    slot[i].GetComponent<Slot>().item = null;
                    slot[i].GetComponent<Slot>().vacio = true;
                    slot[i].GetComponent<Slot>().icono = null;
                    //slot[i].GetComponent<Slot>().ActualizarSlot();
                }
            }


        }
    }

    public void CerrarInventario()
    {
        habilitado = !habilitado;
        FindObjectOfType<AudioManager>().Play("Inventario");
        inventario.SetActive(habilitado);
        if (habilitado)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
