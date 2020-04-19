using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameGlobal {
    public class GossipFormat{
        private ENUM_GossipType m_GossipType;
        private int m_GossipValue;
        private string m_GossipData;

        public ENUM_GossipType GossipType { get => m_GossipType; set => m_GossipType = value; }
        public int GossipValue { get => m_GossipValue; set => m_GossipValue = value; }
        public string GossipData { get => m_GossipData; set => m_GossipData = value; }
    }

    public enum ENUM_GossipType {
        DecreaseHP,
        DecreaseRP,
        KillEnemy,
        FeceScientist_A,
        FeceScientist_B,
        SeeManyEnemy,
        Custom,
    }
}