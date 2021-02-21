using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _centerPoints;
    [SerializeField] GameObject[] racketsObjects = new GameObject[2];
    [SerializeField] Ball _ballObject;
    [SerializeField] Text _scoreBoardText;
    [SerializeField] byte[] _scoreBoard = new byte[2];
    public byte [] ScoreBoard
    {
        get => _scoreBoard;
        set
        {
            _scoreBoard = value;
            if (_scoreBoard[0] == ScoreObjective ||
                _scoreBoard[1] == ScoreObjective)
            {
                string winnerText = (ScoreBoard[0] > ScoreBoard[1]) ?
                    "JUGADOR 1" : "JUGADOR 2";
                string finishMessage = $"{ScoreBoard[0]} - {ScoreBoard[1]}\n" +
                    $"GANADOR: {winnerText}";
                SetInitialValues();
                SetScoreBoardText(finishMessage);
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
        _centerPoints.SetActive(false);
        SetScoreBoardText("Para comenzar Pulsad ESCAPE");
    }

    public void SetInitialValues()
    {
        _centerPoints.SetActive(false);
        StartGamePlay = false;
        BallOnPlay = false;
        FinishMatch = true;
        ScoreBoard[0] = 0;
        ScoreBoard[1] = 0;
        SetRacketInitialPosition();
    }

    private void SetRacketInitialPosition()
    {
        racketsObjects[0].transform.position = new Vector2(-64, 0);
        racketsObjects[1].transform.position = new Vector2(64, 0);
    }

    public void ChangeScoreBoard()
    {
        SetScoreBoardText($"{_scoreBoard[0]}           {_scoreBoard[1]}");
        BallOnPlay = false;
    }

    public void SetScoreBoardText(string text)
    {
        _scoreBoardText.text = text;
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
        _centerPoints.SetActive(true);
    }
}
