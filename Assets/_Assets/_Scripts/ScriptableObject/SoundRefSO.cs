using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SoundRefSO : ScriptableObject
{
    [Header("Player")]
    public AudioClip[] moving;
    public AudioClip[] attack;
    public AudioClip[] hit;
    public AudioClip[] jump;
    public AudioClip[] airAttack;
    public AudioClip[] fall;
    public AudioClip[] getHit;
    public AudioClip[] usePotion;
    public AudioClip[] dead;
    public AudioClip[] interact;
    public AudioClip[] pickUp;
    [Header("Boss")]
    public AudioClip[] boss_attack;
    public AudioClip[] boss_spell;
    public AudioClip[] boss_dead;

    [Header("Mob")]
    public AudioClip[] Ranged_Globin_Shoot;
    public AudioClip[] Scout_Globin_Stab;
    public AudioClip[] Globin_chase;
    public AudioClip[] Toad_Swing;
    public AudioClip[] Pumkin_Attack;
    public AudioClip[] Spider_Attack;
    [Header("Ability")]
    public AudioClip[]Explosion;
    
}
