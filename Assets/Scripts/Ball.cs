﻿using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed = 30f;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity =
            Vector2.right * _speed;
    }

    public void Reset()
    {
        // Paramos la pelota completamente (no se mueve)
        _rigidbody2D.velocity = Vector2.zero;

        // Mover la pelota al punto central
        _rigidbody2D.transform.position = new Vector2(0, 0);
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
            // Obtenemos el valor del factor de impacto vertical
            float y = HitVerticalFactor(gameObject.transform.position.y,
            collision.gameObject.transform.position.y,
            collision.collider.bounds.size.y);

            // Obtener la dirección horizontal dependiendo en que raqueta impacta
            float x = (collision.gameObject.name == "Left") ? 1 : -1;

            Vector2 direction = new Vector2(x, y).normalized;

            _rigidbody2D.velocity = direction * _speed;
        } else
        {
            Debug.Log("Colisiona con otro elemento");
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
