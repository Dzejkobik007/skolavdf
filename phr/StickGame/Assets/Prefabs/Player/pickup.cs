using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickup : MonoBehaviour
{
    void Start(){
        Debug.Log("test");
    }
    void OnTriggerStay2D(Collider2D col){
        if(Input.GetKeyDown(KeyCode.E)&&col.gameObject.layer == LayerMask.NameToLayer("Pickable")&&col.transform.parent==null){
            transform.parent.parent.parent.GetComponent<balance>().pickup(col.gameObject);
            transform.parent.parent.parent.GetComponent<balance>().turncollisionsoff(col.gameObject);
        }
    }
}
