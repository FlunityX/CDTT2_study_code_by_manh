using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossSpellAttack : MonoBehaviour,IRangeAttack
{
    [SerializeField] private Transform _bossSpell;
    [SerializeField] private Transform spellHeighPoint;
    private Boss _boss;
    private void Start()
    {
        _boss = GetComponentInParent<Boss>();
    }
    public void RangeAttack()
    {
        _boss.attackCount = 0;
        for (int i = 0; i <= 5; i++)
        {
            Invoke("SpawnSpell", .8f * i);
        }
    }
   private void SpawnSpell()
    {
        Transform spell = Instantiate(_bossSpell, _boss.transform);
        spell.transform.position = new Vector2(Player.Instance.transform.position.x, spellHeighPoint.position.y);
    }
   
}
