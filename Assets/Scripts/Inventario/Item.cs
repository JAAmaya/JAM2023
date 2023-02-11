using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string descripcion;
    public Sprite icono;

    [HideInInspector]
    public bool recogido, equipado;

    [HideInInspector]
    public GameObject WeaponManager, weapon;

    public bool playersWeapon;

    private void Start()
    {
        WeaponManager = GameObject.FindWithTag("WeaponManager");
        if(!playersWeapon)
        {
            int allWeapons = WeaponManager.transform.childCount;
            for(int i = 0; i < allWeapons; i++)
            {
                if(WeaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = WeaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (equipado)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                equipado = false;
            }
            if(!equipado)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Usar()
    {
        if (type == "Arma")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipado = true;
            //equipado = true;
        }
    }
}
