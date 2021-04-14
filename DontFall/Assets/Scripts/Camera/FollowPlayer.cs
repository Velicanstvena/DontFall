using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset = new Vector3(0f, 7f, -11.5f);

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
