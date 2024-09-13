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
	}

	//move the camera white awsd or with mouse in the border
	private void MoveScreen()
    {
		if ( 
            Input.GetKey ("w") || 
			( Input.mousePosition.y >= (Screen.height - panBoardThickness) && 
             Input.mousePosition.y <= Screen.height)
			|| Input.GetKey(KeyCode.UpArrow)
           ) 
        {
			GoForward ();
		}
		if ( Input.GetKey ("s") || 
			( Input.mousePosition.y <= panBoardThickness && 
             Input.mousePosition.y >= 0f ) ||
			Input.GetKey(KeyCode.DownArrow)
           ) 
        {
			GoBack ();
		}
		if ( 
            Input.GetKey ("d") || 
			( Input.mousePosition.x >= Screen.width - panBoardThickness && Input.mousePosition.x <= Screen.width) ||
			Input.GetKey(KeyCode.RightArrow)
           ) 
        {
			GoRight ();
		}
		if (
            Input.GetKey ("a") || 
			(Input.mousePosition.x <= panBoardThickness && Input.mousePosition.x >= 0f) ||
			Input.GetKey(KeyCode.LeftArrow)
        ) 
        {
			GoLeft ();
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
		transform.Translate ( Vector3.forward * panSpeed * Time.deltaTime, Space.Self );
	}

	private void GoBack () 
    {
		transform.Translate ( Vector3.back * panSpeed * Time.deltaTime, Space.Self );
	}

	private void GoLeft () 
    {
		transform.Translate ( Vector3.left * panSpeed * Time.deltaTime, Space.Self );
	}

	private void GoRight () 
    {
		transform.Translate ( Vector3.right * panSpeed * Time.deltaTime, Space.Self );
	}
}
