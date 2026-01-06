using TMPro;
using UnityEngine;

public class TradeAbleObject : MonoBehaviour,IInteractable
{
   
    public Item tradeAbleObject;
    [Header("Ref")]
    public CollectCoin coin;
    public SwordHit swordHit;
   
    //objelerin içinde IInteractable Interface varsa çalışır ve listeye ekler
    public void InteractableOBJ(PlayerInventory player)
    {
        if (coin.TotalCoin >= 5)
        {
             player.ınventory.AddItem(tradeAbleObject);
             coin.TotalCoin-=5;
             swordHit.swordDamage+=15f;
             Destroy(gameObject);
        }
       else
        {
            Debug.Log("yetersiz");
        }
    }

   
}
