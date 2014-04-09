using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Xml.Serialization;

namespace IdioSoft.Common.Class
{
    public class XmlSerialization
    {
        /// <summary>   
        /// 将一个对象保存到一个XML文件
        /// </summary>   
        /// <param name="fileName">保存的文件路径</param>
        public string Save(string fileName)
        {
            string tmpFilename = fileName + ".tmp";
            FileInfo tmpFileInfo = new FileInfo(tmpFilename);
            FileInfo sFileInfo = new FileInfo(fileName);
            if (tmpFileInfo.Exists)
            {
                tmpFileInfo.Delete();
            }
            FileStream stream = new FileStream(tmpFilename, FileMode.Create);
            Save(stream);
            stream.Close();
            sFileInfo.Delete();
            tmpFileInfo.CopyTo(fileName, true);
            tmpFileInfo.Delete();
            return "";
        }
        /// <summary>   
        /// 将一个对象保存到一个XML文件
        /// </summary>   
        /// <param name="objStream">保存文件的文件流</param>
        public string Save(Stream objStream)
        {
            XmlSerializer xmlser = new XmlSerializer(this.GetType());
            string strError = "";
            try
            {
                xmlser.Serialize(objStream, this);
            }
            catch (Exception ex)
            {
                strError = "Error" + ex.Message + "\n";
            }
            return strError;
        }
        /// <summary>   
        /// 载入一个被串行化后的XML文件
        /// </summary>   
        /// <param name="filename">文件路径</param>
        /// <param name="newType">被串行化对像的类型</param>
        public static object Load(string filename, Type newType)
        {
            FileInfo fileInfo = new FileInfo(filename);
            if (fileInfo.Exists == false)
            {
                return System.Activator.CreateInstance(newType);
            }
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            object newObject = Load(stream, newType);
            stream.Close();
            return newObject;
        }
        /// <summary>   
        /// 载入一个被串行化后的XML文件
        /// </summary>   
        /// <param name="stream">载入的文件流</param>
        /// <param name="newType">被串行化对像的类型</param>
        public static object Load(Stream stream, Type newType)
        {
            XmlSerializer xmlser = new XmlSerializer(newType);
            object newObject = xmlser.Deserialize(stream);
            return newObject;
        }
    }
}
