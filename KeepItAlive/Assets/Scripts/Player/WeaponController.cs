using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class WeaponController : MonoBehaviour {
        private Animator m_WeaponAni = null;
        private int m_WeaponRotation = 0;
        private Transform m_ButtelParent = null;
        private AudioSource m_Audio = null;

        private void Start(){
            m_WeaponAni = this.GetComponent<Animator>();
            m_ButtelParent = GameObject.Find("ButtelParent").transform;
            m_Audio = this.GetComponent<AudioSource>();
        }
        
        private void Update(){
            if (GlobalValue.GetCurrentGamePhase()== ENUM_GamePhase.Play) {
                GetWeaponRotation();
                if (Input.GetMouseButtonDown(0)) {
                    //播放动画
                    m_WeaponAni.SetTrigger("Attack");
                    //产生子弹
                    CreateButtel();
                    //播放音效
                    m_Audio.Play();
                }

                //武器跟随鼠标旋转
                if (m_WeaponRotation < -90 || m_WeaponRotation > 90) {
                    this.transform.rotation = Quaternion.Euler(0, 180, 180 - m_WeaponRotation);
                }
                else {
                    this.transform.rotation = Quaternion.Euler(0, 0, m_WeaponRotation);
                } 
            }
        }

        /// <summary>
        /// 计算出武器应该旋转的角度
        /// </summary>
        private void GetWeaponRotation() {
            Vector2 weaponScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            m_WeaponRotation = (int)Vector2.SignedAngle(Vector2.right,new Vector2 (Input.mousePosition.x,Input.mousePosition.y)-weaponScreenPos);
        }

        /// <summary>
        /// 产生子弹
        /// </summary>
        private void CreateButtel() {
            Instantiate(Resources.Load<GameObject>("Perfabs/Buttel"),this.transform.position,Quaternion.Euler(0,0,m_WeaponRotation), m_ButtelParent);
        }
    }
}