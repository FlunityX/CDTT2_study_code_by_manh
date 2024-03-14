
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("------- Audio Clip -------")]
    public AudioClip background;
    public AudioClip swingSword;
    public AudioClip hurtByObstacle;
    public AudioClip die;
    public AudioClip walk;
    public AudioClip hit;
    public AudioClip jump;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
