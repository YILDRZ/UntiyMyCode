using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public List<Item> items = new List<Item>();
  
   [Header("References")]
   public Image ınventoryUI;
   public TextMeshProUGUI ınventoryItems;
   public TextMeshProUGUI ınventoryItemsInfo;

    void Start()
    {
         ınventoryUI.gameObject.SetActive(false);
    }
    void Update()
    {
        ShowInventory();
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            
        }
    }

    public void ShowInventory()
    {
      
       if(Input.GetKeyDown(KeyCode.Tab))
       {
          ınventoryUI.gameObject.SetActive(true);

            if (items.Count <= 0)
            {
                ınventoryItemsInfo.text="ITEM YOK";
            }
            else
            {
                ınventoryItemsInfo.text="";
                 foreach (Item item in items)
                {
                    ınventoryItems.text=item.itemName;
                 
                }
                
            }
           
       }
       else if (Input.GetKeyUp(KeyCode.Tab))
        {
             ınventoryUI.gameObject.SetActive(false);
        }
       
    }
  
   
    
}
