using TMPro;
using UnityEngine;

public class BoostObject : MonoBehaviour
{
   
   
    public float boostSpeed, BoostJump, BoostSprint;
    
    [Header("References")]
    Player player;
    Animator anim;
    HealthComp healtComp;
    MySoundFX mySoundFX;
  
    Spell spell;
    float spellSpeed = 2f; //spell 2 saniyeye tekrardan almak için

    void Awake()
    {
        player = FindAnyObjectByType<Player>();
        spell = GetComponent<Spell>();
        healtComp = GetComponent<HealthComp>();
        mySoundFX=GetComponent<MySoundFX>();
        
        anim = player.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoostObject"))
        {
           
           
            //player boost
            player.BoostSpeed(BoostSprint, boostSpeed, 10f);
            player.BoostJump(BoostJump, 10f);

            //anim speed
            anim.speed = 1.5f;
            Invoke(nameof(ResetAnimSpeed), 10f);

            //spell speed
            spell.spellDuration = 1.5f; // spell cooldown 1.5 saniyeye düşürmek için
            Invoke(nameof(ResetSpellSpeed), 10f); // 10f (10 saniye sonra biter ve spell 2f ye geri döner)

            mySoundFX.BoostFX();

            Destroy(other.gameObject);

        }
        if (other.CompareTag("Heal"))
        {
           
            if (healtComp.currentHP != 100)
            {
                healtComp.RestoerHP(20);
                //soundFX
                 mySoundFX.HealthFX();
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("HP allready max");
            }
            
           
        }

    }
    private void ResetAnimSpeed()
    {
        anim.speed = 1f;
    }
    private void ResetSpellSpeed()
    {
        spell.spellDuration = spellSpeed;
    }
   
   
}
