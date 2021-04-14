using UnityEngine;

public class MovingUpAndDown : MonoBehaviour
{
    [SerializeField] Vector3 upPosition;
    [SerializeField] Vector3 downPosition;
    [SerializeField] float step = 1f;
    [SerializeField] float speed = 15f;
    [SerializeField] private bool onTheUpperSide = false;
    [SerializeField] private bool onTheDownSide = true;

    private void Start()
    {
        float difficultyLevel = PlayerPrefsController.GetDifficulty();

        if(!gameObject.CompareTag("Crown")) speed *= difficultyLevel + 0.5f;
    }

    void Update()
    {
        if (transform.position.y < upPosition.y && onTheDownSide)
        {
            MoveUp();

            if (transform.position.y > upPosition.y)
            {
                onTheDownSide = false;
                onTheUpperSide = true;
            }
        }

        if (transform.position.y > downPosition.y && onTheUpperSide)
        {
            MoveDown();

            if (transform.position.y < downPosition.y)
            {
                onTheDownSide = true;
                onTheUpperSide = false;
            }
        }
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void MoveDown()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
}
