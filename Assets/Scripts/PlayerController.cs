using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText, WinText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCount();
        WinText.text = " ";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube") {
            Destroy(other.gameObject);
            count++;
            SetCount();
        } }
    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 6)
            WinText.text = "You win!";
    }
}
