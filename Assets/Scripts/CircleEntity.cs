using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CircleEntity : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    private bool _isJumping;

    private float _startJumpVericalPos;
    
    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_isJumping)
            UpdateJump();
    }

    public void MoveHorizontally(float direction)
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = direction * _horizontalSpeed;
        _rigidbody.velocity = velocity;
    }
    
    public void MoveVertically(float direction)
    {
        if(_isJumping)
            return;
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = direction * _verticalSpeed;
        _rigidbody.velocity = velocity;
    }

    public void Jump()
    {
        if(_isJumping)
            return;

        _isJumping = true;
        _rigidbody.AddForce(Vector2.up * _jumpForce);
        _rigidbody.gravityScale = _gravityScale;
        _startJumpVericalPos = transform.position.y;
    }

    private void UpdateJump()
    {
        if (_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVericalPos)
        {
            ResetJump();
            return;
        }
    }

    private void ResetJump()
    {
        _isJumping = false;
        _rigidbody.position = new Vector2(_rigidbody.position.x, _startJumpVericalPos);
        _rigidbody.gravityScale = 0;
    }
}
