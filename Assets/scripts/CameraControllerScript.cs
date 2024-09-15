using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour 
{
	public float panSpeed = 30f;
	public float panBoardThickness = 10f;
	public float scrollSpeed = 5f;
	public float scrollMaxSensibility = 1f;
	public float moduleDimension;
	public float minY = 10f;
	public float maxY = 80f;

    private float frontRation;
    private float backRation;
    private float rightRation;
    private float leftRation;
	private float minXInMaxY = 10f;
	private float maxXInMaxY = 80f;
	private float minZInMaxY = 10f;
	private float maxZInMaxY = 80f;
    private float minX = 10f;
    private float maxX = 80f;
    private float minZ = 10f;
    private float maxZ = 80f;
    private float epsilon = 0.0001f;
    float posX;
    float posY;
    float posZ;

	private Animator anim;
    private ParticleSystem rain;

	private void Update ()
    {
		MoveScreen ();
		LimitPosition ();
	}

	private void Start()
    {
        minXInMaxY = (-1f) * moduleDimension - 8.5f;
        maxXInMaxY = moduleDimension - 23f;
		minZInMaxY = (-1f)*moduleDimension - 16.5f;
        maxZInMaxY = moduleDimension - 33f;

        frontRation = (maxZInMaxY - moduleDimension) / maxY;
        backRation = ( minZInMaxY + moduleDimension ) / maxY;
        leftRation = ( minXInMaxY + moduleDimension ) / maxY;
        rightRation = (maxXInMaxY - moduleDimension) / maxY;

		anim = GetComponentInChildren<Animator>();
        rain = gameObject.GetComponentInChildren<ParticleSystem>();
	}

    private void DisableRainCollision()
    {
        ParticleSystem.CollisionModule collision = rain.collision;
        collision.enabled = false;
    }

    private void EnableRainCollision()
    {
        ParticleSystem.CollisionModule collision = rain.collision;
        collision.enabled = true;
    }

	//move the camera white awsd or with mouse in the border
	private void MoveScreen()
    {
        bool movement = false;
		if ( 
            Input.GetKey(KeyCode.W) || 
			( Input.mousePosition.y >= (Screen.height - panBoardThickness) && 
             Input.mousePosition.y <= Screen.height)
			|| Input.GetKey(KeyCode.UpArrow)
           ) 
        {
            DisableRainCollision();
			GoForward ();
            movement = true;
		}
		if ( Input.GetKey (KeyCode.S) || 
			( Input.mousePosition.y <= panBoardThickness && 
             Input.mousePosition.y >= 0f ) ||
			Input.GetKey(KeyCode.DownArrow)
           ) 
        {
            DisableRainCollision();
			GoBack ();
            movement = true;
		}
		if ( 
            Input.GetKey (KeyCode.D) || 
			( Input.mousePosition.x >= Screen.width - panBoardThickness && Input.mousePosition.x <= Screen.width) ||
			Input.GetKey(KeyCode.RightArrow)
           ) 
        {
            DisableRainCollision();
			GoRight ();
            movement = true;
		}
		if (
            Input.GetKey (KeyCode.A) || 
			(Input.mousePosition.x <= panBoardThickness && Input.mousePosition.x >= 0f) ||
			Input.GetKey(KeyCode.LeftArrow)
        ) 
        {
            DisableRainCollision();
			GoLeft ();
            movement = true;
		}
        if (movement == false)
        {
            EnableRainCollision();
        }
	}
    
	private void LimitPosition()
    {
        SetPos();
        SetCameraEdgesForTheHeigh();
        ClampCameraPosition();
		transform.position = new Vector3 (posX, posY, posZ);
	}

    private void SetPos()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    private void SetCameraEdgesForTheHeigh()
    {
        minX = leftRation * posY - moduleDimension;
        minZ = backRation * posY - moduleDimension;
        maxX = rightRation * posY + moduleDimension;
        maxZ = frontRation * posY + moduleDimension;
    }

    private void ClampCameraPosition()
    {
        posX = Mathf.Clamp(posX, minX, maxX);
        posY = Mathf.Clamp(posY, minY, maxY);
        posZ = Mathf.Clamp(posZ, minZ, maxZ);
    }

	private void GoForward () 
    {
		transform.Translate ( panSpeed * Time.unscaledDeltaTime * Vector3.forward, Space.Self );
    }

	private void GoBack () 
    {
		transform.Translate ( panSpeed * Time.unscaledDeltaTime * Vector3.back, Space.Self );
    }

	private void GoLeft () 
    {
		transform.Translate ( panSpeed * Time.unscaledDeltaTime * Vector3.left, Space.Self );
    }

	private void GoRight () 
    {
		transform.Translate ( panSpeed * Time.unscaledDeltaTime * Vector3.right, Space.Self );
    }
}
