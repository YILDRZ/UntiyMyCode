using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableOBJ : MonoBehaviour
{
   public LayerMask DestructLayer;
   float radius=5f;
   public GameObject BurnFX;
   
   public GameObject ExpFx;
    void Start()
    {
        ExpFx.SetActive(false);
        BurnFX.SetActive(false);
    }
    public void DestructActive()
    {
        StartCoroutine(DestructTime());
    }
    IEnumerator DestructTime()
    {
        BurnFX.SetActive(true);
         yield return new WaitForSeconds(1f);

        MeshRenderer mesh=GetComponent<MeshRenderer>();
        if(mesh!=null)
        mesh.enabled=false;
        ExpFx.SetActive(true);
        BurnFX.SetActive(false);
        ExpFx.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        //patlamadan etkilenen 2. obje
         Destruct();
         //kendisi
         Destroy(gameObject);
       

    }
   public void Destruct()
    {
        Collider[] hits=Physics.OverlapSphere(transform.position,radius,DestructLayer);
        foreach(var c in hits)
        {
            if (c.GetComponent<DestructOBJ>())
            {
                c.GetComponent<DestructOBJ>().StartExp();
            }

        }
    }
    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
