using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour, Iinteractuable
{
    private GameObject player;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private GameObject weapon;
    private SpriteRenderer weaponRenderer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        weapon = Instantiate(weaponPrefab, transform.position, transform.rotation);
        weapon.transform.SetParent(this.transform);
        weaponRenderer.sortingOrder = 1;
        weapon.SetActive(false);
    }
    public void Interaction()
    {
        weapon.SetActive(true);
        Transform weaponParent = player.transform.Find("Hand/Weapon");
        GameObject oldWeapon = weaponParent.GetChild(0).gameObject;
        oldWeapon.SetActive(true);
        oldWeapon.transform.SetParent(this.transform);
        weapon.transform.SetParent(weaponParent.transform);
        weapon = oldWeapon;
        weapon.SetActive(false);

        player.GetComponent<PlayerController>().UpdateWeapon();
    }
}