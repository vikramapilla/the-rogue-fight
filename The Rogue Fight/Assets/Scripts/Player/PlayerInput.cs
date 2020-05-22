using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    #region Summary

    // Purpose:     Responsible for the input from the player
    // Component:   Player Input

    #endregion

    #region Class Members

    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;

    #endregion

    private void Start()
    {
        // get references to the behaviour scripts
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        InputForMovement();
    }

    private void InputForMovement()
    {
        if (_playerMovement != null)
        {
            float horizontal = Input.GetAxis("Horizontal");

            _playerMovement.Move(horizontal);

            if (Input.GetKeyDown(KeyCode.W))
            {
                _playerMovement.Jump();
            }
        }
    }

    private void InputForAttack()
    {
        if (_playerAttack != null)
        {
            // call attack methods
        }

    }
}
