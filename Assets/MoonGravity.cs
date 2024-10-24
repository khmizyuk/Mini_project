using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetMoonGravity() 
    {
        Physics.gravity = new Vector3(0, -1.62f, 0);
        Debug.Log("Функция SetMoonGravity запущена!");
    }
}
