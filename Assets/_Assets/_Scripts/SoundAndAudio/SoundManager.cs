using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PLAYER_PREF_SOUND_EFFECT_VOLLUME = "SoundEffectVollume";
    
    [SerializeField] private SoundRefSO SoundRefSO;
    private float vollume = 1f;


    private void Awake()
    {
        
        vollume = PlayerPrefs.GetFloat(PLAYER_PREF_SOUND_EFFECT_VOLLUME, 1f);
    }
    private void Start()
    {
        if (Loader.GetCurrentScene() != Loader.Scene.MenuScene.ToString())
        {
            Player.Instance.OnPlayerAttack += Player_OnPlayerAttack;
            Player.Instance.OnPlayerAttackHit += Player_OnPlayerAttackHit;
            Player.Instance.OnPlayerGetHit += Player_OnPlayerGetHit;
            Player.Instance.OnPlayerHeal += Player_OnPlayerHeal;
            Player.Instance.OnPlayerInteract += Player_OnPlayerInteract;
            Player.Instance.OnPlayerJump += Player_OnPlayerJump;
        }
    }

    private void Player_OnPlayerAttackHit(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.hit, Player.Instance.transform.position, vollume);
    }

    private void Player_OnPlayerJump(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.jump, Player.Instance.transform.position, vollume);

    }


    //Player Play Sound
  

    private void Player_OnPlayerInteract(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.interact, Player.Instance.transform.position, vollume);

    }

    private void Player_OnPlayerHeal(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.usePotion, Player.Instance.transform.position, vollume);

    }

    private void Player_OnPlayerGetHit(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.getHit, Player.Instance.transform.position, vollume);

    }

    private void Player_OnPlayerAttack(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.attack, Player.Instance.transform.position, vollume);

    }
    public void Player_Moving(Vector2 pos)
    {
        PlaySound(SoundRefSO.moving, pos, vollume);

    }
    public void Player_Falling(Vector2 pos)
    {
        PlaySound(SoundRefSO.fall, pos, vollume);

    }


    private void PlaySound(AudioClip clip,Vector2 position, float vollume=1f)
    {
        AudioSource.PlayClipAtPoint(clip, position, vollume);
    }
    private void PlaySound(AudioClip[] clipsArrray,Vector2 position, float vollume=1f)
    {
        AudioSource.PlayClipAtPoint(clipsArrray[Random.Range(0,clipsArrray.Length)], position, vollume);
    }
    public void ChangeVollumme(float value)
    {
         vollume = value;
        PlayerPrefs.SetFloat(PLAYER_PREF_SOUND_EFFECT_VOLLUME,vollume);
        PlayerPrefs.Save();
    }
    public float GetVollume() { return vollume; }

    //boss Sound

    public  void PlayBossAttack(Vector2 pos) {
        PlaySound(SoundRefSO.boss_attack, pos, vollume);
    }
    public  void PlayBossSpell(Vector2 pos) {
        PlaySound(SoundRefSO.boss_spell, pos, vollume);
    }
    public void PlayBossDead(Vector2 pos)
    {
        PlaySound(SoundRefSO.boss_dead, pos, vollume);
    }
    //monster sound
    public void PlayRangedGlobinAttack(Vector2 pos)
    {
        PlaySound(SoundRefSO.Ranged_Globin_Shoot, pos, vollume);
    }
    public void PlayMobAttack(Vector2 pos)//use for both toad and tank globin
    {
        PlaySound(SoundRefSO.Toad_Swing, pos, vollume);
    }
    public void PlayGlobinChase(Vector2 pos)
    {
        PlaySound(SoundRefSO.Globin_chase, pos, vollume);
    }
    public void PlayScoutGlobinAttack(Vector2 pos)
    {
        PlaySound(SoundRefSO.Scout_Globin_Stab, pos, vollume);
    }
    public void PlayMob2Attack(Vector2 pos)//use for both spder and pumkin
    {
        PlaySound(SoundRefSO.Pumkin_Attack, pos, vollume);
    }

    //Ability sound
    public void PlayExplosionSound(Vector2 pos)
    {
        PlaySound(SoundRefSO.Explosion, pos, vollume);
    }
}
