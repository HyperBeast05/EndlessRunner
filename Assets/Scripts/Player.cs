using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerAnimations m_playerAnim;
    private PlayerActions m_playerActions;
    private void Awake()
    {
        m_playerAnim = GetComponent<PlayerAnimations>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Jump(InputAction.CallbackContext context)
    {       
        m_playerAnim.Jump();
    }

    private void Magic(InputAction.CallbackContext context)
    {
        m_playerAnim.Magic();
    }
    private void OnEnable()
    {
        m_playerActions = new PlayerActions();
        m_playerActions.Enable();
        m_playerActions.PlayerMovement.Jump.performed += Jump;
        m_playerActions.PlayerMovement.Magic.performed += Magic;
    }
    private void OnDisable()
    {
        m_playerActions.Disable();
        m_playerActions.PlayerMovement.Jump.performed -= Jump;
        m_playerActions.PlayerMovement.Magic.performed -= Magic;

    }
}
