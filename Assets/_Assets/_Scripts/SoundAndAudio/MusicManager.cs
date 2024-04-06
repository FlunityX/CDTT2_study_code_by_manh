using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private string PLAYER_PREF_MUSIC_VOLLUME = "MusicVollume";
    private float vollume = 1;
    [SerializeField] private MusicRefSO musicRefSO;
    [SerializeField]private AudioSource audioSource;

    private void Awake()
    {
        vollume = PlayerPrefs.GetFloat(PLAYER_PREF_MUSIC_VOLLUME,1f);
        audioSource = GetComponent<AudioSource>();    
        audioSource.volume = vollume;
    }
    private void Start()
    {
        audioSource.clip = musicRefSO.backGroundMusic1;
        audioSource.Play();
    }

    public void ChangeVollume()
    {
        vollume += .1f;
        if(vollume >1f) vollume = 0;
        audioSource.volume = vollume;   
        PlayerPrefs.SetFloat(PLAYER_PREF_MUSIC_VOLLUME,vollume);
        PlayerPrefs.Save();

    }

    public float GetVollume() {  return vollume; }
}
