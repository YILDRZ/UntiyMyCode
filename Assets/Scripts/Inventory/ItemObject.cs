using UnityEngine;

public class ItemObject : MonoBehaviour,IInteractable
{
    public Item item;
    //objelerin içinde IInteractable Interface varsa çalışır ve listeye ekler
    public void InteractableOBJ(PlayerInventory player)
    {
        player.ınventory.AddItem(item);
        Destroy(gameObject);
    }
}
