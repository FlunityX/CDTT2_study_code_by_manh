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
        //playerSound
        Player.Instance.OnPlayerAttack += Player_OnPlayerAttack;
        Player.Instance.OnPlayerAttackHit += Player_OnPlayerAttackHit;
        Player.Instance.OnPlayerGetHit += Player_OnPlayerGetHit;
        Player.Instance.OnPlayerHeal += Player_OnPlayerHeal;
        Player.Instance.OnPlayerInteract += Player_OnPlayerInteract;
        Player.Instance.OnPlayerSlide += Player_OnPlayerSlide;
        Player.Instance.OnPlayerJump += Player_OnPlayerJump;
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
    private void Player_OnPlayerSlide(object sender, System.EventArgs e)
    {
        PlaySound(SoundRefSO.slide, Player.Instance.transform.position, vollume);
    }

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
    public void ChangeVollumme()
    {
        vollume += .1f;
        if (vollume> 1f) vollume = 0f;
        PlayerPrefs.SetFloat(PLAYER_PREF_SOUND_EFFECT_VOLLUME,vollume);
        PlayerPrefs.Save();
    }
    public float GetVollume() { return vollume; }
}
