using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wpf_IIoT002
{
    public class GlobalVars
    {
        //研发二楼车间
        public static machineFlag DY04Flag = new machineFlag();
        public static machineFlag DY03Flag = new machineFlag();
        public static machineFlag DY02Flag = new machineFlag();
        public static machineFlag DY01Flag = new machineFlag();
        public static machineFlag SG01Flag = new machineFlag();
        public static machineFlag SG02Flag = new machineFlag();
        public static machineFlag SG03Flag = new machineFlag();
        public static machineFlag SE14Flag = new machineFlag();
        public static machineFlag SE12Flag = new machineFlag();
        public static machineFlag SE11Flag = new machineFlag();
        public static machineFlag SY01Flag = new machineFlag();
        //研发二楼洁净车间
        public static machineFlag DE03Flag = new machineFlag();
        public static machineFlag DE02Flag = new machineFlag();
        public static machineFlag DE01Flag = new machineFlag();
        public static machineFlag SE08Flag = new machineFlag();
        public static machineFlag SE07Flag = new machineFlag();
        public static machineFlag SE06Flag = new machineFlag();
        public static machineFlag SE05Flag = new machineFlag();
        public static machineFlag SE04Flag = new machineFlag();
        public static machineFlag SE03Flag = new machineFlag();
        public static machineFlag SE02Flag = new machineFlag();
        public static machineFlag SE01Flag = new machineFlag();
        //研发一楼车间
        public static machineFlag DF20Flag = new machineFlag();
        public static machineFlag DF18Flag = new machineFlag();
        public static machineFlag DE12Flag = new machineFlag();
        public static machineFlag DE11Flag = new machineFlag();
        public static machineFlag SM02Flag = new machineFlag();
        public static machineFlag SM01Flag = new machineFlag();
        public static machineFlag SR02Flag = new machineFlag();
        public static machineFlag SR01Flag = new machineFlag();
        public static machineFlag DM01Flag = new machineFlag();
        public static machineFlag DF21Flag = new machineFlag();

        //建立全局静态变量保存Banner信息
        public static BannerMessages bannerMessages = new BannerMessages();

        //建立全局静态变量以保存报警信息       
        public static List<AlarmMessage> alarmMessages = new List<AlarmMessage>();

        //建立全局变量保存被触发的报警信息List
        public static ObservableCollection<AlarmMessage> AlarmMessagesDS = new ObservableCollection<AlarmMessage>();

        //建立全局变量保存界面加载和服务器状态信息
        public static StatusMessages statusMessages = new StatusMessages();

        //建立全局变量保存每个机器的可计算信息
        //int _quantityOfMachine = 33;
        public static int[] executing = new int[33];
        public static int[] executingAndMaking = new int[33];
        public static int[] executingAndStartFurnace = new int[33];
        public static int[] executingAndStopFurnace = new int[33];
        public static int[] alarming = new int[33];
    }
}
