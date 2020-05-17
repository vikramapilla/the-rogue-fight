using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager _instance;

    public static WeaponManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Weapon Manager not attached to a gameObject");
            }

            return _instance;
        }
    }

    private List<GameObject> _weaponBuffer;

    private void Awake()
    {
        _instance = this;

        _weaponBuffer = new List<GameObject>();
    }

    public void GenerateWeapons(GameObject weaponPrefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject weapon = CreateWeapon(weaponPrefab);
            weapon.SetActive(false);

            _weaponBuffer.Add(weapon);
        }
    }

    private GameObject CreateWeapon(GameObject weaponPrefab)
    {
        return Instantiate(weaponPrefab, gameObject.transform);
    }

    public GameObject GetWeapon()
    {
        foreach(GameObject weapon in _weaponBuffer)
        {
            if (weapon.activeSelf == false)
            {
                weapon.SetActive(true);
                return weapon;
            }
        }

        GameObject newWeapon = CreateWeapon(_weaponBuffer[0]);
        newWeapon.SetActive(false);

        _weaponBuffer.Add(newWeapon);

        return newWeapon;
    }

}
