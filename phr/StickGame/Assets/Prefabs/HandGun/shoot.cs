using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent!=null&&Input.GetMouseButtonDown(0)){
            Shot();
        }
    }
    void Shot(){
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.GetChild(0).position, transform.TransformDirection(Vector2.right)*100, 100f);
        if(hit.collider != null){
            Debug.DrawRay(transform.GetChild(0).position, transform.TransformDirection(Vector2.right)*100, Color.green, 10f);
            Debug.Log(hit.collider.name);
        }
    }
}
