/***********************************************************************
说明：此动态库支持同时操作多个MODEM，每个MODEM分配一个唯一编号，叫服务号。
	  服务号在使用SMSStartServiceEx或SMSStartService启动函数时会返回，

	  发送短信可以用SMSSendMessage和SMSSendMessageEx函数，只要给出短信
	  内容，传递给函数参数即可，如果短信长度过长，会自动断成多条短信发送。
	  使用SMSSendMessageEx发送短信时有3种格式可以选择:
	  0：7BIT；此格式只用于发送英文短信。
	  4：8BIT；此格式可以用于发送中文短信或者16进制短信，主要用于发送16进制短信。
	  8：UCS2；此格式主要用于发送中文短信。
	  255：自动识别

      接收短信有两种方式:
	  一种是使用回调函数，这样当有短信到来时会自动跳转到回调函数执行，
	  回调函数的参数包含收到的短信内容和时间，可以在回调函数里面处理
	  接收到的短信。可以装入数据库，也可以显示到运行界面。推荐使用这
	  种方式。
	  
	  另一种是使用SMSGetNextMessageEx或者SMSGetNextMessage查询方式，每隔
	  一段时间去轮询一次，如果已经有短信到来，此函数每使用一次接收一条短信。
	  如果短信已经接收完，通过此函数返回值可以判断。

	  另外还有一些辅助函数，用来查询指定短信是否发送成功，查询定义MODEM状态，
	  查询服务状态，查询指定MODEM信号和是否开启长短信功能等等。

	  注意：其中有一个发送结果报告功能，可以用函数SMSEnableReport选择
	  开启或关闭这个功能，默认关闭。此功能如果开启，应该用SMSReportEx
	  或者SMSReport函数定期去查询短信发送报告，否则每发送一条短信内存
	  就会被分配出去一点，使用此函数获取一条报告，内存中就会清除一条报告。
	  推荐不开启。使用查询SMSQuery函数来查询短信是否发送成功。

***********************************************************************/

#ifndef __SMS_DLL_FILE_HEAD__
#define __SMS_DLL_FILE_HEAD__

#define DLL_FUCTION_HEAD		__declspec (dllexport)

