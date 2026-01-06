using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Inventory ınventory;
    public Transform raycastHit;
    RaycastHit hit;
    //[Header("References")]
    //CollectCoin coin;
    //MySoundFX mySoundFX;
     //public SwordHit swordHit;
    
    

    void Awake()
    {
       // coin = GetComponent<CollectCoin>();
        //mySoundFX=GetComponent<MySoundFX>();
      
    }
    void Update()
    {
        //PickUpItem();
        //Trade();
        if(Input.GetKeyDown(KeyCode.E))
        CheckItem();
    }
    /*public void PickUpItem()
    {
        Ray ray = new Ray(raycastHit.position, raycastHit.forward);
        //raycast herhangi bir ojeye çarparsa if girer
        if (Physics.Raycast(ray, out hit, 3f))
        {
            // girdiği gibi ItemObject'ti çağırır
            ItemObject ıtemObject = hit.collider.GetComponent<ItemObject>();
            //eğer çarptığı collider da bu obje varsa if'e girer yoksa null döner
            if (ıtemObject != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ınventory.AddItem(ıtemObject.item);
                    Destroy(hit.collider.gameObject); 
                }

            }
        }
        //tarde-------------------------------------
         if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Trade"))
            {
                TradeAbleObject ıtemObject = hit.collider.GetComponent<TradeAbleObject>();

                if (ıtemObject != null)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (coin.TotalCoin >= 5)
                        {
                            ınventory.AddItem(ıtemObject.tradeAbleObject);
                            SwordDamageBoost();
                            Destroy(hit.collider.gameObject);
                            coin.TotalCoin -= 5;
                            mySoundFX.PowerBoost();
                        }
                        else
                        {
                            Debug.Log("yetersiz");
                        }

                    }
                }

            }
        }
    }
    public void Trade()
    {
        Ray ray = new Ray(raycastHit.position, raycastHit.forward);


        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Trade"))
            {
                TradeAbleObject ıtemObject = hit.collider.GetComponent<TradeAbleObject>();

                if (ıtemObject != null)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (coin.TotalCoin >= 5)
                        {
                            ınventory.AddItem(ıtemObject.tradeAbleObject);
                            SwordDamageBoost();
                            Destroy(hit.collider.gameObject);
                            coin.TotalCoin -= 5;
                            mySoundFX.PowerBoost();
                        }
                        else
                        {
                            Debug.Log("yetersiz");
                        }

                    }
                }

            }
        }
    }
     public void SwordDamageBoost()
    {
          swordHit.swordDamage+=15f; 
    }
    */
    
    public void CheckItem()
    {
        Ray ray=new Ray(raycastHit.position,raycastHit.forward);
         //raycast herhangi bir ojeye çarparsa if girer
        if(Physics.Raycast(ray,out hit, 3f))
        {
             // girdiği gibi IInteractable objeyi çağırır
            IInteractable ınteractable=hit.collider.GetComponent<IInteractable>();
             //eğer çarptığı collider da bu obje varsa if'e girer yoksa null döner
            if (ınteractable != null)
            {
                ınteractable.InteractableOBJ(this);
            }
        }
    }
}
