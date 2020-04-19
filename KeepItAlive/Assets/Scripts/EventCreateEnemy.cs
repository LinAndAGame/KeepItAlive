using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class EventCreateEnemy : MonoBehaviour {
        public int m_EnemyCount = 10;
        public ENUM_Enemy m_EnemyType;
        public Vector3 m_EnemyPos;
        

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag=="Player") {
                //关闭这个触发器
                this.GetComponent<BoxCollider2D>().enabled = false;
                //产生敌人
                CreateEnemy();
                if (m_EnemyCount>=20) {
                    UITool.CreateGossipUI(ENUM_GossipType.SeeManyEnemy);
                }
            }
        }

        private void CreateEnemy() {
            GameObject perfab = null;
            switch (m_EnemyType) {
                case ENUM_Enemy.blue:
                    perfab = Resources.Load<GameObject>("Perfabs/Enemy_Blue");
                    break;
                case ENUM_Enemy.green:
                    perfab = Resources.Load<GameObject>("Perfabs/Enemy_Green");
                    break;
                case ENUM_Enemy.red:
                    perfab = Resources.Load<GameObject>("Perfabs/Enemy_Red");
                    break;
                case ENUM_Enemy.boss:
                    perfab = Resources.Load<GameObject>("Perfabs/Enemy_Boss");
                    break;
                default:
                    break;
            }
            for (int i = 0; i < m_EnemyCount; i++) {
                Instantiate(perfab,m_EnemyPos,Quaternion.identity);
            }
        }
    }
}