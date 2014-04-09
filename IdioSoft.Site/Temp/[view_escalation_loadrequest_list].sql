drop view [View_Escalation_LoadRequest_List]
go

/****** Object:  View [dbo].[View_Escalation_LoadRequest_List]    Script Date: 2014/1/11 12:13:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Escalation_LoadRequest_List]
AS
SELECT        s.RequestID, s.ProductName, s.ProductDesc, s.ServiceType, m.MLFB, m.SerialNo, s.AppCompanyName, s.EnduserCompanyName, s.NotificationNo
FROM            dbo.webInfo_ServiceRequest_Info AS s INNER JOIN
                         dbo.webInfo_Servicerequest_Material_Info AS m ON s.ID = m.uRequestID
WHERE        (s.isCancel = 0) AND (s.isSubmit = 1) AND (s.isDel = 0)

GO

 

