using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject cube;
    private Vector3 initialPosition = new Vector3(7.21f, 4.9f, -18.86f);
    public GameObject ball;
    private Vector3 initialPositionBall = new Vector3(8.02f, 4.9f, -18.86f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void restart_game(GameObject cube)
    {
        //reset the cube position
        cube.transform.position = initialPosition;

    }

    public void restart_ball(GameObject ball)
    {
        //reset the cube position
        ball.transform.position = initialPositionBall;

    }
}