using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    int Coin;
    public int TotalCoin;
    public TextMeshProUGUI coinInfo;
   
    [Header("References")]
    MySoundFX mySoundFX;
   
    void Awake()
    {
        mySoundFX=GetComponent<MySoundFX>();
      
    }
    void Start()
    {
        TotalCoin = 0;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            coinInfo.text = $"coin: {TotalCoin.ToString()}";
           
        }
        else
        {
             coinInfo.text = " ";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Coin"))
        {
            Coin++;
            TotalCoin = Coin;
            mySoundFX.CoinFX();
            Destroy(other.gameObject);
           
        }
    }
    

}
