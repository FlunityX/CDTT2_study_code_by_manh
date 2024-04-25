using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour,IHasHpBar,IDealDamage,IReceiveDamage, IDataPersistence
{
    public static Player Instance {  get; private set; }
    public PlayerMovement _playerMovement;
    [SerializeField]public PlayerVisual _playerVisual;
    [SerializeField] public PlayerAttack _playerAttack;
    [SerializeField] public PlayerCollider _playerCollider;
    [SerializeField] public AbilityHolder _abilityHolder;
    [SerializeField] public PlayerStat _playerStat;
    [SerializeField] public CapsuleCollider2D Collider;
    [SerializeField] public CapsuleCollider2D SlideCollider;
    [SerializeField] private StatusEffectSO _status;
    public Transform _dropItemPoint;
    public bool isGetHit;
    public bool canUsePotion;
    public GameObject hitVFX;
    public bool isUsePotion = false;
    public float coin;
    Vector2 checkpointPos;
    AudioManager audioManager;
    
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;
    //event
    public event EventHandler OnPlayerAttack;
    public event EventHandler OnPlayerAttackHit;
    public event EventHandler OnPlayerHeal;
    public event EventHandler OnPlayerGetHit;
    public event EventHandler OnPlayerInteract;
    public event EventHandler OnPlayerSlide;
    public event EventHandler OnPlayerJump;

    
    private void Awake()
    {
        Instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        checkpointPos = transform.position;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerVisual = GetComponentInChildren<PlayerVisual>();
        _playerAttack = GetComponentInChildren<PlayerAttack>();
        GameInput.Instance.OnInteract += GameInput_OnInteract;
        hitVFX = GameManager.Instance.resourceManager.PlayerHitVFX;
    }
    private void Update()
    {
        Die();
       
    }

    public StatusEffectSO GetEffect()
    {
        return _status;
    }
    public void SetStatusEffect()
    {
        
        _status = PlayerInventory.Instance.GetStatusEffect();
    }
    public void RemoveEffect()
    {
        _status = null;
    }
    private void GameInput_OnInteract(object sender, EventArgs e)
    {
        _playerCollider.InteractableCollider();
    }

    //deal dmg and receive dmg
    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _playerStat.currentHp -= dmg * 1 - (_playerStat.Defense/100);// imcome dmg reduce base on percentage of defense
        GetHit();
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {
            HpNormalized = _playerStat.currentHp / _playerStat.Hp
        }); ;
        
        
    }

    public void Die()
    {
        if (_playerStat.currentHp <= 0)
        {
            //audioManager.PlaySFX(audioManager.die);
 
            transform.position = checkpointPos;
            _playerStat.currentHp = 0;
            HealHp(_playerStat.Hp);
        }
        
    }

    public void HealHp(float Hp)
    {
        _playerStat.currentHp += Hp;
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {   
            HpNormalized = _playerStat.currentHp / _playerStat.Hp
        }); ;
    }
    
    //return value
    public float GetDirX()
    {
        return _playerMovement.dirX;
    }
    public Rigidbody2D GetRigidbody()
    {
        return _playerMovement._rigidbody;
    }

    private void GetHit()
    {
        isGetHit = true;
    }

    public void InstantiateHitEffect(Transform enemy)
    {
        Instantiate(hitVFX, enemy.position, enemy.rotation,enemy);
    }
    //invoke event
    public void PlayerAttackInvoke()
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerAttackHitInvoke()
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerHealInvoke()
    {
        OnPlayerHeal?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerGetHitInvoke()
    {
        OnPlayerGetHit?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerInteractInvoke()
    {
        OnPlayerInteract?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerSlideInvoke()
    {
        OnPlayerSlide?.Invoke(this, EventArgs.Empty);
    }
    public void PlayerJumpInvoke()
    {
        OnPlayerJump?.Invoke(this, EventArgs.Empty);
    }
    //end invoke event

    public void ImmuteAttack()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
    public void UnimmuteAttack()
    {
        gameObject.layer = LayerMask.NameToLayer(GameConstant.PLAYER_TAG);

    }
    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.lastCheckpoint;
    }


    public void SaveData(ref GameData data)
    {
        data.lastCheckpoint = this.checkpointPos;
    }

}
