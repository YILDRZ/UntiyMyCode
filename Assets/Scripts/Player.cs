using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public Vector3 moveDir;
    Rigidbody rb;
    Animator anim;
    float startingSpeed, StartingJump, startingSprint;


    #region Movement

    [Header("Movement")]
    public float MoveSpeed;
    public float horizontalI, verticalI;
    #endregion
    #region Sprint
    [Header("Sprint")]
    public float SprintForce;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public bool issprinting;
    #endregion

    #region Jump
    [Header("Jump")]
    public float JumpForce;
    public float CoolDown;
    public float PlayerHeight = 2f;
    public KeyCode JumpKey = KeyCode.Space;
    public LayerMask ground;
    public bool isjump;
    public bool isground;
    #endregion

    #region Crouch

    [Header("Crouch")]
    public float CrouchHeight;
    public float CrouchSpeed;
    public KeyCode CrouchKey = KeyCode.LeftControl;
    float originalSpeed, originalHeight;
    Vector3 originalScale;

    #endregion
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
     
    }
    void Start()
    {
         //boost
        startingSpeed = MoveSpeed;
        StartingJump = JumpForce;
        startingSprint = SprintForce;
        //crouch
        originalSpeed = MoveSpeed;
        originalHeight = PlayerHeight;
        originalScale = transform.localScale;
        //jump
        isjump = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //raycast
        isground = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, ground);
        //animation
        anim.SetBool("IsGround", isground);
        

        if (isground)
        {
            anim.SetBool("JumpAnim", false);
        }

        Inputs();
       
    }
    void FixedUpdate()
    {
        Movement();
        
    }
    private void Inputs()
    {
        horizontalI = Input.GetAxis("Horizontal");
        verticalI = Input.GetAxis("Vertical");

        //sprint
        if (Input.GetKeyDown(sprintKey))
        {
            issprinting = true;
        }
        else if (Input.GetKeyUp(sprintKey))
        {
            issprinting = false;
        }

        //jump
        if (Input.GetKeyDown(JumpKey) && isjump && isground)
        {
            isjump = false;
            Jump();
            Invoke(nameof(ResetJump), CoolDown);
        }
        //crouch
        if (Input.GetKeyDown(CrouchKey))
        {
            StartCrouch();
        }
        else if (Input.GetKeyUp(CrouchKey))
        {
            StopCrouch();
        }
      
       
       
      
       
       
    }
    private void Movement()
    {
        //movement
        moveDir = transform.forward * verticalI + transform.right * horizontalI;
        //sprint
        float currentSpeed = issprinting ? SprintForce : MoveSpeed;

        //velocity 
        Vector3 moveVelocity = moveDir * currentSpeed;
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);

        

        
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);

        anim.SetBool("JumpAnim", true);
    }
    private void ResetJump()
    {
        isjump = true;
    }
   
    public void BoostSpeed(float sprint, float speed, float duration)
    {
        MoveSpeed += speed;
        SprintForce += sprint;
        Invoke(nameof(ResetSpeed), duration);
    }
    public void ResetSpeed()
    {
        MoveSpeed = startingSpeed;
        SprintForce = startingSprint;
    }
    public void BoostJump(float jump, float duration)
    {
        JumpForce += jump;
        Invoke(nameof(ResetBoostJump), duration);
    }
    public void ResetBoostJump()

    {
        JumpForce = StartingJump;
    }

    private void StartCrouch()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * CrouchHeight, transform.localScale.z);
        rb.AddForce(Vector3.down * 2f, ForceMode.Impulse);
        MoveSpeed *= CrouchSpeed;
        PlayerHeight *= CrouchHeight;
    }
    private void StopCrouch()

    {
        transform.localScale = originalScale;
        MoveSpeed = originalSpeed;
        PlayerHeight = originalHeight;
    }
  
  
   
}
