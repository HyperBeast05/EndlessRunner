using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator m_playerAnim;

    private readonly int jUMP_HASH = Animator.StringToHash("Jump");
    private readonly int MAGIC_HASH = Animator.StringToHash("Magic");
    private void Awake()
    {
        m_playerAnim = GetComponent<Animator>();
    }

    public void Jump() => m_playerAnim.SetTrigger(jUMP_HASH);
    public void Magic() => m_playerAnim.SetTrigger(MAGIC_HASH);
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
