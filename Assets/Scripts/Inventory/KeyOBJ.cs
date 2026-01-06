using System;
using Unity.VisualScripting;
using UnityEngine;

public class KeyOBJ : MonoBehaviour
{
    [Header("Values")]
   public Transform raycastTranform;
   //anahtar objesi
   public Item item;
   RaycastHit hit;
   public Inventory ınv;
   public event Action keyInfo;
    
    void Update()
    {
        
        Intract();
    }
    public void Intract()
    {
        Ray ray=new Ray(raycastTranform.position,raycastTranform.forward);

        if(Physics.Raycast(ray,out hit, 3f))
        {
            if (hit.collider.CompareTag("Door"))
            {
                PlayerInventory playerInventory=GetComponent<PlayerInventory>();

                if(playerInventory!=null)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (ınv.items.Contains(item))
                        {
                          Destroy(hit.collider.gameObject);
                        }
                        else
                        {
                            Debug.Log("anahtar yok");
                        }
                    }
                }
            }

        }
    }
}
