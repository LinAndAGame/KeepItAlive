using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using DefaultNameSpace;

namespace MyGameGlobal {
    public static class PlayerInfo {
        private static bool m_DoorA = false;           //是否拥有A门的钥匙
        private static int m_Food = 0;
        private static int m_Intection = 0;
        private static bool m_GetData = false;
        private static List<TaskFormat> m_TaskList = new List<TaskFormat>();
        private static bool m_TalkToNpcA = false;
        private static bool m_MissionDoneA = false;
        private static bool m_TalkToNpcB = false;
        private static bool m_MissionDoneB = false;

        public static bool DoorA { get => m_DoorA;
            set {
                m_DoorA = value;
                GameObject.Find("Canvas/Panel_Battle/Panel_PlayerItemInfo/Img_IDCard/Txt_IDCardValue").GetComponent<Text>().text = "X1";
            }
        }
        public static int Food {
            get => m_Food;
            set {
                m_Food = value;
                GameObject.Find("Canvas/Panel_Battle/Panel_PlayerItemInfo/Img_Food/Txt_FoodValue").GetComponent<Text>().text = "X" + value.ToString();
            }
        }
        public static int Intection {
            get => m_Intection;
            set {
                m_Intection = value;
                GameObject.Find("Canvas/Panel_Battle/Panel_PlayerItemInfo/Img_Intection/Txt_IntectionValue").GetComponent<Text>().text = "X" + value.ToString();
            }
        }
        public static bool TalkToNpcA { get => m_TalkToNpcA; set => m_TalkToNpcA = value; }
        public static bool TalkToNpcB { get => m_TalkToNpcB; set => m_TalkToNpcB = value; }
        public static bool MissionDoneA { get => m_MissionDoneA; set => m_MissionDoneA = value; }
        public static bool MissionDoneB { get => m_MissionDoneB; set => m_MissionDoneB = value; }
        public static bool GetData { get => m_GetData; set => m_GetData = value; }

        public static void AddTaskList(TaskFormat task) {
            if (task != null) {
                m_TaskList.Add(task);
                UpdateTaskUI();
            }
        }

        /// <summary>
        /// 移除任务
        /// </summary>
        /// <param name="taskName"></param>
        public static void RemoveTaskList(string taskName) {
            for (int i = 0; i < m_TaskList.Count; i++) {
                if (taskName == m_TaskList[i].TaskName) {
                    m_TaskList.RemoveAt(i);
                    UpdateTaskUI();
                    return;
                }
            }
        }




        private static void UpdateTaskUI() {
            UITool.ClearTaskUI();
            for (int i = 0; i < m_TaskList.Count; i++) {
                UITool.CreateTaskUI(m_TaskList[i].TaskName, m_TaskList[i].TaskDescription, new Vector2(0, i * -100));
            }
        }
    }
}