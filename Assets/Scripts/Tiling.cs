using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour
{

    const int LEFT = -1, RIGHT = 1;     // Should maybe be an enum instead of ints

    public int offsetX = 2;

    // this are used for checking if we need to instantiate stuff
    private bool hasRightBuddy = false, hasLeftBuddy = false;
    public bool reverseScale = false;

    private float spriteWidth = 0.0f;		// the width of our element
    private Camera cam;                     // "reference" to the scene camera
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // does it still need buddies?  If not, do nothing
        if (!hasLeftBuddy || !hasRightBuddy)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            // checking if we can see the edge of the element and then calling MakeNewBuddy if we can
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasRightBuddy)
            {
                MakeNewBuddy(RIGHT);
                hasRightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasLeftBuddy)
            {
                MakeNewBuddy(LEFT);
                hasLeftBuddy = true;
            }
        }
    }

    // a function that creates a buddy on the side required
    void MakeNewBuddy(int placement)
    {
        // calculating the new position for our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * placement, myTransform.position.y, myTransform.position.z);
        // instantiating our new buddy and storing him in a variable
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        // if not tilable, let's reverse the size of our object to get rid of ugly seams
        if (reverseScale)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = this.myTransform.parent;
        if (placement > 0)
        {
            newBuddy.GetComponent<Tiling>().SetHasLeftBuddy(true);
        }
        else
        {
            newBuddy.GetComponent<Tiling>().SetHasRightBuddy(true);
        }
    }
    public bool GetHasLeftBuddy() { return hasLeftBuddy; }
    public bool GetHasRightBuddy() { return hasRightBuddy; }
    public void SetHasLeftBuddy(bool b) { hasLeftBuddy = b; }
    public void SetHasRightBuddy(bool b) { hasRightBuddy = b; }
}