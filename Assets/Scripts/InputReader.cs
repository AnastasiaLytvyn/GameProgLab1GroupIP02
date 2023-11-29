using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CircleEntity _circleEntity;

    private float _directionX;
    private float _directionY;
    
    private void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _directionY = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
            _circleEntity.Jump();
    }
    
    private void FixedUpdate()
    {
        _circleEntity.MoveHorizontally(_directionX);
        _circleEntity.MoveVertically(_directionY);
    }
}
