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

    private void Update()
    {
        SetVelocity();
    }

    public void SetVelocity()
    {
        transform.Translate(Vector3.up * 12f * Time.deltaTime);
    }



}
