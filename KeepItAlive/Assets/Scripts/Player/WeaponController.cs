using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class WeaponController : MonoBehaviour {
        private Animator m_WeaponAni = null;
        private int m_WeaponRoattion = 0; 

        private void Start(){
            m_WeaponAni = this.GetComponent<Animator>();    
        }
        
        private void Update(){
            GetWeaponRotation();
            if (Input.GetMouseButtonDown(0)) {
                //播放动画
                m_WeaponAni.SetTrigger("Attack");
                //产生子弹
                CreateButtel();
            }

            //武器跟随鼠标旋转
            if (m_WeaponRoattion < -90 || m_WeaponRoattion > 90) {
                this.transform.rotation = Quaternion.Euler(0, 180,180- m_WeaponRoattion);
            }
            else {
                this.transform.rotation = Quaternion.Euler(0, 0, m_WeaponRoattion);
            }
        }

        /// <summary>
        /// 计算出武器应该旋转的角度
        /// </summary>
        private void GetWeaponRotation() {
            Vector2 weaponScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            m_WeaponRoattion = (int)Vector2.SignedAngle(Vector2.right,new Vector2 (Input.mousePosition.x,Input.mousePosition.y)-weaponScreenPos);
        }

        /// <summary>
        /// 产生子弹
        /// </summary>
        private void CreateButtel() {

        }
    }
}