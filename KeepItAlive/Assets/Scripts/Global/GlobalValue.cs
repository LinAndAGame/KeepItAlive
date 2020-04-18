using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameGlobal {
    public static class GlobalValue {
        public static bool s_IsWin = false;

        private static ENUM_GamePhase s_GamePhase = ENUM_GamePhase.Introduce;

        /// <summary>
        /// 得到输入的XY轴信息
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetInputAxis() {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        }

        /// <summary>
        /// 前往下一个游戏状态
        /// </summary>
        /// <returns></returns>
        public static ENUM_GamePhase TurnToNextGamePhase(ENUM_GamePhase gamePhase) {
            if (s_GamePhase<gamePhase) {
                s_GamePhase = gamePhase;
            }
            else {
                Debug.LogWarning("不可以向前切换游戏状态。");
            }
            return s_GamePhase;
        }

        /// <summary>
        /// 输出当前的游戏状态
        /// </summary>
        /// <returns></returns>
        public static ENUM_GamePhase GetCurrentGamePhase() {
            return s_GamePhase;
        }
    }


    #region 枚举类型的定义
    public enum ENUM_GamePhase {
        Introduce,          //介绍
        Play,               //游玩
        Settlement,         //结算
    } 

    public enum ENUM_Enemy {
        blue,
        green,
        yellow,
        red,
        boss
    }
    #endregion
}