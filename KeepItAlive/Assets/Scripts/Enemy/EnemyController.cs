using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace {
    public class EnemyController : MonoBehaviour {
        public float m_Speed = 5;
        private Transform m_Player = null;
        private Vector3 m_DirToTarget;
        private Rigidbody2D m_Rigid2D = null;

        private void Start(){
            m_Player = GameObject.Find("Player").transform;
            m_Rigid2D = this.GetComponent<Rigidbody2D>();
        }
        
        private void Update(){
            GetDirToTarget();
            if (m_Rigid2D!=null) {
                m_Rigid2D.MovePosition(this.transform.position + m_DirToTarget * m_Speed * Time.deltaTime); 
            }
        }

        private void GetDirToTarget() {
            m_DirToTarget = (m_Player.position - this.transform.position).normalized;
        }
    }
}