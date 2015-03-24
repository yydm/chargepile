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
        public Form2()
        {
            InitializeComponent();
            RemoteDataGatherRpcDao.Current.RpcUrl = "http://wl715.mooo.com:90/PowerpileService/rpc/JsonRpcService.rpc";
            //构建请求
            JsonRequest req = new JsonRequest()
            {
                ClassType = "DataGatherRpc",
                Scope = RequestScope.Singleton,
                Method = "PushCommand"
            };
            CmdRequest cmdreq = new CmdRequest() { ChargPileId = 12132, CmdType = CmdTaskType.Start.ToString(), CmdId = Guid.NewGuid().ToString() };

            req.AddParam(cmdreq);
              
            var setting = new JsonSerializerSettings();
            setting.DefaultValueHandling = DefaultValueHandling.Ignore;
            var timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            setting.Converters.Add(timeConverter);

            this.txtRequest.Text = JsonConvert.SerializeObject(req, Formatting.Indented, setting);
              
        }
          private void button1_Click(object sender, EventArgs e)
          {
              RpcClient c = new RpcClient();
              c.RpcUrl = txtUrl.Text;
              JsonRequest req = JsonConvert.DeserializeObject<JsonRequest>(this.txtRequest.Text);
              var resp = c.Invoke(req);
       
              txtResponse.Text = JsonConvert.SerializeObject(resp, Formatting.Indented);

          }

          private void button2_Click(object sender, EventArgs e)
          {
              CmdRequest cmdreq = new CmdRequest() { ChargPileId = 12132, CmdType = CmdTaskType.Start.ToString(), CmdId = Guid.NewGuid().ToString() };
              var result = RemoteDataGatherRpcDao.Current.QueryCmdResponse("12214321");
              
             
                  MessageBox.Show(result.ToString());
              
          }
    }
}
