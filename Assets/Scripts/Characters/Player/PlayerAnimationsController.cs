using UnityEngine;

namespace RPG
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        private void Start()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            ConnectAnimations();
        }

        private void ConnectAnimations()
        {
            #region Run Forward
            if (Input.GetKeyDown(KeyCode.W))
            {
                _playerAnimator.SetBool("Running", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _playerAnimator.SetBool("Running", false);
            }
            #endregion

            #region Run Backward
            if (Input.GetKeyDown(KeyCode.S))
            {
                _playerAnimator.SetBool("RunBackward", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _playerAnimator.SetBool("RunBackward", false);
            }
            #endregion

            #region Strafe Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                _playerAnimator.SetBool("RunRight", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _playerAnimator.SetBool("RunRight", false);
            }
            #endregion

            #region Strafe Left

            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerAnimator.SetBool("RunLeft", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _playerAnimator.SetBool("RunLeft", false);
            }
            #endregion
        }
    }
}
