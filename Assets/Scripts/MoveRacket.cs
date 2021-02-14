using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    private float _verticalMovement;
    [SerializeField] float _speedMovement = 30f;
    [SerializeField] string _axisName = "VerticalLeft";
    // Update is called once per frame
    void FixedUpdate()
    {
        _verticalMovement = Input.GetAxisRaw(_axisName);

        GetComponent<Rigidbody2D>().velocity =
            new Vector2(0, _verticalMovement * _speedMovement);
    }
}
