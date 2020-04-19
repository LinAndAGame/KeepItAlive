using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;
using MyGameKernel;

namespace DefaultNameSpace {
    public class EventContentNpc : MonoBehaviour {
        public ENUM_Speaker m_Speaker;
        private GameObject m_Tip = null;
        private bool m_Enter = false;

        private void Start(){
            
        }
        
        private void Update(){
            if (m_Enter==true) {
                JudgeInStay();
                TipFollowNPC();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag=="Player") {
                JudgeInEnter();
                m_Enter = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.tag == "Player") {
                m_Enter = false;
                if (m_Tip != null) {
                    Destroy(m_Tip);
                }
            }
        }


        private void TipFollowNPC() {
            if (m_Tip != null) {
                m_Tip.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(this.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            }
        }

        private void JudgeInEnter() {
            switch (m_Speaker) {
                case ENUM_Speaker.Scientist_A:
                    if (PlayerInfo.TalkToNpcA==false || PlayerInfo.MissionDoneA==false) {
                        m_Tip = UITool.CreateTipUI("F");
                        TipFollowNPC();
                    }
                    break;
                case ENUM_Speaker.Scientist_B:
                    if (PlayerInfo.TalkToNpcB == false || PlayerInfo.MissionDoneB == false) {
                        m_Tip = UITool.CreateTipUI("F");
                        TipFollowNPC();
                    }
                    break;
                default:
                    break;
            }
        }

        private void JudgeInStay() {
            Debug.Log(111);
            switch (m_Speaker) {
                case ENUM_Speaker.Scientist_A:
                    if (Input.GetKeyDown(KeyCode.F)) {
                        if (PlayerInfo.TalkToNpcA==false) {
                            DialogFormat dialog = DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_A);
                            if (dialog!=null) {
                                //显示对话内容
                                UITool.ShowDialogText(dialog);
                                //更改游戏状态为Talking
                                GlobalValue.ChangeGamePhare(ENUM_GamePhase.Talking);
                            }
                            else {
                                UITool.HideDialogText();
                                //添加任务
                                TaskFormat task = new TaskFormat();
                                task.TaskName = "Find Food";
                                task.TaskDescription ="Map Right UP And Right Middle";
                                PlayerInfo.AddTaskList(task);
                                //更新玩家数据
                                PlayerInfo.TalkToNpcA = true;
                                //更改游戏状态为Play
                                GlobalValue.ChangeGamePhare(ENUM_GamePhase.Play);
                                //告诉你食物的位置
                                UITool.ShowFoodInMap();
                            }
                        }
                        else if (PlayerInfo.MissionDoneA == false) {
                            if (PlayerInfo.Food>0) {
                                --PlayerInfo.Food;
                                //任务奖励，告诉你注射剂的位置
                                UITool.ShowIntectionInMap();
                                PlayerInfo.MissionDoneA = true;
                                //取消任务
                                PlayerInfo.RemoveTaskList("Find Food");
                            }
                            else {
                                UITool.CreateGossipUICustom("I need find food!");
                            }
                        }
                        else {
                            UITool.CreateGossipUICustom("There is no task here!");
                        }
                    }
                    break;
                case ENUM_Speaker.Scientist_B:
                    if (Input.GetKeyDown(KeyCode.F)) {
                        if (PlayerInfo.TalkToNpcB == false) {
                            DialogFormat dialog = DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_B);
                            if (dialog != null) {
                                //显示对话内容
                                UITool.ShowDialogText(dialog);
                                GlobalValue.ChangeGamePhare(ENUM_GamePhase.Talking);
                            }
                            else {
                                UITool.HideDialogText();
                                //添加任务
                                TaskFormat task = new TaskFormat();
                                task.TaskName = "Find Food2";
                                task.TaskDescription = "Map Right";
                                PlayerInfo.AddTaskList(task);
                                //更新玩家数据
                                PlayerInfo.TalkToNpcB = true;
                                GlobalValue.ChangeGamePhare(ENUM_GamePhase.Play);
                            }
                        }
                        else if (PlayerInfo.MissionDoneB == false) {
                            if (PlayerInfo.Food > 0) {
                                --PlayerInfo.Food;
                                //任务奖励，拥有上锁的门的钥匙
                                PlayerInfo.DoorA = true;
                                PlayerInfo.MissionDoneB = true;
                                //取消任务
                                PlayerInfo.RemoveTaskList("Find Food2");
                            }
                            else {
                                UITool.CreateGossipUICustom("I need find food!");
                            }
                        }
                        else {
                            UITool.CreateGossipUICustom("There is no task here!");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}