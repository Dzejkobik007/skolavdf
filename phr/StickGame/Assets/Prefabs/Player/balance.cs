using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class balance : MonoBehaviour
{
    private GameObject[] objects;
    public _Muscle[] muscles;
    public Vector2 WalkRightVector;
    public Vector2 WalkLeftVector;
    public Vector2 JumpVector;
    private bool jumpRst = true;
    private bool moveRst = true;
    public float MoveDelay;
    public Rigidbody2D rbLeft;
    public Rigidbody2D rbRight;
    public bool airWalk = false;
    public Transform holdAreaRight;
    public Transform holdAreaLeft;
    // Start is called before the first frame update
    void Start()
    {
        foreach (_Muscle muscle1 in muscles)
        {
            foreach (_Muscle muscle2 in muscles)
            {
                Physics2D.IgnoreCollision(muscle1.bone.GetComponent<Collider2D>(),muscle2.bone.GetComponent<Collider2D>());
            }
        }
        objects = GameObject.FindGameObjectsWithTag("ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Input.GetKey(KeyCode.S)){
            rbRight.gravityScale =4;
            rbLeft.gravityScale =4;
            foreach (_Muscle muscle in muscles)
            {
                muscle.ActivateMuscle();
            }
        }
        else{
            rbRight.gravityScale =10;
            rbLeft.gravityScale =10;
        }
        if(Input.GetKey(KeyCode.D)){
            foreach (_Muscle muscle in muscles)
            {
                MoveCheck(muscle);
            }
            if (moveRst == true)
            {
                Invoke("Step1Right", 0f);
                Invoke("Step2Right", 0.085f);
            }
        }
        if(Input.GetKey(KeyCode.A)){
            foreach (_Muscle muscle in muscles)
            {
                MoveCheck(muscle);
            }
            if (moveRst == true)
            {
                Invoke("Step1Left", 0f);
                Invoke("Step2Left", 0.085f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            foreach (_Muscle muscle in muscles)
            {
                JumpCheck(muscle);
            }
            if(jumpRst==true){
                Invoke("Jump", 0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.G)&&(holdAreaRight.childCount>0||holdAreaLeft.childCount>0)){
            Throw();
        }
    }

    public void Step1Right(){
        rbRight.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbLeft.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }
    public void Step2Right(){
        rbLeft.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbRight.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }
    public void Step1Left(){
        rbRight.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbLeft.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }
    public void Step2Left(){
        rbLeft.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbRight.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }
    public void Jump(){
        rbLeft.AddForce(JumpVector, ForceMode2D.Impulse);
        rbLeft.AddForce(JumpVector, ForceMode2D.Impulse);
    }
    private void JumpCheck(_Muscle muscle)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            var obj = objects[i].GetComponent<BoxCollider2D>();
            if (muscle.bone.IsTouching(obj))
            {
                jumpRst = true;
                break;
            }
            else
                jumpRst = false;
        }
    }

    private void MoveCheck(_Muscle muscle)
    {
        if (!airWalk)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                var obj = objects[i].GetComponent<BoxCollider2D>();
                if (muscle.bone.IsTouching(obj))
                {
                    moveRst = true;
                    break;
                }
                else
                    moveRst = false;
            }
        } else
        {
            moveRst = true;
        }

    }
    public void pickup(GameObject obj){
        if(holdAreaRight.transform.childCount==0){
            Destroy(obj.GetComponent<Rigidbody2D>());
            obj.transform.parent = holdAreaRight;
            obj.transform.SetPositionAndRotation(holdAreaRight.position, holdAreaRight.rotation);
            obj.GetComponent<shoot>().enabled = true;
        }
        else if (holdAreaLeft.transform.childCount == 0)
        {
            Destroy(obj.GetComponent<Rigidbody2D>());
            obj.transform.parent = holdAreaLeft;
            obj.transform.SetPositionAndRotation(holdAreaLeft.position, holdAreaLeft.rotation);
            obj.GetComponent<shoot>().enabled = true;
        }  
        
    }
    public void Throw(){
        if(holdAreaRight.transform.childCount>0){
            var item = holdAreaRight.GetChild(0).transform;
            item.AddComponent<Rigidbody2D>();
            item.GetComponent<Rigidbody2D>().AddForce(holdAreaRight.GetChild(0).transform.right*1000f);
            item.transform.parent = null;
            item = null;
        }
        if(holdAreaLeft.transform.childCount>0){
            var item = holdAreaLeft.GetChild(0).transform;
            item.AddComponent<Rigidbody2D>();
            item.GetComponent<Rigidbody2D>().AddForce(holdAreaLeft.GetChild(0).transform.right*1000f);
            item.transform.parent = null;
            item = null;
        }
    }
    public void turncollisionsoff(GameObject obj){
        foreach (_Muscle muscle in muscles)
            {
                foreach (var collider in obj.GetComponents<Collider2D>())
                {
                    Physics2D.IgnoreCollision(collider,muscle.bone.GetComponent<Collider2D>());
                }       
            }
    }
}
[System.Serializable]
public class _Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;
    public float followMouse = 0;
    public void ActivateMuscle(){
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation,restRotation+Mathf.Atan2(Input.mousePosition.y-Camera.main.WorldToScreenPoint(bone.position).y, Input.mousePosition.x-Camera.main.WorldToScreenPoint(bone.position).x) * Mathf.Rad2Deg*followMouse,force*Time.deltaTime));
    }
    public void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col);
    }
}