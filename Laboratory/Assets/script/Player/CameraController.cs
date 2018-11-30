using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    private float playerY;

    // Use this for initialization
    void Start()
    {
        this.offset = this.transform.position - this.Player.transform.position;
        this.playerY = this.Player.transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 posX = new Vector3(this.Player.transform.position.x, this.playerY, 0);
        this.transform.position = posX + this.offset;
    }
}