using Unity.VisualScripting;
using UnityEngine;

public class EqiuptmentSystem : MonoBehaviour
{
    public GameObject weapon;
     public GameObject weaponHolder;
     public GameObject SheatHolder;
   

     GameObject Currentweapon;
      GameObject CurrentSheatweapon;
      BoxCollider weaponCollider;

   
    void Start()
    {
        CurrentSheatweapon=Instantiate(weapon,SheatHolder.transform);
        Currentweapon=Instantiate(weapon,weaponHolder.transform);
        
        
        CurrentSheatweapon.SetActive(true);
        Currentweapon.SetActive(false);

        weaponCollider=Currentweapon.AddComponent<BoxCollider>();
        weaponCollider.isTrigger=true;
        weaponCollider.enabled=false;
    }
    public void Draw()
    {
        CurrentSheatweapon.SetActive(false);
        Currentweapon.SetActive(true);
        
    }
    public void Sheat()
    {
        CurrentSheatweapon.SetActive(true);
        Currentweapon.SetActive(false);

    }
    public void EnableCollider()
    {
        weaponCollider.enabled=true;
    }
    public void DisableCollider()
    {
        weaponCollider.enabled=false;
    }
   
   
}
