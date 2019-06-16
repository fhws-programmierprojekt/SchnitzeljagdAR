using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelObject : MonoBehaviour
{
    [SerializeField]
    private Transform puzzelPlace;      //The corrospunding place for this puzzel piece
    private Vector2 initialPostion;     //Start postion of the puzzel piece
    private float deltaX, deltaY;       //Used the for the movement of the puzzel piece
    public bool locked;                 //Used for locking the puzzel piece in place if its in the right place
    

    // Start is called before the first frame update
    void Start()
    {
        initialPostion = transform.position;
    } 

    // Update is called once per frame
    void Update()
    {
          if (Input.touchCount > 0 && !locked)
          { 
                
                Touch touch = Input.GetTouch(0);
                Vector3 tch = new Vector3(touch.position.x, touch.position.y, 10);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(tch);
            Debug.Log(touchPos);
                switch (touch.phase)
                {
                    //Just touched the screen
                    case TouchPhase.Began:
                        //Touching the puzzel piece
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                        }
                        break;
                    //Moving the finger on the screen
                    case TouchPhase.Moved:
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                        }
                        break;
                    //Finger realesd the screen
                    case TouchPhase.Ended:
                        if (Mathf.Abs(transform.position.x - puzzelPlace.position.x) <= 0.5f &&
                            Mathf.Abs(transform.position.y - puzzelPlace.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(puzzelPlace.position.x, puzzelPlace.position.y);
                            locked = true;
                            PuzzelController.counter++;
                        }
                        else
                        {
                            transform.position = new Vector2(initialPostion.x, initialPostion.y);
                        }
                        break;
                }
          } 
    }
 }

