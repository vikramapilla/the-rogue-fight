using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Summary
    
    // Purpose:     Responsible for the movement of the player
    // Component:   Player Behaviour
    
    #endregion

    #region Editor Variables

    [SerializeField] [Range(1, 10)] private float _moveSpeed;

    [SerializeField] [Range(1, 10)] private float _jumpSpeed;
    [SerializeField] [Range(1, 10)] private float _jumpReach;

    #endregion

    #region Class Members

    private Animator _animator;

    private float _moveDirection;
    private bool _isJumping;

    #endregion


    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Player Animator component is missing");
        }
    }


    private void Update()
    {
        CheckForMovement();
        CheckForJump();
    }

    private void CheckForMovement()
    {
        _moveDirection = Input.GetAxis("Horizontal");

        // move the player when Horizontal keys are pressed
        if (_moveDirection != 0)
        {
            Move(_moveDirection);
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }

    private void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void Move(float moveDirection)
    {
        Vector3 amountToTranslate;

        // compute the amount to translate based on the moveDirection in range [-1, 1]
        amountToTranslate = Vector3.right * moveDirection * _moveSpeed * Time.deltaTime;

        transform.Translate(amountToTranslate);
    }

    private void Jump()
    {
        if (_isJumping == false)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    IEnumerator JumpCoroutine()
    {
        _isJumping = true;

        float startPosition = transform.position.y;
        float endPosition = transform.position.y + _jumpReach; // calculate the end position of the jump

        Vector3 amountToTranslate;

        // loop until the endPosition is reached
        while (startPosition < endPosition)
        {
            // compute the translation amount based on jumpSpeed
            amountToTranslate = Vector3.up * _jumpSpeed * Time.deltaTime;

            transform.Translate(amountToTranslate);

            // set current position to the startPosition
            startPosition = transform.position.y;

            yield return new WaitForSeconds(0.0125f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ground collision check to avoid jump while in the air
        if (collision.collider.tag == "Ground")
        {
            _isJumping = false;
        }
    }

}
