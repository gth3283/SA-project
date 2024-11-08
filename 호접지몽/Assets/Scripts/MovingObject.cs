using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public string cName;
    static public MovingObject instance;

    public string MapName;//플레이어 위치 맵 저장

    private BoxCollider2D BoxCollider;
    public LayerMask LayerMask;

    public float speed;//캐릭터 이동속도
    private Vector3 vector;//x,y,z축 추가

    public float Running;
    private float applyRun;
    private bool runFlag = false;

    public int TileCount;//타일당 이동 구현 ex)player의 speed가 2.5이고 타일의 크기가 50픽셀/2.5 = 20
    private int CountBreaker;

    private bool Move = true;

    private Animator ani;

    private NPCCollision NPCCollision;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            BoxCollider = GetComponent<BoxCollider2D>();
            ani = GetComponent<Animator>();
            NPCCollision = GetComponent<NPCCollision>();
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
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

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);//�Է¹ޱ�
            
            if(vector.x != 0)
            {
                vector.y = 0;
            }
            
            ani.SetFloat("DirX", vector.x);
            ani.SetFloat("DirY", vector.y);
            ani.SetBool("Walking", true);
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed * TileCount, vector.y * speed * TileCount);

            BoxCollider.enabled = false;
            RaycastHit2D hit = Physics2D.Linecast(start, end, LayerMask);
            BoxCollider.enabled = true;

            if (hit.transform != null)
            {
                break;
            }


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
           
        }
        ani.SetBool("Walking", false);
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
