using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace RPG
{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private Vector3 movementDistance;


        [Header("Movement Controller")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private bool _isMoving = false;
        [SerializeField] private bool _canMove = true;
        [SerializeField] private bool _runLeft = false;
        [SerializeField] private bool _runRight = false;

        [Header("Movement Parameters")]
        [SerializeField] private Vector2 _movementDirectionV2;
        [SerializeField] private Vector3 _movementDirectionV3;
        [SerializeField] private Vector3 _nextPosition;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _rotationPower = 3f;
        [SerializeField] private float _rotationLerp = 0.5f;

        [Header("Components")]
        [SerializeField] private Vector2 _lookDirection;
        [SerializeField] private Quaternion _nextRotation;

        [Header("Cinemachine")]
        public GameObject pointToFollow;

        [Header("Dash Parameters")]
        private float _dashInput;
        [SerializeField] private bool _canDash = true;
        [SerializeField] private bool _isDashing = false;
        [SerializeField] private float _dashLength = 2f;
        [SerializeField] private float _dashDuration = .25f;
        [SerializeField] private float _dashCooldown = 5f;
        [SerializeField] private float _dashStaminaCost = 10f;

        [Header("Player Attributes Controller")]
        [SerializeField] private PlayerAttributes _playerAttributes;
        private PlayerAttackSystem _playerAttackSystem;

        private void Start()
        {
            _playerAttributes = GetComponent<PlayerAttributes>();
            _characterController = GetComponent<CharacterController>();
            _playerAttackSystem = GetComponent<PlayerAttackSystem>();
        }

        private void Update()
        {   
            if(_playerAttackSystem.IsAttacking())
            {
                _canMove = false;
            }
            else
            {
                _canMove = true;
            }
            MovePlayer();
            RotatePlayer(_lookDirection);
            DashPlayer();
        }


        public void OnMovement(InputValue input)
        {
            _movementDirectionV2 = input.Get<Vector2>();
        }

        public void OnLook(InputValue input)
        {
            _lookDirection = input.Get<Vector2>();
        }
        public void OnDash(InputValue input)
        {
            _dashInput = input.Get<float>();
        }

        #region Update Functions
        private void MovePlayer()
        {
            if(_canMove)
            {
                Vector3 moveDirectionForward = transform.forward * _movementDirectionV2.y;
                Vector3 moveDirectionSide = transform.right * _movementDirectionV2.x;
                Vector3 moveDirectionVert = -transform.up;
                Vector3 _movementDirectionV3 = (moveDirectionForward + moveDirectionSide + moveDirectionVert).normalized;
                movementDistance = _movementDirectionV3 * _moveSpeed * Time.deltaTime;
                _characterController.Move(movementDistance);
                _isMoving = movementDistance.x == 0 && movementDistance.z == 0 ? false : true;

                if(Input.GetKeyDown(KeyCode.A))
                {
                    _runLeft = true;
                }
                else if(Input.GetKeyUp(KeyCode.S)) 
                {
                    _runLeft = false;
                }
                
            }
        }

        private void RotatePlayer(Vector2 rotateDirection)
        {
            pointToFollow.transform.rotation *= Quaternion.AngleAxis(_lookDirection.x * _rotationPower / 10, Vector3.up);
            pointToFollow.transform.rotation *= Quaternion.AngleAxis(_lookDirection.y * _rotationPower / 10, Vector3.right);
            Vector3 angles = pointToFollow.transform.localEulerAngles;
            angles.z = 0;
        
            float angle = pointToFollow.transform.localEulerAngles.x;
        
            if (angle > 180 && angle < 340)
            {
                angles.x = 340;
            }
            else if (angle < 180 && angle > 40)
            {
                angles.x = 40;
            }

            if (_movementDirectionV2.x == 0 && _movementDirectionV2.y == 0)
            {
                _nextPosition = transform.position;
                return;
            }

            pointToFollow.transform.localEulerAngles = angles;
            _nextRotation = Quaternion.Lerp(pointToFollow.transform.rotation, _nextRotation, Time.deltaTime * _rotationLerp);
        
            transform.rotation = Quaternion.Euler(0, pointToFollow.transform.rotation.eulerAngles.y, 0);
            pointToFollow.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
        }
        private void DashPlayer()
        {
            if (_dashInput != 0 && _canDash && _playerAttributes.GetCurrentStamina() >= _dashStaminaCost)
            {
                StartCoroutine(Dash());
                _playerAttributes.ReduceStamina(_dashStaminaCost);
            }
        }

        private IEnumerator Dash()
        {
            _canDash = false;
            _isDashing = true;

            _characterController.Move(transform.forward * _dashLength);
            yield return new WaitForSeconds(_dashDuration);

            _isDashing = false;
            yield return new WaitForSeconds(_dashCooldown);
            _canDash = true;
        }

        public bool IsPlayerMove()
        {
            return _isMoving;
        }

        public bool IsPlayerMoveLeft()
        {
            return _runLeft;
        }

        public bool IsPlayerMoveRight() 
        {
            return _runRight;
        }
        #endregion
        
    }
}