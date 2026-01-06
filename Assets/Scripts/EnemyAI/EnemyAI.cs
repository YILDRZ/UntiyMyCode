using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
  
    public Transform player;
    public NavMeshAgent Agent;
    MySoundFX mySoundFX;
    Animator anim;
   
    [Header("Range")]
    public float detectRange = 15f;
    public float attackRange = 7f;

    [Header("Patrol Settings")]
    public float walkPointRange = 10f;
    Vector3 walkPoint;
    bool walkPointSet;

    [Header("SpellAttack")]
    public SpellMenu spellMenu;
    public Transform spellSpawnPos;
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
            ChasePlayer(distance);
        }
        else
        {
            Patrol();
        }
    }

  
    private void Patrol()
    {
        anim.SetBool("Aiming", false);
        anim.SetFloat("Blend", 0.5f);

        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
            Agent.SetDestination(walkPoint);

        float distanceToWalkPoint = Vector3.Distance(transform.position, walkPoint);

        // Hedefe ulaştı
        if (distanceToWalkPoint < 1.5f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(walkPoint, out hit, 2f, NavMesh.AllAreas))
        {
            walkPoint = hit.position;
            walkPointSet = true;
        }
    }

  
    private void ChasePlayer(float distance)
    {
        if (distance > attackRange)
        {
            Agent.SetDestination(player.position);
            anim.SetBool("Aiming", false);
            anim.SetFloat("Blend", 0.5f);
        }
        else
        {
            Agent.ResetPath();
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            anim.SetBool("Aiming", true);
            anim.SetFloat("Blend", 0f);

            if (canspell)
            {
                anim.SetTrigger("spellAttack");
                CastSpell();
                canspell = false;
                Invoke(nameof(ResetShoot), attackCooldown);

                // soundfx
                mySoundFX.SpellFX();
            }
        }
    }

    private void CastSpell()
    {
      GameObject spell = Instantiate(spellMenu.spellPrefab, spellSpawnPos.position, spellSpawnPos.rotation);
        Rigidbody rb = spell.GetComponent<Rigidbody>();

        rb.linearVelocity = spellSpawnPos.forward * spellMenu.speed;
        Destroy(spell, spellMenu.Duration);
    }

    private void ResetShoot()
    {
        canspell = true;
    }
   
}
