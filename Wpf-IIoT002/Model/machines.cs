using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT002
{
    public class machines
    {
        private Dictionary<string, int> machineDFDict = new Dictionary<string, int>();
        private Dictionary<string, int> machineSFDict = new Dictionary<string, int>();

        public void setMachineDF()
        {
            machineDFDict.Clear();
            ///DG01
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.机器运行标志", 11);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.炉子电源开关", 12);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.升料机开关", 13);
            machineDFDict.Add("研发楼二楼车间DG01.#01.报警信息.报警提示", 14);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.烤模时间设定", 15);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.浸料时间设定", 16);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.烤料时间设定", 17);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.冷却时间设定", 18);
            machineDFDict.Add("研发楼二楼车间DG01.#01.状态.刷油时间设定", 19);
            ///DY03
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.机器运行标志", 21);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.炉子电源开关", 22);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.升料机开关", 23);
            machineDFDict.Add("研发楼二楼车间DY03.#03.报警信息.报警提示", 24);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.烤模时间设定", 25);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.浸料时间设定", 26);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.烤料时间设定", 27);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.冷却时间设定", 28);
            machineDFDict.Add("研发楼二楼车间DY03.#03.状态.刷油时间设定", 29);
            ///DY02
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.机器运行标志", 31);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.炉子电源开关", 32);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.升料机开关", 33);
            machineDFDict.Add("研发楼二楼车间DY02.#02.报警信息.报警提示", 34);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.烤模时间设定", 35);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.浸料时间设定", 36);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.烤料时间设定", 37);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.冷却时间设定", 38);
            machineDFDict.Add("研发楼二楼车间DY02.#02.状态.刷油时间设定", 39);
            ///DY01
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.机器运行标志", 41);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.炉子电源开关", 42);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.升料机开关", 43);
            machineDFDict.Add("研发楼二楼车间DY01.#01.报警信息.报警提示", 44);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.烤模时间设定", 45);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.浸料时间设定", 46);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.烤料时间设定", 47);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.冷却时间设定", 48);
            machineDFDict.Add("研发楼二楼车间DY01.#01.状态.刷油时间设定", 49);
            ///DE03
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.机器运行标志", 51);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.炉子电源开关", 52);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.升料机开关", 53);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.报警信息.报警提示", 54);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.烤模时间设定", 55);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.浸料时间设定", 56);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.烤料时间设定", 57);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.冷却时间设定", 58);
            machineDFDict.Add("研发楼二楼洁净车间DE03.#03.状态.刷油时间设定", 59);
            ///DE02
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.机器运行标志", 61);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.炉子电源开关", 62);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.升料机开关", 63);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.报警信息.报警提示", 64);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.烤模时间设定", 65);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.浸料时间设定", 66);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.烤料时间设定", 67);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.冷却时间设定", 68);
            machineDFDict.Add("研发楼二楼洁净车间DE02.#02.状态.刷油时间设定", 69);
            ///DE01
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.机器运行标志", 71);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.炉子电源开关", 72);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.升料机开关", 73);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.报警信息.报警提示", 74);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.烤模时间设定", 75);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.浸料时间设定", 76);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.烤料时间设定", 77);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.冷却时间设定", 78);
            machineDFDict.Add("研发楼二楼洁净车间DE01.#01.状态.刷油时间设定", 79);
            ///08号大机
            machineDFDict.Add("制造车间大机#08.#08.状态.机器运行标志", 81);
            machineDFDict.Add("制造车间大机#08.#08.状态.炉子电源开关", 82);
            machineDFDict.Add("制造车间大机#08.#08.状态.升料机开关", 83);
            machineDFDict.Add("制造车间大机#08.#08.报警信息.报警提示", 84);
            machineDFDict.Add("制造车间大机#08.#08.状态.烤模时间设定", 85);
            machineDFDict.Add("制造车间大机#08.#08.状态.浸料时间设定", 86);
            machineDFDict.Add("制造车间大机#08.#08.状态.烤料时间设定", 87);
            machineDFDict.Add("制造车间大机#08.#08.状态.冷却时间设定", 88);
            machineDFDict.Add("制造车间大机#08.#08.状态.刷油时间设定", 89);
            ///09号大机
            machineDFDict.Add("制造车间大机#09.#09.状态.机器运行标志", 91);
            machineDFDict.Add("制造车间大机#09.#09.状态.炉子电源开关", 92);
            machineDFDict.Add("制造车间大机#09.#09.状态.升料机开关", 93);
            machineDFDict.Add("制造车间大机#09.#09.报警信息.报警提示", 94);
            machineDFDict.Add("制造车间大机#09.#09.状态.烤模时间设定", 95);
            machineDFDict.Add("制造车间大机#09.#09.状态.浸料时间设定", 96);
            machineDFDict.Add("制造车间大机#09.#09.状态.烤料时间设定", 97);
            machineDFDict.Add("制造车间大机#09.#09.状态.冷却时间设定", 98);
            machineDFDict.Add("制造车间大机#09.#09.状态.刷油时间设定", 99);
            ///10号大机
            machineDFDict.Add("制造车间大机#10.#10.状态.机器运行标志", 101);
            machineDFDict.Add("制造车间大机#10.#10.状态.炉子电源开关", 102);
            machineDFDict.Add("制造车间大机#10.#10.状态.升料机开关", 103);
            machineDFDict.Add("制造车间大机#10.#10.报警信息.报警提示", 104);
            machineDFDict.Add("制造车间大机#10.#10.状态.烤模时间设定", 105);
            machineDFDict.Add("制造车间大机#10.#10.状态.浸料时间设定", 106);
            machineDFDict.Add("制造车间大机#10.#10.状态.烤料时间设定", 107);
            machineDFDict.Add("制造车间大机#10.#10.状态.冷却时间设定", 108);
            machineDFDict.Add("制造车间大机#10.#10.状态.刷油时间设定", 109);
            ///11号大机
            machineDFDict.Add("制造车间大机#11.#11.状态.机器运行标志", 111);
            machineDFDict.Add("制造车间大机#11.#11.状态.炉子电源开关", 112);
            machineDFDict.Add("制造车间大机#11.#11.状态.升料机开关", 113);
            machineDFDict.Add("制造车间大机#11.#11.报警信息.报警提示", 114);
            machineDFDict.Add("制造车间大机#11.#11.状态.烤模时间设定", 115);
            machineDFDict.Add("制造车间大机#11.#11.状态.浸料时间设定", 116);
            machineDFDict.Add("制造车间大机#11.#11.状态.烤料时间设定", 117);
            machineDFDict.Add("制造车间大机#11.#11.状态.冷却时间设定", 118);
            machineDFDict.Add("制造车间大机#11.#11.状态.刷油时间设定", 119);
            ///12号大机
            machineDFDict.Add("制造车间大机#12.#12.状态.机器运行标志", 121);
            machineDFDict.Add("制造车间大机#12.#12.状态.炉子电源开关", 122);
            machineDFDict.Add("制造车间大机#12.#12.状态.升料机开关", 123);
            machineDFDict.Add("制造车间大机#12.#12.报警信息.报警提示", 124);
            machineDFDict.Add("制造车间大机#12.#12.状态.烤模时间设定", 125);
            machineDFDict.Add("制造车间大机#12.#12.状态.浸料时间设定", 126);
            machineDFDict.Add("制造车间大机#12.#12.状态.烤料时间设定", 127);
            machineDFDict.Add("制造车间大机#12.#12.状态.冷却时间设定", 128);
            machineDFDict.Add("制造车间大机#12.#12.状态.刷油时间设定", 129);
            ///13号大机
            machineDFDict.Add("制造车间大机#13.#13.状态.机器运行标志", 131);
            machineDFDict.Add("制造车间大机#13.#13.状态.炉子电源开关", 132);
            machineDFDict.Add("制造车间大机#13.#13.状态.升料机开关", 133);
            machineDFDict.Add("制造车间大机#13.#13.报警信息.报警提示", 134);
            machineDFDict.Add("制造车间大机#13.#13.状态.烤模时间设定", 135);
            machineDFDict.Add("制造车间大机#13.#13.状态.浸料时间设定", 136);
            machineDFDict.Add("制造车间大机#13.#13.状态.烤料时间设定", 137);
            machineDFDict.Add("制造车间大机#13.#13.状态.冷却时间设定", 138);
            machineDFDict.Add("制造车间大机#13.#13.状态.刷油时间设定", 139);
            ///14号大机
            machineDFDict.Add("制造车间大机#14.#14.状态.机器运行标志", 141);
            machineDFDict.Add("制造车间大机#14.#14.状态.炉子电源开关", 142);
            machineDFDict.Add("制造车间大机#14.#14.状态.升料机开关", 143);
            machineDFDict.Add("制造车间大机#14.#14.报警信息.报警提示", 144);
            machineDFDict.Add("制造车间大机#14.#14.状态.烤模时间设定", 145);
            machineDFDict.Add("制造车间大机#14.#14.状态.浸料时间设定", 146);
            machineDFDict.Add("制造车间大机#14.#14.状态.烤料时间设定", 147);
            machineDFDict.Add("制造车间大机#14.#14.状态.冷却时间设定", 148);
            machineDFDict.Add("制造车间大机#14.#14.状态.刷油时间设定", 149);
            ///15号大机
            machineDFDict.Add("制造车间大机#15.#15.状态.机器运行标志", 151);
            machineDFDict.Add("制造车间大机#15.#15.状态.炉子电源开关", 152);
            machineDFDict.Add("制造车间大机#15.#15.状态.升料机开关", 153);
            machineDFDict.Add("制造车间大机#15.#15.报警信息.报警提示", 154);
            machineDFDict.Add("制造车间大机#15.#15.状态.烤模时间设定", 155);
            machineDFDict.Add("制造车间大机#15.#15.状态.浸料时间设定", 156);
            machineDFDict.Add("制造车间大机#15.#15.状态.烤料时间设定", 157);
            machineDFDict.Add("制造车间大机#15.#15.状态.冷却时间设定", 158);
            machineDFDict.Add("制造车间大机#15.#15.状态.刷油时间设定", 159);
            ///16号大机
            machineDFDict.Add("制造车间大机#16.#16.状态.机器运行标志", 161);
            machineDFDict.Add("制造车间大机#16.#16.状态.炉子电源开关", 162);
            machineDFDict.Add("制造车间大机#16.#16.状态.升料机开关", 163);
            machineDFDict.Add("制造车间大机#16.#16.报警信息.报警提示", 164);
            machineDFDict.Add("制造车间大机#16.#16.状态.烤模时间设定", 165);
            machineDFDict.Add("制造车间大机#16.#16.状态.浸料时间设定", 166);
            machineDFDict.Add("制造车间大机#16.#16.状态.烤料时间设定", 167);
            machineDFDict.Add("制造车间大机#16.#16.状态.冷却时间设定", 168);
            machineDFDict.Add("制造车间大机#16.#16.状态.刷油时间设定", 169);
            ///17号大机
            machineDFDict.Add("制造车间大机#17.#17.状态.机器运行标志", 171);
            machineDFDict.Add("制造车间大机#17.#17.状态.炉子电源开关", 172);
            machineDFDict.Add("制造车间大机#17.#17.状态.升料机开关", 173);
            machineDFDict.Add("制造车间大机#17.#17.报警信息.报警提示", 174);
            machineDFDict.Add("制造车间大机#17.#17.状态.烤模时间设定", 175);
            machineDFDict.Add("制造车间大机#17.#17.状态.浸料时间设定", 176);
            machineDFDict.Add("制造车间大机#17.#17.状态.烤料时间设定", 177);
            machineDFDict.Add("制造车间大机#17.#17.状态.冷却时间设定", 178);
            machineDFDict.Add("制造车间大机#17.#17.状态.刷油时间设定", 179);
            ///18号大机
            //machineDFDict.Add("制造车间大机#18.#18.状态.机器运行标志", 181);
            //machineDFDict.Add("制造车间大机#18.#18.状态.炉子电源开关", 182);
            //machineDFDict.Add("制造车间大机#18.#18.状态.升料机开关", 183);
            ///19号大机
            machineDFDict.Add("制造车间大机#19.#19.状态.机器运行标志", 191);
            machineDFDict.Add("制造车间大机#19.#19.状态.炉子电源开关", 192);
            machineDFDict.Add("制造车间大机#19.#19.状态.升料机开关", 193);
            machineDFDict.Add("制造车间大机#19.#19.报警信息.报警提示", 194);
            machineDFDict.Add("制造车间大机#19.#19.状态.烤模时间设定", 195);
            machineDFDict.Add("制造车间大机#19.#19.状态.浸料时间设定", 196);
            machineDFDict.Add("制造车间大机#19.#19.状态.烤料时间设定", 197);
            machineDFDict.Add("制造车间大机#19.#19.状态.冷却时间设定", 198);
            machineDFDict.Add("制造车间大机#19.#19.状态.刷油时间设定", 199);

        }

        public void setMachineSF()
        {
            machineSFDict.Clear();
            
            ///SR01
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.机器运行标志", 1001);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.炉子电源开关", 1002);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机开关", 1003);
            machineSFDict.Add("研发楼一楼车间SR01.#01.报警信息.报警提示", 1004);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第1段速度", 1005);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第2段速度", 1006);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第3段速度", 1007);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第4段速度", 1008);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第1段位置", 1009);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第2段位置", 1010);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第3段位置", 1011);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机上升第4段位置", 1012);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第1段速度", 1013);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第2段速度", 1014);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第3段速度", 1015);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第4段速度", 1016);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第1段位置", 1017);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第2段位置", 1018);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第3段位置", 1019);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料第4段位置", 1020);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.烤模时间设定值", 1021);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.二次烤料时间", 1022);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机浸料时间设定值", 1023);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.一次烤料时间设定", 1024);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.冷却时间设定", 1025);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.实际产量", 1026);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.每模产量", 1027);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.每模模具头数量", 1028);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.计划产量", 1029);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.上升段数", 1030);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.浸料段数", 1031);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.升料机手动设定速度", 1032);
            machineSFDict.Add("研发楼一楼车间SR01.#01.状态.第1模总时间显示", 1033);
        }

        public Dictionary<string, int> getMachineDF()
        {
            return machineDFDict;
        }

        public Dictionary<string, int> getMachineSF()
        {
            return machineSFDict;
        }

    }
}
