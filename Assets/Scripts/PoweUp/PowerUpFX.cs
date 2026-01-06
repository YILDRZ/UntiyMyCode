using UnityEngine;


public class PowerUpFX : MonoBehaviour
{
    [Header("ParticleFX")]
   public ParticleSystem powerFX;
  ParticleSystem.MainModule main;

   [Header("Ref")]
   PowerUp powerUp;
    void Awake()
    {
          powerUp=GetComponent<PowerUp>();
    }
    void Start()
    {
        main = powerFX.main;
    }
    void Update()
    {
        HandleFx();
      PowerFxDecline();
       
    }
    private void HandleFx()
    {
        

        if (powerUp.PowerBoostTimer >= powerUp.superSayin2_Timer)
        {
            main.startColor = Color.blue;
            if (!powerFX.isPlaying)
                powerFX.Play();
        }
        else if (powerUp.PowerBoostTimer >= powerUp.superSayinTimer)
        {
            main.startColor = Color.yellow;
            if (!powerFX.isPlaying)
                powerFX.Play();
        }
        else if (powerUp.PowerBoostTimer>= powerUp.powerTimer)
        {
            main.startColor = Color.white;
            if (!powerFX.isPlaying)
                powerFX.Play();
        }
        
    }
    public void PowerFxDecline()
    {
          

        if (powerUp.PowerBoostTimer < powerUp.powerTimer)
        {
            if (powerFX.isPlaying)
                powerFX.Stop();
        }
    }
  
}
