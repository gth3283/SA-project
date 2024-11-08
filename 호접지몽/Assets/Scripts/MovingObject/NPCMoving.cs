using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    [Tooltip("NPCmove를 체크하면 NPC가 움직임")]
    public bool NPCmove;
    public string[] direction; // NPC가 움직일 방향 설정

    [Tooltip("NPC가 각 방향에서 이동할 칸 수")]
    public int[] tileCounts; // 각 방향별 이동 칸 수


    [Range(1, 4)]
    [Tooltip("1 = 천천히, 2 = 조금 천천히, 3 = 보통, 4 = 빠르게")]
    public int frequency; // NPC가 얼마나 빠르게 움직일 것인가

    
}

public class NPCMoving : MonoBehaviour
{
    public string cName;
    static public NPCMoving instance;

    public string MapName; // 플레이어 위치 맵 저장

    private BoxCollider2D BoxCollider;
    public LayerMask LayerMask;

    public float baseSpeed = 1f; // 기본 이동 속도, 기본값 설정
    private Vector3 vector; // x, y, z 축 추가

    private bool Move = true;
    public NPCMove npcMoveData; // NPCMove 데이터 참조

    private Animator ani;

    private NPCCollision NPCCollision;
    private bool RayCastHit = false;

    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            BoxCollider = GetComponent<BoxCollider2D>();
            ani = GetComponent<Animator>();
            NPCCollision = GetComponent<NPCCollision>();
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }

        // NPC가 움직이도록 설정되어 있으면 이동 시작
        if (npcMoveData.NPCmove)
        {
            StartCoroutine(AutoMoveCoroutine());
        }
    }

    IEnumerator AutoMoveCoroutine()
    {
        int dirIndex = 0;
        float speed = baseSpeed * npcMoveData.frequency; // 속도 조정

        while (npcMoveData.NPCmove)
        {
            while (NPCCollision.isCollision || RayCastHit) //충돌 상태라면 대기
            {
                yield return new WaitForSeconds(0.5f);
            }
            // 방향 순환
            if (dirIndex >= npcMoveData.direction.Length)
                dirIndex = 0;

            // 방향에 대한 칸 수 설정
            int tileCount = npcMoveData.tileCounts.Length > dirIndex ? npcMoveData.tileCounts[dirIndex] : 1; // 기본값 1

            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * baseSpeed * tileCount, vector.y * baseSpeed * tileCount);

            BoxCollider.enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(start, end);
            BoxCollider.enabled = true;
            Debug.DrawRay(start, end);

            if (!hit)
            {
                RayCastHit = false;
                NPCMove(npcMoveData.direction[dirIndex], tileCount);
                dirIndex++;
            }
            else
                RayCastHit = true;

            // 속도에 맞춰 대기
            yield return new WaitForSeconds(1f / npcMoveData.frequency);
        }
    }

    IEnumerator MoveCoroutineDirection(Vector3 direction, int tileCount)
    {
        int countBreaker = 0;
        Move = false; //이동 중에는 새로운 명령 무시

        ani.SetBool("Walking", true);
        while (countBreaker < tileCount)
        {
            transform.Translate(direction.x * baseSpeed, direction.y * baseSpeed, 0);
            countBreaker++;
            yield return new WaitForSeconds(0.01f);
        }

        ani.SetBool("Walking", false);
        Move = true;
    }

    // NPC 이동 메서드
    protected void NPCMove(string _dir, int tileCount)
    {
        if (!Move) return; // 이동 중일 때는 새로운 이동 명령을 무시

        vector.Set(0, 0, vector.z);

        switch (_dir)
        {
            case "UP":
                vector.y = 1f;
                ani.SetFloat("DirX", 0);
                ani.SetFloat("DirY", 1);
                break;
            case "DOWN":
                vector.y = -1f;
                ani.SetFloat("DirX", 0);
                ani.SetFloat("DirY", -1);
                break;
            case "RIGHT":
                vector.x = 1f;
                ani.SetFloat("DirX", 1);
                ani.SetFloat("DirY", 0);
                break;
            case "LEFT":
                vector.x = -1f;
                ani.SetFloat("DirX", -1);
                ani.SetFloat("DirY", 0);
                break;
        }

        StartCoroutine(MoveCoroutineDirection(vector, tileCount));
    }
}
