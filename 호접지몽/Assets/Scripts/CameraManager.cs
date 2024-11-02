using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    //카메라를 Object에 고정시키는 스크립트
    public GameObject target;
    public float moveSpeed;
    private Vector3 Position;

    private Vector3 minBound;
    private Vector3 maxBound;

    private float halfWidth;
    private float halfHeight;

    private Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject != null)
        {
            Position.Set(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, Position, moveSpeed*Time.deltaTime);
        }
    }
}
