using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {

    [Range(1,100)]
    public float moveSpeed;

    public float jumpSpeed = 5f;

    bool isMove = false;

    Rigidbody2D body;

    Animator ani;

    Vector3 dir;

	// Use this for initialization
	void Start () {
        body = transform.GetComponent<Rigidbody2D>();
        ani = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector2(-moveSpeed, body.velocity.y);
            isMove = true;
            transform.localScale = new Vector3(-5, 5, 1);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(moveSpeed, body.velocity.y);
            isMove = true;
            transform.localScale = new Vector3(5, 5, 1);
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            body.velocity = new Vector2(0, body.velocity.y);
            isMove = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            body.velocity = new Vector2(0, body.velocity.y);
            isMove = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (body.velocity.y == 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ani.Play("cat_shotstart");
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            ani.Play("cat_shotboom");
            GameObject o= Instantiate(Resources.Load("bullet")) as GameObject;
            o.transform.position = transform.Find("point").position;
            o.GetComponent<bullet>().dir = dir;
        }
        if (transform.localScale.x > 0)
        {
            dir = Vector3.right;
        }
        else
        {
            dir = Vector3.left;
        }
        ani.SetBool("IsMove", isMove);
	}
}
