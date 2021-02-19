using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] byte[] _scoreBoard = new byte[2];
    [SerializeField] Ball _ballObject;
    [SerializeField] Text _scoreBoardText;
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
        // Vamos a iniciar el objeto de la pelota
        _ballObject = FindObjectOfType<Ball>();
        _scoreBoard[0] = 0;
        _scoreBoard[1] = 0;
        _scoreBoardText = FindObjectOfType<Text>();
        ChangeScoreBoard();
    }

    public void ChangeScoreBoard()
    {
        _scoreBoardText.text = $"{_scoreBoard[0]}           {_scoreBoard[1]}";
    }

    public void ResetBallPosition()
    {
        _ballObject.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
