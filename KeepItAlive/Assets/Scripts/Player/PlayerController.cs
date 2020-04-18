using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class PlayerController : MonoBehaviour {
        public float m_Speed = 10;

        private Vector3 m_InputAxis = Vector3.zero;
        private Rigidbody2D m_Rigid2D = null;
        private Animator m_PlayerAni = null;


        private void Start(){
            m_Rigid2D = this.GetComponent<Rigidbody2D>();
            m_PlayerAni = this.GetComponent<Animator>();
        }
        
        private void Update(){
            m_InputAxis = GlobalValue.GetInputAxis();
            m_Rigid2D.MovePosition(this.transform.position + m_InputAxis * m_Speed * Time.deltaTime);
            if (m_InputAxis!=Vector3.zero) {
                m_PlayerAni.SetBool("Run", true);
            }
            else {
                m_PlayerAni.SetBool("Run", false);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            //玩家移动的时候左右旋转
            if (m_InputAxis.x<0) {
                this.transform.rotation = Quaternion.Euler(0,180,0);
            }
            else {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}