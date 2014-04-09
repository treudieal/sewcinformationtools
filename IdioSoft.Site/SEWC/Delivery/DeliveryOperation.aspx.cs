using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdioSoft.Site.ClassLibrary;

using System.Data;
using IdioSoft.Business.Method;

namespace IdioSoft.Site.SEWC.Delivery
{
    public partial class DeliveryOperation : IPage
    {
        public string OperID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            OperID = Request.funString_RequestFormValue("sID");
            cboWarranty.subComboBox_LoadItems("select Warranty from CallCenter_Basic_Warranty_Info", 0, new ListItem("", ""));
            if (funBoolean_DetailExist())
            {
                subDB_Detail();
            }
            else
            {
                subDB_DefaultInfo();
            }
            if (!IsPostBack)
            {
                string OperationType = Request.funString_RequestFormValue("OperationType").ToString().Trim().ToLower();
                if (OperationType == "detail")
                {
                    btnSave.Visible = false;
                    btnSubmit.Visible = false;

                    txtRequestID.Attributes.Add("disabled", "disabled");
                    txtMLFB.Attributes.Add("disabled", "disabled");
                    txtSerialNo.Attributes.Add("disabled", "disabled");
                    txtQty.Attributes.Add("disabled", "disabled");
                    cboServiceType.Attributes.Add("disabled", "disabled");
                    cboWarranty.Attributes.Add("disabled", "disabled");
                    txtWeight.Attributes.Add("disabled", "disabled");
                    dtpissueDNDate.Attributes.Add("disabled", "disabled");
 
                    txtNewSerialNo.Attributes.Add("disabled", "disabled");
                    dtpDeliveryDate.Attributes.Add("disabled", "disabled");
                    txtTrackingNo.Attributes.Add("disabled", "disabled");
                    txtReceiveCompany.Attributes.Add("disabled", "disabled");
                    txtReceiver.Attributes.Add("disabled", "disabled");
                    txtReceiverTel.Attributes.Add("disabled", "disabled");
                    txtReceiverAddress.Attributes.Add("disabled", "disabled");

                }
            }
        }

        public bool funBoolean_DetailExist()
        {
            string strSQL = "select count(*) from SEWC_Delivery_Info where uRequestID = '" + OperID + "'";
            return objDbSQLAccess.funString_SQLExecuteScalar(strSQL).funInt_StringToInt(0) > 0;
        }

        public void subDB_DefaultInfo()
        {
            string strSQL = @"SELECT     RequestID, ReceiveCompany, DeliveryType, Receiver, ReceiverTel, ReceiverAddress, Warranty, ServiceType
FROM         dbo.webInfo_ServiceRequest_Info  where ID = '" + OperID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                cboWarranty.subComboBox_SelectItemByText(ds.Tables[0].Rows[0]["Warranty"].ToString());
                txtRequestID.Value = ds.Tables[0].Rows[0]["RequestID"].ToString();
                txtReceiveCompany.Value = ds.Tables[0].Rows[0]["ReceiveCompany"].ToString();
                txtReceiver.Value = ds.Tables[0].Rows[0]["Receiver"].ToString();
                txtReceiverTel.Value = ds.Tables[0].Rows[0]["ReceiverTel"].ToString();
                txtReceiverAddress.Value = ds.Tables[0].Rows[0]["ReceiverAddress"].ToString();

                cboServiceType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceType"].ToString());
                if (ds.Tables[0].Rows[0]["ServiceType"].ToString().Trim().ToLower() != "exch")
                {
                    trNew.Attributes.Add("style", "display:none;");
                }
                else
                {
                    trNew.Attributes.Remove("style");
                }
            }

            strSQL = "select top 1 MLFB,SerialNo, Quantity from webInfo_Servicerequest_Material_Info where uRequestID = '" + OperID + "'";
            DataSet dsItem = new DataSet();
            dsItem = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (dsItem != null && dsItem.Tables[0].Rows.Count > 0)
            {
                txtMLFB.Value = dsItem.Tables[0].Rows[0]["MLFB"].ToString();
                txtSerialNo.Value = dsItem.Tables[0].Rows[0]["SerialNo"].ToString();
                txtQty.Value = dsItem.Tables[0].Rows[0]["Quantity"].ToString();
            }
        }

        public void subDB_Detail()
        {
            string strSQL = "";

            strSQL = @"SELECT  d.MLFB, d.SerialNo, d.Qty, d.[WeightUnit], d.DeliveryDate, d.TrackingNo, d.ReceiveCompany, d.Receiver, d.ReceiverTel, d.ReceiverAddress, d.NewMLFB, d.NewSerialNo, 
                      s.RequestID , s.ServiceType, s.ProductName, s.ProductDesc, s.Warranty,d.issueDNDate
                     FROM dbo.SEWC_Delivery_Info AS d INNER JOIN
                      dbo.webInfo_ServiceRequest_Info AS s ON d.uRequestID = s.ID   where d.uRequestID = '" + OperID + "'";
            DataSet ds = objDbSQLAccess.funDataset_SQLExecuteNonQuery(strSQL);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtRequestID.Value = ds.Tables[0].Rows[0]["RequestID"].ToString();
                txtMLFB.Value = ds.Tables[0].Rows[0]["MLFB"].ToString();
                txtSerialNo.Value = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                txtQty.Value = ds.Tables[0].Rows[0]["Qty"].ToString();
                cboWarranty.subComboBox_SelectItemByText(ds.Tables[0].Rows[0]["Warranty"].ToString());
                txtWeight.Value = ds.Tables[0].Rows[0]["WeightUnit"].ToString();
                dtpDeliveryDate.Value = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
                txtTrackingNo.Value = ds.Tables[0].Rows[0]["TrackingNo"].ToString();
                //ReceiveCompany, Receiver, ReceiverTel, ReceiverAddress
                txtReceiveCompany.Value = ds.Tables[0].Rows[0]["ReceiveCompany"].ToString();
                txtReceiver.Value = ds.Tables[0].Rows[0]["Receiver"].ToString();
                txtReceiverTel.Value = ds.Tables[0].Rows[0]["ReceiverTel"].ToString();
                txtReceiverAddress.Value = ds.Tables[0].Rows[0]["ReceiverAddress"].ToString();
             
                txtNewSerialNo.Value = ds.Tables[0].Rows[0]["NewSerialNo"].ToString();
                cboServiceType.subComboBox_SelectItemByValue(ds.Tables[0].Rows[0]["ServiceType"].ToString());
                dtpissueDNDate.Value = ds.Tables[0].Rows[0]["issueDNDate"].ToString();
                if (ds.Tables[0].Rows[0]["ServiceType"].ToString().Trim().ToLower() != "exch")
                {
                    trNew.Attributes.Add("style", "display:none;");
                }
                else
                {
                    trNew.Attributes.Remove("style");
                }
            }

        }

        public string PuRequestIDs
        {
            get
            {
                string sID = Request["sID"].ToString();
                return sID;
            }
        }
    }
}