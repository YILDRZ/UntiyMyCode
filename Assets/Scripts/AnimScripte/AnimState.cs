using UnityEngine;

public class AnimState : MonoBehaviour
{
   public enum PlayerState
    {
        Idle, Walk,Run
    }
    public PlayerState currentState;
    [Header("Ref")]
    Player player;
    public Animator anim;
    void Awake()
    {
         player=GetComponent<Player>();
    }
    void Update()
    {
        HandleState();
    }
    public void HandleState()
    {
        //state machine ne yapacağını değil nasıl geçiş yapacağını bilmeli 
        switch (currentState)
        {
            case PlayerState.Idle:
            IdleAnim();
            break;

            case PlayerState.Walk:
            WalkAnim();
            break;

            case PlayerState.Run:
            RunAnim();
            break;
        }
    }
    //---------------------ANIMATIONS----------------------------
    private void IdleAnim()
    {
       anim.SetFloat("Blend",0,0.1f,Time.deltaTime);

       if( player.horizontalI!=0 || player.verticalI != 0)
        {
            currentState=PlayerState.Walk;
        }
        
    }
     private void WalkAnim()
    {
        anim.SetFloat("Blend",0.5f,0.1f,Time.deltaTime);

        if(player.horizontalI==0 && player.verticalI == 0)
        {
            currentState=PlayerState.Idle;
        }
        if (player.issprinting)
        {
            currentState=PlayerState.Run;
        }
    } 
    
    private void RunAnim()
    {
         anim.SetFloat("Blend",1f,0.1f,Time.deltaTime);
         

        if (!player.issprinting)
        {
            currentState=PlayerState.Walk;
        }
    }
   
}
