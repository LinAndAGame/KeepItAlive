using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class EventCreateEnemy : MonoBehaviour {
        public int m_EnemyCount = 10;
        public ENUM_Enemy m_EnemyType;
        public Vector3 m_EnemyPos;

        private void Start(){
            
        }
        
        private void Update(){
            
        }
        

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag=="Player") {
                //关闭这个触发器
                this.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("事件被触发了！");
                //产生敌人
                CreateEnemy(); 
            }
        }

        private void CreateEnemy() {
            GameObject perfab = Resources.Load<GameObject>("Perfabs/Enemy_Red");
            for (int i = 0; i < m_EnemyCount; i++) {
                Instantiate(perfab,m_EnemyPos,Quaternion.identity);
            }
        }
    }
}