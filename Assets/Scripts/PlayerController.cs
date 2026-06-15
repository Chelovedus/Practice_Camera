using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private MovementParticles _movementParticles;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (_movementParticles != null)
        {
            _movementParticles.SetMoving(_moveDirection.sqrMagnitude > 0.01f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _moveDirection * _moveSpeed;
        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;
    }
}