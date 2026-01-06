using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
   public Queue<GameObject> bulletpoll=new Queue<GameObject>();
   int poolSize=5;

    void Start()
    {
        for(int i = 0; i < poolSize; ++i)
        {
           GameObject bullet= Instantiate(prefab,Vector3.zero,Quaternion.identity);
           bullet.SetActive(false);
                      //ekliyor
           bulletpoll.Enqueue(bullet);
        }
    }
    private void HandleBullet()
    {
        
    }
    private GameObject GetBullet()
    {
        if (bulletpoll.Count > 0)
        {
                                        //çıkarıyor
             GameObject bullet=bulletpoll.Dequeue();
            bullet.SetActive(true);

             return bullet;
        }
        return null;
    }
    private void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletpoll.Enqueue(bullet);
    }
    private IEnumerator DisableBullet(GameObject bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnBullet(bullet);
    }
    
}
