using UnityEngine;

public class MySoundFX : MonoBehaviour
{
     AudioSource audioSource;
    [Header("Sounds")]
    public AudioClip WalkssoundFx;
    public AudioClip JumpSoundFX;
    public AudioClip LandSoundFX;
    public AudioClip SpellSoundFX;
    public AudioClip HitSoundFX;
    public AudioClip CollectSoundFX;
    public AudioClip BoostCollectSoundFX;
     public AudioClip HealthSoundFX;
     public AudioClip powerBoost;
     public AudioClip drawSwordSoundFX;
     public AudioClip attackSoundFX;
     public AudioClip effortSoundFX;
     public AudioClip effortSoundFX2;
     
     
    
    [Header("References")]
    Player player;
   

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }
    public void WalkSoundEfects()
    {

        if (player.moveDir.magnitude > 0)
        {
            audioSource.PlayOneShot(WalkssoundFx);
        }
    }
    public void JumpFX()=> audioSource.PlayOneShot(JumpSoundFX);
    
    public void LandFX()=>  audioSource.PlayOneShot(LandSoundFX);
    
    public void SpellFX() => audioSource.PlayOneShot(SpellSoundFX);
    public void HitFX() => audioSource.PlayOneShot(HitSoundFX);
    public void CoinFX()=> audioSource.PlayOneShot(CollectSoundFX);
     public void BoostFX()=> audioSource.PlayOneShot(BoostCollectSoundFX);
     public void HealthFX()=> audioSource.PlayOneShot(HealthSoundFX);
     public void PowerBoost()=> audioSource.PlayOneShot(powerBoost);
     public void DrawWeaponSoundFX()=> audioSource.PlayOneShot(drawSwordSoundFX);
     public void AttackSoundFX()=> audioSource.PlayOneShot(attackSoundFX);
       public void EffortSoundFX()=> audioSource.PlayOneShot(effortSoundFX);
        public void EffortSoundFX2()=> audioSource.PlayOneShot(effortSoundFX2);
     
  
}
