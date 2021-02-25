using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed = 300;
    [SerializeField]
    private float mouseSpeed = 3;
    private GameObject CameraRot;
    private float X;
    private float Y;
	
	//for jump action
	private Vector3 jump;
    private float jumpForce = 0.8f;
    private bool isGrounded;
	
	//maximum speed of player
	private float maxSpeed = 5;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        CameraRot = Camera.main.gameObject;
		
		//for jump action
		jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

	void OnCollisionStay()
	{
        isGrounded = true;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
		{
			isGrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
		
		//lose a life if the player falls off
		if(rb.position.y < -3f)
		{
			FindObjectOfType<GameManager>().LoseLife();
		}
		
		//restrics player movement speed
		rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		
		float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = transform.rotation * new Vector3(moveH, 0, moveV);
        rb.AddForce(movement * Time.deltaTime * speed);

        Y += Input.GetAxis("Mouse X") * mouseSpeed;
        X += Input.GetAxis("Mouse Y") * mouseSpeed;
        X = Mathf.Clamp(X, -20f, 20f);
        transform.eulerAngles = new Vector3(0, Y, 0);
        CameraRot.transform.eulerAngles = new Vector3(-X, Y, 0);
    }
}
