using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;//캐릭터 속도
    private Vector3 vector;//x,y,z축 사용

    public float Running;
    private float applyRun;
    private bool runFlag = false;

    public int TileCount;//쯔꾸르 특성상 타일당 상호작용을 구현하기 위해 타일만큼 이동 ex)player의 경우 speed값이 2.5이므로 한 타일의 크기인 50픽셀/2.5 = 20 설정
    private int CountBreaker;

    private bool Move = true;

    // Start is called before the first frame update
    void Start()
    {
 
    }
    IEnumerator MoveCoroutine()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            applyRun = Running;
            runFlag = true;
        }
        else
        {
            applyRun = 0;
            runFlag = false;
        }

        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);//입력받기

        while (CountBreaker < TileCount)
        {
            if (vector.x != 0)
            {
                transform.Translate(vector.x * (speed + applyRun), 0, 0);
            }
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * (speed + applyRun), 0);
            }

            if (runFlag)
            {
                CountBreaker++;
            }

            CountBreaker++;
            yield return new WaitForSeconds(0.01f);
        }

        CountBreaker = 0;
        Move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                Move = false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
