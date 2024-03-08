using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private BossCollider _bossCollider;
    private BossMeleeAttack _meleeAttack;
    private BossSpellAttack _spellAttack;
    private BossMovement _bossMovement;
    public BossCollider GetBossCollider() { return _bossCollider; }
    public BossMeleeAttack GetBossMeleeAttack() { return _meleeAttack; }
    public BossSpellAttack GetBossSpellAttack() { return _spellAttack; }
    public BossMovement GetBossMovement() { return _bossMovement; }

    public float attackSpeed;
    public bool _isFacingLeft;
    public bool _isFacingRight;
    public int attackCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
