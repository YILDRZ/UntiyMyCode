using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthComp : MonoBehaviour
{
   [Header("Values")]
    public float maxHealth = 100f;
    public float currentHP;
    public Slider slider;
    public event Action Death;
    [Header("Ref")]
       AnimManager animManager;
      public DropItem dropItem;
 
    void Awake()
    {
        animManager=GetComponent<AnimManager>();
    }
    void Start()
    {
         currentHP = maxHealth;
        slider.maxValue=maxHealth;
        slider.value=currentHP;
    }


    public void TakeDamage(float damage)
    {
        currentHP -= damage;
      //anim
      if (animManager != null && animManager.anim != null)
        animManager.anim.SetTrigger("IsDamaged");
         //UI
        slider.value=currentHP;
       //HP
        if (currentHP <= 0)
        {
            Died();
        }
        
    }
    public void RestoerHP(float RestoreHP)
    {
       
      if (currentHP >= maxHealth)
     {
        currentHP = maxHealth;
        
        return;
     }

       currentHP+=RestoreHP;

     if (currentHP > maxHealth)
        currentHP = maxHealth;

     slider.value = currentHP;
    }
  
public void Died()
   {
     
       Death?.Invoke();
       Destroy(gameObject);
   }
   
}
