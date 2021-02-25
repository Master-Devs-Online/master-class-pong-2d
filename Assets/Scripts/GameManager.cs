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
            if (_scoreBoard[0] == ScoreObjective ||
                _scoreBoard[1] == ScoreObjective)
            {
                FinishMatch = true;
                StartGamePlay = false;
                ScoreBoard[0] = 0;
                ScoreBoard[1] = 0;
            }
        }
    }
    [SerializeField] bool _ballOnPlay = false;
    public bool BallOnPlay
    {
        get => _ballOnPlay;
        set
        {
            _ballOnPlay = value;
            if (_ballOnPlay)
            {
                Debug.Log("Empezamos a lanzar la bola");
                _ballObject.Launch();
            }
        }
    }
    [SerializeField] bool _startGamePlay = false;
    public bool StartGamePlay
    {
        get => _startGamePlay;
        set
        {
            _startGamePlay = value; 
        }
    }
    [SerializeField] byte _scoreObjective = 10;
    public byte ScoreObjective
    {
        get => _scoreObjective;
    }
    [SerializeField] bool _finishMatch = false;
    public bool FinishMatch
    {
        get => _finishMatch;
        set
        {
            _finishMatch = value;
            if (_finishMatch)
            {
                SetScoreBoardText("FINALLLLLL");
            }
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
        SetScoreBoardText("Para comenzar Pulsad ESPACIO");
    }

    public void SetScoreBoardText(string text)
    {
        _scoreBoardText.text = text;
    }

    public void ChangeScoreBoard()
    {
        SetScoreBoardText($"{_scoreBoard[0]}           {_scoreBoard[1]}");
        BallOnPlay = false;
    }

    public void ResetBallPosition(sbyte nextDirection)
    {
        _ballObject.Reset(nextDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !BallOnPlay)
        {
            Debug.Log("Pulsamos espacio");
            StartGame();
        }
    }

    public void StartGame()
    {
        BallOnPlay = true;
    }
}
