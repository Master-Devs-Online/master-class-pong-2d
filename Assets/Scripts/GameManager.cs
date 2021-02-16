using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] byte[] _scoreBoard = new byte[2];
    public byte [] ScoreBoard
    {
        get => _scoreBoard;
        set
        {
            _scoreBoard = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _scoreBoard[0] = 0;
        _scoreBoard[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
