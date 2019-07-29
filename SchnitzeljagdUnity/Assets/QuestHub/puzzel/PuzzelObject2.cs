using UnityEngine;
using UnityEngine.UI;

public class PuzzelObject2 : MonoBehaviour
{
    [SerializeField]
    private Transform puzzelPlace;      //The corrospunding place for this puzzel piece
    private Vector2 initialPostion;     //Start postion of the puzzel piece
    private float deltaX, deltaY;       //Used the for the movement of the puzzel piece
    public bool locked;                 //Used for locking the puzzel piece in place if its in the right place
    public bool touched;                //Used to check if the puzzel piece is allready touched         
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        initialPostion = transform.position;
        touched = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.touches[0];
            Vector3 tch = new Vector3(touch.position.x, touch.position.y, 10);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(tch);
            Collider2D puzzel = new Collider2D();
            try
            {
                text = GameObject.Find("Text").GetComponent<Text>();
                text.text = tch.ToString("G4");
            }
            catch
            {

            }
            switch (touch.phase)
            {
                //Just touched the screen
                case TouchPhase.Began:
                    //Touching the puzzel piece
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        touched = true;
                    }
                    break;
                //Moving the finger on the screen
                case TouchPhase.Moved:
                    if (touched)
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
                        touched = false;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPostion.x, initialPostion.y);
                        touched = false;
                    }
                    break;
            }
        }
    }
}