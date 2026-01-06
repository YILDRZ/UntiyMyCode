using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


public class HitDamage : MonoBehaviour
{
  
   public ParticleSystem particleExpolosion;
    public ParticleSystem particleFire;
    public ParticleSystem particleFlash;
    public ParticleSystem particleSmoke;

    [Header("References")]
    MySoundFX mySoundFX;
   
    public SpellMenu spellMenu;
   

    void Awake()
    {
        mySoundFX = FindAnyObjectByType<MySoundFX>();
       
    }
    public void OnTriggerEnter(Collider other)
    {
        //enemy
        if (other.CompareTag("Hit"))
        {
            other.GetComponent<HealthComp>().TakeDamage(spellMenu.damage);

               //OBJ
                Destroy(gameObject);
                //FX
                SpellParticle();
                //sound
                 mySoundFX.HitFX();
            
            CameraShake.Instance.ShakeCamera(0.5f,0.5f);
        }
        //enemy2
        if (other.CompareTag("Enemy2"))
        {
            if (spellMenu.damage >= 20)
            {
                 other.GetComponent<HealthComp>().TakeDamage(spellMenu.damage);
                //OBJ
                Destroy(gameObject);
                //FX
                SpellParticle();
                //sound
                 mySoundFX.HitFX();
            
               CameraShake.Instance.ShakeCamera(0.5f,0.5f);
            }
            else
            {
                Debug.Log("Power Uplan!!");
            }
        }
        //enemy3
          if (other.CompareTag("Enemy3"))
        {
            if (spellMenu.damage >= 30)
            {
                 other.GetComponent<HealthComp>().TakeDamage(spellMenu.damage);
                //OBJ
                Destroy(gameObject);
                //FX
                SpellParticle();
                //sound
                 mySoundFX.HitFX();
            
               CameraShake.Instance.ShakeCamera(0.5f,0.5f);
            }
            else
            {
                Debug.Log("Power Uplan!!");
            }
        }
        //OBJ
        if (other.CompareTag("DestructOBJ"))
        {
            other.GetComponent<InteractableOBJ>().DestructActive();

                //OBJ
                Destroy(gameObject);
                //FX
                SpellParticle();
                //sound
                 mySoundFX.HitFX();
        }

    }
    public void SpellParticle()
    {
         //particle Efect
            if (particleExpolosion != null)
            {
                ParticleSystem exp = Instantiate(particleExpolosion, transform.position, Quaternion.identity);
                exp.Play();
                Destroy(exp.gameObject, exp.main.duration);
            }

            if (particleFire != null)
            {
                ParticleSystem fire = Instantiate(particleFire, transform.position, Quaternion.identity);
                fire.Play();
                Destroy(fire.gameObject, fire.main.duration);
            }

            if (particleFlash != null)
            {
                ParticleSystem flash = Instantiate(particleFlash, transform.position, Quaternion.identity);
                flash.Play();
                Destroy(flash.gameObject, flash.main.duration);
            }

            if (particleSmoke != null)
            {
                ParticleSystem smoke = Instantiate(particleSmoke, transform.position, Quaternion.identity);
                smoke.Play();
                Destroy(smoke.gameObject, smoke.main.duration);
            }

           
           
    }
    
   
}
