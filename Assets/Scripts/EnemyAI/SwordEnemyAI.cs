using UnityEngine;
using UnityEngine.AI;
public class SwordEnemyAI : MonoBehaviour
{
    [Header("References")]
  
    public Transform player;
    public NavMeshAgent Agent;
    
    Animator anim;
   
    [Header("Range")]
    public float detectRange = 15f;
    public float attackRange = 7f;

    [Header("Patrol Settings")]
    public float walkPointRange = 10f;
    Vector3 walkPoint;
    bool walkPointSet;

    
    

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
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
       anim.SetTrigger("Sheat");
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
           anim.SetTrigger("Draw");
            anim.SetFloat("Blend", 0.5f);
        }
        else
        {
            Agent.ResetPath();
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            anim.SetTrigger("Attack");
            anim.SetFloat("Blend", 0f);

          
        }
    }


}
