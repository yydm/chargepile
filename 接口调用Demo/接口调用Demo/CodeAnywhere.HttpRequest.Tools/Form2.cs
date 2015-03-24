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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CodeAnywhere.HttpRequest.Tools
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //构建请求
            var req = new JsonRequest
                {
                    ClassType = "jDao",
                    Scope = RequestScope.Singleton,
                    Method = "QueryDt"
                };
            var dic = new Dictionary<String, object> { { "PowerPileNo", "0000001" } };

            req.AddParam(@"select * from powerpilestates where powerpileno=#PowerPileNo")
                .AddParam(dic);
            var setting = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff" };
            setting.Converters.Add(timeConverter);

            txtRequest.Text = JsonConvert.SerializeObject(req, Formatting.Indented, setting);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var c = new RpcClient { RpcUrl = txtUrl.Text };
            var req = JsonConvert.DeserializeObject<JsonRequest>(txtRequest.Text);
            var resp = c.Invoke(req);

            txtResponse.Text = JsonConvert.SerializeObject(resp, Formatting.Indented);

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
          
        }
    }
}
