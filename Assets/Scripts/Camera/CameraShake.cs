using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
public static CameraShake Instance{get; private set;}

    CinemachineBasicMultiChannelPerlin perlin;
    float ShakeTimer;
    float ShakeTimerTotal;
    float StartingIntensity;
    void Awake()
    {
        Instance=this;
        
        perlin=GetComponent<CinemachineBasicMultiChannelPerlin>();
    }
private IEnumerator CameraShakeCoroutine(float intensetiy,float time,float delay)
    {
        yield return new WaitForSeconds(delay);
        perlin.AmplitudeGain=intensetiy;
        ShakeTimer=time;
        ShakeTimerTotal=time;
        StartingIntensity=intensetiy;
    }
    public void ShakeCamera(float intensetiy,float time,float delay = 0)
    {
        StartCoroutine(CameraShakeCoroutine(intensetiy,time,delay));
    }
    void Update()
    {
        if (ShakeTimer > 0f)
        {
            ShakeTimer-=Time.deltaTime;
            if (ShakeTimer <= 0f)
            {
                perlin.AmplitudeGain=Mathf.Lerp(StartingIntensity,0f,1-(ShakeTimer/ShakeTimerTotal));
            }
        }
    }
}
