```c sahrp
public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private PlayerState state = PlayerState.idle;
    private int maxHealth = 100;
    private int health;
    private int damage = 10;
    public int MaxHealth { get { return maxHealth;}}
    public int Health { get { return health; } }
    Vector3 moveDirection;
    private Animator anim;
   [SerializeField] internal bool isGround;
    [SerializeField] private Transform Feet;
    [SerializeField] private LayerMask Ground;
    
   [SerializeField] private Camera MainCamera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // 初始时隐藏光标
       anim = GetComponent<Animator>();
        health = MaxHealth;

    }

    void Update()
    {
        IsGrounded();
        switch (state)
        {
            case PlayerState.idle:
                HandleMovement();
                Attack();
                Jump();
                break;
            case PlayerState.run:
                HandleMovement();
                Jump();
                break;
            case PlayerState.die:
                Die();
                break;
        }
      
       
        MouseControl();
       
       
       
    }
    private void HandleMovement()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        Vector3 gravityVelocity = rb.velocity.y * Vector3.up;
        // 如果有移动方向，调整朝向
        if (moveDirection != Vector3.zero)
        {
           state = PlayerState.run;
            Vector3 forwardDirection = MainCamera.transform.forward;
            rb.velocity = moveDirection * 6f + gravityVelocity;//受到重力
      
            
                Quaternion targetRotation = Quaternion.LookRotation(forwardDirection);

                // 将玩家的旋转设置为目标旋转
                this.transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    360f * Time.deltaTime); 
           
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            state= PlayerState.idle;
        }
        
    }//移动控制
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up*200 , ForceMode.Impulse);
        }
    }
    private void MouseControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // 显示光标
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false; // 隐藏光标
            }
        }

    }//指针控制
    private void IsGrounded()
    {
        RaycastHit hit;
        isGround = Physics.Raycast(Feet.position, Vector3.down, out hit, 3f, Ground);
    }
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            Collider[] colliders = Physics.OverlapSphere(transform
                .position, 3f);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy"&&Vector3.Angle(
                    collider.transform.position-transform.position,
                    transform.forward)<60)
                {
                    collider.GetComponent<EnemyControl>().GetDamage(damage);
                }
            }
        }
    }
    private void Die()
    {
        anim.SetBool("isDie",true);
    }
    public void GetDamage(int damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            this.state= PlayerState.die;
        }
    }

}
public enum PlayerState
{ 
idle,
run,
die
}
```
``` c sharp
public class PlayerAnim : MonoBehaviour
{
    internal Animator anim;
    private float speed;
    private PlayerControl PlayerControl;
    private float jumpCD=0.5f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerControl = GetComponent<PlayerControl>();
      
    }
    void Update()
    {
        Run();
        Jump();    
    }
    private void Jump()
    {jumpCD-=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)&&PlayerControl.isGround)
        {
            if (speed > 0) anim.SetTrigger("JumpRun");
            else anim.SetTrigger("Jump");
        }
       
    }
    private void Run()
    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            speed = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs
                (vertical));
            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Vertical", vertical);
            anim.SetFloat("Speed", speed);
    }
    
   
}
```
