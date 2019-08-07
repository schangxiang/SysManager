using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using SysManager.Common.Utilities;

namespace SysManager.DB.Utilities
{
    /// <summary>
    /// Dapper���ݷ��ʳ��������
    /// </summary>
    public abstract class DapperDataBase
    {
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <returns></returns>
        public abstract IDbConnection CreateDbConnection();


        /// <summary>
        /// ִ�в�ѯ�б�
        /// </summary>
        public  List<T> QueryList<T>(string sqlStr)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Query<T>(sqlStr) as List<T>;
            }
        }
        /// <summary>
        /// ִ�в�ѯ�б�
        /// ע�⣺���ﷺ��ֻ����һ������κͳ��ζ���ͬһ�����������ͬһ�������ѯ����ΪNULL
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="sqlStr">ִ��SQL�ַ���</param>
        /// <param name="param">����</param>
        /// <returns>��ѯ�б�</returns>
        public  List<T> QueryList<T>(string sqlStr, T param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Query<T>(sqlStr, param) as List<T>;
            }
        }
        /// <summary>
        /// ִ�в�ѯ��������
        /// </summary>
        public  T QuerySingle<T>(string sqlStr, T param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Query<T>(sqlStr, param).SingleOrDefault();
            }
        }

        /// <summary>
        /// ִ���Ƿ��������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr">��ѯ������SELECT COUNT(1)  FROM XXX ��</param>
        /// <param name="param">��������</param>
        /// <returns></returns>
        public  bool Exists(string sqlStr, Object param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                int count = conn.Query<int>(sqlStr, param).FirstOrDefault();
                return count > 0 ? true : false;
            }
        }

        /// <summary>
        /// �洢���̲�ѯ�б�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public  List<T> QueryListByProc<T>(string procName, T param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Query<T>(procName, param, commandType: CommandType.StoredProcedure) as List<T>;
            }
        }
        /// <summary>
        /// �洢���̲�ѯ�б�
        /// </summary>
        /// <typeparam name="T">�洢���̲���������������������</typeparam>
        /// <typeparam name="T1">���ز���</typeparam>
        /// <param name="procName">�洢������</param>
        /// <param name="param">�洢���̲���</param>
        /// <returns>���ز����б�</returns>
        public  List<T1> QueryListByProc<T, T1>(string procName, T param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Query<T1>(procName, param, commandType: CommandType.StoredProcedure) as List<T1>;
            }
        }

        /// <summary>
        /// ִ��SQL
        /// </summary>
        /// <typeparam name="T">ִ�в���</typeparam>
        /// <param name="insertSql">Ҫִ�е�sql���</param>
        /// <param name="param">ִ�в���</param>
        /// <returns>��Ӱ�������</returns>
        public  int ExecuteSql<T>(string insertSql, T param)
        {
            using (IDbConnection conn = CreateDbConnection())
            {
                return conn.Execute(insertSql, param);
            }
        }
    }
}
