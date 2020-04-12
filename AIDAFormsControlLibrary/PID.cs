﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AIDAFormsControlLibrary
{
    /// <summary>
    /// 一个整数粒度的PID控制器，支持正反输出，
    /// 支持不断重复调用，
    /// 该控制器会始终保持最后一次调用在持续输出
    /// </summary>
    public class PID
    {
        private float SetSpeed; //定义设定值     
        private float ActualSpeed; //定义实际值    
        private float err; //定义偏差值   
        private float err_next; //定义上一个偏差值     
        private float err_last;  //定义最上前的偏差值      
        private float Kp, Ki, Kd; //定义比例、积分、微分系数 
        private float currentTar = -1;
        private float currentResultBuffer;
        /// <summary>
        /// p越小，曲线越平直
        /// </summary>
        /// <param name="kp"></param>
        /// <param name="ki"></param>
        /// <param name="kd"></param>
        public PID(float kp = 0.1f, float ki = 0.2f, float kd = 0.4f)
        {
            SetSpeed = 0;
            ActualSpeed = 0;
            err = 0;
            err_last = 0;
            err_next = 0;
            Kp = kp;
            Ki = ki;
            Kd = kd;
        }

        public void SetPID(float kp, float ki, float kd)
        {
            Kp = kp;
            Ki = ki;
            Kd = kd;
        }

        public void SetWithPID(float current, float target)
        {
            Task.Run(() => Excute(current, target));
            //Excute(current, target);
        }

        private void Excute(float current, float target)
        {
            if (currentTar == target)
                return;
            if (currentResultBuffer != 0)
                current = currentResultBuffer;
            float originTar = current;
            bool reverse = false;
            if (target < current)
            {
                target = current - target;
                current = 0;
                reverse = true;
            }
            currentTar = target;
            //重置
            ActualSpeed = current;
            err_last = err_next = 0;

            float lastResult = current;
            float currentResult;
            while (Math.Abs(target - (currentResult = PIDCaculate(target))) > 0.01 && currentTar == target)
            {
                if (reverse)
                {
                    PIDOutEvent_Float?.Invoke(originTar - currentResult);
                    currentResultBuffer = originTar - currentResult;
                    if ((int)lastResult < (int)currentResult)
                        PIDOutEvent_Int?.Invoke(originTar - currentResult);
                }
                else
                {
                    PIDOutEvent_Float?.Invoke(currentResult);
                    currentResultBuffer = currentResult;
                    if ((int)lastResult < (int)currentResult)
                        PIDOutEvent_Int?.Invoke(currentResult);
                }
                lastResult = currentResult;
            }
            if (currentTar == target && !reverse)
            {
                currentResultBuffer = target;
                PIDOutEvent_Float?.Invoke(target);
                PIDOutEvent_Int?.Invoke(target);
            }
            else if (currentTar == target && reverse)
            {
                currentResultBuffer = current;
                PIDOutEvent_Float?.Invoke(current);
                PIDOutEvent_Int?.Invoke(current);
            }
        }

        private float PIDCaculate(float target)
        {
            //Thread.Sleep(20);
            SetSpeed = target;
            err = SetSpeed - ActualSpeed;
            var incrementSpeed = Kp * (err - err_next + Ki * err + Kd * (err - 2 * err_next + err_last));
            ActualSpeed += incrementSpeed;
            err_last = err_next;
            err_next = err;
            return ActualSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">当前输出的值</param>
        public delegate void PIDHandller(float value);
        /// <summary>
        /// Float事件每次计算都会触发
        /// </summary>
        public event PIDHandller PIDOutEvent_Float;
        /// <summary>
        /// Int事件只有在整数部分发生变化是才会触发
        /// </summary>
        public event PIDHandller PIDOutEvent_Int;
    }
}
