
/**
 * @fileOverview  由Codeanywhere 框架自动生成的jsonRpc服务端对象【Headfree.PowerPile.JsonRpc.Bussiness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null】的包装类
 * 服务端类的更新时间： 2014/4/28 10:03:29
 *  @version 1.0
 */
BaseClient = function(p_url) {
		var me = this;
		/**
		 * Rpc服务地址
		 * 
		 * @type String
		 * @memberOf cw.rpc.BaseClient.prototype
		 * @name url
		 */
		me.url = p_url;
		/**
		 * json请求对象
		 * 
		 * @field
		 * @name jsonRequest
		 * @memberOf cw.rpc.BaseClient.prototype
		 */
		me.jsonRequest = {
			scope : 'Prototype',
			args : []
		};
		$.extend(me,
				/**
				 * @lends cw.rpc.BaseClient.prototype
				 */
				{

			/**
			 * 设置类名
			 */
			setType : function(p_type) {
				me.jsonRequest.type = p_type;
				return me;
			},
			/**
			 * 设置调用的方法名
			 */
			setMethod : function(p_method) {
				me.jsonRequest.method = p_method;
				me.clearArgs();
				return me;
			},
			/**
			 * 是否共享实例
			 */
			isSingleton : function(p_bool) {
				if (p_bool) {
					me.jsonRequest.scope = 'Singleton';
				} else {
					me.jsonRequest.scope = 'Prototype';
				}
				return me;
			},
			/**
			 * 添加一个参数到请求中
			 */
			addArgs : function(p_arg) {
				me.jsonRequest.args.push(p_arg);
				return me;
			},
			/**
			 * 清除参数
			 */
			clearArgs : function() {
				me.jsonRequest.args.clear();
				return me;
			},
			/**
			 * 异步调用方法
			 * 
			 * @param {Function}callback
			 * @optional , 传递参数时，为异步调用，否则为同步调用
			 */
			invoke : function(callback) {
				if ($.isFunction(callback)) {
					// 异步调用
					$.ajax({
								type : "POST",
								url : me.url,
								data : JSON2.stringify(me.jsonRequest),
								success : function(resp) {
									if (!resp.success) {
										 if(resp.message.length>30)
										 {
											alert(resp.message);
										 }
										 else
										 {
										 	$.messager.alert($global.title.info, resp.message, "error");
										 }
										
									}

									callback.apply(me, arguments);

								},
								error : function(xhr) {
									
									/*$.messager.alert('Ajax错误', '调用地址' + me.url
													+ "发生错误", "error");*/
									alert('Ajax错误\r\n'+'调用地址' + me.url+"发生错误");

								}
							});
				} else {
					// 同步调用

					var xhr= $.ajax({
								type : "POST",
								url : me.url,
								data : JSON2.stringify(me.jsonRequest),
								async : false
							});
					try
					{
						return JSON2.parse(xhr.responseText)
					}
					catch(e)
					{
						return {
							success:false,
							message:e.message
						}
					}
				}
			}
		});

		return me;
	};



	/**
	 * 数据采集接口
	 * @class
	 * @name DataGatherRpc
	 * @memberOf cw.rpc
	 * @param {String}
	 * p_url rpc服务器地址
	 */
	DataGatherRpc = function() {
		//继承
		var me = new BaseClient('rpc/JsonRpcService.rpc');
		me.setType('DataGatherRpc');

		/**
		 * 提交充电记录
		 * @name CommitPowerRecord 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.CommitPowerRecord= function(entity,callback)
		{
			me.setMethod('CommitPowerRecord')
			.addArgs(entity);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 手工灭警处理
		 * @name ManBreakWarn 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.ManBreakWarn= function(targetdev,GATITEMID,processeep,callback)
		{
			me.setMethod('ManBreakWarn')
			.addArgs(targetdev).addArgs(GATITEMID).addArgs(processeep);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 推遥测数据到实时缓存区
		 * @name PushYCData 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PushYCData= function(data,callback)
		{
			me.setMethod('PushYCData')
			.addArgs(data);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 从实时缓存区拉遥测数据
		 * @name PullYCData 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PullYCData= function(PowerPileId,callback)
		{
			me.setMethod('PullYCData')
			.addArgs(PowerPileId);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 推遥信数据到实时缓存区
		 * @name PushYXData 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PushYXData= function(data,callback)
		{
			me.setMethod('PushYXData')
			.addArgs(data);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 从实时缓存区拉遥信数据
		 * @name PullYXData 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PullYXData= function(PowerPileId,callback)
		{
			me.setMethod('PullYXData')
			.addArgs(PowerPileId);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 放置控制命令到命令队列
		 * @name PushCommand 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PushCommand= function(data,callback)
		{
			me.setMethod('PushCommand')
			.addArgs(data);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 查询命令响应结果
		 * @name QueryCmdResponse 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryCmdResponse= function(CmdId,callback)
		{
			me.setMethod('QueryCmdResponse')
			.addArgs(CmdId);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 清除超过指定时间的数据
		 * @name ClearTimeOutData 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.ClearTimeOutData= function(nTimeout,callback)
		{
			me.setMethod('ClearTimeOutData')
			.addArgs(nTimeout);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 将当前内存数据保存为历史数据
		 * @name DumpMemeryDataToHis 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.DumpMemeryDataToHis= function(CycleType,p_Interval,callback)
		{
			me.setMethod('DumpMemeryDataToHis')
			.addArgs(CycleType).addArgs(p_Interval);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 备份当前内存数据库
		 * @name BackupDataBase 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.BackupDataBase= function(callback)
		{
			me.setMethod('BackupDataBase')
			;
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 刷新DTU网络状态
		 * @name RefreshNetSate 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.RefreshNetSate= function(netstate,callback)
		{
			me.setMethod('RefreshNetSate')
			.addArgs(netstate);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 充电桩实时状态
		 * @name RefreshPowerPileSate 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.RefreshPowerPileSate= function(piplestate,callback)
		{
			me.setMethod('RefreshPowerPileSate')
			.addArgs(piplestate);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 获取通信网络状态dtustatus：000：通信正常 001：通信异常 002：通信断开
		 * @name QueryNetState 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryNetState= function(callback)
		{
			me.setMethod('QueryNetState')
			;
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 获取充电站下充电桩实时工作状态=待机=1,充电=2,充满=3,离线=4,异常=5
		 * @name QueryStationPileWorkStatus 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryStationPileWorkStatus= function(zhuan_bh,callback)
		{
			me.setMethod('QueryStationPileWorkStatus')
			.addArgs(zhuan_bh);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 获取充电桩实时工作状态=待机=1,充电=2,充满=3,离线=4,异常=5
		 * @name QueryPileWorkStatus 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryPileWorkStatus= function(callback)
		{
			me.setMethod('QueryPileWorkStatus')
			;
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 充电桩使用情况统计
		 * @name QueryPowerPileUse 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryPowerPileUse= function(StationId,dtBegin,dtEnd,callback)
		{
			me.setMethod('QueryPowerPileUse')
			.addArgs(StationId).addArgs(dtBegin).addArgs(dtEnd);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 充电站使用情况统计
		 * @name QueryStationUse 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.QueryStationUse= function(dtBegin,dtEnd,callback)
		{
			me.setMethod('QueryStationUse')
			.addArgs(dtBegin).addArgs(dtEnd);
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};

		/**
		 * 充电厂站停电信息监视 -powerStopState:000-正常 002-全部停电
		 * @name PowerStopMonitor 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.PowerStopMonitor= function(callback)
		{
			me.setMethod('PowerStopMonitor')
			;
			if ($.isFunction(callback)) {
				me.invoke(callback);
			}
			else
			{
				return me.invoke();
			}
		};
return me;
};


