﻿using BLL.PropertyClasses.Master;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class ConfigProcessMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public int Save(ConfigProcess_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.AddParams("@process_id", pClsProperty.process_id, DbType.Int32);
            Request.AddParams("@sub_process_id", pClsProperty.sub_process_id, DbType.String);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32);
            Request.AddParams("@employee_id", pClsProperty.employee_id, DbType.Int32);
            Request.AddParams("@active", pClsProperty.active, DbType.Int32);
            Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
            Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
            Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
            Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

            Request.CommandText = BLL.TPV.SProc.MST_Config_Process_Save;
            Request.CommandType = CommandType.StoredProcedure;
            if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            {
                return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            }
            else
            {
                return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            }
        }
        public DataTable GetData(int company_id, int branch_id, int location_id, int department_id)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = BLL.TPV.SProc.MST_config_Emp_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@company_id", company_id, DbType.Int32);
            Request.AddParams("@branch_id", branch_id, DbType.Int32);
            Request.AddParams("@location_id", location_id, DbType.Int32);
            Request.AddParams("@department_id", department_id, DbType.Int32);
            if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            {
                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            }
            else
            {
                Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request);
            }
            return DTab;
        }
        public int Delete(ConfigProcess_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@employee_id", pClsProperty.employee_id, DbType.Int32);
            Request.AddParams("@process_id", pClsProperty.process_id, DbType.Int32);
            Request.AddParams("@type", pClsProperty.type, DbType.String);
            Request.CommandText = BLL.TPV.SProc.MST_Config_Process_Save;
            Request.CommandType = CommandType.StoredProcedure;
            if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            {
                return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            }
            else
            {
                return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            }
        }
        public object GetProcessData(int employee_id, int process_id)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@employee_id", employee_id, DbType.Int32);
            Request.AddParams("@process_id", process_id, DbType.Int32);
            Request.CommandText = TPV.SProc.MST_Config_Process_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            {
                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            }
            else
            {
                Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request);
            }
            DataTable DTab1 = new DataTable();
            DataRow DRow = DTab1.NewRow();
            DRow.Table.Columns.Add("sub_process_id");
            DRow.Table.Columns.Add("sub_process_name");

            string StrId = "";
            string StrName = "";
            foreach (DataRow DR in DTab.Rows)
            {
                StrId = StrId + DR["sub_process_id"] + ",";
                StrName = StrName + DR["sub_process_name"] + ",";
            }

            if (StrId != "")
            {
                StrId = StrId.Substring(0, StrId.Length - 1);
                StrName = StrName.Substring(0, StrName.Length - 1);
            }
            DRow["sub_process_id"] = StrId;
            DRow["sub_process_name"] = StrName;
            return DRow;
        }
    }
}
