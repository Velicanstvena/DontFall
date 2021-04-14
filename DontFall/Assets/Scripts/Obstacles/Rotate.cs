using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        float difficultyLevel = PlayerPrefsController.GetDifficulty();

        speed *= difficultyLevel + 0.5f;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 1f * speed * Time.deltaTime);
    }
}
