using System;
using System.Collections.Generic;

using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;

namespace IdioSoft.Common.Class
{
    [Serializable]
    public class ByteSerialization
    {
        /// <summary>
        /// 将类串化为字节
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public byte[] funBytes_Object(object obj)
        {
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            return fs.GetBuffer();
        }
        /// <summary>
        /// 将字节转换为对像
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public object funObject_Load(byte[] array)
        {
            object o = new object();
            //定义一个流
            MemoryStream stream = new MemoryStream(array);
            //定义一个格式化器
            BinaryFormatter bf = new BinaryFormatter();

            o = bf.Deserialize(stream);

            stream.Close();
            return o;
        }

    }
}
