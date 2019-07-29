/*
 * CLR Version：4.0.30319.42000
 * NameSpace：SysManager.Common.Utilities.DotNetCode
 * FileName：CommonHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/20 5:00:46
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/20 5:00:46 新規作成 (by shaocx)
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// 公共帮助类
    /// </summary>
    public sealed class CommonHelper
    {


        /// <summary>
        /// 对象互转
        /// </summary>
        /// <typeparam name="T1">原对象</typeparam>
        /// <typeparam name="T2">新对象</typeparam>
        /// <param name="param">原对象</param>
        /// <returns></returns>
        public static T2 T1ToT2<T1, T2>(T1 param)
        {
            string json = JsonConvert.SerializeObject(param);
            return JsonConvert.DeserializeObject<T2>(json);
        }

        /// <summary>
        /// List转换DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
        {
            Type type = typeof(T);
            PropertyInfo[] proInfo = type.GetProperties();
            DataTable dt = new DataTable();
            foreach (PropertyInfo p in proInfo)
            {
                //类型存在Nullable<Type>时，需要进行以下处理，否则异常
                Type t = p.PropertyType;
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    t = t.GetGenericArguments()[0];
                dt.Columns.Add(p.Name, t);
            }
            foreach (T t in list)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo p in proInfo)
                {
                    object obj = p.GetValue(t);
                    if (obj == null) continue;
                    if (p.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                        continue;
                    dr[p.Name] = obj;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
