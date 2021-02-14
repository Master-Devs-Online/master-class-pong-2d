using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity =
            Vector2.right * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
