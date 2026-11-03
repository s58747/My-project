using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveForthAndBack : MonoBehaviour
{

    // Speed variable. Can be accessed through Inspector
    public float speed = 5f;

    // Just to fulfill the requirement: use void Start
    // "Yeet" will be seen in console
    void Start() {
        Debug.Log("Yeet");
    }

    // Move the object using the direction parameter
    void Move(float direction) {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
    }

    // When pressing the specified key, Move will be called and operated
    // Forward direction = 1, backward direction = -1
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            Move(1f);
        } else if (Input.GetKey(KeyCode.S)) {
            Move(-1f);
        }
        
    }
}
