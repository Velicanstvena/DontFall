using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameController>().NumberOfCrowns += 1;
            FindObjectOfType<SceneLoader>().LoadWinScreen();
            Destroy(gameObject);
        }
    }
}
