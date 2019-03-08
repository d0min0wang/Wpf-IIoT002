using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using OPCAutomation;
using System.ComponentModel;

namespace Wpf_IIoT002
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //OPCHelper oPCHelper;
        //初始化客户端
        private OPCClientWrapper opcClient = new OPCClientWrapper();

        //private machinesFlags MachinesFlags = new machinesFlags();

        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            SR01Status.DataContext = machinesFlags.SR01Flag;

            //opcClient.Init("192.168.0.130", "Kepware.KEPServerEX.V6");
            ////添加点位变化事件回调
            //opcClient.OpcDataChangedEvent += new OPCDataChangedHandler(OpcClient_OpcDataChangedEvent);
            ////添加监视点位
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.机器运行标志",1001);
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.炉子电源开关", 1002);
            //opcClient.MonitorOPCItem("研发楼一楼车间SR01.#01.状态.升料机开关", 1003);

        }

        private void OpcClient_OpcDataChangedEvent(List<OPCChangeModel> list)
        {
            //OPC值变化监视事件处理函数
            foreach (OPCChangeModel model in list)
            {
                switch(model.Index)
                {
                    case 1001:
                        machinesFlags.SR01Flag.MachineStartusQuality = model.Quality;
                        machinesFlags.SR01Flag.IsMachineStart =(Boolean)model.Value;
                        break;
                    case 1002:
                        machinesFlags.SR01Flag.FurnaceStartusQuality = model.Quality;
                        machinesFlags.SR01Flag.IsFurnaceStart = (Boolean)model.Value;
                        break;
                    case 1003:
                        machinesFlags.SR01Flag.LiterStartusQuality = model.Quality;
                        machinesFlags.SR01Flag.IsLiterStart = (Boolean)model.Value;
                        break;
                }
            }
            label184.Text = machinesFlags.SR01Flag.MachineStatus.ToString();
        }

        #region
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
            //oPCHelper.Dispose();
            opcClient.Disconnect();
        }
    }
}
