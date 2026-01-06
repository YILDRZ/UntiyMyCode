using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DestructOBJ : MonoBehaviour
{
    MeshRenderer msh;
    public GameObject expFX;
    public GameObject burnFX;
    void Awake()
    {
        msh=GetComponent<MeshRenderer>();
    }
    void Start()
    {
        expFX.SetActive(false);
        burnFX.SetActive(false);
    }
    public void StartExp()
    {
        StartCoroutine(ExplosionTime());
    }
     IEnumerator ExplosionTime()
    {
        burnFX.SetActive(true);
        yield return new WaitForSeconds(1f);
        burnFX.SetActive(false);
        msh.enabled=false;
        expFX.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
