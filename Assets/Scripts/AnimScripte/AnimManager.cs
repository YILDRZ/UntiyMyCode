using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [Header("Values")]
     public Animator anim;
    bool attack=true;

     void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
         InputAction();
       
    }
    public void InputAction()
    {
         // spell combat anim
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Aiming", true);
            attack=false;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Aiming", false);
            attack=true;
        }
        if (Input.GetMouseButtonDown(0) && anim.GetBool("Aiming"))
            anim.SetTrigger("spellAttack");
        
       


        //combat anim
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Draw");
            anim.SetBool("IsDraw",true);
           
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            anim.SetTrigger("Sheat");
             anim.SetBool("IsDraw",false);
             

        }
        if (Input.GetMouseButtonDown(0) && attack && anim.GetBool("IsDraw"))
        {
          AttackAnim();
        }
       
       

         
    }

    public void AttackAnim()
    {
        attack = false;
        anim.SetTrigger("Attack");
       
        Invoke(nameof(ResetAttack), 1f);  // cooldown
    }

    private void ResetAttack()
    {
        attack = true;
    }
   public void PowerUpAnim() => anim.SetTrigger("PowerUp");

 
}
