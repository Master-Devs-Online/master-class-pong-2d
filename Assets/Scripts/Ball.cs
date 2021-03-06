﻿using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _startSpeed = 30f;
    [SerializeField] float _currentSpeed;
    [SerializeField] float _maxSpeed = 80f;
    private TrailRenderer _trailRenderer;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private sbyte _nextDirection;
    // Start is called before the first frame update
    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Launch()
    {
        // Habilitar rastro de la pelota
        _trailRenderer.emitting = true;
        _trailRenderer.time = 0.2f;

        // Asignamos la velocidad de la pelota para lanzar nueva jugada
        _currentSpeed = _startSpeed;

        if (!_gameManager.StartGamePlay)
        {
            Debug.Log("EMPEZANDO LA PARTIDA POR PRIMERA VEZ");
            _gameManager.StartGamePlay = true;
            _gameManager.FinishMatch = false;
            _gameManager.ChangeScoreBoard();

            // Determinar dirección inicial de manera aleatoria
            float randomValue = Random.Range(0f, 1f);

            // Especificando la dirección
            _nextDirection = (sbyte)((randomValue <= 0.5f) ? 1 : -1);

            Debug.Log(randomValue);
            Debug.Log(_nextDirection);

        }
        _rigidbody2D.velocity =
            new Vector2(_nextDirection, 0) * _currentSpeed;
    }

    public void Reset(sbyte nextDirection)
    {
        // Paramos la pelota completamente (no se mueve)
        _rigidbody2D.velocity = Vector2.zero;

        // Deshabilitar rastro de la pelota
        _trailRenderer.emitting = false;
        _trailRenderer.time = 0f;

        // Mover la pelota al punto central
        _rigidbody2D.transform.position = new Vector2(0, 0);
        // Añadir dirección en la que irá después de un gol
        _nextDirection = nextDirection;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
            collision: Información del elemento con el que colisiona.
            Por ejemplo la raqueta, pared,...
            collision.gameObject = Elemento con el que chocamos
            collision.gameObject.tag = Tag del elemento con el que chocamos
            collision.gameObject.name = Nombre del elemento con el que chocamos
            Para la pelota hacemos uso del gameObject
         */
        if (collision.gameObject.tag == "Racket")
        {
            _audioManager.Play(Sounds.RACKET);
            // Obtenemos el valor del factor de impacto vertical
            float y = HitVerticalFactor(gameObject.transform.position.y,
            collision.gameObject.transform.position.y,
            collision.collider.bounds.size.y);

            // Obtener la dirección horizontal dependiendo en que raqueta impacta
            float x = (collision.gameObject.name == "Left") ? 1 : -1;

            Vector2 direction = new Vector2(x, y).normalized;

            if (_currentSpeed < _maxSpeed)
            {
                _currentSpeed += 2f;
            }

            _rigidbody2D.velocity = direction * _currentSpeed;
        } 

        if (collision.gameObject.tag == "Wall")
        {
            _audioManager.Play(Sounds.WALL);
        }



    }

    float HitVerticalFactor(
        float ballPosition,
        float racketPosition,
        float racketHeight)
    {
        return (ballPosition - racketPosition) / racketHeight;
    }
}
