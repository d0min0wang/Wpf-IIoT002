using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using OPCAutomation;

namespace Wpf_IIoT002
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        kepServerStruct KepServerMain = new kepServerStruct();
        kepServerStruct KepServerStructDF = new kepServerStruct();
        kepServerStruct KepServerStructDFAlarm = new kepServerStruct();
        kepServerStruct KepServerStructSF = new kepServerStruct();
        kepServerStruct KepServerStructSFAlarm = new kepServerStruct();

        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region OPC服务器连接函数
        /// <summary>
        /// OPC服务器连接函数
        /// </summary>
        private void opcServerConnection()
        {
            try
            {
                String serIp = "192.168.0.130";//服务器的IP地址
                String serverName = "Kepware.KEPServerEX.V6";//OPC服务器名称
                KepServerMain.KepServer = new OPCServer();
                //连接OPC服务器,opc服务名,ip
                //MessageBox.Show("OK");
                KepServerMain.KepServer.Connect(serverName, serIp);
                //判断连接状态
                if (KepServerMain.KepServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    labelServerStatus.Text = "服务器已连接";
                }
                else
                {
                    //这里你可以根据返回的状态来自定义显示信息，请查看自动化接口API文档
                    labelServerStatus.Text = "服务器状态：" + KepServerMain.KepServer.ServerState.ToString() + "   ";
                    return;
                }


                KepServerMain.KepGroups = KepServerMain.KepServer.OPCGroups;


                //用了并行处理，速度有所提高
                Stopwatch watch = new Stopwatch();///用于计算时间
                watch.Start();
                Parallel.Invoke(
                    () => kepProcessStatus(),
                    () => kepProcessAlarm());
                watch.Stop();
                label184.Text = watch.ElapsedMilliseconds.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 机器状态数据获取线程
        /// <summary>
        /// 大自动机数据获取线程
        /// </summary>
        public async void kepProcessStatus()
        {
            KepServerStructDF.KepGroup = KepServerMain.KepGroups.Add("GroupStatus");
            KepServerStructDF.KepGroup.UpdateRate = 100;
            KepServerStructDF.KepGroup.IsActive = true;
            KepServerStructDF.KepGroup.IsSubscribed = true;
            //当KepGroup中数据发生改变的触发事件
            KepServerStructDF.KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange_Status);
            //KepGroupDF14.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
            KepServerStructDF.KepItems = KepServerStructDF.KepGroup.OPCItems;
            //KepItemsDF14 = KepGroupDF14.OPCItems;
            ///初始化机器列表
            machinesDF.setMachineDF();
            Dictionary<string, int> machinesName = machinesDF.getMachineDF();

            await Task.Run(() =>
            {
                foreach (KeyValuePair<string, int> keyValuePair in machinesName)
                {
                    KepServerStructDF.KepItems.AddItem(keyValuePair.Key, keyValuePair.Value);
                }
            });
            //OPCItem bItem = KepServerStructDF.KepItems.Item(1);
        }

        /// <summary>
        /// 大自动机报警数据获取线程
        /// </summary>
        public async void kepProcessAlarm()
        {
            KepServerStructDFAlarm.KepGroup = KepServerMain.KepGroups.Add("GroupAlarm");
            KepServerStructDFAlarm.KepGroup.UpdateRate = 100;
            KepServerStructDFAlarm.KepGroup.IsActive = true;
            KepServerStructDFAlarm.KepGroup.IsSubscribed = true;
            //当KepGroup中数据发生改变的触发事件
            KepServerStructDFAlarm.KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange_Alarm);
            //KepGroupDF14.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
            KepServerStructDFAlarm.KepItems = KepServerStructDFAlarm.KepGroup.OPCItems;
            //KepItemsDF14 = KepGroupDF14.OPCItems;
            ///初始化机器列表
            alarmDF.setMachineDFAlarm();
            Dictionary<string, int> alarmName = alarmDF.getMachineDFAlarm();

            await Task.Run(() =>
            {
                foreach (KeyValuePair<string, int> keyValuePair in alarmName)
                {
                    KepServerStructDFAlarm.KepItems.AddItem(keyValuePair.Key, keyValuePair.Value);
                }
            });
            //OPCItem bItem = KepServerStructDFAlarm.KepItems.Item(1);
        }
        #endregion

        #region 数据改变时触发的事件处理函数
        /// <summary>
        /// 当Status数据改变时触发的事件
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        public void KepGroup_DataChange_Status(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                int index = Convert.ToInt32(ClientHandles.GetValue(i)) / 10;
                switch (Convert.ToInt32(ClientHandles.GetValue(i)) % 10)
                {
                    case 1:
                        machineFlagDF[index].setIsMachineStart(Convert.ToBoolean(ItemValues.GetValue(i)));
                        machineFlagDF[index].setMachineStatusQuality(Convert.ToInt32(Qualities.GetValue(i)));
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXMachineFlagDF[index], machineFlagDF[index].machineStatus());
                        break;
                    case 2:
                        machineFlagDF[index].setIsFurnaceStart(Convert.ToBoolean(ItemValues.GetValue(i)));
                        machineFlagDF[index].setFurnaceStatusQuality(Convert.ToInt32(Qualities.GetValue(i)));
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXMachineFlagDF[index], machineFlagDF[index].machineStatus());
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXFurnaceFlagDF[index], machineFlagDF[index].furnaceStatus());
                        //textBox2.Text = Convert.ToBoolean(ItemValues.GetValue(i)).ToString();
                        break;
                    case 3:
                        machineFlagDF[index].setLiterStart(Convert.ToBoolean(ItemValues.GetValue(i)));
                        machineFlagDF[index].setLiterStatusQuality(Convert.ToInt32(Qualities.GetValue(i)));
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXMachineFlagDF[index], machineFlagDF[index].machineStatus());
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXLiterFlagDF[index], machineFlagDF[index].literStatus());
                        //textBox3.Text = machineFlagDF01.getLiterStart();
                        break;
                    case 4:
                        machineFlagDF[index].setAlarm(Convert.ToBoolean(ItemValues.GetValue(i)));
                        machineFlagDF[index].setAlarmStatusQuality(Convert.ToInt32(Qualities.GetValue(i)));
                        this.Dispatcher.BeginInvoke(UpdateDFStatusDelegate, buttonXAlarmFlagDF[index], machineFlagDF[index].alarmStatus());
                        break;
                    case 5:
                        machineFlagDF[index].FlareMoldTimeSetting = Convert.ToInt32(ItemValues.GetValue(i));
                        break;
                    case 6:
                        machineFlagDF[index].DipingMaterialTimeSetting = Convert.ToInt32(ItemValues.GetValue(i));
                        break;
                    case 7:
                        machineFlagDF[index].FlareMaterialTimeSetting = Convert.ToInt32(ItemValues.GetValue(i));
                        break;
                    case 8:
                        machineFlagDF[index].CoolingTimeSetting = Convert.ToInt32(ItemValues.GetValue(i));
                        break;
                    case 9:
                        machineFlagDF[index].BrushOilTimeSetting = Convert.ToInt32(ItemValues.GetValue(i));
                        break;

                }

            }
            //labelDateTime.Text = DateTime.Now.ToString();

        }

        /// <summary>
        /// 当Alarm数据改变时触发的事件
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        public void KepGroup_DataChange_Alarm(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                if (Convert.ToBoolean(ItemValues.GetValue(i)) && Convert.ToInt32(Qualities.GetValue(i)) == 192)
                {
                    alarmMessagesDF.SetAlarmMessage(Convert.ToInt32(ClientHandles.GetValue(i)), true, DateTime.Parse(TimeStamps.GetValue(i).ToString()).AddHours(8));
                }
                else
                {
                    alarmMessagesDF.SetAlarmMessage(Convert.ToInt32(ClientHandles.GetValue(i)), false, DateTime.MinValue);
                }
                //listBoxAlarm.DataSource = alarmMessagesDF;
                //alarmMessagesDF[Convert.ToInt32(ClientHandles.GetValue(i)) / 100].TimeStamp = TimeStamps.GetValue(i).ToString();

            }
        }
        #endregion

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ImageSE12_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ImageSE12_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        #endregion
    }
}
