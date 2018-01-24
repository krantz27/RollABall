using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Text timerText;
    private float startTime;
    private bool active;
    public Text countText;
    public Text winText;
    public float speed;
    private Rigidbody rb;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetText();
        winText.text = "";
        active = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if (active == true)
        {
            float current = Time.time - startTime;

            string minutes = ((int)current / 60).ToString();
            string sec = (current % 60).ToString("f2");
            timerText.text = minutes + ":" + sec;
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetText();
        }
        if(other.gameObject.CompareTag("Special"))
        {
            other.gameObject.SetActive(false);
            count += 5;
            SetText();
        }
    }

    void SetText()
    {
        countText.text = countText.text = "Count: " + count.ToString();
        if(count>=15)
        {
            winText.text = "Level Complete!";
            active = false;
          
        }
    }
}
