using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_Main
{
    public partial class OCC_Main : Form
    {
        public const string FORM_NAME = "首页";

        public OCC_Main()
        {
            InitializeComponent();

            DataGridViewDevicesInitialize();
        }

        private void DataGridViewDevicesInitialize()
        {
            DataGridViewDevice.Rows.Clear();

            var deviceInfoCoollection = DataBaseCRUDManager.Instance.GetAllActivatedDeviceInfo();
            if (deviceInfoCoollection.Count > 0)
            {
                DataGridViewDevice.Rows.Add(deviceInfoCoollection.Count);

                for (int i = 0; i < deviceInfoCoollection.Count; i++)
                {
                    Debug.Info($" index {i} {deviceInfoCoollection[i].Name}");
                    DataGridViewDevice.Rows[i].Tag = deviceInfoCoollection[i];
                    DataGridViewDevice.Rows[i].Cells["DeviceName"].Value = deviceInfoCoollection[i].Name;

                }

            }


        }
    }
}
