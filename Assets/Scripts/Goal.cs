using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Left")
        {
            Debug.Log("Izquierda recibe gol. Derecha marca gol");
        } else if (gameObject.name == "Right")
        {
            Debug.Log("Derecha recibe gol. Izquierda marca gol");
        }
    }
}
