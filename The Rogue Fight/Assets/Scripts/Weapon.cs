using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    public void SetVelocity()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.right * _speed;
    }

}
