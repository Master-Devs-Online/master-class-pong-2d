using UnityEngine;

public enum Sounds
{
    WALL,
    RACKET,
    GOAL
}

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] AudioClip _audioGoal, _audioRacket, _audioRebound;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(Sounds sound)
    {
        switch(sound)
        {
            case Sounds.WALL:
                _audioSource.clip = _audioRebound;
                break;
            case Sounds.RACKET:
                _audioSource.clip = _audioRacket;
                break;
            case Sounds.GOAL:
                _audioSource.clip = _audioGoal;
                break;
        }
        _audioSource.Play();
    }
    
}
