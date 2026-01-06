using UnityEngine;
[CreateAssetMenu(fileName = "spells", menuName = "SpellMenu")]
public class SpellMenu : ScriptableObject
{
    public float speed;
    public float damage;
    public float Duration;
    public GameObject spellPrefab;
}
