using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;
    private float difficulty;

    [SerializeField] private float creditEarned;
    [SerializeField] private float numberOfCrowns;

    public float CreditEarned
    {
        get
        {
            return creditEarned;
        }
        set
        {
            creditEarned = value;
        }
    }

    public float NumberOfCrowns
    {
        get
        {
            return numberOfCrowns;
        }
        set
        {
            numberOfCrowns = value;
        }
    }

    // Change obstacles by difficulty level
    void Start()
    {
        DontDestroyOnLoad(this);

        difficulty = PlayerPrefsController.GetDifficulty();

        switch (difficulty)
        {
            case 0:
                foreach(GameObject obstacle in obstacles)
                {
                    obstacle.gameObject.SetActive(false);
                }
                break;
            case 1:
                obstacles[1].gameObject.SetActive(false);
                obstacles[2].gameObject.SetActive(false);
                obstacles[4].gameObject.SetActive(false);
                break;
        }
    }
}
