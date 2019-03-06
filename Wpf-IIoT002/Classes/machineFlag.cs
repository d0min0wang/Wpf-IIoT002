using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_IIoT002
{
    public class machineFlag
    {
        private int _machineStartusQuality;
        private Boolean isMachineStart;

        private int _furnaceStartusQuality;
        private Boolean isFurnaceStart;

        private int _literStartusQuality;
        private Boolean isLiterStart;

        private int _alarmStatusQuality;
        private Boolean isAlarm;

        private int flareMoldTimeSetting;//烤模时间设定
        private int dippingMaterialTimeSetting;//浸料时间设定
        private int flareMaterialTimeSetting;//烤料时间设定
        private int coolingTimeSetting;//冷却时间设定
        private int brushOilTimeSetting;//刷油时间设定

        public int FlareMoldTimeSetting
        {
            get { return flareMoldTimeSetting; }
            set { flareMoldTimeSetting = value; }
        }

        public int DipingMaterialTimeSetting
        {
            get { return dippingMaterialTimeSetting; }
            set { dippingMaterialTimeSetting = value; }
        }

        public int FlareMaterialTimeSetting
        {
            get { return flareMaterialTimeSetting; }
            set { flareMaterialTimeSetting = value; }
        }

        public int CoolingTimeSetting
        {
            get { return coolingTimeSetting; }
            set { coolingTimeSetting = value; }
        }

        public int BrushOilTimeSetting
        {
            get { return brushOilTimeSetting; }
            set { brushOilTimeSetting = value; }
        }



        public void setIsMachineStart(Boolean isStart)
        {
            isMachineStart = isStart;
        }

        public void setIsFurnaceStart(Boolean isStart)
        {
            isFurnaceStart = isStart;
        }

        public void setLiterStart(Boolean isStart)
        {
            isLiterStart = isStart;
        }

        public void setAlarm(Boolean alarm)
        {
            isAlarm = alarm;
        }

        //机器状态数据质量标志
        public void setMachineStatusQuality(int quality)
        {
            _machineStartusQuality = quality;
        }
        public int getMachineStatusQuality()
        {
            return _machineStartusQuality;
        }

        //炉子状态数据质量标志
        public void setFurnaceStatusQuality(int quality)
        {
            _furnaceStartusQuality = quality;
        }
        public int getFurnaceStatusQuality()
        {
            return _furnaceStartusQuality;
        }

        //升料机状态数据质量标志
        public void setLiterStatusQuality(int quality)
        {
            _literStartusQuality = quality;
        }
        public int getLiterStatusQuality()
        {
            return _literStartusQuality;
        }

        //报警状态数据质量标志
        public void setAlarmStatusQuality(int quality)
        {
            _alarmStatusQuality = quality;
        }
        public int getAlarmStatusQuality()
        {
            return _alarmStatusQuality;
        }

        //开机
        public int getMachineStart()
        {
            if (isMachineStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //开炉做管
        public int getMaking()
        {
            if (isMachineStart && isFurnaceStart && isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //开炉空转
        public int getIdling()
        {
            if (isMachineStart && isFurnaceStart && !isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //不开炉空转
        public int getIdlingAndFurnaceStop()
        {
            if (isMachineStart && !isFurnaceStart && !isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //停机
        public int getHalting()
        {
            if (!isMachineStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //报警
        public int getAlarm()
        {
            if (isAlarm)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public Color machineStatus()
        {
            //机器状态
            if (_machineStartusQuality == 192)
            {
                if (isMachineStart)
                {
                    if (isFurnaceStart && isLiterStart)
                    {
                        return Colors.LimeGreen;//机器启动，炉子启动，升料机启动则显示绿色
                    }
                    else
                    {
                        return Colors.Orange;//机器启动，炉子或者升料机关闭则显示黄色
                    }
                }
                else
                {
                    return Colors.Red;//机器关闭则显示红色
                }
            }
            else
            {
                return Colors.DarkGray;
            }

        }

        public Color furnaceStatus()
        {
            //炉子状态
            if (_furnaceStartusQuality == 192)
            {
                if (isFurnaceStart)
                {
                    return Colors.LimeGreen;//炉子开启则显示绿色
                }
                else
                {
                    return Colors.Red;//炉子关闭则显示红色
                }
            }
            else
            {
                return Colors.DarkGray;
            }
        }

        public Color literStatus()
        {
            //升料机状态
            if (_literStartusQuality == 192)
            {
                if (isLiterStart)
                {
                    return Colors.LimeGreen;//升料机开启则显示绿色
                }
                else
                {
                    return Colors.Red;//升料机关闭则显示红色
                }
            }
            else
            {
                return Colors.DarkGray;
            }
        }

        public Color alarmStatus()
        {
            //报警状态
            if (_alarmStatusQuality == 192)
            {
                if (isAlarm)
                {
                    return Colors.Red;//有报警则显示红色
                }
                else
                {
                    return Colors.DarkGray;//无报警则显示绿色
                }
            }
            else
            {
                return Colors.DarkGray;
            }
        }
    }
}
