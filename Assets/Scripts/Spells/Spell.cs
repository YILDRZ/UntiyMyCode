
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    
    public Transform SpellPos;
    public SpellMenu spellMenu;
    [Header("Values")]
     public bool canspell;
    public float spellDuration;
 

    [Header("Sound Settings")]
    MySoundFX mySoundFX;

     [Header("Spell UI")]
     public Image CoolDownImage;
    public float cooldownTimer;
    float timer;
    bool iscooldown;
    [Header("Ref")]
    Animator anim;
    void Awake()
    {
         anim = GetComponent<Animator>();
        mySoundFX = GetComponent<MySoundFX>();
    }
    void Start()
    {
        canspell = true;
       

        //sepll UI
        timer=0;
        CoolDownImage.fillAmount=0f;
        iscooldown=false;
        
        
    }

    void Update()
    {
        Inputs();
        ResetCoolDownUI();
    }
   
    public void Inputs()
    {      
        
           
            //spell
             if (Input.GetMouseButtonDown(0) && canspell && anim.GetBool("Aiming"))
             {
          

            canspell = false;
            CastSpell();
            Invoke(nameof(ResetSpell), spellDuration);
            //sound effect
            mySoundFX.SpellFX();
            //UI
            StartCoolDownUI();
          }
        
      
        
    }
    private void CastSpell()
    {
        GameObject spell = Instantiate(spellMenu.spellPrefab, SpellPos.position, SpellPos.rotation);
        Rigidbody rb = spell.GetComponent<Rigidbody>();

        rb.linearVelocity = SpellPos.forward * spellMenu.speed;
        Destroy(spell, spellMenu.Duration);
    }
    private void ResetSpell()
    {
        canspell = true;
    }
    public void StartCoolDownUI()
    {
        timer=cooldownTimer;
        CoolDownImage.fillAmount=1f;
        iscooldown=true;

    }
    private void ResetCoolDownUI()
    {
        timer-=Time.deltaTime;
        CoolDownImage.fillAmount=timer/cooldownTimer;
        if (timer <= 0)
        {
            CoolDownImage.fillAmount=0;
            iscooldown=false;
        }
    }
 
}
