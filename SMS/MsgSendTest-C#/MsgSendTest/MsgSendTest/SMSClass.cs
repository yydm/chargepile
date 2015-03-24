using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;//  P/Invoke 必需
using System.Text;

namespace CSSMS
{
    class SMS
    {
        public struct SMSReportStruct
        {
            public uint index;          //短消息编号:index，从0开始递增
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] Msg;
            public int Success;      //是否发送成功 0为失败，非0为成功            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] PhoneNo;
        }

        public struct SMSMessageStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] Msg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] PhoneNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] ReceTime;
        }



        /// <summary>
        ///启动服务,打开串口，初始化Modem, 0为失败，非0为成功
        ///校验位， EvenParity :0,MarkParity:1,NoParity:2,OddParity:3,SpaceParity,4
        ///停止位 OneStopBit 0,OnePointFiveStopBits:1,TwoStopBits 2
        ///流控:NoFlowControl:0,    CtsRtsFlowControl:1,    CtsDtrFlowControl:2,    DsrRtsFlowControl:3,    DsrDtrFlowControl:4,    XonXoffFlowControl:5
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSStartService(int nPort, uint BaudRate,
            int Parity, int DataBits, int StopBits, int FlowControl, string csca);

        /// <summary>
        ///停止服务，并关闭串口,0为失败，非0为成功
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSStopSerice();


        /// <summary>
        ///发送短消息,返回短消息编号:index，从0开始递增，该函数不会阻塞，立既返回，请用函数SMSQuery(DWORD index)来查询是否发送成功
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern uint SMSSendMessage(string Msg, string PhoneNo);



        /// <summary>
        ///报告短信发送壮态(成功与否)0为有报告，非0为无
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSReport(ref SMSReportStruct rept);


        /// <summary>
        ///查询指定序号的短信是否发送成功(该序号由SMSSendMessage返回)
        ///返回 0 表示发送失败
        ///     1 表示发送成功
        ///    -1 表示没有查询到该序号的短信,可能仍在发送中。
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSQuery(uint index);



        /// <summary>
        ///接收短信,0为有短信，非0为无
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSGetNextMessage(ref SMSMessageStruct Msg);


        /// <summary>
        ///返回错误内容的长度
        /// </summary>
        [DllImport("SMSDLL.dll")]
        public static extern int SMSGetLastError(byte[] err);


    }
}
