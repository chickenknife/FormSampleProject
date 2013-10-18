using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace propertyGridSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var hoge = CurrentSetting.propertySettings;
            this.propertyGrid1.SelectedObject = CurrentSetting.propertySettings;
            this.init();
        }

        private void init()
        {
            this.textBox1.Text = CurrentSetting.propertySettings.firsttext;
            this.label1.Text = CurrentSetting.propertySettings.folderpath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(CurrentSetting.propertySettings.savepath);
            fi.CreateText().Write(this.textBox1.Text);
        }
    }
}
