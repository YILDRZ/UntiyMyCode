using UnityEngine;
using UnityEngine.AI;

public class EnemyAı : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent Agent;
    MySoundFX mySoundFX;
    Animator anim;

    [Header("Range")]
    public float detectRange = 15f;
    public float attackRange = 7F;
    float walkPointRange;
    Vector3 walkPoint;

    [Header("SpellAttack")]
    public GameObject spellPrefab;  
    public Transform spellSpawnPos;   
    public float spellSpeed = 20f;
    public float spellDuration = 3f;  
    public float attackCooldown = 2f; 

    bool canspell;
    void Awake()
    {
         Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
         mySoundFX = FindAnyObjectByType<MySoundFX>();
    }
    void Start()
    {
        canspell = true;
    }

    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            Agent.SetDestination(player.position); //haraket başlat
            anim.SetFloat("Blend", 0.5f);
            
            if (distance <= attackRange)
            {
                Agent.ResetPath(); //hareketi durdur
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                anim.SetBool("Aiming", true);
                anim.SetFloat("Blend", 0f);

                if (canspell)
                {
                    anim.SetTrigger("spellAttack");
                    CastSpell();
                    canspell = false;
                    Invoke(nameof(ResetShoot), attackCooldown);
                    //soundfx
                    mySoundFX.SpellFX();
                }
            }
        }
        else
        {
            Agent.ResetPath();
            anim.SetBool("Aiming", false);
            anim.SetFloat("Blend", 0f);
        }
    }
   
    private void CastSpell()
    {
        GameObject spell = Instantiate(spellPrefab, spellSpawnPos.position, spellSpawnPos.rotation);
        Rigidbody rb = spell.GetComponent<Rigidbody>();

        rb.linearVelocity = spellSpawnPos.forward * spellSpeed;
        Destroy(spell, spellDuration);
    }

    private void ResetShoot()
    {
        canspell = true;
    }
    
}
