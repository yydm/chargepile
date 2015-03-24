
/**
 * @fileOverview  由Codeanywhere 框架自动生成的jsonRpc服务端对象【Headfree.PowerPile.JsonRpc.Bussiness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null】的包装类
 * 服务端类的更新时间： 2013/7/15 8:56:08
 *  @version 1.0
 */
$.$import('cw.rpc.BaseClient');
with ($.$namespace('cw.rpc')) {

	/**
	 * 数据采集接口
	 * @class
	 * @name DataGatherRpc
	 * @memberOf cw.rpc
	 * @param {String}
	 * p_url rpc服务器地址
	 */
	cw.rpc.DataGatherRpc = function() {
		//继承
		var me = new BaseClient('rpc/JsonRpcService.rpc');
		me.setType('DataGatherRpc');

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
		me.PullYCData= function(stationId,callback)
		{
			me.setMethod('PullYCData')
			.addArgs(stationId);
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
		me.PullYXData= function(stationId,callback)
		{
			me.setMethod('PullYXData')
			.addArgs(stationId);
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
		 * 将当前内存数据保存为历史数据
		 * @name DumpMemeryDataToHis 
		 * @memberOf cw.rpc.DataGatherRpc.prototype
		 */
		me.DumpMemeryDataToHis= function(stationId,callback)
		{
			me.setMethod('DumpMemeryDataToHis')
			.addArgs(stationId);
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
};

