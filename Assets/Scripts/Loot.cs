using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour, Iinteractuable
{
    private GameObject player;
    [SerializeField] private GameObject weapon;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Interaction()
    {
        Transform weaponParent = player.transform.Find("Hand/Weapon");
        Destroy(weaponParent.GetChild(0).gameObject);
        GameObject newWeapon = Instantiate(weapon, weaponParent.position, weaponParent.rotation);
        newWeapon.transform.SetParent(weaponParent.transform);
        player.GetComponent<PlayerController>().UpdateWeapon();
    }    
}
