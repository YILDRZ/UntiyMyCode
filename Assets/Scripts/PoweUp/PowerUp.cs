using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [Header("Ref")]
    public SpellMenu spellMenu;
    float startingDamage=10f;
    Player player;
    public Slider powerInfo;
     public Image fillImage;
     public TextMeshProUGUI TimerInfo;
     AnimManager animManager;

    [Header("PowerBoostTimer")]
    public float PowerBoostTimer=0;
    public float maxTimer=20f;

    [Header("PowerTimer")]
    public float powerTimer=2f;
    public float superSayinTimer=5f;
    public float superSayin2_Timer=9f;

    [Header("Power")]
    public float powerBoost=10;
    public float superSayinPower=20f;
    public float superSayin2_Power=40f;
    [Header("Boolen")]
     bool ispowerd;
     bool supersayin;
    bool supersayin2;
    void Awake()
    {
        player=GetComponent<Player>();
        animManager=GetComponent<AnimManager>();
    }
    void Start()
    {
        StartSlider();
    }
    void Update()
    {
        TimerInfo.text=PowerBoostTimer.ToString();
        PowerDecline();
        TimerCheck();
       PowerCheck();
       
    }
    private void StartSlider()
  {
     powerInfo.minValue = 0;
        powerInfo.maxValue = powerTimer;
        powerInfo.value = 0;

        spellMenu.damage = startingDamage;
        fillImage.color = Color.white;
  }
    private void PowerCheck()
    {
          if(player.horizontalI==0 && player.verticalI==0)
          {
            //anim
            animManager.anim.SetBool("CanPowerUp",true);
            if (Input.GetKey(KeyCode.F))
            {
              //anim
              animManager.anim.SetTrigger("PowerUp");
            //süre
            PowerBoostTimer+=Time.deltaTime;
           //slider
            powerInfo.value=PowerBoostTimer;
            if (PowerBoostTimer >= superSayin2_Timer)
            {
                supersayin2=true;
                 
                if(supersayin2)
                {
                  spellMenu.damage+=superSayin2_Power;
                }
                

            }
           else if (PowerBoostTimer >= superSayinTimer)
            {
                supersayin=true;
                 
                if(supersayin)
                spellMenu.damage=superSayinPower;
            }


           else if (PowerBoostTimer >= powerTimer)
             {
                 ispowerd=true;
                if (ispowerd)
                     spellMenu.damage=powerBoost;   
             }
            }
            else 
              {
                //anim
                animManager.anim.SetBool("CanPowerUp",false);
                  TimerDecline();
                      
             }
        }
        else
        {
          //anim
          animManager.anim.SetBool("CanPowerUp",false);
             TimerDecline();
        }
    }
  public void PowerDecline()
    {
       
        switch (PowerBoostTimer)
        {
            case float timer when timer  <=powerTimer:
              spellMenu.damage=startingDamage;
            powerInfo.maxValue=powerTimer;
            break;

            case float timer when timer <= superSayinTimer:
            spellMenu.damage=powerBoost;
             fillImage.color=Color.white;
             break;

             case float timer when timer <= superSayin2_Timer:
              spellMenu.damage=superSayinPower;
             fillImage.color=Color.yellow;
           break;

           case float timer when timer <= maxTimer:
             powerInfo.maxValue=superSayin2_Timer-superSayinTimer;
            fillImage.color=Color.blue;
            break;


        }
    }
    public void TimerCheck()
    {
        if(powerTimer>=maxTimer)
        powerTimer=maxTimer;
    }
    private void TimerDecline()
    {
                  PowerBoostTimer-=Time.deltaTime;
                     powerInfo.value=PowerBoostTimer;
                     if (PowerBoostTimer <= 0)
                    {
                     PowerBoostTimer=0;
                     ispowerd=false;
                     supersayin=false;
                         supersayin2=false;
                     }
    }
  

}
