﻿using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class SaleReturn
    {
        InterfaceLayer Ope = new InterfaceLayer();

        BLL.Validation Val = new BLL.Validation();
        public SaleReturn_Property Save(SaleReturn_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@sale_return_id", pClsProperty.sale_return_id, DbType.Int32);
                Request.AddParams("@invoice_no", pClsProperty.invoice_no, DbType.String);
                Request.AddParams("@return_date", pClsProperty.return_date, DbType.Date);
                Request.AddParams("@return_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32);
                Request.AddParams("@party_id", pClsProperty.Party_Id, DbType.Int32);
                Request.AddParams("@broker_id", pClsProperty.Broker_Id, DbType.Int32);
                Request.AddParams("@delivery_type_id", pClsProperty.delivery_type_id, DbType.Int32);
                Request.AddParams("@total_pcs", pClsProperty.total_pcs, DbType.Decimal);
                Request.AddParams("@total_carat", pClsProperty.total_carat, DbType.Decimal);
                Request.AddParams("@term_days", pClsProperty.Term_Days, DbType.Int32);
                Request.AddParams("@add_on_days", pClsProperty.Add_On_Days, DbType.Int32);
                Request.AddParams("@remarks", pClsProperty.remarks, DbType.String);
                Request.AddParams("@special_remarks", pClsProperty.Special_Remark, DbType.String);
                Request.AddParams("@client_remarks", pClsProperty.Client_Remark, DbType.String);
                Request.AddParams("@payment_remarks", pClsProperty.Payment_Remark, DbType.String);
                Request.AddParams("@gross_amount", pClsProperty.Gross_Amount, DbType.Decimal);
                Request.AddParams("@brokerage_per", pClsProperty.Brokerage_Per, DbType.Decimal);
                Request.AddParams("@brokerage_amount", pClsProperty.Brokerage_Amt, DbType.Decimal);
                Request.AddParams("@discount_per", pClsProperty.Discount_Per, DbType.Decimal);
                Request.AddParams("@discount_amount", pClsProperty.Discount_Amt, DbType.Decimal);
                Request.AddParams("@interest_per", pClsProperty.Interest_Per, DbType.Decimal);
                Request.AddParams("@interest_amount", pClsProperty.Interest_Amt, DbType.Decimal);
                Request.AddParams("@shipping", pClsProperty.Shipping_Charge, DbType.Decimal);
                Request.AddParams("@net_amount", pClsProperty.net_amount, DbType.Decimal);
                Request.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                Request.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                Request.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                Request.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);
                Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int64);

                Request.CommandText = BLL.TPV.SProc.TRN_SaleReturn_Master_Save;
                Request.CommandType = CommandType.StoredProcedure;

                DataTable p_dtbMasterId = new DataTable();
                if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                {
                    if (Conn != null)
                        Conn.Inter1.GetDataTable(DBConnections.ConnectionString, DBConnections.ProviderName, p_dtbMasterId, Request, pEnum);
                    else
                        Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, p_dtbMasterId, Request);
                }
                else
                {
                    if (Conn != null)
                        Conn.Inter2.GetDataTable(DBConnections.ConnectionDeveloper, DBConnections.ProviderDeveloper, p_dtbMasterId, Request, pEnum);
                    else
                        Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, p_dtbMasterId, Request);
                }
                if (p_dtbMasterId != null)
                {
                    if (p_dtbMasterId.Rows.Count > 0)
                    {
                        pClsProperty.sale_return_id = Convert.ToInt32(p_dtbMasterId.Rows[0][0]);
                    }
                }
                else
                {
                    pClsProperty.sale_return_id = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pClsProperty;
        }
        public int Save_Detail(SaleReturn_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit, BeginTranConnection Conn = null)
        {
            try
            {
                int IntRes = 0;
                Request RequestDetails = new Request();

                RequestDetails.AddParams("@sale_return_id", pClsProperty.sale_return_id, DbType.Int32);
                RequestDetails.AddParams("@return_detail_id", pClsProperty.return_detail_id, DbType.Int32);
                RequestDetails.AddParams("@assort_id", pClsProperty.assort_id, DbType.Int32);
                RequestDetails.AddParams("@sieve_id", pClsProperty.sieve_id, DbType.Int32);
                RequestDetails.AddParams("@sub_sieve_id", pClsProperty.sub_sieve_id, DbType.Int32);
                RequestDetails.AddParams("@pcs", pClsProperty.pcs, DbType.Int32);
                RequestDetails.AddParams("@carat", pClsProperty.carat, DbType.Decimal);
                RequestDetails.AddParams("@rate", pClsProperty.rate, DbType.Decimal);
                RequestDetails.AddParams("@amount", pClsProperty.amount, DbType.Decimal);
                RequestDetails.AddParams("@discount", pClsProperty.discount, DbType.Decimal);
                RequestDetails.AddParams("@currency_id", GlobalDec.gEmployeeProperty.currency_id, DbType.Int32);
                RequestDetails.AddParams("@rate_type_id", GlobalDec.gEmployeeProperty.rate_type_id, DbType.Int32);
                RequestDetails.AddParams("@form_id", pClsProperty.form_id, DbType.Int32);
                RequestDetails.AddParams("@user_id", GlobalDec.gEmployeeProperty.user_id, DbType.Int32);
                RequestDetails.AddParams("@ip_address", GlobalDec.gStrComputerIP, DbType.String);
                RequestDetails.AddParams("@return_date", pClsProperty.return_date, DbType.Date);
                RequestDetails.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
                RequestDetails.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
                RequestDetails.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
                RequestDetails.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);
                RequestDetails.AddParams("@old_carat", pClsProperty.old_carat, DbType.Decimal);
                RequestDetails.AddParams("@old_pcs", pClsProperty.old_pcs, DbType.Int32);
                RequestDetails.AddParams("@flag", pClsProperty.flag, DbType.Int32);
                RequestDetails.AddParams("@old_assort_id", pClsProperty.old_assort_id, DbType.Int32);
                RequestDetails.AddParams("@old_sieve_id", pClsProperty.old_sieve_id, DbType.Int32);
                RequestDetails.AddParams("@old_sub_sieve_id", pClsProperty.old_sub_sieve_id, DbType.Int32);
                RequestDetails.AddParams("@current_rate", pClsProperty.current_rate, DbType.Decimal);
                RequestDetails.AddParams("@current_amount", pClsProperty.current_amount, DbType.Decimal);
                RequestDetails.AddParams("@entry_date", Val.DBDate(GlobalDec.gStr_SystemDate), DbType.Date);
                RequestDetails.AddParams("@entry_time", GlobalDec.gStr_SystemTime, DbType.String);

                RequestDetails.CommandText = BLL.TPV.SProc.TRN_SaleReturn_Detail_Save;
                RequestDetails.CommandType = CommandType.StoredProcedure;
                if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                {
                    if (Conn != null)
                        IntRes = Conn.Inter1.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails, pEnum);
                    else
                        IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionString, DBConnections.ProviderName, RequestDetails);
                }
                else
                {
                    if (Conn != null)
                        IntRes = Conn.Inter2.ExecuteNonQuery(DBConnections.ConnectionDeveloper, DBConnections.ProviderDeveloper, RequestDetails, pEnum);
                    else
                        IntRes = Ope.ExecuteNonQuery(DBConnections.ConnectionDeveloper, DBConnections.ProviderDeveloper, RequestDetails);
                }
                return IntRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetData(string p_dtpFromDate, string p_dtpToDate)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_SaleReturn_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@From_Date", p_dtpFromDate, DbType.Int32);
            Request.AddParams("@To_Date", p_dtpToDate, DbType.Int32);
            Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32);
            Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32);
            Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32);
            Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32);

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
        public DataTable GetDataDetails(int p_numID)
        {
            DataTable DTab = new DataTable();
            try
            {
                Request Request = new Request();
                Request.CommandText = BLL.TPV.SProc.TRN_SaleReturn_GetDetailsData;
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("@p_numBT_ID", p_numID, DbType.Int32);

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
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return DTab;
            }
        }
        public DataTable GetStockCarat(int p_numCompany_id, int p_numBranch_id, int p_numLocation_id, int p_numDepartment_id, int p_numAssort_id, int p_numSieve_id)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = BLL.TPV.SProc.TRN_BT_GetStockCarat;
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Company_id", p_numCompany_id, DbType.Int32);
            Request.AddParams("@Branch_id", p_numBranch_id, DbType.Int32);
            Request.AddParams("@Location_id", p_numLocation_id, DbType.Int32);
            Request.AddParams("@Department_id", p_numDepartment_id, DbType.Int32);
            Request.AddParams("@Assort_id", p_numAssort_id, DbType.Int32);
            Request.AddParams("@Sieve_id", p_numSieve_id, DbType.Int32);

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
    }
}
