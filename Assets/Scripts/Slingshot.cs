using CharecterSystem.Action;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _lenght;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _force;
    [SerializeField] private JumpCharecter _jumpCharecter;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    private Vector3 _initialPosition;
    private Vector3 _currentPosition;
    public bool IsMouseDown { get; private set; }
    public bool IsGround { get; set; }
    public bool CanRot { get; set; } = true;

    public void Update()
    {
        if (IsGround)
        {
            if(CanRot) _sprite.flipX = (_currentPosition - transform.position).x > 0;

            if (Input.GetMouseButtonDown(0) && IsMouseDown)
            {
                _initialPosition = transform.position;
                _lineRenderer.SetPosition(0, _initialPosition);
                _lineRenderer.positionCount = 1;
                _lineRenderer.enabled = true;
            }
            else if (IsMouseDown)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;

                _currentPosition = Camera.main.ScreenToWorldPoint(mousePos);
                _currentPosition = transform.position + Vector3.ClampMagnitude(_currentPosition - transform.position, _lenght);
                _lineRenderer.positionCount = 2;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, _currentPosition);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                _lineRenderer.enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (IsGround)
        {
            _animator.SetInteger("JumpPower", 10);
            IsMouseDown = true;
        }
    }

    private void OnMouseUp()
    {
        if (IsGround)
        {
            _animator.SetInteger("JumpPower", 0);
            IsMouseDown = false;
            Vector3 force = (_currentPosition - transform.position) * _force * -1;
            _jumpCharecter.Jump(force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGround = false;
    }
}
