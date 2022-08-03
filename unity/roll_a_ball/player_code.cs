using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public AudioSource cube;
	public AudioSource start;
	public AudioSource obj;
	public AudioSource win;
	public AudioSource lost;

	
	public TextMeshProUGUI lifeobj;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public GameObject ltext;
    private float movementX;
    private float movementY;
	private Rigidbody rb;
	private int count=0;
	private int life=3;
	void Start ()
	{
		start.Play();
		rb = GetComponent<Rigidbody>();
		SetCountText ();
        winTextObject.SetActive(false);
		ltext.SetActive(false);
	}

	void FixedUpdate ()
	{
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("cube"))
		{				cube.Play();
		other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("obj"))
		{	obj.Play();
			other.gameObject.SetActive (false);
			life = life -1;
			SetCountText ();
		}
	}
  
        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();
        	movementX = v.x;
        	movementY = v.y;
        }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		lifeobj.text = "Life: " + life.ToString(); 

		if (life ==0)
		{lost.Play();
			speed=0;
			ltext.SetActive(true);
			gameObject.SetActive(false);
			
		}

		else
		{
			if (count == 7) 
				{win.Play();
                    winTextObject.SetActive(true);
					speed=0;
					gameObject.SetActive(false);
				}
		}
	}
}
