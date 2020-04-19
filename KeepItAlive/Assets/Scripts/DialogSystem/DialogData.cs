using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LitJson;
using System.IO;
using System.Text;

namespace MyGameGlobal {
    public static class DialogData {
        private static string m_DialogPath = Application.streamingAssetsPath + "/Dialog.txt";

        private static Dictionary<ENUM_DialogType, List<DialogFormat>> m_DialogDataDic = new Dictionary<ENUM_DialogType, List<DialogFormat>>();
        private static int m_Index = -1;
        private static ENUM_DialogType m_CurrentDialogType=ENUM_DialogType.Introduce_Start;

        static DialogData() {
            m_DialogDataDic[ENUM_DialogType.Introduce_Start] = new List<DialogFormat>();
            m_DialogDataDic[ENUM_DialogType.Introduce_End] = new List<DialogFormat>();
            m_DialogDataDic[ENUM_DialogType.PlayerTrigger_A] = new List<DialogFormat>();
            m_DialogDataDic[ENUM_DialogType.PlayerTrigger_B] = new List<DialogFormat>();

            ReadDialogData();
        }

        /// <summary>
        /// 获得指定对话类型的下一句的对话内容Format
        /// </summary>
        /// <param name="dialogType">对话类型</param>
        /// <returns></returns>
        public static DialogFormat GetNextDialogData(ENUM_DialogType dialogType) {
            if (m_CurrentDialogType==dialogType) {
                ++m_Index;
                if (m_Index> m_DialogDataDic[m_CurrentDialogType].Count-1) {
                    return null;
                }
            }
            else {
                m_Index = 0;
                m_CurrentDialogType = dialogType;
            }
            return m_DialogDataDic[m_CurrentDialogType][m_Index];
        }

        private static void ReadDialogData() {

            string str = File.ReadAllText(m_DialogPath,Encoding.UTF8);
            JsonData dialogArray = JsonMapper.ToObject(str);
            foreach (JsonData item in dialogArray) {
                DialogFormat d = new DialogFormat();
                d.DialogType = (ENUM_DialogType)System.Enum.Parse(typeof(ENUM_DialogType), item["DialogType"].ToString());
                d.DialogSpeaker = (ENUM_Speaker)System.Enum.Parse(typeof(ENUM_Speaker), item["Speaker"].ToString());
                d.DialogContent = item["Content"].ToString();
                m_DialogDataDic[d.DialogType].Add(d);
            }
        }
    }
}