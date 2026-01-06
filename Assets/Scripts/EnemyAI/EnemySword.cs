using UnityEngine;

public class EnemySword : MonoBehaviour
{
    public float swordDamage=20f;
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthComp>().TakeDamage(swordDamage); 
           
           
        }
    }
}
