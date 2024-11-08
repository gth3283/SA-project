using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    [System.Serializable]
    public class Data  // 이 구역에 저장되어야 하는 내용을 넣어야 합니다.
    {
        public float playerX;
        public float playerY;
        public float playerZ;

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
