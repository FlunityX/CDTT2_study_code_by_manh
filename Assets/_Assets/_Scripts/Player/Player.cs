using System;

using UnityEngine;


public class Player : MonoBehaviour,IHasHpBar,IDealDamage,IReceiveDamage
{
    public static Player Instance {  get; private set; }
    public PlayerMovement _playerMovement;
    public PlayerVisual _playerVisual;
     public PlayerAttack _playerAttack;
     public PlayerCollider _playerCollider;
     public AbilityHolder _abilityHolder;
     public StatusEffectHolder _statusHolder;
     public PlayerStat _playerStat;
     public CapsuleCollider2D Collider;
    
    public TrailRenderer trailRenderer;
    public Transform _dropItemPoint;
    public GameObject hitVFX;
    public bool isGetHit;
    public bool canUsePotion;
    public bool isUsePotion = false;
    public float coin;
    public Vector2 checkpointPos;
    
    
    //event
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;
    public event EventHandler OnPlayerAttack;
    public event EventHandler OnPlayerAttackHit;
    public event EventHandler OnPlayerHeal;
    public event EventHandler OnPlayerGetHit;
    public event EventHandler OnPlayerInteract;
    public event EventHandler OnPlayerSlide;
    public event EventHandler OnPlayerJump;
    public event EventHandler OnPlayerSave;
    
    private void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

       




    }
    private void Start()
    {
        
        GameInput.Instance.OnInteract += GameInput_OnInteract;
        hitVFX = GameManager.Instance.resourceManager.PlayerHitVFX;
        trailRenderer.enabled = false;

    }
    private void Update()
    {
        Die();
       
    }

  
  
    public void RemoveAbility()
    {
        _abilityHolder._abilitySO = null;
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

            SaveSystem.LoadCurrentScene();
  
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
    
    public void SaveData()
    {
        SaveSystem.SavePlayer();
        OnPlayerSave?.Invoke(this, EventArgs.Empty);
    }
  
   
  
    public void LastCheckPoint()
    {
       checkpointPos = transform.position;
    }
     public void SpawnOnLastCheckPoint(Vector2 pos)
    {
        transform.position = pos;
    }
   
   
}
