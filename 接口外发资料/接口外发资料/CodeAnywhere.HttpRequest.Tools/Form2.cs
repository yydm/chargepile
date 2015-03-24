using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CodeAnywhere.Json.Rpc;
using CodeAnywhere.Json.Rpc.Core;
using Headfree.CitSystem.DataAdapt.Rpc;
using Headfree.PowerPile.Core.Data.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CodeAnywhere.HttpRequest.Tools
{
    public partial class Form2 : Form
    {
        string cmdid = Guid.NewGuid().ToString();
        public Form2()
        {
            InitializeComponent();
            RemoteDataGatherRpcDao.Current.RpcUrl = "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc";
            
            //构建请求
            var req = new JsonRequest()
            {
                ClassType = "DataGatherRpc",
                Scope = RequestScope.Singleton,
                Method = "PushCommand"
            };
            var cmdreq = new CmdRequest()
                {
                    ChargPileId = 12132, 
                    CmdType = CmdTaskType.Start.ToString(), 
                    CmdId = cmdid
                };

            req.AddParam(cmdreq);

            var setting = new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };
            var timeConverter = new IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff"
                };
            setting.Converters.Add(timeConverter);

            this.txtRequest.Text = JsonConvert.SerializeObject(req, Formatting.Indented, setting);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var c = new RpcClient
                {
                    RpcUrl = txtUrl.Text
                };
            var req = JsonConvert.DeserializeObject<JsonRequest>(this.txtRequest.Text);
            var resp = c.Invoke(req);

            txtResponse.Text = JsonConvert.SerializeObject(resp, Formatting.Indented);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var cmdreq = new CmdRequest()
            //    {
            //        ChargPileId = 12132, 
            //        CmdType = CmdTaskType.Start.ToString(), 
            //        CmdId = Guid.NewGuid().ToString()
            //    };
            var result = RemoteDataGatherRpcDao.Current.QueryCmdResponse(cmdid);

            MessageBox.Show(result.ToString());

        }
    }
}
