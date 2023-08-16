
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    
    GameController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        
        controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(controller.IsGameOver()){
            return;
        }
         
        transform.position = transform.position + Vector3.left * controller.WallSpeed() * Time.deltaTime;  

    }
    
}
