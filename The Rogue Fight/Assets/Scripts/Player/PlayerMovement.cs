using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Summary

    // Purpose:     Responsible for the movement of the player
    // Callbacks:   Called from PlayerInput according to the inputs
    // Component:   Player Behaviour

    #endregion

    #region Editor Variables

    [SerializeField] [Range(1, 10)] private float _moveSpeed;

    [SerializeField] [Range(1, 10)] private float _jumpSpeed;
    [SerializeField] [Range(1, 10)] private float _jumpReach;

    #endregion

    #region Class Members

    private Animator _animator;

    private bool _isGrounded; // to check if the player is grounded, used to trigger jump

    #endregion


    private void Start()
    {
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Player Animator component is missing");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ground collision check to avoid jump while in the air
        if (collision.collider.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    public void Move(float horizontal)
    {
        if (horizontal != 0)
        {
            Vector3 amountToTranslate;
            // compute the amount to translate based on the horizontal in the range [-1, 1]
            amountToTranslate = Vector3.right * horizontal * _moveSpeed * Time.deltaTime;

            transform.Translate(amountToTranslate);

            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    IEnumerator JumpCoroutine()
    {
        _isGrounded = false;

        float startPosition = transform.position.y;
        float endPosition = transform.position.y + _jumpReach; // calculate the end position of the jump

        Vector3 amountToTranslate;
        float delta;

        Debug.Log("Started: " + endPosition);
        // loop until the endPosition is reached
        while (startPosition < endPosition)
        {
            delta = _jumpSpeed * Time.deltaTime;

            // compute the translation amount based on jumpSpeed
            amountToTranslate = Vector3.up * delta;

            transform.Translate(amountToTranslate);

            // increment startPosition by delta
            startPosition += delta;

            yield return new WaitForSeconds(0.0125f);
        }
        Debug.Log("Finished: " + transform.position.y);
    }

}
