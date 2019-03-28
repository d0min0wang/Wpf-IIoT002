using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Wpf_IIoT002
{
    public class machineItems:IDisposable
    {
        //机器状态位字典
        private Dictionary<string, int> _machineFlagDict=new Dictionary<string, int>();

        //机器状态位置类的构造函数
        public machineItems()
        {
            //研发楼二楼车间
            //DY04 Index:0
            AddStatusItems("研发楼二楼车间", "S7-1200-DY", "DY04", (int)MachineIndex.DY04);
            //DY03 Index:1
            AddStatusItems("研发楼二楼车间", "S7-1200-DY", "DY03", (int)MachineIndex.DY03);
            //DY02 Index:2
            AddStatusItems("研发楼二楼车间", "S7-1200-DY", "DY02", (int)MachineIndex.DY02);
            //DY01 Index:3
            AddStatusItems("研发楼二楼车间", "S7-1200-DY", "DY01", (int)MachineIndex.DY01);
            //SG01 Index:4
            AddStatusItems("研发楼二楼车间", "S7-200", "SG01", (int)MachineIndex.SG01);
            //SG02 Index:5
            AddStatusItems("研发楼二楼车间", "S7-200", "SG02", (int)MachineIndex.SG02);
            //SG03 Index:6
            AddStatusItems("研发楼二楼车间", "S7-200", "SG03", (int)MachineIndex.SG03);
            //SE14 Index:7
            AddStatusItems("研发楼二楼车间", "S7-200", "SE14", (int)MachineIndex.SE14);
            //SE12 Index:8
            AddStatusItems("研发楼二楼车间", "S7-200", "SE12", (int)MachineIndex.SE12);
            //SE11 Index:9
            AddStatusItems("研发楼二楼车间", "S7-200", "SE11", (int)MachineIndex.SE11);
            //SY01 Index:10
            AddStatusItems("研发楼二楼车间", "S7-200", "SY01", (int)MachineIndex.SY01);
            //研发二楼洁净车间
            //DE03 Index:11
            AddStatusItems("研发楼二楼洁净车间", "S7-1200-2", "DE03", (int)MachineIndex.DE03);
            //DE02 Index:12
            AddStatusItems("研发楼二楼洁净车间", "S7-1200-2", "DE02", (int)MachineIndex.DE02);
            //DE01 Index:13
            AddStatusItems("研发楼二楼洁净车间", "S7-1200-2", "DE01", (int)MachineIndex.DE01);
            //SE08 Index:14
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE08", (int)MachineIndex.SE08);
            //SE07 Index:15
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE07", (int)MachineIndex.SE07);
            //SE06 Index:16
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE06", (int)MachineIndex.SE06);
            //SE05 Index:17
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE05", (int)MachineIndex.SE05);
            //SE04 Index:18
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE04", (int)MachineIndex.SE04);
            //SE03 Index:19
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE03", (int)MachineIndex.SE03);
            //SE02 Index:20
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE02", (int)MachineIndex.SE02);
            //SE01 Index:21
            AddStatusItems("研发楼二楼洁净车间", "S7-200", "SE01", (int)MachineIndex.SE01);
            //研发一楼车间
            //DF20 Index:22
            AddStatusItems("研发楼一楼车间", "S7-1200-2-DF", "DF20", (int)MachineIndex.DF20);
            //DF18 Index:23
            AddStatusItems("研发楼一楼车间", "S7-200", "DF18", (int)MachineIndex.DF18);
            //DE12 Index:24
            AddStatusItems("研发楼一楼车间", "S7-200", "DE12", (int)MachineIndex.DE12);
            //DE11 Index:25
            AddStatusItems("研发楼一楼车间", "S7-200", "DE11", (int)MachineIndex.DE11);
            //SM02 Index:26
            AddStatusItems("研发楼一楼车间", "S7-200", "SM02", (int)MachineIndex.SM02);
            //SM01 Index:27
            AddStatusItems("研发楼一楼车间", "S7-200", "SM01", (int)MachineIndex.SM01);
            //SR02 Index:28
            AddStatusItems("研发楼一楼车间", "S7-1200", "SR02", (int)MachineIndex.SR02);
            //SR01 Index:29
            AddStatusItems("研发楼一楼车间", "S7-1200-SR01", "SR01", (int)MachineIndex.SR01);
            //DM01 Index:30
            AddStatusItems("研发楼一楼车间", "S7-1200-DM", "DM01", (int)MachineIndex.DM01);
            //DF21 Index:31
            AddStatusItems("研发楼一楼车间", "S7-1200-2-DF", "DF21", (int)MachineIndex.DF21);
        }

        private void AddStatusItems(string workshop, string plcType, string machineNo, int index)
        {
            Type type = null;
            //遍历Enum获取并添加所有报警信息
            switch (plcType)
            {
                case "S7-200":
                    type = typeof(S7200StatusInfo);
                    break;
                case "S7-1200":
                    type = typeof(S71200StatusInfo);
                    break;
                case "S7-1200-SR01":
                    type = typeof(S71200StatusInfoSR01);
                    break;
                case "S7-1200-1":
                    type = typeof(S71200StatusInfoFor1);
                    break;
                case "S7-1200-2":
                    type = typeof(S71200StatusInfoFor2);
                    break;
                case "S7-1200-2-DF":
                    type = typeof(S71200StatusInfoFor2DF);
                    break;
                case "S7-1200-DY":
                    type = typeof(S71200StatusInfoDY);
                    break;
                case "S7-1200-DM":
                    type = typeof(S71200StatusInfoDM);
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
                _handleName = workshop + machineNo + "." + _description;
                _machineFlagDict.Add(_handleName, index * 100 + (int)x.GetValue(null));
            }
        }

        public Dictionary<string, int> getMachineFlagDict()
        {
            return _machineFlagDict;
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
                _machineFlagDict = null;

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~machineItems() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
