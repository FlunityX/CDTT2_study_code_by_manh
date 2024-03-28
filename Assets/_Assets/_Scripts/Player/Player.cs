using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IHasHpBar,IDealDamage,IReceiveDamage, IDataPersistence
{
    public static Player Instance {  get; private set; }
    public PlayerMovement _playerMovement;
    [SerializeField]public PlayerVisual _playerVisual;
    [SerializeField] public PlayerAttack _playerAttack;
    [SerializeField] public PlayerCollider _playerCollider;
    [SerializeField] public PlayerSlideCollider _playerSlideCollider;
    [SerializeField] public AbilityHolder _abilityHolder;
    [SerializeField] public CapsuleCollider2D Collider;

    public bool isGetHit=false;
    public bool canUsePotion;
    public bool isUsePotion = false;
    public float Speed=1f;
    public float Dmg=1f;
    public float HpMax = 10;
    public float currentHp = 1;
    public float coin;
    Vector2 checkpointPos;
    AudioManager audioManager;
    
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;
    //event
    public event EventHandler OnPlayerAttack;
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
    }
    private void Update()
    {
        Die();
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
        currentHp -= dmg;
        GetHit();
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {
            HpNormalized = currentHp / HpMax
        }); ;
        
        
    }

    public void Die()
    {
        if (currentHp <= 0)
        {
            audioManager.PlaySFX(audioManager.die);
 
            transform.position = checkpointPos;
            currentHp = 0;
            HealHp(HpMax);
        }
        
    }

    public void HealHp(float Hp)
    {
        currentHp += Hp;
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {   
            HpNormalized = currentHp / HpMax
        }); ;
    }
    
    //return value
    public float GetDirX()
    {
        return _playerMovement.dirX;
    }
    public Rigidbody2D GetRigidbody()
    {
        return _playerMovement._boxRigidbody;
    }

    private void GetHit()
    {
        isGetHit = true;
        //isGetHit =false;
    }

    //invoke event
    public void PlayerAttackInvoke()
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
