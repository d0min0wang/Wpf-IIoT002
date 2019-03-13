using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Reflection;

namespace Wpf_IIoT002
{
    public class AlarmItems : IDisposable
    {
        //机器报警位字典
        private Dictionary<string, int> _alarmFlagDict = new Dictionary<string, int>();

        public AlarmItems()
        {
            //研发楼二楼车间
            //DY04 Index:0
            AddAlarmItems("研发楼二楼车间", "S7-200", "DY","04", (int)MachineIndex.DY04);
            //DY03 Index:1
            AddAlarmItems("研发楼二楼车间", "S7-200", "DY","03", (int)MachineIndex.DY03);
            //DY02 Index:2
            AddAlarmItems("研发楼二楼车间", "S7-200", "DY","02", (int)MachineIndex.DY02);
            //DY01 Index:3
            AddAlarmItems("研发楼二楼车间", "S7-200", "DY","01", (int)MachineIndex.DY01);
            //SG01 Index:4
            AddAlarmItems("研发楼二楼车间", "S7-200", "SG","01", (int)MachineIndex.SG01);
            //SG02 Index:5
            AddAlarmItems("研发楼二楼车间", "S7-200", "SG","02", (int)MachineIndex.SG02);
            //SG03 Index:6
            AddAlarmItems("研发楼二楼车间", "S7-200", "SG","03", (int)MachineIndex.SG03);
            //SE14 Index:7
            AddAlarmItems("研发楼二楼车间", "S7-200", "SE","14", (int)MachineIndex.SE14);
            //SE12 Index:8
            AddAlarmItems("研发楼二楼车间", "S7-200", "SE","12", (int)MachineIndex.SE12);
            //SE11 Index:9
            AddAlarmItems("研发楼二楼车间", "S7-200", "SE","11", (int)MachineIndex.SE11);
            //SY01 Index:10
            AddAlarmItems("研发楼二楼车间", "S7-200", "SY","01", (int)MachineIndex.SY01);
            //研发二楼洁净车间
            //DE03 Index:11
            AddAlarmItems("研发楼二楼洁净车间", "S7-1200-2", "DE","03", (int)MachineIndex.DE03);
            //DE02 Index:12
            AddAlarmItems("研发楼二楼洁净车间", "S7-1200-2", "DE","02", (int)MachineIndex.DE02);
            //DE01 Index:13
            AddAlarmItems("研发楼二楼洁净车间", "S7-1200-2", "DE","01", (int)MachineIndex.DE01);
            //SE08 Index:14
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","08", (int)MachineIndex.SE08);
            //SE07 Index:15
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","07", (int)MachineIndex.SE07);
            //SE06 Index:16
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","06", (int)MachineIndex.SE06);
            //SE05 Index:17
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","05", (int)MachineIndex.SE05);
            //SE04 Index:18
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","04", (int)MachineIndex.SE04);
            //SE03 Index:19
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","03", (int)MachineIndex.SE03);
            //SE02 Index:20
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","02", (int)MachineIndex.SE02);
            //SE01 Index:21
            AddAlarmItems("研发楼二楼洁净车间", "S7-200", "SE","01", (int)MachineIndex.SE01);
            //研发一楼车间
            //DF20 Index:22
            AddAlarmItems("研发楼一楼车间", "S7-1200-2-DF", "DF","20", (int)MachineIndex.DF20);
            //DF18 Index:23
            AddAlarmItems("研发楼一楼车间", "S7-200", "DF","18", (int)MachineIndex.DF18);
            //DE12 Index:24
            AddAlarmItems("研发楼一楼车间", "S7-200", "DE","12", (int)MachineIndex.DE12);
            //DE11 Index:25
            AddAlarmItems("研发楼一楼车间", "S7-200", "DE","11", (int)MachineIndex.DE11);
            //SM02 Index:26
            AddAlarmItems("研发楼一楼车间", "S7-200", "SM","02", (int)MachineIndex.SM02);
            //SM01 Index:27
            AddAlarmItems("研发楼一楼车间", "S7-200", "SM","01", (int)MachineIndex.SM01);
            //SR02 Index:28
            AddAlarmItems("研发楼一楼车间", "S7-1200", "SR","02", (int)MachineIndex.SR02);
            //SR01 Index:29
            AddAlarmItems("研发楼一楼车间", "S7-1200", "SR","01", (int)MachineIndex.SR01);
            ////DM01 Index:30
            //AddAlarmItems("研发楼一楼车间", "S7-1200-2", "DM01", (int)MachineIndex.DM01);
            //DF21 Index:31
            AddAlarmItems("研发楼一楼车间", "S7-1200-2-DF", "DF","21", (int)MachineIndex.DF21);
        }


        private void AddAlarmItems(string workshop,string plcType, string machineType, string machineNo,  int index)
        {
            Type type = null;
            //遍历Enum获取并添加所有报警信息
            switch (machineType)
            {
                case "DF":
                    type = typeof(AlarmInfoOfDF);
                    break;
                case "SF":
                    type = typeof(AlarmInfoOfSF);
                    break;
                case "SE":
                    type = typeof(AlarmInfoOfSE);
                    break;
            }


            foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string _handleName;
                string _description = string.Empty;
                object[] array = x.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    _description = ((DescriptionAttribute)array[0]).Description;
                }
                else
                {
                    _description = ""; //none description,set empty
                }
                _handleName = workshop +machineType+ machineNo + "." + ".报警信息." + _description;
                _alarmFlagDict.Add(_handleName, index * 10000 + (int)x.GetValue(null));
                //初始化报警信息List
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessage.MachineNo = machineNo;
                alarmMessage.Index = index * 10000 + (int)x.GetValue(null);
                alarmMessage.AlarmMessages = _description;
                GlobalVars.alarmMessages.Add(alarmMessage);
            }
        }

        public Dictionary<string, int> getAlarmFlagDict()
        {
            return _alarmFlagDict;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                _alarmFlagDict = null;
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AlarmItems() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
