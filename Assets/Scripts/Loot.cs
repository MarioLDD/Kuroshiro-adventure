using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour, Iinteractuable
{
    private GameObject player;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private GameObject weapon;
    private SpriteRenderer weaponRenderer;
    private PlayerController playerController;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        
    }
    void Start()
    {
        weapon = Instantiate(weaponPrefab, this.transform.position, this.transform.rotation, this.transform);
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
        weaponRenderer.sortingOrder = 1;
        weapon.SetActive(false);
    }
    public void Interaction()
    {
        weapon.SetActive(true);
        Transform weaponParent = player.transform.Find("Hand/Weapon");
        GameObject oldWeapon = weaponParent.GetChild(0).gameObject;
        oldWeapon.transform.SetParent(this.transform, false);
        weapon.transform.SetParent(weaponParent.transform, false);
        weapon = oldWeapon;

        playerController.UpdateWeapon();
    }
}