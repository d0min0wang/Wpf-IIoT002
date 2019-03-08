using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel;

namespace Wpf_IIoT002
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //初始化客户端
        private OPCClientWrapper opcClient = new OPCClientWrapper();
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            BindingInit();
        }

        /// <summary>
        /// 初始化数据绑定
        /// </summary>
        private void BindingInit()
        {
            //研发二楼车间
            DG01Status.DataContext = machinesFlags.DG01Flag;
            DY03Status.DataContext = machinesFlags.DY03Flag;
            DY02Status.DataContext = machinesFlags.DY02Flag;
            DY01Status.DataContext = machinesFlags.DY01Flag;
            SG01Status.DataContext = machinesFlags.SG01Flag;
            SG02Status.DataContext = machinesFlags.SG02Flag;
            SG03Status.DataContext = machinesFlags.SG03Flag;
            SE11Status.DataContext = machinesFlags.SE11Flag;
            SE14Status.DataContext = machinesFlags.SE14Flag;
            SY01Status.DataContext = machinesFlags.SY01Flag;
            //研发二楼洁净车间
            DE03Status.DataContext = machinesFlags.DE03Flag;
            DE02Status.DataContext = machinesFlags.DE02Flag;
            DE01Status.DataContext = machinesFlags.DE01Flag;
            SE08Status.DataContext = machinesFlags.SE08Flag;
            SE07Status.DataContext = machinesFlags.SE07Flag;
            SE06Status.DataContext = machinesFlags.SE06Flag;
            SE05Status.DataContext = machinesFlags.SE05Flag;
            SE04Status.DataContext = machinesFlags.SE04Flag;
            SE03Status.DataContext = machinesFlags.SE03Flag;
            SE02Status.DataContext = machinesFlags.SE02Flag;
            SE01Status.DataContext = machinesFlags.SE01Flag;
            //研发一楼车间
            DF20Status.DataContext = machinesFlags.DF20Flag;
            DF18Status.DataContext = machinesFlags.DF18Flag;
            DE12Status.DataContext = machinesFlags.DE12Flag;
            DE11Status.DataContext = machinesFlags.DE11Flag;
            SM02Status.DataContext = machinesFlags.SM02Flag;
            SM01Status.DataContext = machinesFlags.SM01Flag;
            SE12Status.DataContext = machinesFlags.SE12Flag;
            SR02Status.DataContext = machinesFlags.SR02Flag;
            SR01Status.DataContext = machinesFlags.SR01Flag;
            DF21Status.DataContext = machinesFlags.DF21Flag;
        }

        /// <summary>
        /// OPC客户端初始化函数
        /// </summary>
        private async void OpcClientInit()
        {
            opcClient.Init("192.168.0.130", "Kepware.KEPServerEX.V6");
            //添加点位变化事件回调
            opcClient.OpcDataChangedEvent += new OPCDataChangedHandler(OpcClient_OpcDataChangedEvent);
            //添加监视点位
            machineItems MachineItems = new machineItems();
            await Task.Run(() =>
            {
                foreach (KeyValuePair<string, int> keyValuePair in MachineItems.MachineFlagDict)
                {
                     opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value);
                }
            });
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.机器运行标志", 2901);
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.炉子电源开关", 2902);
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.升料机开关", 2903);
        }

        private void OpcClient_OpcDataChangedEvent(List<OPCChangeModel> list)
        {
            //OPC值变化监视事件处理函数
            foreach (OPCChangeModel model in list)
            {
                //switch(model.Index)
                //{
                //    case 2901:
                //        machinesFlags.SR01Flag.MachineStartusQuality = model.Quality;
                //        machinesFlags.SR01Flag.IsMachineStart = (Boolean)model.Value;
                //        break;
                //    case 2902:
                //        machinesFlags.SR01Flag.FurnaceStartusQuality = model.Quality;
                //        machinesFlags.SR01Flag.IsFurnaceStart = (Boolean)model.Value;
                //        break;
                //    case 2903:
                //        machinesFlags.SR01Flag.LiterStartusQuality = model.Quality;
                //        machinesFlags.SR01Flag.IsLiterStart = (Boolean)model.Value;
                //        break;
                //    case 2904:
                //        machinesFlags.SR01Flag.AlarmStatusQuality = model.Quality;
                //        machinesFlags.SR01Flag.IsAlarm = (Boolean)model.Value;
                //        break;
                //}
                switch(model.Index/100)
                {
                    case 29:
                        MachineFlagSet(machinesFlags.SR01Flag, model, model.Index);
                        break;
                }
            }
            //label184.Text = machinesFlags.SR01Flag.MachineStatus.ToString();
            //MachineFlagSet(machinesFlags.SR01Flag, model);
        }

        private void MachineFlagSet(machineFlag flag,OPCChangeModel model,int index)
        {
            switch (index%100)
            {
                //MachineFlagSet(machinesFlags.SR01Flag, model);
                case 1:
                    flag.MachineStartusQuality = model.Quality;
                    flag.IsMachineStart = (Boolean)model.Value;
                    break;
                case 2:
                    flag.FurnaceStartusQuality = model.Quality;
                    flag.IsFurnaceStart = (Boolean)model.Value;
                    break;
                case 3:
                    flag.LiterStartusQuality = model.Quality;
                    flag.IsLiterStart = (Boolean)model.Value;
                    break;
                case 4:
                    flag.AlarmStatusQuality = model.Quality;
                    flag.IsAlarm = (Boolean)model.Value;
                    break;
            }
        }

        #region Tooltip提示
        private void ImageDG01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDG01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY03_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY03_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDY01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE03_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE03_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG03_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSG03_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE11_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE11_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE14_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE14_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSY01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSY01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE08_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE08_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE07_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE07_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE06_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE06_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE05_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE05_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE04_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE04_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE03_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE03_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF18_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF18_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE12_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE12_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE11_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDE11_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSM02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSM02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSM01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSM01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSR02_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSR02_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSR01_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSR01_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF20_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF20_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF21_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageDF21_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE12_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE12_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            cancelTokenSource.Cancel();
            opcClient.Disconnect();
        }
    }
}
