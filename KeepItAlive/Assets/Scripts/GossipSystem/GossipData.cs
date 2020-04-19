using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Text;
using LitJson;

namespace MyGameGlobal {
    public static class GossipData {
        private static string m_DialogPath = Application.streamingAssetsPath + "/Gossip.txt";

        private static Dictionary<ENUM_GossipType, List<GossipFormat>> m_GossipDataDic = new Dictionary<ENUM_GossipType, List<GossipFormat>>();

        static GossipData() {
            m_GossipDataDic[ENUM_GossipType.DecreaseHP] = new List<GossipFormat>();
            m_GossipDataDic[ENUM_GossipType.DecreaseRP] = new List<GossipFormat>();
            m_GossipDataDic[ENUM_GossipType.FeceScientist_A] = new List<GossipFormat>();
            m_GossipDataDic[ENUM_GossipType.FeceScientist_B] = new List<GossipFormat>();
            m_GossipDataDic[ENUM_GossipType.KillEnemy] = new List<GossipFormat>();
            m_GossipDataDic[ENUM_GossipType.SeeManyEnemy] = new List<GossipFormat>();

            ReadGossipData();
        }

        public static string GetGossipData(ENUM_GossipType gossipType, int value) {
            List<GossipFormat> temp = new List<GossipFormat>();
            foreach (GossipFormat item in m_GossipDataDic[gossipType]) {
                if (value <= item.GossipValue) {
                    temp.Add(item);
                }
            }

            return temp[UnityEngine.Random.Range(0, temp.Count)].GossipData;
        }


        private static void ReadGossipData() {
            string str = File.ReadAllText(m_DialogPath, Encoding.UTF8);
            JsonData js = JsonMapper.ToObject(str);
            foreach (JsonData item in js) {
                GossipFormat gossip = new GossipFormat();
                gossip.GossipType = (ENUM_GossipType)System.Enum.Parse(typeof(ENUM_GossipType), item["TriggerType"].ToString());
                gossip.GossipValue = Convert.ToInt32(item["TriggerValue"].ToString());
                gossip.GossipData = item["GossipData"].ToString();
                m_GossipDataDic[gossip.GossipType].Add(gossip);
            }
        }
    }
}