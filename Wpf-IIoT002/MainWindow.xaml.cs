using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Wpf_IIoT002
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //初始化客户端
        private OPCClientWrapper opcClient = new OPCClientWrapper();
        //初始化Banner Model
        private BannerMessages bannerMessages = new BannerMessages();
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Windows加载时用异步方式连接OPC服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindingInit();
            Stopwatch watch = new Stopwatch();///用于计算时间
            watch.Start();
            await OpcClientInit();
            watch.Stop();
            GlobalVars.statusMessages.GuiLoadedTime = watch.ElapsedMilliseconds.ToString();
        }

        /// <summary>
        /// 初始化数据绑定函数
        /// </summary>
        private void BindingInit()
        {
            //Banner
            GridBanner.DataContext = GlobalVars.bannerMessages;
            //研发二楼车间
            DG01Status.DataContext = GlobalVars.DY04Flag;
            DY03Status.DataContext = GlobalVars.DY03Flag;
            DY02Status.DataContext = GlobalVars.DY02Flag;
            DY01Status.DataContext = GlobalVars.DY01Flag;
            SG01Status.DataContext = GlobalVars.SG01Flag;
            SG02Status.DataContext = GlobalVars.SG02Flag;
            SG03Status.DataContext = GlobalVars.SG03Flag;
            SE11Status.DataContext = GlobalVars.SE11Flag;
            SE14Status.DataContext = GlobalVars.SE14Flag;
            SY01Status.DataContext = GlobalVars.SY01Flag;
            //研发二楼洁净车间
            DE03Status.DataContext = GlobalVars.DE03Flag;
            DE02Status.DataContext = GlobalVars.DE02Flag;
            DE01Status.DataContext = GlobalVars.DE01Flag;
            SE08Status.DataContext = GlobalVars.SE08Flag;
            SE07Status.DataContext = GlobalVars.SE07Flag;
            SE06Status.DataContext = GlobalVars.SE06Flag;
            SE05Status.DataContext = GlobalVars.SE05Flag;
            SE04Status.DataContext = GlobalVars.SE04Flag;
            SE03Status.DataContext = GlobalVars.SE03Flag;
            SE02Status.DataContext = GlobalVars.SE02Flag;
            SE01Status.DataContext = GlobalVars.SE01Flag;
            //研发一楼车间
            DF20Status.DataContext = GlobalVars.DF20Flag;
            DF18Status.DataContext = GlobalVars.DF18Flag;
            DE12Status.DataContext = GlobalVars.DE12Flag;
            DE11Status.DataContext = GlobalVars.DE11Flag;
            SM02Status.DataContext = GlobalVars.SM02Flag;
            SM01Status.DataContext = GlobalVars.SM01Flag;
            SE12Status.DataContext = GlobalVars.SE12Flag;
            SR02Status.DataContext = GlobalVars.SR02Flag;
            SR01Status.DataContext = GlobalVars.SR01Flag;
            DF21Status.DataContext = GlobalVars.DF21Flag;

            //机器状态
            label184.DataContext = GlobalVars.statusMessages;
            labelServerStatus.DataContext = GlobalVars.statusMessages;
        }

        /// <summary>
        /// OPC客户端初始化函数
        /// </summary>
        private async Task OpcClientInit()
        {
            opcClient.Init("192.168.0.130", "Kepware.KEPServerEX.V6");
            if (opcClient.IsOPCServerConnected())
            {
                GlobalVars.statusMessages.ServerStatusString = "已连接到主OPC服务器";
                //添加点位变化事件回调
                opcClient.OpcDataChangedEvent += new OPCDataChangedHandler(OpcClient_OpcDataChangedEvent);
                //添加监视点位
                machineItems MachineItems = new machineItems();
                ////await Task.Run(() =>
                ////{
                //    foreach (KeyValuePair<string, int> keyValuePair in MachineItems.getMachineFlagDict())
                //    {
                //    await Task.Run(() => { opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value); });
                //    }
                ////});
                await Task.Run(() =>
                    Parallel.ForEach(MachineItems.getMachineFlagDict(), keyValuePair =>
                    {
                        opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value);
                    }
                ));
                MachineItems.Dispose();
            }
            else
            {
                GlobalVars.statusMessages.ServerStatusString = "OPC服务器未连接";
            }
        }

        /// <summary>
        /// OPC数据变化响应事件
        /// </summary>
        /// <param name="list"></param>
        private void OpcClient_OpcDataChangedEvent(List<OPCChangeModel> list)
        {
            //Console.WriteLine("调用Method1的线程ID为：{0}", Thread.CurrentThread.ManagedThreadId);
            //OPC值变化监视事件处理函数
            foreach (OPCChangeModel model in list)
            {
                switch(model.Index/100)
                {
                    //研发楼二楼
                    case 0:
                        MachineFlagSet(GlobalVars.DY04Flag, model, model.Index);
                        break;
                    case 1:
                        MachineFlagSet(GlobalVars.DY03Flag, model, model.Index);
                        break;
                    case 2:
                        MachineFlagSet(GlobalVars.DY02Flag, model, model.Index);
                        break;
                    case 3:
                        MachineFlagSet(GlobalVars.DY01Flag, model, model.Index);
                        break;
                    case 4:
                        MachineFlagSet(GlobalVars.SG01Flag, model, model.Index);
                        break;
                    case 5:
                        MachineFlagSet(GlobalVars.SG02Flag, model, model.Index);
                        break;
                    case 6:
                        MachineFlagSet(GlobalVars.SG03Flag, model, model.Index);
                        break;                    
                    case 7:
                        MachineFlagSet(GlobalVars.SE14Flag, model, model.Index);
                        break;
                    case 8:
                        MachineFlagSet(GlobalVars.SE12Flag, model, model.Index);
                        break;
                    case 9:
                        MachineFlagSet(GlobalVars.SE11Flag, model, model.Index);
                        break;
                    case 10:
                        MachineFlagSet(GlobalVars.SY01Flag, model, model.Index);
                        break;
                    //研发二楼洁净车间
                    case 11:
                        MachineFlagSet(GlobalVars.DE03Flag, model, model.Index);
                        break;
                    case 12:
                        MachineFlagSet(GlobalVars.DE02Flag, model, model.Index);
                        break;
                    case 13:
                        MachineFlagSet(GlobalVars.DE01Flag, model, model.Index);
                        break;
                    case 14:
                        MachineFlagSet(GlobalVars.SE08Flag, model, model.Index);
                        break;
                    case 15:
                        MachineFlagSet(GlobalVars.SE07Flag, model, model.Index);
                        break;
                    case 16:
                        MachineFlagSet(GlobalVars.SE06Flag, model, model.Index);
                        break;
                    case 17:
                        MachineFlagSet(GlobalVars.SE05Flag, model, model.Index);
                        break;
                    case 18:
                        MachineFlagSet(GlobalVars.SE04Flag, model, model.Index);
                        break;
                    case 19:
                        MachineFlagSet(GlobalVars.SE03Flag, model, model.Index);
                        break;
                    case 20:
                        MachineFlagSet(GlobalVars.SE02Flag, model, model.Index);
                        break;
                    case 21:
                        MachineFlagSet(GlobalVars.SE01Flag, model, model.Index);
                        break;
                    //研发一楼车间
                    case 22:
                        MachineFlagSet(GlobalVars.DF20Flag, model, model.Index);
                        break;
                    case 23:
                        MachineFlagSet(GlobalVars.DF18Flag, model, model.Index);
                        break;
                    case 24:
                        MachineFlagSet(GlobalVars.DE12Flag, model, model.Index);
                        break;
                    case 25:
                        MachineFlagSet(GlobalVars.DE11Flag, model, model.Index);
                        break;
                    case 26:
                        MachineFlagSet(GlobalVars.SM02Flag, model, model.Index);
                        break;
                    case 27:
                        MachineFlagSet(GlobalVars.SM01Flag, model, model.Index);
                        break;
                    case 28:
                        MachineFlagSet(GlobalVars.SR02Flag, model, model.Index);
                        break;
                    case 29:
                        MachineFlagSet(GlobalVars.SR01Flag, model, model.Index);
                        break;
                    case 30:
                        MachineFlagSet(GlobalVars.DF21Flag, model, model.Index);
                        break;
                }
            }
            //label184.Text = machinesFlags.SR01Flag.MachineStatus.ToString();
        }

        /// <summary>
        /// 机器状态数据更新函数
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="model"></param>
        /// <param name="index"></param>
        private void MachineFlagSet(machineFlag flag,OPCChangeModel model,int index)
        {
            switch (index%100)
            {
                //MachineFlagSet(machinesFlags.SR01Flag, model);
                case 1://机器开机状态位
                    flag.MachineStartusQuality = model.Quality;
                    flag.IsMachineStart = Convert.ToBoolean(model.Value);
                    break;
                case 2://机器炉子状态位
                    flag.FurnaceStartusQuality = model.Quality;
                    flag.IsFurnaceStart = Convert.ToBoolean(model.Value);
                    break;
                case 3://机器升料机状态位
                    flag.LiterStartusQuality = model.Quality;
                    flag.IsLiterStart = Convert.ToBoolean(model.Value);
                    break;
                case 4://机器报警状态位
                    flag.AlarmStatusQuality = model.Quality;
                    flag.IsAlarm = Convert.ToBoolean(model.Value);
                    break;
                case 5://烤模时间设定
                    flag.FlareMoldTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 6://浸料时间设定
                    flag.DipingMaterialTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 7://烤料时间设定
                    flag.FlareMaterialTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 8://冷却时间设定
                    flag.CoolingTimeSetting = Convert.ToInt32(model.Value);
                    break;
            }
            BannerMessageSet(flag, index / 100);
        }

        /// <summary>
        /// Banner数据更新函数
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="index"></param>
        private void BannerMessageSet(machineFlag flag,int index)
        {
            //开机数量
            GlobalVars.executing[index] = flag.getMachineStart();
            GlobalVars.bannerMessages.Executing = GlobalVars.executing.Sum().ToString();
            //停机数量
            GlobalVars.bannerMessages.NoExecuting = (31 - GlobalVars.executing.Sum()).ToString();
            //开炉做管数量
            GlobalVars.executingAndMaking[index] = flag.getMaking();
            GlobalVars.bannerMessages.ExecutingAndMaking = GlobalVars.executingAndMaking.Sum().ToString();
            //开炉空转数量
            GlobalVars.executingAndStartFurnace[index] = flag.getIdling();
            GlobalVars.bannerMessages.ExecutingAndStartFurnace = GlobalVars.executingAndStartFurnace.Sum().ToString();
            //不开炉空转数量
            GlobalVars.executingAndStopFurnace[index] = flag.getIdlingAndFurnaceStop();
            GlobalVars.bannerMessages.ExecutingAndStopFurnace = GlobalVars.executingAndStopFurnace.Sum().ToString();
            //报警数量
            GlobalVars.alarming[index] = flag.getAlarm();
            GlobalVars.bannerMessages.Alarming = GlobalVars.alarming.Sum().ToString();
            //开机率
            if (GlobalVars.executing.Sum() > 0)
            {
                GlobalVars.bannerMessages.UtilizationRatio = (int)Math.Round((double)(GlobalVars.executing.Sum()) * 100.0 / 31.0, 0);
                GlobalVars.bannerMessages.UtilizationRatioStr = ((int)Math.Round((double)(GlobalVars.executing.Sum()) * 100.0 / 31.0, 0)).ToString() + "%";
            }
            //做管率
            if (GlobalVars.executingAndMaking.Sum() > 0)
            {
                GlobalVars.bannerMessages.MakingRatio = (int)Math.Round((double)(GlobalVars.executingAndMaking.Sum()) * 100.0 / 31.0, 1);
                GlobalVars.bannerMessages.MakingRatioStr = ((int)Math.Round((double)(GlobalVars.executingAndMaking.Sum()) * 100.0 / 31.0, 1)) + "%";
            }
        }

        #region Tooltip提示
        private void ImageDY04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DY04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DY04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DY04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DY04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DY04Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DY04Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DY04);

            //}
            GlobalVars.DY04Flag.Toolstip = str;
        }


        private void ImageDY03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DY03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DY03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DY03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DY03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DY03Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DY03Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DY03);

            //}
            GlobalVars.DY03Flag.Toolstip = str;
        }


        private void ImageDY02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DY02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DY02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DY02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DY02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DY02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DY02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DY02);

            //}
            GlobalVars.DY02Flag.Toolstip = str;
        }


        private void ImageDY01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DY01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DY01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DY01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DY01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DY01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DY01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DY01);

            //}
            GlobalVars.DY01Flag.Toolstip = str;
        }


        private void ImageDE03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DE03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DE03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DE03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DE03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DE03Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DE03Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DE03);

            //}
            GlobalVars.DE03Flag.Toolstip = str;
        }


        private void ImageDE02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DE02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DE02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DE02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DE02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DE02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DE02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DE02);

            //}
            GlobalVars.DE02Flag.Toolstip = str;
        }


        private void ImageDE01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DE01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DE01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DE01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DE01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DE01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DE01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DE01);

            //}
            GlobalVars.DE01Flag.Toolstip = str;
        }


        private void ImageSG01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SG01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SG01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SG01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SG01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SG01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SG01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SG01);

            //}
            GlobalVars.SG01Flag.Toolstip = str;
        }


        private void ImageSG02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SG02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SG02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SG02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SG02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SG02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SG02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SG02);

            //}
            GlobalVars.SG02Flag.Toolstip = str;
        }


        private void ImageSG03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SG03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SG03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SG03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SG03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SG03Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SG03Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SG03);

            //}
            GlobalVars.SG03Flag.Toolstip = str;
        }


        private void ImageSE11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE11Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE11Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE11);

            //}
            GlobalVars.SE11Flag.Toolstip = str;
        }


        private void ImageSE14_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE14Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE14Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE14Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE14Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE14Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE14Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE14);

            //}
            GlobalVars.SE14Flag.Toolstip = str;
        }


        private void ImageSY01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SY01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SY01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SY01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SY01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SY01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SY01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SY01);

            //}
            GlobalVars.SY01Flag.Toolstip = str;
        }


        private void ImageSE08_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE08Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE08Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE08Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE08Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE08Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE08Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE08);

            //}
            GlobalVars.SE08Flag.Toolstip = str;
        }

        private void ImageSE07_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE07Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE07Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE07Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE07Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE07Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE07Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE07);

            //}
            GlobalVars.SE07Flag.Toolstip = str;
        }


        private void ImageSE06_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE06Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE06Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE06Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE06Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE06Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE06Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE06);

            //}
            GlobalVars.SE06Flag.Toolstip = str;
        }


        private void ImageSE05_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE05Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE05Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE05Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE05Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE05Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE05Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE05);

            //}
            GlobalVars.SE05Flag.Toolstip = str;
        }


        private void ImageSE04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE04Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE04Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE04);

            //}
            GlobalVars.SE04Flag.Toolstip = str;
        }


        private void ImageSE03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE03Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE03Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE03);

            //}
            GlobalVars.SE03Flag.Toolstip = str;
        }


        private void ImageSE02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE02);

            //}
            GlobalVars.SE02Flag.Toolstip = str;
        }


        private void ImageSE01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE01);

            //}
            GlobalVars.SE01Flag.Toolstip = str;
        }


        private void ImageDF18_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF18Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF18Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF18Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF18Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF18Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DF18Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DF18);

            //}
            GlobalVars.DF18Flag.Toolstip = str;
        }


        private void ImageDE12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DE12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DE12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DE12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DE12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DE12Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DE12Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DE12);

            //}
            GlobalVars.DE12Flag.Toolstip = str;
        }


        private void ImageDE11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DE11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DE11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DE11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DE11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DE11Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DE11Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DE11);

            //}
            GlobalVars.DE11Flag.Toolstip = str;
        }


        private void ImageSM02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SM02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SM02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SM02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SM02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SM02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SM02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SM02);

            //}
            GlobalVars.SM02Flag.Toolstip = str;
        }


        private void ImageSM01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SM01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SM01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SM01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SM01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SM01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SM01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SM01);

            //}
            GlobalVars.SM01Flag.Toolstip = str;
        }


        private void ImageSR02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SR02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SR02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SR02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SR02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SR02Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SR02Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SR02);

            //}
            GlobalVars.SR02Flag.Toolstip = str;
        }


        private void ImageSR01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SR01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SR01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SR01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SR01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SR01Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SR01Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SR01);

            //}
            GlobalVars.SR01Flag.Toolstip = str;
        }


        private void ImageDF20_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF20Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF20Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF20Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF20Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF20Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DF20Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DF20);

            //}
            GlobalVars.DF20Flag.Toolstip = str;
        }


        private void ImageDF21_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF21Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF21Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF21Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF21Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF21Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.DF21Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.DF21);

            //}
            GlobalVars.DF21Flag.Toolstip = str;
        }


        private void ImageSE12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE12Flag.BrushOilTimeSetting.ToString() + "\n";
            //if (GlobalVars.SE12Flag.getAlarm() == 1)
            //{
            //    str += "报警信息：" + "\n";
            //    str += GetAlarmMessages(MachineIndex.SE12);

            //}
            GlobalVars.SE12Flag.Toolstip = str;
        }

        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            cancelTokenSource.Cancel();
            opcClient.Disconnect();
        }

    }
}
