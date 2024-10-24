using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEarthGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Debug.Log("Функция SetEarthGravity запущена!");
    }
}
