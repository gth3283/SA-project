using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCameraManeger : MonoBehaviour
{
    static public FollowingCameraManeger instance;

    public GameObject target;
    public float moveSpeed;
    private Vector3 Position;

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    private float halfWidth;
    private float halfHeight;

    private Camera Camera;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

     //Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = Camera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    //Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)
        {
            Position.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, Position, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(transform.position.x,minBound.x+halfWidth,maxBound.x-halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
