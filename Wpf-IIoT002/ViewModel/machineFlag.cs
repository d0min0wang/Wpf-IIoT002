using System;
using System.ComponentModel;

namespace Wpf_IIoT002
{
    public class machineFlag: INotifyPropertyChanged
    {
        //开机状态位
        private TagQuality _machineStartusQuality;
        public TagQuality MachineStartusQuality
        {
            get { return _machineStartusQuality; }
            set
            {
                _machineStartusQuality = value;
                NotifyPropertyChanged("MachineStartusQuality");
            }
        }
        private Boolean _isMachineStart;
        public Boolean IsMachineStart
        {
            get { return _isMachineStart; }
            set
            {
                _isMachineStart = value;
                //NotifyPropertyChanged("IsMachineStart");
                NotifyPropertyChanged("machineStatus");
            }
        }

        //炉子状态位
        private TagQuality _furnaceStartusQuality;
        public TagQuality FurnaceStartusQuality
        {
            get { return _furnaceStartusQuality; }
            set
            {
                _furnaceStartusQuality = value;
                NotifyPropertyChanged("FurnaceStartusQuality");
            }
        }
        private Boolean _isFurnaceStart;
        public Boolean IsFurnaceStart
        {
            get { return _isFurnaceStart; }
            set
            {
                _isFurnaceStart = value;
                //NotifyPropertyChanged("IsFurnaceStart");
                NotifyPropertyChanged("furnaceStatus");
            }
        }

        //升料机状态位
        private TagQuality _literStartusQuality;
        public TagQuality LiterStartusQuality
        {
            get { return _literStartusQuality; }
            set
            {
                _literStartusQuality = value;
                NotifyPropertyChanged("LiterStartusQuality");
            }
        }
        private Boolean _isLiterStart;
        public Boolean IsLiterStart
        {
            get { return _isLiterStart; }
            set
            {
                _isLiterStart = value;
                //NotifyPropertyChanged("IsLiterStart");
                NotifyPropertyChanged("literStatus");
            }
        }

        //报警状态位
        private TagQuality _alarmStatusQuality;
        public TagQuality AlarmStatusQuality
        {
            get { return _alarmStatusQuality; }
            set
            {
                _alarmStatusQuality = value;
                NotifyPropertyChanged("AlarmStatusQuality");
            }
        }
        private Boolean _isAlarm;
        public Boolean IsAlarm
        {
            get { return _isAlarm; }
            set
            {
                _isAlarm = value;
                //NotifyPropertyChanged("IsAlarm");
                NotifyPropertyChanged("alarmStatus");
            }
        }

        private int flareMoldTimeSetting;//烤模时间设定
        private int dippingMaterialTimeSetting;//浸料时间设定
        private int flareMaterialTimeSetting;//烤料时间设定
        private int coolingTimeSetting;//冷却时间设定
        private int brushOilTimeSetting;//刷油时间设定

        public int FlareMoldTimeSetting
        {
            get { return flareMoldTimeSetting; }
            set {
                flareMoldTimeSetting = value;
                NotifyPropertyChanged("FlareMoldTimeSetting");
            }
        }

        public int DipingMaterialTimeSetting
        {
            get { return dippingMaterialTimeSetting; }
            set
            {
                dippingMaterialTimeSetting = value;
                NotifyPropertyChanged("DipingMaterialTimeSetting");
            }
        }

        public int FlareMaterialTimeSetting
        {
            get { return flareMaterialTimeSetting; }
            set
            {
                flareMaterialTimeSetting = value;
                NotifyPropertyChanged("FlareMaterialTimeSetting");
            }
        }

        public int CoolingTimeSetting
        {
            get { return coolingTimeSetting; }
            set
            {
                coolingTimeSetting = value;
                NotifyPropertyChanged("CoolingTimeSetting");
            }
        }

        public int BrushOilTimeSetting
        {
            get { return brushOilTimeSetting; }
            set
            {
                brushOilTimeSetting = value;
                NotifyPropertyChanged("BrushOilTimeSetting");
            }
        }



        //开机
        public int getMachineStart()
        {
            if (_isMachineStart)
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
            if (_isMachineStart && _isFurnaceStart && _isLiterStart)
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
            if (_isMachineStart && _isFurnaceStart && !_isLiterStart)
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
            if (_isMachineStart && !_isFurnaceStart && !_isLiterStart)
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
            if (!_isMachineStart)
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
            if (_isAlarm)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public int machineStatus()
        {
            //机器状态
            if (_machineStartusQuality == TagQuality.Good)
            {
                if (_isMachineStart)
                {
                    if (_isFurnaceStart && _isLiterStart)
                    {
                        return 2;//机器启动，炉子启动，升料机启动则显示绿色
                    }
                    else
                    {
                        return 3;//机器启动，炉子或者升料机关闭则显示黄色
                    }
                }
                else
                {
                    return 1;//机器关闭则显示红色
                }
            }
            else
            {
                return 0;//掉线则显示灰色
            }

        }

        public int furnaceStatus()
        {
            //炉子状态
            if (_furnaceStartusQuality == TagQuality.Good)
            {
                if (_isFurnaceStart)
                {
                    return 2;//炉子开启则显示绿色
                }
                else
                {
                    return 1;//炉子关闭则显示红色
                }
            }
            else
            {
                return 0;
            }
        }

        public int literStatus()
        {
            //升料机状态
            if (_literStartusQuality == TagQuality.Good)
            {
                if (_isLiterStart)
                {
                    return 2;//升料机开启则显示绿色
                }
                else
                {
                    return 1;//升料机关闭则显示红色
                }
            }
            else
            {
                return 0;
            }
        }

        public int alarmStatus()
        {
            //报警状态
            if (_alarmStatusQuality == TagQuality.Good)
            {
                if (_isAlarm)
                {
                    return 1;//有报警则显示红色
                }
                else
                {
                    return 2;//无报警则显示绿色
                }
            }
            else
            {
                return 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // NotifyPropertyChanged will raise the PropertyChanged event passing the
        // source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