extern "C" 
{
	typedef signed char         INT8, *PINT8;
	typedef signed short        INT16, *PINT16;
	typedef signed int          INT32, *PINT32;
	typedef signed __int64      INT64, *PINT64;
	typedef unsigned char       UINT8, *PUINT8;
	typedef unsigned short      UINT16, *PUINT16;
	typedef unsigned int        UINT32, *PUINT32;
	typedef unsigned __int64    UINT64, *PUINT64;
	typedef int                 BOOL;
	typedef char				CHAR;

	typedef	struct _sms_report_stu
	{
		UINT32		index;			// 发送短信时返回的索引号
		CHAR		Msg[256];		// 短信内容
		INT32		Success;		// 是否成功。1：成功。0：失败
		CHAR		PhoneNo[32];		// 手机号码 
	}SMSReportStruct;

	typedef struct _sms_msg_stu
	{
		CHAR		szMsg[256];		// 短信内容
		CHAR		szPhoneNo[32];		// 手机号码
		CHAR		szReceTime[32];		// 短信时间
	}SMSMessageStruct;

	typedef	struct _sms_report_ex_stu
	{
		UINT32		uIndex;			// 发送短信时返回的索引号 
		CHAR		szMsg[256];		// 短信内容
		INT8		nSuccess;		// 是否成功。1：成功。0：失败
		CHAR		szPhoneNo[32];		// 手机号码 
		UINT16		uMsgLen;		// 短信长度
	}SMSReportStructEx;

	typedef struct _sms_msg_ex_stu
	{
		CHAR		szMsg[256];		// 短信内容
		UINT16		uMsgLen;		// 短信长度
		CHAR		szPhoneNo[32];		// 手机号码
		CHAR		szReceTime[32];		// 短信时间
	}SMSMessageStructEx;


	typedef void (*RECV_SMS_CALLBACK)(INT32 nPort, 			// 服务编号，启动服务时返回
									  SMSMessageStructEx *pMessage, 	// 接收到的短信
									  void *pParam);			// 输入参数

	typedef void (*SEND_SMS_CALLBACK)(INT32 nPort, 			// 服务编号，启动服务时返回
									  UINT32 uSMSIndex, 		// 发送短信索引
									  SMSMessageStructEx *pMessage, 	// 发送的短信
									  INT8 nSuccess, 			// 是否成功 1：成功。0：失败
									  void *pParam);			// 输入参数

	//启动服务,打开串口，初始化Modem
	// 返回 =< 0 表示启动失败。> 0 表示启动成功，返回服务编号
	DLL_FUCTION_HEAD INT32 _stdcall SMSStartService(INT32 nPort, 			// 端口号
								   UINT32 uBaudRate,		// 波特率
								   INT32 nParity,			// 校验位（现已无用）
								   INT32 nDataBits, 		// 数据位（现已无用）
								   INT32 nStopBits,		// 停止位（现已无用）
								   INT32 nFlowControl, 		// 流控位（现已无用）
								   CHAR *pCsca);			// 短信中心号码，使用默认的中心号码传入CARD

	//启动服务,打开串口，初始化Modem
	// 返回 < 0 表示启动失败。>= 0 表示启动成功，返回服务编号
	DLL_FUCTION_HEAD INT32 _stdcall SMSStartServiceEx(INT32 nPort, 			// 端口号
									 UINT32 uBaudRate,		// 波特率
									 INT32 nParity,			// 校验位（现已无用）
									 INT32 nDataBits, 		// 数据位（现已无用）
									 INT32 nStopBits,		// 停止位（现已无用）
									 INT32 nFlowControl, 		// 流控位（现已无用）
									 CHAR *pCsca,			// 短信中心号码，使用默认的中心号码传入CARD
									 RECV_SMS_CALLBACK DealRecvSms,	// 接收短信的回调函数
									 void *pRecvSmsParam,		// 回调函数传入的参数
									 SEND_SMS_CALLBACK DealSendSms,	// 发送短信结果的回调函数
									 void *pSendSmsParam);		// 回调函数传入的参数

	//停止所有服务
	// 返回非0为成功，0为失败
	DLL_FUCTION_HEAD INT32 _stdcall SMSStopService();	

	//停止所有服务
	// 返回非0为成功，0为失败
	DLL_FUCTION_HEAD INT32 _stdcall SMSStopSerice();

	// 停止指定服务号的服务
	// 返回非0为成功，0为失败
	DLL_FUCTION_HEAD INT32 _stdcall SMSStopServiceByPort(INT32 nPort);	// 服务编号，启动服务时返回 

	// 查看服务是否有一个在运行
	// 返回非0为是，0为否
	DLL_FUCTION_HEAD INT8 _stdcall SMSServiceStarted();

	// 挂机所有服务
	DLL_FUCTION_HEAD void _stdcall SMSServiceSuspend();

	// 所有服务继续运行
	DLL_FUCTION_HEAD void _stdcall SMSServiceResume(void);

	// 挂机指定的服务
	DLL_FUCTION_HEAD void _stdcall SMSServiceSuspendByPort(INT32 nPort);	// 服务编号，启动服务时返回 

	// 挂机指定的服务继续运行
	DLL_FUCTION_HEAD void _stdcall SMSServiceResumeByPort(INT32 nPort);	// 服务编号，启动服务时返回 

	// 查看指定服务是否有在运行
	// 返回非0为是，0为否
	DLL_FUCTION_HEAD INT8 _stdcall SMSServiceStartedByPort(INT32 nPort);	// 服务编号，启动服务时返回 

	// 是否启用发送结果报告功能。否则引起内存浪费
	DLL_FUCTION_HEAD void _stdcall SMSEnableReport(INT8 bEnable);		// 是否启用，1：启用；0：不启用

	// 是否启用长短信功能。如果不启用则不支持长短信。
	DLL_FUCTION_HEAD void _stdcall SMSEnableLongSms(INT8 bEnable);		// 是否启用，1：启用；0：不启用

	// 未完成长短信生存时间。只在接收长短信开启时有用。在接收长短信的过程中，可能发生长短信只收到一部分的情况，
	// 这种未完成的长短信，不能一直驻留在内存中，需要设定一个时间，当超出这个时间时，如果接收还未完成，就将这个未完成的短信从内存中清除。这里默认的时间是30分钟
	// lifeTimeSecond的单位是秒
	DLL_FUCTION_HEAD void _stdcall SMSSetLongSmsLifeTime( UINT64 lifeTimeSecond );

	//报告短信发送壮态(成功与否) 
	// 返回非0为有报告，0为无
	DLL_FUCTION_HEAD INT32 _stdcall SMSReport(SMSReportStruct *pReport);	// 报告结构体指针

	//报告短信发送壮态(成功与否) 
	// 返回非0为有报告，0为无
	DLL_FUCTION_HEAD INT32 _stdcall SMSReportEx(SMSReportStructEx *pReport);// 报告结构体指针

	//报告指定服务的短信发送壮态(成功与否) 
	// 返回非0为有报告，0为无
	DLL_FUCTION_HEAD INT32 _stdcall SMSReportExByPort(INT32 nPort, 			// 服务编号，启动服务时返回 
									 SMSReportStructEx *pReport);	// 报告结构体指针

	//查询指定序号的短信是否发送成功(该序号由SMSSendMessage返回)
	//返回 0 表示发送失败
	//     1 表示发送成功
	//    -1 表示没有查询到该序号的短信,可能仍在发送中。
	DLL_FUCTION_HEAD INT32 _stdcall SMSQuery(UINT32 uIndex);				// 短信索引号	

	// 得到最后失败的原因
	// 返回信息长度
	DLL_FUCTION_HEAD INT32 _stdcall SMSGetLastError(CHAR *pError, 			// 缓冲
								   UINT16 uLen);			// 缓冲大小

	// 得到指定服务最后失败的原因
	// 返回信息长度
	DLL_FUCTION_HEAD INT32 _stdcall SMSGetLastErrorEx(INT32 nPort, 			// 服务编号，启动服务时返回 
									 CHAR *pError, 			// 缓冲
									 UINT16 uLen);			// 缓冲大小

	// 通过错误返回值查看错误信息。现在只有启动服务返回结果有效。
	// 返回信息长度
	DLL_FUCTION_HEAD INT32 _stdcall SMSGetErrorByID(INT32 nErrorID, 			// 服务编号，启动服务时返回 
								   CHAR *pError, 			// 缓冲
								   UINT16 uLen);			// 缓冲大小

	//发送短消息
	// 返回短消息编号:index，从0开始递增，该函数不会阻塞，立既返回，请用函数SMSQuery(DWORD index)来查询是否发送成功
	DLL_FUCTION_HEAD UINT32 _stdcall SMSSendMessage(CHAR *pMsg, 			// 传入以0x00结尾的字符串
								   CHAR *pPhone); 			// 接收方电话号码 

	// 发送短消息
	// 返回加入发送缓冲队列是否成功，0：失败，未找到服务编号，非0：成功
	DLL_FUCTION_HEAD INT32 _stdcall SMSSendMessageEx(INT32 nPort, 			// 服务编号，启动服务时返回，0 表示任务服务器发送都可
									CHAR *pMsg, 			// 短信内容
									UINT16 uMsgLen, 		// 短信长度
									CHAR *pPhone, 			// 接收方电话号码 
									UINT8 uCode, 			// 编码格式	0：7BIT；4：8BIT；8：UCS2；255：自动识别
									UINT32 *pIndex);		// 短消息编号

	// 收取接收短信
	// 返回0：没有短信；1：有短信
	DLL_FUCTION_HEAD INT32 _stdcall SMSGetNextMessage(SMSMessageStruct* pMsg);	// 短信结构体

	// 收取接收短信
	// 返回0：没有短信；1：有短信
	DLL_FUCTION_HEAD INT32 _stdcall SMSGetNextMessageEx(INT32 nPort, 		// 服务编号，启动服务时返回 
									   SMSMessageStructEx* pMsg);	// 短信结构体

	// 得到指定服务所对MODEM的状态
	// 返回状态信息 0：正常；1：未启动；2：信号低；3：未登网；4：AT不通
	DLL_FUCTION_HEAD UINT8 _stdcall SMSGetStateByID(INT32 nPort);			// 服务编号，启动服务时返回 

	// 得到指定服务所对MODME的信号
	DLL_FUCTION_HEAD BOOL  _stdcall SMSGetCsq(INT32 nPort, 				// 服务编号，启动服务时返回 
							 UINT16 *pS, 				
							 UINT16 *pQ);	

	// 设置使用国家。现在只区别日本和其它
	DLL_FUCTION_HEAD BOOL _stdcall SMSSetNation(INT32 nPort, 			// 服务编号，启动服务时返回 
							   UINT16 uNation);			// 其它：0（默认）1：日本  2：新西兰

	// 设置短信中心号码类型，默认是91，形式如 +8613912345678
	// 关于手机号类型如何设置，可以百度 TON/NPI 了解详细
	DLL_FUCTION_HEAD void _stdcall SMSSetCSCAType( UINT8 u8Type );

	// 设置目的号码类型，默认是91，形式如 +8613912345678
	DLL_FUCTION_HEAD void _stdcall SMSSetDstPhoneType( UINT8 u8Type );

	// 设置区号。如中国区是86。默认是86
	DLL_FUCTION_HEAD void _stdcall SMSSetAreaCode( UINT8 u8AreaCode );
}

#endif