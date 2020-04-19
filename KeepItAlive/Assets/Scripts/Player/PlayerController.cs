using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;
using MyGameKernel;

namespace DefaultNameSpace {
    public class PlayerController : MonoBehaviour {
        public float m_Speed = 10;

        private Vector3 m_InputAxis = Vector3.zero;
        private Rigidbody2D m_Rigid2D = null;
        private Animator m_PlayerAni = null;
        private Transform m_CanvasPlayer = null;


        private void Start(){
            m_Rigid2D = this.GetComponent<Rigidbody2D>();
            m_PlayerAni = this.GetComponent<Animator>();
            m_CanvasPlayer = this.transform.Find("Canvas_Player");
        }
        
        private void Update(){
            if (GlobalValue.GetCurrentGamePhase() == ENUM_GamePhase.Play) {
                if (PlayerInfo.GetData==true) {
                    GlobalValue.ChangeGamePhare(ENUM_GamePhase.Settlement);
                    PlayerInfo.RemoveTaskList("Find Data");
                }


                m_InputAxis = GlobalValue.GetInputAxis();
                m_Rigid2D.MovePosition(this.transform.position + m_InputAxis * m_Speed * Time.deltaTime);
                if (m_InputAxis != Vector3.zero) {
                    m_PlayerAni.SetBool("Run", true);
                }
                else {
                    m_PlayerAni.SetBool("Run", false);
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                //玩家移动的时候左右旋转
                if (m_InputAxis.x < 0) {
                    this.transform.rotation = Quaternion.Euler(0, 180, 0);
                    m_CanvasPlayer.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    m_CanvasPlayer.localRotation = Quaternion.Euler(0, 0, 0);
                } 
            }
            else if (GlobalValue.GetCurrentGamePhase() == ENUM_GamePhase.Introduce) {
                if (Input.anyKeyDown) {
                    UITool.HideNormalPanel();
                    DialogFormat dialogData = DialogData.GetNextDialogData(ENUM_DialogType.Introduce_Start);
                    if (dialogData==null) {
                        GlobalValue.ChangeGamePhare(ENUM_GamePhase.Play);
                        UITool.HideDialogText();
                        TaskFormat task = new TaskFormat();
                        task.TaskName = "Find Data";
                        task.TaskDescription = "Map Left Up!";
                        PlayerInfo.AddTaskList(task);
                    }
                    else {
                        UITool.ShowDialogText(dialogData);  
                    }
                }
            }
            else if (GlobalValue.GetCurrentGamePhase() == ENUM_GamePhase.Talking) {
                m_InputAxis = Vector2.zero;
            }
            else if (GlobalValue.GetCurrentGamePhase() == ENUM_GamePhase.Settlement) {
                //最终结算。
                GameObject.Find("Canvas").transform.Find("Panel_Settlement").gameObject.SetActive(true);
            }
        }
    }
}