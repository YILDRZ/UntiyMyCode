using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Ref")]
    public GameObject[] EnemyGameOBJ;
   
    public Transform Post;
    float ResetSpawnTime=60f;
  

    [Header("Value")]
    int SpawnCollDown=60;
     float timer;
     bool canspawn;
    void Start()
    {
        canspawn=true;
    }
    void Update()
    {
        timer+=Time.deltaTime;

        if (timer >= SpawnCollDown&& canspawn)
        {
            canspawn=false;
            Spawn();
            timer=0;
            Invoke(nameof(ResetSpawn),ResetSpawnTime);
        }
      
    }
    public void Spawn()
    {
        int randomIndex=Random.Range(0,EnemyGameOBJ.Length);
        Instantiate(EnemyGameOBJ[randomIndex],Post.position,Post.rotation);
    }
    private void ResetSpawn()
    {
        canspawn=true;
    }
}
