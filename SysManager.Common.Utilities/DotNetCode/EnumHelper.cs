using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Common.Utilities
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public sealed class EnumHelper
    {
        /// <summary>
        /// 枚举转集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumberEntity> EnumToList<T>()
        {
            List<EnumberEntity> list = new List<EnumberEntity>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumberEntity m = new EnumberEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Desction = da.Description;
                }
                m.EnumValue = Convert.ToInt32(e);
                m.EnumName = e.ToString();
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 获取枚举的描述属性
        /// </summary>
        /// <param name="en">枚举值</param>
        /// <returns>枚举的描述属性</returns>
        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();   //获取类型
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员
            if (memberInfos != null && memberInfos.Length > 0)
            {
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];   //获取描述特性

                if (attrs != null && attrs.Length > 0)
                {
                    return attrs[0].Description;    //返回当前描述
                }
            }
            return en.ToString();
        }
    }

    /// <summary>
    /// 枚举实体类
    /// </summary>
    public sealed class EnumberEntity
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Desction { set; get; }

        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string EnumName { set; get; }

        /// <summary>  
        /// 枚举对象的值  
        /// </summary>  
        public int EnumValue { set; get; }
    }
}
