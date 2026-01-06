using UnityEngine;
using UnityEngine.Events;

public class DropItem : MonoBehaviour
{
     [Header("Values")]
    public GameObject[] OBJ;

    [Header("Ref")]
    public HealthComp healthComp;

    void OnEnable()
    {
        if (healthComp != null)
            healthComp.Death += Drop;
    }

    void OnDisable()
    {
        if (healthComp != null)
            healthComp.Death -= Drop;
    }

    public void Drop()
    {
        int rnd=Random.Range(0,3);
        Instantiate(OBJ[rnd], transform.position, Quaternion.identity);
    }
}
