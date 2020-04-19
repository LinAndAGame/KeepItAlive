/****************************************************
	文件：Ease.cs
	作者：林文豪
	日期：2020/04/06 14:03:22
	功能：核心层，设置了一些缓动函数
*****************************************************/

using System;

namespace MyGameKernel {
    public enum EaseType {
        Liner = 0,
        SinIn = 1,
        SinOut,
        SinInOut,
        QuadIn,
        QuadOut,
        QuadInOut,
        CubicIn,
        CubicOut,
        CubicInOut,
        QuartIn,
        QuartOut,
        QuartInOut,
        QuintIn,
        QuintOut,
        QuintInOut,
        CircIn,
        CircOut,
        CircInOut,
        ExpoIn,
        ExpoOut,
        ExpoInOut,
    }

    public static class Ease {
        /// <summary>
        /// 得到缓动时间
        /// </summary>
        /// <param name="t">当前时间</param>
        /// <param name="d">目标时间</param>
        /// <param name="easeType">缓动类型</param>
        /// <returns></returns>
        public static float EaseValue(float t, float d, EaseType easeType) {
            switch (easeType) {
                case EaseType.Liner:
                    return t / d;
                case EaseType.SinIn:
                    return -(float)Math.Cos(t / d * (Math.PI / 2)) + 1;
                case EaseType.SinOut:
                    return (float)Math.Sin(t / d * (Math.PI / 2));
                case EaseType.SinInOut:
                    return -0.5f * ((float)Math.Cos(Math.PI * t / d) - 1);
                case EaseType.QuadIn:
                    return (t /= d) * t;
                case EaseType.QuadOut:
                    return -(t /= d) * (t - 2);
                case EaseType.QuadInOut:
                    if ((t /= d / 2) < 1)
                        return 0.5f * t * t;
                    return -0.5f * ((--t) * (t - 2) - 1);
                case EaseType.CubicIn:
                    return (t /= d) * t * t;
                case EaseType.CubicOut:
                    return (t = t / d - 1) * t * t + 1;
                case EaseType.CubicInOut:
                    if ((t /= d / 2) < 1)
                        return 0.5f * t * t * t;
                    return 0.5f * ((t -= 2) * t * t + 2);
                case EaseType.QuartIn:
                    return (t /= d) * t * t * t;
                case EaseType.QuartOut:
                    return -((t = t / d - 1) * t * t * t - 1);
                case EaseType.QuartInOut:
                    if ((t /= d / 2) < 1)
                        return 0.5f * t * t * t * t;
                    return -0.5f * ((t -= 2) * t * t * t - 2);
                case EaseType.QuintIn:
                    return (t /= d) * t * t * t * t;
                case EaseType.QuintOut:
                    return (t = t / d - 1) * t * t * t * t + 1;
                case EaseType.QuintInOut:
                    if ((t /= d / 2) < 1)
                        return 0.5f * t * t * t * t * t;
                    return 0.5f * ((t -= 2) * t * t * t * t + 2);
                case EaseType.CircIn:
                    return -((float)Math.Sqrt(1 - (t /= d) * t) - 1);
                case EaseType.CircOut:
                    return (float)Math.Sqrt(1 - (t = t / d - 1) * t);
                case EaseType.CircInOut:
                    if ((t /= d / 2) < 1)
                        return -0.5f * ((float)Math.Sqrt(1 - t * t) - 1);
                    return 0.5f * ((float)Math.Sqrt(1 - (t -= 2) * t) + 1);
                case EaseType.ExpoIn:
                    return (t == 0) ? 0 : (float)Math.Pow(2, 10 * (t / d - 1));
                case EaseType.ExpoOut:
                    return (t == d) ? 1 : (-(float)Math.Pow(2, -10 * t / d) + 1);
                case EaseType.ExpoInOut:
                    if (t == 0)
                        return 0;
                    if (t == d)
                        return 1;
                    if ((t /= d / 2) < 1)
                        return 0.5f * (float)Math.Pow(2, 10 * (t - 1));
                    return 0.5f * (-(float)Math.Pow(2, -10 * --t) + 2);
                default:
                    return -1;
            }
        }
    }
}
