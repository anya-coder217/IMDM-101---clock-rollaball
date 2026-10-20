using UnityEngine;

public class CameraController : MonoBehaviour
{

//referenc the player (sphere) GameObject
public GameObject player;

//the distance between the camera and the player
private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //calculate initial offset between camer and player position
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //maintain previously established offset between cam and player throughout the game
        transform.position = player.transform.position + offset;
    }
}
