using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MoveForthAndBack : MonoBehaviour
{

    // Speed variable. Can be accessed through Inspector
    // (Part 2) changed public -> [SerializeField] private,
    // (Part 2) still accessible from Inspector, while remaining private
    [SerializeField] private float speed = 5f;

    // (Part 2) initiallized event
    public event Action OnMoved;

    // (Part 2) color variable to record original color of the sphere
    private Color originalColor;

    // (Part 2) number of frames Move() is called
    // (Part 2) since using static, the number will be shared between
    // (Part 2) objects using this code
    private static int moveCount = 0;

    // Just to fulfill the requirement: use void Start
    // "Yeet" will be seen in console
    void Start() {
        Debug.Log("Yeet");

        // (Part 2) recorded original color of the sphere
        originalColor = GetComponent<Renderer>().material.color;

        // (Part 2) linked event to function
        OnMoved += ChangeColor;
    }

    // Move the object using the direction parameter
    void Move(float direction) {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
        
        // (Part 2) called event
        OnMoved?.Invoke();

        // (Part 2) update moveCount
        moveCount++;

        // (Part 2) print moveCount
        Debug.Log("Moved: " + moveCount);
    }

    // (Part 2) function linked to event
    // (Part 2) changes the color of the sphere into red
    void ChangeColor() {
        Renderer objRenderer = GetComponent<Renderer>();
        objRenderer.material.color = Color.red;
    }

    // When pressing the specified key, Move will be called and operated
    // Forward direction = 1, backward direction = -1
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            Move(1f);
        } else if (Input.GetKey(KeyCode.S)) {
            Move(-1f);
        } else {
            // (Part 2) when not moving,
            // (Part 2) changes the color of the sphere back to original
            GetComponent<Renderer>().material.color = originalColor;
        }
        
    }
}
