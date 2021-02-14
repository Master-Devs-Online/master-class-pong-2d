using UnityEngine;

public class AddPoints : MonoBehaviour
{
    [SerializeField] GameObject _pointGameObject;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 25; i++)
        {
            GameObject pointGameObject = Instantiate(_pointGameObject,
                new Vector2(0, 36f - 3 * i), Quaternion.identity);
            pointGameObject.transform.parent =
                GameObject.Find("CenterPoints").transform;
        }
    }
}
