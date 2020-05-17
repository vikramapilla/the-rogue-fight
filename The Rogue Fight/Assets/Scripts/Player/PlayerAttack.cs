using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    #region Summary

    // Purpose:     Responsible for the player attack
    // Component:   Player Behaviour

    #endregion

    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _weaponStartPoint;

    [SerializeField] private float _attackCooldown;

    private Animator _animator;

    private float _currentCooldown;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Player Animator component is missing");
        }

        _currentCooldown = _attackCooldown;

        WeaponManager.Instance.GenerateWeapons(_weapon, 10);
    }

    private void Update()
    {

        _currentCooldown += Time.deltaTime;

        if(_currentCooldown > _attackCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();

                _animator.SetTrigger("shooting");
                _currentCooldown = 0;
            }
        }
    }

    private void Attack()
    {
        StartCoroutine(DelayInstantiateWeaponCoroutine());
    }

    IEnumerator DelayInstantiateWeaponCoroutine()
    {
        yield return new WaitForSeconds(0.25f);

        GameObject weapon = WeaponManager.Instance.GetWeapon();

        weapon.transform.position = _weaponStartPoint.transform.position;
        weapon.transform.rotation = _weapon.transform.rotation;

        weapon.GetComponent<Weapon>().SetVelocity();
    }

}
