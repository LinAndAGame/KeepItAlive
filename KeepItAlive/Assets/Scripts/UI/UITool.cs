using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using MyGameKernel;
using MyGameGlobal;

namespace DefaultNameSpace {
    public class UITool {
        private static GameObject m_TxtValuePerfab;
        private static GameObject m_TxtValueIns;
        private static Transform m_ValueTxtParent;

        private static Transform m_DialosCanvas;
        private static GameObject m_NormalPanel;

        private static GameObject m_PanelTask;
        private static GameObject m_TaskPerfab;

        private static GameObject m_CanvasPlayer;
        private static GameObject m_GossipPerfab;

        private static GameObject m_PanelBattle;
        private static GameObject m_TipPerfab;

        static UITool() {
            m_TxtValuePerfab = Resources.Load<GameObject>("Perfabs/Txt_Value");
            m_ValueTxtParent = GameObject.Find("Canvas/Panel_Battle/ValueTextParent").transform;

            m_DialosCanvas = GameObject.Find("Canvas_Dialog").transform;
            HideDialogText();

            m_NormalPanel = GameObject.Find("Canvas/Panel_Normal");
            m_PanelTask = GameObject.Find("Canvas/Panel_Battle/Panel_Task");
            m_TaskPerfab = Resources.Load<GameObject>("Perfabs/Txt_TaskName");

            m_CanvasPlayer = GameObject.Find("Player/Canvas_Player");
            m_GossipPerfab = Resources.Load<GameObject>("Perfabs/Img_Gossip");

            m_PanelBattle = GameObject.Find("Canvas/Panel_Battle");
            m_TipPerfab = Resources.Load<GameObject>("Perfabs/Img_Tip");
        }

        public static void CreateValueText(Transform target, int value, bool decrease = true) {
            m_TxtValueIns = GameObject.Instantiate(m_TxtValuePerfab, Camera.main.WorldToScreenPoint(target.position), Quaternion.identity, m_ValueTxtParent);
            if (decrease == true) {
                m_TxtValueIns.GetComponent<Text>().text = "-" + value.ToString();
            }
            else {
                m_TxtValueIns.GetComponent<Text>().text = "+" + value.ToString();
            }
        }

        public static void ShowDialogText(DialogFormat dialog) {
            m_DialosCanvas.gameObject.SetActive(true);
            m_DialosCanvas.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
            m_DialosCanvas.Find("Panel").Find("Txt_Speaker").GetComponent<Text>().text = dialog.DialogSpeaker.ToString();
            m_DialosCanvas.Find("Panel").Find("Txt_Content").GetComponent<Text>().text = dialog.DialogContent;
        }

        public static void HideDialogText() {
            m_DialosCanvas.gameObject.SetActive(false);
        }

        public static void HideNormalPanel() {
            m_NormalPanel.SetActive(false);
        }

        public static void CreateTaskUI(string name ,string description,Vector2 anchPosRelative) {
            GameObject taskIns = GameObject.Instantiate(m_TaskPerfab);
            taskIns.transform.SetParent(m_PanelTask.transform,false);
            taskIns.GetComponent<Text>().text = name+":";
            taskIns.transform.Find("Txt_TaskDescription").GetComponent<Text>().text= description;
            taskIns.GetComponent<RectTransform>().anchoredPosition += anchPosRelative;
        }

        public static void ClearTaskUI() {
            for (int i = 0; i < m_PanelTask.transform.childCount; i++) {
                GameObject.Destroy(m_PanelTask.transform.GetChild(i).gameObject);
            }
        }

        public static void CreateGossipUI(ENUM_GossipType gossipType,int value=0) {
            GameObject gossipIns = GameObject.Instantiate(m_GossipPerfab);
            gossipIns.transform.SetParent(m_CanvasPlayer.transform,false);
            gossipIns.GetComponentInChildren<Text>().text = GossipData.GetGossipData(gossipType,value);
            GameObject.Destroy(gossipIns.gameObject,2);
            GameObject.Find("Player").GetComponent<PlayerValue>().ResetTimerGossip();
        }

        public static void CreateGossipUICustom(string content) {
            GameObject gossipIns = GameObject.Instantiate(m_GossipPerfab);
            gossipIns.transform.SetParent(m_CanvasPlayer.transform, false);
            gossipIns.GetComponentInChildren<Text>().text = content;
            GameObject.Destroy(gossipIns.gameObject, 2);
            GameObject.Find("Player").GetComponent<PlayerValue>().ResetTimerGossip();
        }

        public static GameObject CreateTipUI(string tip) {
            GameObject tipIns = GameObject.Instantiate(m_TipPerfab);
            tipIns.transform.SetParent(m_PanelBattle.transform, false);
            tipIns.GetComponentInChildren<Text>().text = tip;
            return tipIns;
        }


        public static void ShowIntectionInMap() {
            GameObject intectionParent = GameObject.Find("SceneItem/Intection");
            for (int i = 0; i < intectionParent.transform.childCount; i++) {
                intectionParent.transform.GetChild(i).Find("MinimapUI_Intection").gameObject.SetActive(true);
            }
        }

        public static void ShowFoodInMap() {
            GameObject foodParnet = GameObject.Find("SceneItem/Food");
            for (int i = 0; i < foodParnet.transform.childCount; i++) {
                foodParnet.transform.GetChild(i).Find("MinimapUI_Food").gameObject.SetActive(true);
            }
        }
    }
}