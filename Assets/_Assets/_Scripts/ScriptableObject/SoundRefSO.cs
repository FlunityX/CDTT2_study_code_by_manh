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
    public AudioClip[] slide;
    public AudioClip[] interact;
    [Header("Boss")]
    public AudioClip[] boss_moving;
    public AudioClip[] boss_attack;
    public AudioClip[] boss_spell;
    public AudioClip[] boss_getHit;
    public AudioClip[] boss_dead;
}
