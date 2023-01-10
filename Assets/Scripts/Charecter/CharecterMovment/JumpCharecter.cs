using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace CharecterSystem.Action
{
    public class JumpCharecter : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Slingshot _lingshot;
        [SerializeField] private Animator _animator;
        [SerializeField] private float crawlerRadiusX;
        [SerializeField] private float crawlerRadiusY;
        [SerializeField] private Transform _transform;
        [SerializeField] private LayerMask _layerMask;

        public bool IsJumping { get; private set; } = false;

        public void Jump(Vector3 force)
        {
            _animator.SetBool("Jump", false);
            if (!IsJumping)
            {
            _lingshot.CanRot = true;
            }
            _rb.velocity = force;
            IsJumping = true;
        }

        void FixedUpdate()
        {
            Debug.DrawRay(_transform.position, transform.up * crawlerRadiusY, Color.red);
            RaycastHit2D hit1U = Physics2D.Raycast(_transform.position, Vector2.up, crawlerRadiusY, _layerMask);
            Debug.DrawRay(_transform.position, -transform.up * crawlerRadiusY, Color.red);
            RaycastHit2D hit1D = Physics2D.Raycast(_transform.position, -Vector2.up, crawlerRadiusY, _layerMask);
            Debug.DrawRay(_transform.position, transform.right * crawlerRadiusX , Color.red);
            RaycastHit2D hit1R = Physics2D.Raycast(_transform.position, Vector2.right, crawlerRadiusX, _layerMask);
            Debug.DrawRay(_transform.position, -transform.right * crawlerRadiusX, Color.red);
            RaycastHit2D hit1L = Physics2D.Raycast(_transform.position, -Vector2.right, crawlerRadiusX, _layerMask);



            if (!IsJumping)
            {
            _lingshot.CanRot = false;
            if (hit1R.collider != null || hit1L.collider != null)
            {
            _animator.SetBool("Jump", false);
            _lingshot.CanRot = false;
            _animator.SetBool("Climb", true);
            _transform.rotation = new Quaternion(0, 0, 0, 0);
            return;
            }

            else if (hit1U.collider != null)
            {
                    if (transform.rotation.z != 1) {
                        _transform.rotation = new Quaternion(0, 0, 90, 0);
                    }
            _lingshot.CanRot = false;
            _animator.SetBool("Climb", false);
            _animator.SetBool("Jump", false);
            return;
            }

            else if (hit1D.collider != null)
            {
            _transform.rotation = new Quaternion(0, 0, 0, 0);
            _animator.SetBool("Climb", false);
            _animator.SetBool("Jump", false);
            _lingshot.CanRot = false;
            return;
            }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Adhesion();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Stop")) _rb.gravityScale = 1;
        }

        private void Adhesion()
        {
            _lingshot.CanRot = false;
            _rb.gravityScale = 0;
            _animator.SetBool("Jump", false);
            _rb.velocity = Vector2.zero;
            IsJumping = false;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _rb.gravityScale = 1;
            _animator.SetBool("Jump", true);
        }
    }
}