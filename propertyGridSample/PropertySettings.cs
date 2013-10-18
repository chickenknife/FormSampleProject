using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace propertyGridSample
{
    public class PropertySettings
    {
        const string configfilepath = @"PropertySettings.config";

        public PropertySettings()
        {

        }

        public void Save()
        {
            //todo logging
            XmlSerializer xs = new XmlSerializer(this.GetType());
            FileStream fs = new FileStream(configfilepath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public void Load()
        {
            this.Load(configfilepath);
        }

        private void Load(string filename)
        {
            XmlSerializer xs = new XmlSerializer(this.GetType());
            FileStream fs = null;
            bool newElementFlag = false;
            try
            {
                FileInfo finfo = new FileInfo(filename);
                if (!finfo.Exists)
                {
                    //todo logging
                    Save();

                    Load();

                    Save();

                }
                else
                {
                    fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    PropertySettings me = (PropertySettings)xs.Deserialize(fs);

                    //-------Text---------
                    this.firsttext = me.firsttext;
                    if (this.firsttext == null)
                    {
                        this.firsttext = "text";
                        newElementFlag = true;
                    }
                    //todo logging

                    //-------save---------
                    this.savepath = me.savepath;
                    if (this.savepath == null)
                    {
                        this.savepath = "savePath";
                        newElementFlag = true;
                    }
                    //todo logging

                    //-------folder---------
                    this.folderpath = me.folderpath;
                    if (this.folderpath == null)
                    {
                        this.folderpath = "folderPath";
                        newElementFlag = true;
                    }
                    //todo logging

                    if (newElementFlag)
                    {
                        Save();
                    }
                }
            }
            catch (Exception ex)
            {
                //todo logging
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        #region define xml
        [XmlElement]
        [Category("text")]
        [DisplayName("first_text")]
        [Description("first display text")]
        [DefaultValue("text")]
        public string firsttext { get; set; }

        //adding a reference to System.Design
        [XmlElement]
        [Category("text")]
        [DisplayName("savefilePath")]
        [Description("select file path")]
        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor),
          typeof(System.Drawing.Design.UITypeEditor))]
        public string savepath { get; set; }

        [XmlElement]
        [Category("folder")]
        [DisplayName("folderPath")]
        [Description("select folder")]
        [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor),
          typeof(System.Drawing.Design.UITypeEditor))]
        public string folderpath { get; set; }

        #endregion
    }
}
