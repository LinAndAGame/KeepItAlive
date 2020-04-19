using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class EventOpenDoor : MonoBehaviour {
        public bool m_Locked = false;

        private GameObject m_Tip = null;

        private Transform m_Door01;     //OpenToLeft
        private Transform m_Door02;     //OpenToRight

        private Vector3 m_Door01OriginPos;
        private Vector3 m_Door02OriginPos;

        private Vector3 m_Door01EndPos;
        private Vector3 m_Door02EndPos;

        private Vector3 m_Door01NowPos;
        private Vector3 m_Door02NowPos;

        private bool m_OpenDoor = false;

        private float m_Timer = 0;
        private const float m_Duration = 0.5f;
        private bool m_EnterTriggerRange = false;

        private void Start() {
            m_Door01 = this.transform.Find("Door_01");
            m_Door02 = this.transform.Find("Door_02");

            m_Door01OriginPos = m_Door01.transform.position;
            m_Door02OriginPos = m_Door02.transform.position;

            m_Door01EndPos = m_Door01OriginPos + (m_Door01.transform.right * -2.5f);
            m_Door02EndPos = m_Door02OriginPos + (m_Door02.transform.right * 2.5f);

            m_Door01NowPos = m_Door01.transform.position;
            m_Door02NowPos = m_Door02.transform.position;
        }

        private void Update() {
            m_Timer += Time.deltaTime;
            if (m_OpenDoor == true) {
                OpenDoor();
            }
            else {
                CloseDoor();
            }

            if (m_EnterTriggerRange==true) {
                if (m_Locked == true) {
                    //显示按F互动的提示
                    TipFollowDoor();
                    //如果按了F键
                    if (Input.GetKeyDown(KeyCode.F)) {
                        //判断是否有资格进入
                        //如果玩家还没有获取资格
                        if (PlayerInfo.DoorA == false) {
                            UITool.CreateGossipUICustom("I Need the AchievesRoomCard!");
                        }
                        else {
                            UITool.CreateGossipUICustom("Woooo!At last the door opened!");
                            if (m_Tip!=null) {
                                Destroy(m_Tip);
                            }
                            m_OpenDoor = true;
                            m_Locked = false;
                        }
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag == "Player") {
                if (m_Locked == false) {
                    m_OpenDoor = true;
                    m_Timer = 0;
                    m_Door01NowPos = m_Door01.transform.position;
                    m_Door02NowPos = m_Door02.transform.position;
                }
                else {
                    m_Tip = UITool.CreateTipUI("F");
                    TipFollowDoor();
                }
                m_EnterTriggerRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.tag == "Player") {
                if (m_Locked == false) {
                    m_OpenDoor = false;
                    m_Timer = 0;
                    m_Door01NowPos = m_Door01.transform.position;
                    m_Door02NowPos = m_Door02.transform.position;
                }
                else {
                    if (m_Tip != null) {
                        Destroy(m_Tip);
                    }
                }
                m_EnterTriggerRange = false;
            }
        }

        private void OpenDoor() {
            m_Door01.transform.position = Vector3.Lerp(m_Door01NowPos, m_Door01EndPos, m_Timer);
            m_Door02.transform.position = Vector3.Lerp(m_Door02NowPos, m_Door02EndPos, m_Timer);
        }

        private void CloseDoor() {
            m_Door01.transform.position = Vector3.Lerp(m_Door01NowPos, m_Door01OriginPos, m_Timer);
            m_Door02.transform.position = Vector3.Lerp(m_Door02NowPos, m_Door02OriginPos, m_Timer);
        }

        private void TipFollowDoor() {
            if (m_Tip != null) {
                m_Tip.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(this.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            }
        }
    }
}