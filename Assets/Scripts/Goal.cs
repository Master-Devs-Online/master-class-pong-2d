using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Left")
        {
            Debug.Log("Izquierda recibe gol. Derecha marca gol");
            _gameManager.ScoreBoard[1] += 1;
        } else if (gameObject.name == "Right")
        {
            Debug.Log("Derecha recibe gol. Izquierda marca gol");
            _gameManager.ScoreBoard[0] += 1;
        }
        _gameManager.ChangeScoreBoard();
        _gameManager.ResetBallPosition();
    }
}
