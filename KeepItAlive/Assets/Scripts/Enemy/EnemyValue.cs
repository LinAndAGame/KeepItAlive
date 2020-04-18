using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace DefaultNameSpace {
    public class EnemyValue : MonoBehaviour {
        public int c_MaxHP = 20;
        private const int c_MinHP = 0;

        private Slider m_SldHP = null;
        private Text m_TxtHP = null;
        private ParticleSystem m_PS = null;

        private int m_EnemyHP = 0;

        public int EnemyHP {
            get => m_EnemyHP;
            set {
                m_EnemyHP = value;
                m_SldHP.value = value;
                m_TxtHP.text = value.ToString() + "/" + c_MaxHP.ToString();
            }
        }

        private void Start() {
            m_SldHP = this.transform.Find("Canvas").Find("Sld_HP").GetComponent<Slider>();
            m_TxtHP= m_SldHP.transform.Find("Text_Value").GetComponent<Text>();
            m_PS = this.transform.Find("EnemyPS").GetComponent<ParticleSystem>();
            m_SldHP.maxValue = c_MaxHP;
            EnemyHP = c_MaxHP;
        }

        private void Update() {

        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.tag=="Player") {
                //Destroy(this.gameObject,1);
                m_PS.Play();
            }
        }



        /// <summary>
        /// 加血
        /// </summary>
        public void IncreaseRP(int value) {
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
            if (EnemyHP - value < c_MinHP) {
                EnemyHP = c_MinHP;
                Debug.Log("Player Dead");
            }
            else {
                EnemyHP -= value;
            }
        }
    }
}