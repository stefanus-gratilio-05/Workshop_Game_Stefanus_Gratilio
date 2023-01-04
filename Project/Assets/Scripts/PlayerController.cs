using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    private float horizontal;
    private float vertical;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    private Camera cam;
    private bool OldKeyPicked = false;
    private bool ModernKeyPicked = false;
    public GameStatus gs;
 
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }
 
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        vertical = Input.GetAxis("Vertical") * MovementSpeed;

        if (transform.position.z >= 61)
        {
            gs.PassedDoor = true;
        }

        if (gs.isGameOver == true)
        {
            horizontal = 0;
            vertical = 0;
        }

        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);
 
        if(characterController.isGrounded)
        {
            velocity = 0;
        } else {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }

        if ((11 <= transform.position.x && transform.position.x <= 13) && (-12 <= transform.position.z && transform.position.z <=-10))
        {
            GameObject Oldkey = GameObject.Find ("old-key");
            if (Oldkey)
            {
                Destroy(Oldkey.gameObject);
                OldKeyPicked = true;
            }
        }

        if ((-70 <= transform.position.x && transform.position.x <= -68) && (-35 <= transform.position.z && transform.position.z <=-33))
        {
            GameObject Modernkey = GameObject.Find ("modern-key");
            if (Modernkey)
            {
                Destroy(Modernkey.gameObject);
                ModernKeyPicked = true;
            }
        }

        if ((-1 <= transform.position.x && transform.position.x <= 1) && (49 <= transform.position.z && transform.position.z <=51) && (OldKeyPicked == true))
        {
            GameObject OldDoor = GameObject.Find ("old-door");
            if (OldDoor)
            {
                Destroy(OldDoor.gameObject);
            }
        }

        if ((-1 <= transform.position.x && transform.position.x <= 1) && (59 <= transform.position.z && transform.position.z <=61) && (ModernKeyPicked == true))
        {
            GameObject ModernDoor = GameObject.Find ("modern-door");
            if (ModernDoor)
            {
                Destroy(ModernDoor.gameObject);
            }
        }
    }
}