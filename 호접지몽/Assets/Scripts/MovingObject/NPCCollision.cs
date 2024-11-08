using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCCollision : MonoBehaviour
{
    public GameObject target;
    public bool isCollision = false;
    private bool isPlayer = false;
    private MovingObject player;
    private float OriginSpeed;
    private int collisionPoint; //충돌 지점이 어디인지

    private void Start()
    {
        if (target.GetComponent<MovingObject>() != null) {
            isPlayer = true;
            player = target.GetComponent<MovingObject>();
            OriginSpeed = player.speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollision = true;
        if (isPlayer) {
            Quaternion targetRotation = Quaternion.LookRotation(collision.transform.position - this.transform.position, this.transform.up);

            if (targetRotation.x > 0)
            {
                collisionPoint = 0; //오른쪽 충돌
                Debug.Log("오른쪽 충돌");
                Debug.Log(targetRotation.x);
                Debug.Log(targetRotation.y);
            }
            else if (targetRotation.x < 0)
            {
                collisionPoint = 1; //왼쪽
                Debug.Log("왼쪽 충돌");
                Debug.Log(targetRotation.x);
                Debug.Log(targetRotation.y);
            }
            else if (targetRotation.y > 0)
                collisionPoint = 2; //위
            else if (targetRotation.y < 0)
                collisionPoint = 3; //아래
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isPlayer)
            StartCoroutine(playerStopCoroutine());
    }

    IEnumerator playerStopCoroutine()
    {
        player.speed = 0f;
        yield return new WaitForSeconds(0.1f);
        player.speed = OriginSpeed;
        yield return new WaitForSeconds(0.1f);
        switch (collisionPoint) {
            case 0:
                if (Input.GetAxisRaw("Horizontal") > 0)
                    player.speed = 0f;
                else
                    player.speed = OriginSpeed;
                break;
            case 1:
                if (Input.GetAxisRaw("Horizontal") < 0)
                    player.speed = 0f;
                else
                    player.speed = OriginSpeed;
                break;
            case 2:
                if (Input.GetAxisRaw("Vertical") > 0)
                    player.speed = 0f;
                else
                    player.speed = OriginSpeed;
                break;
            case 3:
                if (Input.GetAxisRaw("Vertical") < 0)
                    player.speed = 0f;
                else
                    player.speed = OriginSpeed;
                break;
        }
        yield return new WaitForSeconds(0.1f);
    }

    private void OnCollisionExit2D(Collision2D collision) //충돌 상태에서 빠져나갈 때 호출
    {
        isCollision = false;
    }

}
