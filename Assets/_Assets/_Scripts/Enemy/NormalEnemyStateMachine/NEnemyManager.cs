using DG.Tweening;
using UnityEngine;
using System.Security.Cryptography;

public class NEnemyManager : CharacterManager
{
  
    public NEnemyIdleState _NEnemyIdleState= new();
    public NEnemyPartrolState _NEnemyPartrolState= new();
    public NEnemyChaseState _NEnemyChaseState= new();
    public NEnemyAttackState _NEnemyAttackState= new();
    public NEnemyGetHitState _NEnemyGetHitState= new();
    public NEnemyKeepDistanceState _NEnemyKeepDistanceState= new();
    public NEnemyDeadState _NEnemyDeadState= new();
    public NormalEnemy _normalEnemy;
    public Transform[] patrolPoint;
    public Tween tween;
    private Tween moveTween;

    private float ChaseDir;
    public float getHitDuration = .2f;
    public float attackDuration = .5f;

    public float durationCounter;



    private void Start()
    {
        SetUpProperties();
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SetUpProperties()
    {
        _state = _NEnemyIdleState;
        _state.EnterState(this);
    }

    public bool CheckIfPlayerTooClose()
    {
        return Vector3.Distance(Player.Instance.transform.position, transform.position) <= 2f;
    }
    public  void ChangeDirection()
    {
        if (_normalEnemy.transform.localScale == Vector3.one)
        {
            _normalEnemy.transform.localScale = new Vector3(-1, 1, 1);
            

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 1, 1);
          

        }
    }
    public void UpdateChaseDir(Transform target)
    {
        ChaseDir = target.position.x - _normalEnemy.transform.position.x;
        if (ChaseDir > 0)
        {
            _normalEnemy.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            _normalEnemy.transform.localScale = new Vector3(1, 1, 1);

        }

    }
    public void JumpBackWard()
    {
            Vector3 endValue = new Vector3(_normalEnemy.transform.position.x + 8*_normalEnemy.transform.localScale.x, _normalEnemy.transform.position.y, _normalEnemy.transform.position.z);;
        _normalEnemy.transform.DOJump(endValue, 2f, 1, .5f);
        Debug.Log("backWard");
    }
    public void Chase()
    {
        if (ChaseDir > 0)
        {

            moveTween = transform.DOMoveX(transform.position.x + 1f, 1 / _normalEnemy.GetEnemyStat().Speed).OnUpdate(() =>
            {
                if (CheckIfPlayerTooClose())
                {
                    moveTween.Kill();
                }
            });
        }
        else
        {

            moveTween = transform.DOMoveX(transform.position.x - 1f, 1 / _normalEnemy.GetEnemyStat().Speed).OnUpdate(() =>
            {
                if (CheckIfPlayerTooClose())
                {
                    moveTween.Kill();
                }
            });

        }

    }
    public bool CheckIfGetHit()
    {
        return _normalEnemy.isGetHit;
    }
    public bool CheckIfDead()
    {
        return _normalEnemy.isDead;
    }
    public int GeneratePointIndex(int lastIndex)
    {
        int index = Random.Range(0, patrolPoint.Length);
        while(index == lastIndex)
        {
            index = Random.Range(0, patrolPoint.Length);
        }
        return index;
    }
    public void Move(int pointIndex)
    {
        tween = transform.DOMove(new Vector3(patrolPoint[0].position.x,transform.position.y,0), Vector3.Distance(_normalEnemy.transform.position, patrolPoint[pointIndex].position) / _normalEnemy.GetEnemyStat().Speed)
            .OnComplete(() => ChangeState(_NEnemyIdleState));
        UpdateChaseDir(patrolPoint[pointIndex]);

    }
    public void InteruptMove()
    {
        tween.Kill(); 
    }
    public void ResetCounter()
    {
        durationCounter = 0;
    }
}
