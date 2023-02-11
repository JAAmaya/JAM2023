using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public bool vacio;

    public Image icono;

    private void Start()
    {
        icono = transform.GetChild(0).GetComponent<Image>();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ActualizarSlot()
    {
        icono.sprite = item.icono;
        if(icono.sprite != null)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void Usar()
    {
        item?.Usar();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Usar();
    }
}
