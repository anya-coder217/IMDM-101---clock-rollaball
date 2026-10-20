using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    //rigidbody of the player
    private Rigidbody rb;

    //movement along x and y axis
    private float movementX;
    private float movementY;
    
    //speed of the player
    public float speed = 0;

    //UI text component to display count of PickUp objects collected
    public TextMeshProUGUI countText;

    //variable to keep track of picked up objects
    private int count;

    //UI text component to display win message
    public GameObject winTextObject;
    
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get and store the rigidbody component of the player
        rb=GetComponent<Rigidbody>();
        //initialize count to 0
        count = 0;
        //update the count display
        SetCountText();
        //make the win text to be inactive at first
        winTextObject.SetActive(false);
    }

    //called when a move input is detected
    void OnMove(InputValue movementValue)
    {
        //convert the input value into a vector2 movement
        Vector2 movementVector = movementValue.Get<Vector2>();
        //store x and y components of the movement
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        //update count text with current count
        countText.text = "Count: " + count.ToString();
    }
    
    //called once per fixed frame-rate frame
    void FixedUpdate()
    {
        //create a 3D movement vector using x and y inputs
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //apply force to rigidbody to move player
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //check if player object collided with has the "PickUp" tag
        if (other.gameObject.CompareTag("PickUp"))
        {
            //make collided object disappear (deactivate it)
            other.gameObject.SetActive(false);
            //increment the count of picked up objects
            count = count + 1;
            //update count display
            SetCountText();
        }

        //check if count has reached or exceeded the win condition
        if(count >= 12)
        {
            //display win text
            winTextObject.SetActive(true);
        }
    }
}
