using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public TextMeshProUGUI lifeobj;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public GameObject ltext;
    private float movementX;
    private float movementY;
	private Rigidbody rb;
	private int count;
	private int life;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		life=3;
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
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("obj"))
		{
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
		{
			speed=0;
			ltext.SetActive(true);
			gameObject.SetActive(false);
		}

		else
		{
			if (count >= 3) 
				{
                    winTextObject.SetActive(true);
					speed=0;
					gameObject.SetActive(false);
				}
		}
	}
}

