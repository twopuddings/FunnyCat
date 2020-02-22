using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public Vector3 dir;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.8f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += dir * Time.deltaTime * moveSpeed;
	}

    void OnColliderEnter2D(GameObject o)
    {
        Debug.Log(o.name);
    }
}
