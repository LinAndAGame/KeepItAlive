using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace DefaultNameSpace {
    public class PlayerValue : MonoBehaviour {
        public Slider m_SldHP = null;
        public Slider m_SldRP = null;
        public Text m_TxtHP = null;
        public Text m_TxtRP = null;

        private const int c_MinHP = 0;
        private const int c_MaxHP = 100;
        private const int c_MinRP = 0;
        private const int c_MaxRP = 100;

        private int m_PlayerHP = 0;           //HealthPoint(血量)
        private int m_PlayerRP = 0;           //ResistancePoint(抵抗值)

        private float m_Timer = 0;

        public int PlayerHP {
            get => m_PlayerHP;
            set {
                m_PlayerHP = value;
                m_SldHP.value = value;
                m_TxtHP.text = value.ToString() + "/" + c_MaxHP.ToString();
            }
        }

        public int PlayerRP {
            get => m_PlayerRP;
            set {
                m_PlayerRP = value;
                m_SldRP.value = value;
                m_TxtRP.text = value.ToString() + "/" + c_MaxRP.ToString();
            }
        }

        private void Start() {
            PlayerHP = c_MaxHP;
            PlayerRP = c_MaxRP;
        }

        private void Update() {
            m_Timer += Time.deltaTime;
            if (m_Timer >= 0.5f) {
                DecreaseRP(1);
                m_Timer = 0;
            }
        }

        /// <summary>
        /// 加血
        /// </summary>
        /// <param name="value"></param>
        public void IncreaseHP(int value) {
            if (PlayerHP + value > c_MaxHP) {
                PlayerHP = c_MaxHP;
            }
            else {
                PlayerHP += value;
            }
        }

        /// <summary>
        /// 减血
        /// </summary>
        public void DecreaseHP(int value) {
            if (PlayerHP - value < c_MinHP) {
                PlayerHP = c_MinHP;
                Debug.Log("Player Dead");
            }
            else {
                PlayerHP -= value;
            }
        }

        /// <summary>
        /// 增加抵抗值
        /// </summary>
        public void IncreaseRP(int value) {
            if (PlayerRP + value > c_MaxRP) {
                PlayerRP = c_MaxRP;
            }
            else {
                PlayerRP += value;
            }
        }

        /// <summary>
        /// 减少抵抗值
        /// </summary>
        public void DecreaseRP(int value) {
            if (PlayerRP > 0) {
                if (PlayerRP - value < c_MinRP) {
                    PlayerRP = c_MinRP;
                }
                else {
                    PlayerRP -= value;
                }
            }
            else {
                DecreaseHP(value);
            }
        }
    }
}