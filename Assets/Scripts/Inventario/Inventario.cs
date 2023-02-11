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

    void Start()
    {
        inventario.SetActive(false);
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
                GameObject itemRecogido = other.gameObject;
                Item item = itemRecogido.GetComponent<Item>();
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
}
