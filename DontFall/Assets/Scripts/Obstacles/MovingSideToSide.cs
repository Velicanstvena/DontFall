using UnityEngine;

public class MovingSideToSide : MonoBehaviour
{
    [SerializeField] Vector3 leftPosition;
    [SerializeField] Vector3 rightPosition;
    [SerializeField] float step = 1f;
    [SerializeField] float speed = 15f;
    [SerializeField] private bool onTheLeftSide = false;
    [SerializeField] private bool onTheRightSide = true;

    private void Start()
    {
        float difficultyLevel = PlayerPrefsController.GetDifficulty();

        speed *= difficultyLevel + 0.5f;
    }

    void Update()
    {
        if (transform.position.x > leftPosition.x && onTheRightSide)
        {
            MoveLeft();

            if (transform.position.x < leftPosition.x)
            {
                onTheRightSide = false;
                onTheLeftSide = true;
            }
        }
       
        if (transform.position.x < rightPosition.x && onTheLeftSide)
        {
            MoveRight();

            if (transform.position.x > rightPosition.x)
            {
                onTheRightSide = true;
                onTheLeftSide = false;
            }
        }
    }

    private void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - step * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + step * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
