/*
 * 问题：slider的值会莫名其妙的改变
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEditor;
using UnityEngine.UI;
using MyGameKernel;

namespace DefaultNameSpace {
    public class EnemyValue : MonoBehaviour {
        public int c_MaxHP = 20;
        public bool m_IsBoos = false;

        private const int c_MinHP = 0;

        private Slider m_SldHP = null;
        private Text m_TxtHP = null;
        private ParticleSystem m_PS = null;

        private int m_EnemyHP = 0;
        private float m_Timer = 0;

        private AudioSource m_Audio;

        public int EnemyHP {
            get => m_EnemyHP;
            set {
                m_EnemyHP = value;
                m_SldHP.value = value;
                m_TxtHP.text = value.ToString() + "/" + c_MaxHP.ToString();
            }
        }

        private void Start() {
            m_SldHP = this.transform.Find("EnemyCanvas").Find("Sld_EnemyHP").GetComponent<Slider>();
            m_TxtHP= m_SldHP.transform.Find("Text_EnemyValue").GetComponent<Text>();
            m_PS = this.transform.Find("EnemyPS").GetComponent<ParticleSystem>();
            m_SldHP.maxValue = c_MaxHP;
            EnemyHP = c_MaxHP;
            m_Audio = this.GetComponent<AudioSource>();
        }

        private void Update() {
            if (m_IsBoos==true) {
                m_Timer += Time.deltaTime;

                if (EnemyHP<=0) {
                    //销毁物体
                    Destroy(this.gameObject, 1);
                    //销毁刚体
                    Destroy(this.gameObject.GetComponent<Rigidbody2D>());
                    //禁用Box
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    //敌人死亡粒子特效
                    m_PS.Play();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.tag == "Player") {
                if (m_IsBoos==false) {
                    //销毁物体
                    Destroy(this.gameObject, 1);
                    //销毁刚体
                    Destroy(this.gameObject.GetComponent<Rigidbody2D>());
                    //禁用Box
                    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    //敌人死亡粒子特效
                    m_PS.Play();
                    //玩家受伤
                    collision.transform.GetComponent<PlayerValue>().DecreaseHP(EnemyHP);
                    //播放音效

                }
                else {
                    //玩家受伤
                    if (m_Timer>=1) {
                        collision.transform.GetComponent<PlayerValue>().DecreaseHP(10);
                        m_Timer = 0; 
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag=="Buttel") {
                int damage=collision.GetComponent<ButtelController>().GetDamage();
                DecreaseHP(damage);
                m_Audio.Play();
            }
        }



        /// <summary>
        /// 加血
        /// </summary>
        public void IncreaseHP(int value) {
            //创建一个减血UI
            UITool.CreateValueText(this.transform, value,false);

            if (EnemyHP + value > c_MaxHP) {
                EnemyHP = c_MaxHP;
            }
            else {
                EnemyHP += value;
            }
        }

        /// <summary>
        /// 减血
        /// </summary>
        public void DecreaseHP(int value) {
            //创建一个减血UI
            UITool.CreateValueText(this.transform, value);

            if (EnemyHP - value < c_MinHP) {
                EnemyHP = c_MinHP;
                Debug.Log("Enemy Dead");
                //销毁物体
                Destroy(this.gameObject, 1);
                //销毁刚体
                Destroy(this.gameObject.GetComponent<Rigidbody2D>());
                //禁用Box
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //敌人死亡粒子特效
                m_PS.Play();
            }
            else {
                EnemyHP -= value;
            }
        }
    }
}