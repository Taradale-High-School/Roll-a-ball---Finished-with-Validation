using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for physics of player
    public float speed;
    private Rigidbody rb;

    // Reference variables
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get a reference to the players rigidbody
        // Get a reference to the Game Manager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (gameManager.isGameActive == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);
        } else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gameManager.increaseCount();
        }
        else if (other.gameObject.CompareTag("Drop Down"))
        {
            other.gameObject.SetActive(false);
            gameManager.decreaseCount();
        }
    }
}
