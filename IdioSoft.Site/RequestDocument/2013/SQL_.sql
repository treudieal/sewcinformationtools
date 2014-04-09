USE [Informationtools20130528]
GO
/****** Object:  Table [dbo].[SEWC_RepairItem_Info]    Script Date: 08/28/2013 09:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_RepairItem_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[PCBA5ENo] [nvarchar](100) NOT NULL,
	[ComponentLocation] [nvarchar](100) NOT NULL,
	[RepairedComponentA5E] [nvarchar](100) NOT NULL,
	[FailureCodeI] [nvarchar](100) NOT NULL,
	[FailureCodeII] [nvarchar](100) NOT NULL,
	[FailureCodeIII] [nvarchar](100) NOT NULL,
	[FailureType] [nvarchar](100) NOT NULL,
	[RepairAction] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SEWC_RepairItem_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_RepairItem_Info] ([ID], [uRequestID], [PCBA5ENo], [ComponentLocation], [RepairedComponentA5E], [FailureCodeI], [FailureCodeII], [FailureCodeIII], [FailureType], [RepairAction]) VALUES (N'b85d2b44-fa30-46e8-97ab-518fd3352ef6', N'323b3c23-0081-4972-9b49-c3b9d28173db', N'', N'', N'', N'', N'null', N'null', N'', N'')
INSERT [dbo].[SEWC_RepairItem_Info] ([ID], [uRequestID], [PCBA5ENo], [ComponentLocation], [RepairedComponentA5E], [FailureCodeI], [FailureCodeII], [FailureCodeIII], [FailureType], [RepairAction]) VALUES (N'a2e7f37c-121c-4c30-a3a5-70660a99c058', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'cc', N'C', N'ff', N'', N'', N'', N'1', N'2')
INSERT [dbo].[SEWC_RepairItem_Info] ([ID], [uRequestID], [PCBA5ENo], [ComponentLocation], [RepairedComponentA5E], [FailureCodeI], [FailureCodeII], [FailureCodeIII], [FailureType], [RepairAction]) VALUES (N'18e73a1f-a9b8-4a83-9fb1-883807ece7f5', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'A', N'C', N'B', N'', N'', N'', N'1', N'2')
/****** Object:  Table [dbo].[SEWC_Repair_Info]    Script Date: 08/28/2013 09:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Repair_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[RequestID] [nvarchar](100) NOT NULL,
	[WorkStationCode] [nvarchar](50) NOT NULL,
	[CusomerName] [nvarchar](255) NOT NULL,
	[MLFB] [nvarchar](255) NOT NULL,
	[SerialNo] [nvarchar](255) NOT NULL,
	[Qty] [int] NOT NULL,
	[FuntinalState(original)] [nvarchar](255) NOT NULL,
	[FuntinalState(latest)] [nvarchar](255) NOT NULL,
	[Firmware(original)] [nvarchar](255) NOT NULL,
	[Firmware(latest)] [nvarchar](255) NOT NULL,
	[Warranty] [nvarchar](50) NOT NULL,
	[ConfirmWarrantyDate] [datetime] NULL,
	[ServiceType] [nvarchar](50) NOT NULL,
	[StartRepairDate] [datetime] NULL,
	[EndRepairDate] [datetime] NULL,
	[Engineer] [nvarchar](50) NOT NULL,
	[RepairResult] [nvarchar](300) NOT NULL,
	[Remarks] [nvarchar](300) NOT NULL,
	[isSave] [bit] NOT NULL,
	[isSubmit] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
 CONSTRAINT [PK_表SEWC_Repair_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_Repair_Info] ([ID], [uRequestID], [RequestID], [WorkStationCode], [CusomerName], [MLFB], [SerialNo], [Qty], [FuntinalState(original)], [FuntinalState(latest)], [Firmware(original)], [Firmware(latest)], [Warranty], [ConfirmWarrantyDate], [ServiceType], [StartRepairDate], [EndRepairDate], [Engineer], [RepairResult], [Remarks], [isSave], [isSubmit], [CreateDate], [CreateUser]) VALUES (N'3fc2e805-699f-4d77-813e-9b1366b69089', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'2013053985', N'null', N'左权金隅水泥有限公司', N'A001', N'B0001', 10, N'', N'', N'', N'', N'In Warranty', NULL, N'IHR', CAST(0x0000A20D00000000 AS DateTime), CAST(0x0000A22900000000 AS DateTime), N'liu fang', N'11', N'222', 0, 1, CAST(0x0000A227012814E0 AS DateTime), 475)
INSERT [dbo].[SEWC_Repair_Info] ([ID], [uRequestID], [RequestID], [WorkStationCode], [CusomerName], [MLFB], [SerialNo], [Qty], [FuntinalState(original)], [FuntinalState(latest)], [Firmware(original)], [Firmware(latest)], [Warranty], [ConfirmWarrantyDate], [ServiceType], [StartRepairDate], [EndRepairDate], [Engineer], [RepairResult], [Remarks], [isSave], [isSubmit], [CreateDate], [CreateUser]) VALUES (N'1c5517cd-11f4-47c8-b825-d8c731b0c40a', N'323b3c23-0081-4972-9b49-c3b9d28173db', N'2013053984', N'A', N'Assembly ', N'AAA', N'BBB', 10, N'', N'', N'', N'', N'In Warranty', NULL, N'IHR', NULL, NULL, N'liu fang', N'', N'', 0, 0, CAST(0x0000A22701622D24 AS DateTime), 475)
/****** Object:  Table [dbo].[SEWC_Quotation_Info]    Script Date: 08/28/2013 09:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Quotation_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[ProductType] [nvarchar](50) NOT NULL,
	[MLFB] [nvarchar](50) NOT NULL,
	[Component] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SEWC_Quotation_Info_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEWC_IssueRepairOrder_Info]    Script Date: 08/28/2013 09:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_IssueRepairOrder_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[RequestID] [nvarchar](100) NOT NULL,
	[MLFB] [nvarchar](100) NOT NULL,
	[SerialNo] [nvarchar](100) NOT NULL,
	[Qty] [int] NOT NULL,
	[ReceiveDefectiveDate(T3)] [datetime] NULL,
	[Warranty] [nvarchar](100) NOT NULL,
	[ConfirmCompleteDate] [datetime] NULL,
	[IssueRepairOrderDate] [datetime] NULL,
	[Repairble] [bit] NOT NULL,
	[ReveiveBankReceipt] [bit] NOT NULL,
	[QuotationDate] [datetime] NULL,
	[IsGoodWill] [bit] NOT NULL,
	[GoodWillNo] [nvarchar](100) NOT NULL,
	[CustomerConfirmDate] [datetime] NULL,
	[CancelReason] [nvarchar](300) NOT NULL,
	[CancelDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[isSubmit] [bit] NOT NULL,
 CONSTRAINT [PK_SEWC_IssueRepairOrder_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_IssueRepairOrder_Info] ([ID], [uRequestID], [RequestID], [MLFB], [SerialNo], [Qty], [ReceiveDefectiveDate(T3)], [Warranty], [ConfirmCompleteDate], [IssueRepairOrderDate], [Repairble], [ReveiveBankReceipt], [QuotationDate], [IsGoodWill], [GoodWillNo], [CustomerConfirmDate], [CancelReason], [CancelDate], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [isSubmit]) VALUES (N'03cb6ab3-1b19-447a-b713-1e8514668527', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'2013053985', N'A001', N'B0001', 10, CAST(0x0000A22800000000 AS DateTime), N'In Warranty', CAST(0x0000A20D00000000 AS DateTime), CAST(0x0000A22800000000 AS DateTime), 0, 1, NULL, 0, N'200001', NULL, N'', NULL, CAST(0x0000A227012793F8 AS DateTime), 475, CAST(0x0000A2270127BE28 AS DateTime), 475, 1)
INSERT [dbo].[SEWC_IssueRepairOrder_Info] ([ID], [uRequestID], [RequestID], [MLFB], [SerialNo], [Qty], [ReceiveDefectiveDate(T3)], [Warranty], [ConfirmCompleteDate], [IssueRepairOrderDate], [Repairble], [ReveiveBankReceipt], [QuotationDate], [IsGoodWill], [GoodWillNo], [CustomerConfirmDate], [CancelReason], [CancelDate], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [isSubmit]) VALUES (N'5b4b3cf9-2607-44de-9dd9-f0b8621c3a01', N'323b3c23-0081-4972-9b49-c3b9d28173db', N'2013053984', N'AAA', N'BBB', 10, CAST(0x0000A20D00000000 AS DateTime), N'In Warranty', NULL, CAST(0x0000A2270160FDA0 AS DateTime), 0, 0, NULL, 0, N'', NULL, N'', NULL, CAST(0x0000A22701610700 AS DateTime), 475, NULL, NULL, 1)
/****** Object:  Table [dbo].[SEWC_GoodsReceipt_Info]    Script Date: 08/28/2013 09:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_GoodsReceipt_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[RequestID] [nvarchar](50) NOT NULL,
	[SEWCNotificationNo] [nvarchar](100) NOT NULL,
	[ProductDesc] [nvarchar](50) NOT NULL,
	[MLFB] [nvarchar](100) NOT NULL,
	[SerialNo] [nvarchar](100) NOT NULL,
	[Qty] [int] NOT NULL,
	[Warranty] [nvarchar](100) NOT NULL,
	[ReceiveDefectiveDate(T3)] [datetime] NULL,
	[IsReject] [bit] NOT NULL,
	[RejectReason] [nvarchar](300) NOT NULL,
	[RejectFile] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[isSubmit] [bit] NOT NULL,
 CONSTRAINT [PK_SEWC_GoodsReceipt_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_GoodsReceipt_Info] ([ID], [uRequestID], [RequestID], [SEWCNotificationNo], [ProductDesc], [MLFB], [SerialNo], [Qty], [Warranty], [ReceiveDefectiveDate(T3)], [IsReject], [RejectReason], [RejectFile], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [isSubmit]) VALUES (N'ed7639b7-7779-4731-9879-1c1a2396fa1b', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'2013053985', N'100001', N'', N'A001', N'B0001', 10, N'In Warranty', CAST(0x0000A22800000000 AS DateTime), 0, N'', N'pro.sql', CAST(0x0000A227012113E8 AS DateTime), 475, CAST(0x0000A22701217658 AS DateTime), 475, 1)
INSERT [dbo].[SEWC_GoodsReceipt_Info] ([ID], [uRequestID], [RequestID], [SEWCNotificationNo], [ProductDesc], [MLFB], [SerialNo], [Qty], [Warranty], [ReceiveDefectiveDate(T3)], [IsReject], [RejectReason], [RejectFile], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [isSubmit]) VALUES (N'5eeab6cc-9fea-4f9c-b87b-235789f77b17', N'323b3c23-0081-4972-9b49-c3b9d28173db', N'2013053984', N'', N'', N'AAA', N'BBB', 10, N'In Warranty', CAST(0x0000A20D00000000 AS DateTime), 0, N'', N'ViewSQL.sql', CAST(0x0000A22701293B04 AS DateTime), 475, CAST(0x0000A22701294338 AS DateTime), 475, 1)
INSERT [dbo].[SEWC_GoodsReceipt_Info] ([ID], [uRequestID], [RequestID], [SEWCNotificationNo], [ProductDesc], [MLFB], [SerialNo], [Qty], [Warranty], [ReceiveDefectiveDate(T3)], [IsReject], [RejectReason], [RejectFile], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [isSubmit]) VALUES (N'e26a0830-de55-4eed-b918-811fd94df931', N'd89f9605-5023-474a-a9a3-3735859bb5c3', N'2013053990', N'30000022', N'', N'', N'', 0, N'In Warranty', CAST(0x0000A2270164AE28 AS DateTime), 0, N'', N'', CAST(0x0000A2270160E504 AS DateTime), 475, NULL, NULL, 1)
/****** Object:  Table [dbo].[SEWC_Delivery_Info]    Script Date: 08/28/2013 09:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Delivery_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[uRequestID] [uniqueidentifier] NOT NULL,
	[RequestID] [nvarchar](100) NOT NULL,
	[MLFB] [nvarchar](100) NOT NULL,
	[SerialNo] [nvarchar](100) NOT NULL,
	[Qty] [int] NOT NULL,
	[Weight(Unit)] [nvarchar](100) NOT NULL,
	[Warranty] [nvarchar](100) NOT NULL,
	[ReceiveDefectiveDate(T3)] [datetime] NULL,
	[ReceiveRepairedDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[TrackingNo] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[DeliveryType] [nvarchar](50) NOT NULL,
	[ReceiveCompany] [nvarchar](100) NOT NULL,
	[Receiver] [nvarchar](50) NOT NULL,
	[ReceiverTel] [nvarchar](50) NOT NULL,
	[ReceiverAddress] [nvarchar](200) NOT NULL,
	[isSubmit] [bit] NOT NULL,
 CONSTRAINT [PK_SEWC_Delivery_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_Delivery_Info] ([ID], [uRequestID], [RequestID], [MLFB], [SerialNo], [Qty], [Weight(Unit)], [Warranty], [ReceiveDefectiveDate(T3)], [ReceiveRepairedDate], [DeliveryDate], [TrackingNo], [CreateDate], [CreateUser], [ModifyDate], [ModifyUser], [DeliveryType], [ReceiveCompany], [Receiver], [ReceiverTel], [ReceiverAddress], [isSubmit]) VALUES (N'd248598e-5f67-406e-8c26-229a3c273871', N'8c88fd2a-8cfe-2859-2201-8e869f30ecc8', N'2013053985', N'A001', N'B0001', 10, N'1000', N'In Warranty', CAST(0x0000A22800000000 AS DateTime), CAST(0x0000A21100000000 AS DateTime), CAST(0x0000A21B00000000 AS DateTime), N'1000', CAST(0x0000A2270128C4A8 AS DateTime), 475, CAST(0x0000A2270128F4B4 AS DateTime), 475, N'', N'', N'', N'', N'', 1)
/****** Object:  Table [dbo].[SEWC_Basic_WorkStationCode_Info]    Script Date: 08/28/2013 09:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Basic_WorkStationCode_Info](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StationCode] [nvarchar](50) NOT NULL,
	[IsDel] [int] NOT NULL,
 CONSTRAINT [PK_SEWC_Basic_WorkStationCode_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SEWC_Basic_WorkStationCode_Info] ON
INSERT [dbo].[SEWC_Basic_WorkStationCode_Info] ([ID], [StationCode], [IsDel]) VALUES (1, N'A', 0)
INSERT [dbo].[SEWC_Basic_WorkStationCode_Info] ([ID], [StationCode], [IsDel]) VALUES (2, N'B', 0)
SET IDENTITY_INSERT [dbo].[SEWC_Basic_WorkStationCode_Info] OFF
/****** Object:  Table [dbo].[SEWC_Basic_Quotation_Info]    Script Date: 08/28/2013 09:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Basic_Quotation_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductType] [nvarchar](50) NOT NULL,
	[MLFB] [nvarchar](50) NOT NULL,
	[Component] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[OrderNo] [int] NOT NULL,
 CONSTRAINT [PK_SEWC_Basic_Quotation_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'fcac2c6c-4ed8-4903-9448-002021c05aa4', N'V60', N'A001', N'Power board&IGBT', CAST(1750.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'85774e3a-82f5-4b81-bdac-0048abc24bd0', N'V60', N'A001', N'Power board&IGBT', CAST(1160.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1a1aed88-d680-4d99-b1bc-008637cde0df', N'V60', N'A001', N'Power board&IGBT', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'62008958-6052-4c8c-a11c-008b4da30fbd', N'MP277 10" KEY', N'6AV6643-0DD01-1AX0', N'Inverter exchange', CAST(420.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'8c1c12a9-fe2f-4112-92a2-00e45a1aa921', N'S7-1200', N'6ES7211-1HD30-0XB0', N'Total', CAST(537.76 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'15816722-92c5-4b9d-8963-026d7efe42af', N'MP277 10" touch', N'6AV6643-0CD01-1AX1', N'Inverter+Mounting sheet metal', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'c123c184-15c6-4dd8-bc3c-02788128acc3', N'V10', N'6S6SL3217-0CE25-5UA1', N'5UA1 Plastic housing ', CAST(860.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd3ab398e-2676-41fb-96d6-066884fa6601', N'V10', N'6SL3217-0CE31-1UA1', N'Plastic housing+Heatsink', CAST(1230.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'5abf53c7-3780-4516-812c-0723544ae1b8', N'S7-200 CN', N'6ES7214-1AD23-0XB8', N'Total', CAST(495.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f4310718-ac5a-488f-975b-080da1bc2704', N'V60', N'6SL3210-5CC16-0UA0', N'Power board&IGBT', CAST(1230.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'67630449-0fa5-406e-a7bf-0927492bad13', N'S7-200', N'6ES7212-1BB23-0XB0', N'Total', CAST(378.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'dc7443ee-2bf7-4c1f-b620-0a6e5f33b2c2', N'TP177 6" touch', N'6AV6642-0AA11-0AX1', N'PCBA', CAST(870.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b31dbe5a-d037-4ade-b9d6-0ae41c8419fa', N'S7-200', N'6ES7212-1AB23-0XB0', N'Total', CAST(360.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f3d624f2-c668-4229-a569-0cb0b40c3775', N'V10', N'6SL3217-0CE27-5UA1', N'Plastic housing', CAST(860.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'858d63f1-198c-418d-b5f6-0e4f961b46b1', N'TP177 6" touch', N'6AV6642-0BA01-1AX1', N'PCBA', CAST(1260.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a56c817e-7597-4d81-97f6-0f43a33545a4', N'S7-200 CN', N'6ES7214-1BD23-0XB8', N'Total', CAST(540.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'23616262-6812-4c3f-a933-0fb98d18878c', N'V60', N'6SL3210-5CC16-0UA0', N'control board', CAST(1460.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f8aca7cd-5923-472c-ade5-0fc0211e3663', N'S7-1200', N'6ES7212-1AD30-0XB0', N'Total', CAST(584.01 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a34c50f2-abf6-4edc-ad85-11008a7ec5a4', N'MP277 8" touch', N'6AV6643-0CB01-1AX5', N'LCD', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd9bee878-a3a7-4bf5-beb0-135af51c05b6', N'V10', N'6SL3217-0CE31-8UA1', N'Plastic housing', CAST(880.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1dadf41b-041d-4ae1-8940-13da4d2ecf41', N'KTP400/600', N'6AV6647-0AC11-3AX0', N'Total(More than 2 defects)', CAST(1589.29 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd2ee0ed0-5262-4096-81d7-143f6cb7002c', N'KTP400/600', N'', N'', CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'233dff10-8179-47bb-b636-1503b87f7e81', N'TP177 6" touch', N'6AV6642-0BC01-1AX0', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e966b9d0-50a1-4bad-a5cc-150a76571340', N'V60', N'6SL3210-5CC16-0UA0', N'operation board,Heatsink & housing', CAST(1290.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'03b191ce-3065-4f7f-a637-1646f4e53ff1', N'S7-200', N'6ES7214-1BD23-0XB0', N'Total', CAST(540.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1ec32c60-4ba3-45fa-87e6-1646fd6ae87a', N'S7-200', N'6ES7214-1AD23-0XB0', N'Total', CAST(495.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'993e19a0-ff20-4987-bb00-16a79d16c4d0', N'TP177 6" touch', N'6AV6640-0CA11-0AX1', N'PCBA', CAST(780.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'425bb967-fdae-4105-a8da-1883850c7f4a', N'S7-200 CN', N'6ES7214-2AD23-0XB8', N'Total', CAST(304.13 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'558fdd86-e48a-472b-9d90-1a5fb347f2e1', N'KTP400/600', N'6AV6647-0AC11-3AX0', N'外壳损坏', CAST(653.42 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'5a651a73-6a66-407a-9061-1ba86be74e21', N'V10', N'6S6SL3217-0CE25-5UA1', N'Heatsink', CAST(1160.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'845a23ba-a62b-4236-8d96-1cd3386fd0a8', N'MP277 10" touch', N'6AV6643-0CD01-1AX1', N'PCBA', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'212cb886-ac36-4cb7-8610-1e6b1da42b16', N'', N'', N'Top Moulding', CAST(660.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'fb27729a-9946-4f57-9a92-1f61ea18d327', N'S7-1200', N'6ES7212-1BD30-0XB0', N'Total', CAST(636.53 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1edfe9ef-75c5-469f-b92f-1fa3edc35c0d', N'S7-200', N'6ES7214-2BD23-0XB0', N'Total', CAST(291.62 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'45c47079-7297-42d6-aa26-20b2471363b0', N'V60', N'6SL3210-5CC21-0UA0', N'Power board&IGBT', CAST(1990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e1c562c4-8297-46cf-895e-21af7405aa16', N'TP277 6" touch', N'', N'', CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'68cf0310-62ce-4897-9add-2241bd0d27e3', N'TP177 6" touch', N'6AV6640-0CA11-0AX0', N'PCBA', CAST(780.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'cbb9709c-03f0-4f41-a4ad-242fa7932e51', N'V60', N'6SL3210-5CC14-0UA0', N'Power board&IGBT', CAST(1760.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'15fd9120-02a1-4af1-87aa-24efd20053e1', N'TP177 6" touch', N'6AV6642-0AA11-0AX1', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'dce586e3-be6a-43cb-b650-2529991a9263', N'S7-1200', N'6ES7212-1HD30-0XB0', N'Total', CAST(594.98 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'438eb159-5657-4956-b26e-26f0860a7c1f', N'V10', N'6SL3217-0CE27-5UA1', N'Plastic housing+Heatsink', CAST(1230.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'00819f41-c2a1-4374-a183-2a92aaa9deeb', N'V10', N'6SL3217-0CE31-8UA1', N'Heatsink', CAST(1280.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4c17fc66-0874-4ccf-af4d-2af56e296e36', N'MP277 10" touch', N'6AV6643-0CD01-1AX5', N'Inverter+Mounting sheet metal', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'10332506-7950-4ce9-b347-2b75b10493fb', N'MP277 8" touch', N'6AV6643-0CB01-1AX0', N'LCD', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'346d4fd5-3fbd-4b21-846f-2c4b6a5d2183', N'V10', N'6SL3217-0CE32-2UA1', N'Plastic housing', CAST(880.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f72efd3e-0540-4477-878c-2d005c5051d8', N'S7-200 CN', N'6ES7231-0HC22-0XA8', N'Total', CAST(315.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'bf7a7a32-e280-4a69-8bae-2e00a4ae5323', N'TP177 6" touch', N'6AV6640-0CA11-0AX1', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'01e00cb3-fa7e-47f0-a9cd-2e367e414eea', N'V60', N'6SL3210-5CC17-0UA0', N'control board', CAST(1460.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e5bcc351-39be-4413-9381-2e66fc1de0e2', N'S7-1200', N'6ES7214-1AE30-0XB0', N'Total', CAST(725.11 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'eb60392a-6924-4049-b8c8-307306fabda6', N'MP277 10" touch', N'6AV6643-0CD01-1AX1', N'LCD', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'61693dcf-78f8-4d5e-b1ea-314e39cdbcb0', N'MP277 10" touch', N'6AV6643-0CD01-1AX5', N'PCBA', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e591b8f1-922f-47d6-a587-322ba24b6f43', N'TP277 6" touch', N'6AV6643-0AA01-1AX0', N'PCBA', CAST(2000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9fe62d27-5522-43f4-ac48-329567187610', N'TP177 6" touch', N'6AV6642-0BC01-1AX1', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd5991cd6-d553-4f3b-a6a2-352fed5f3c1a', N'KTP400/600', N'6AV6647-0AB11-3AX0', N'Exchange LCD', CAST(1003.28 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b944469a-0366-4927-9408-36285b5a8075', N'S7-1200', N'6ES7211-1BD30-0XB0', N'Total', CAST(578.52 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'cf7ca771-8885-42af-b81a-37271d4c42d5', N'V10', N'6SL3217-0CE27-5UA1', N'Heatsink', CAST(1160.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'cf3c43ec-84fe-4dca-83e2-3a1403ad3fec', N'TP177 6" touch', N'6AV6642-0BA01-1AX1', N'LCD', CAST(1100.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'29624f81-d73d-4521-b5cb-3fb443d169a6', N'KTP400/600', N'6AV6647-0AC11-3AX0', N'Exchange LCD', CAST(1410.85 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9a8a4880-79b1-4195-a9b3-414e56496a45', N'S7-200 CN', N'6ES7214-2BD23-0XB8', N'Total', CAST(326.02 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9dc37de8-f2e2-47fe-b76c-42974e8462fe', N'TP177 6" touch', N'6AV6642-0BC01-1AX1 ', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'96e649cd-b431-48c4-842b-45611acb0fcc', N'TP177 6" touch', N'6AV6642-0BC01-1AX0', N'PCBA', CAST(1160.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'48c47c91-4412-4204-a47d-4aa16999971b', N'TP177 6" touch', N'6AV6642-0BA01-1AX0', N'PCBA', CAST(1260.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'869cc7cc-50fb-465f-9d39-4bb81ae98e89', N'V10', N'6SL3217-0CE31-1UA1', N'Plastic housing', CAST(860.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'cd6df520-42c2-41ed-b6ae-4c6f28b0deb2', N'V10', N'6SL3217-0CE31-5UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd1a27f2a-110e-4101-95ca-4d08ef9f0b56', N'S7-200 CN', N'6ES7216-2BD23-0XB8', N'Total', CAST(855.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'352d4055-1291-44e6-bfa3-4de24bcf9e73', N'S7-200 CN', N'6ES7216-2AD23-0XB8', N'Total', CAST(810.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e6b205b9-c871-4e31-a590-4ebeb109463c', N'TP277 6" touch', N'6AV6643-0AA01-1AX0', N'Inverter', CAST(940.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'13c8609e-a987-4f1f-acff-502641841c60', N'TP177 6" touch', N'6AV6642-0BC01-1AX0', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'53e4a2fe-1064-4484-81d6-516f4b746ba7', N'S7-1200', N'6ES7214-1BE30-0XB0', N'Total', CAST(741.57 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e7fe5201-406a-43ae-b162-52c3b368dd7e', N'S7-200', N'6ES7214-2AD23-0XB0', N'Total', CAST(269.72 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'95ba8ae2-50a6-453a-a990-54c05b823840', N'V10', N'6SL3217-0CE32-2UA1', N'Heatsink', CAST(1280.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a4cea32b-10dd-42c0-b3fc-5531c36c6c22', N'S7-1200', N'6ES7214-1HE30-0XB0', N'Total', CAST(747.84 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'cf16981c-a23a-41e2-8d44-564c2f3df4a6', N'MP277 10" touch', N'6AV6643-0CD01-1AX0', N'Inverter+Mounting sheet metal', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'6e5e4562-99ab-4aaa-a38d-568a915fd885', N'S7-1200', N'6ES7232-4HD30-0XB0', N'Total', CAST(456.23 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'c0a82a3f-e504-4e18-aae4-57157fed3d56', N'V10', N'6SL3217-0CE31-1UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3fe138e3-b7b3-4f0c-8f32-5886164c2d1c', N'S7-200 CN', N'6ES7221-1BH22-0XA8', N'Total', CAST(211.89 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'eb993f52-2908-4d5c-a57b-58d1f11f140b', N'TP177 6" touch', N'6AV6640-0CA11-0AX1', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'2cf5432f-cb3e-4320-aae3-5a8140d0c11f', N'S7-200', N'6ES7216-2AD23-0XB0', N'Total', CAST(810.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'118c5d07-9c27-4316-a793-5c47a569f912', N'S7-1200', N'6ES7221-1BF30-0XB0', N'Total', CAST(214.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1a264231-df78-4627-84e2-5c53ba3d6853', N'KTP178', N'6AV6640-0DA11-0AX0', N'外壳损坏', CAST(390.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'29570bf8-7f61-439c-9554-5e2963b9e067', N'S7-200', N'6ES7235-0KD22-0XA0', N'Total', CAST(360.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f2d8134b-ae1d-4aae-b8e2-5ebd7554e3ad', N'KTP400/600', N'6AV6647-0AA11-3AX0', N'Total', CAST(783.75 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'0b0e2ee0-9b22-47e6-a972-5f700cb90771', N'V10', N'6S6SL3217-0CE25-5UA1', N'Plastic housing+Heatsink', CAST(1230.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'c979f56a-a842-423c-acd3-60d541540094', N'S7-200', N'6ES7216-2BD23-0XB0', N'Total', CAST(855.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'2c1f489f-3067-4eeb-8e41-62e537d3ed17', N'S7-200', N'6ES7221-1BF22-0XA0', N'Total', CAST(134.99 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'25b6eaff-af33-4049-86d3-65b7d75846e9', N'MP277 8" touch', N'6AV6643-0CB01-1AX1', N'PCBA', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd6e5948b-4267-45dd-9bcd-6811c9ec1cb2', N'S7-200', N'6ES7221-1BH22-0XA0', N'Total', CAST(177.49 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f8fa5b8b-527b-4230-9bd8-6b869bb47198', N'S7-1200', N'6ES7221-1BH30-0XB0', N'Total', CAST(342.56 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e5182d29-97d1-4d2f-a494-6c8498d92b0a', N'V10', N'6SL3217-0CE31-8UA1', N'Plastic housing+Heatsink', CAST(1370.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'eb547339-a7cf-4593-97a8-6d9d0c3ef3f9', N'MP277 10" touch', N'6AV6643-0CD01-1AX0', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3e96cb9f-75d4-43bc-93db-6dc0751c3e17', N'V10', N'6SL3217-0CE32-2UA1', N'Plastic housing+Heatsink', CAST(1370.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'2ee52816-d1aa-4fc7-b4a4-6f3b6b8e7ca3', N'MP277 8" touch', N'6AV6643-0CB01-1AX0', N'Inverter+Mounting sheet metal', CAST(560.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'315bff27-314e-499e-98cc-706efe4acf6c', N'V60', N'6SL3210-5CC14-0UA0', N'control board', CAST(1460.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd53d6cce-5196-4812-9115-710531f42f3e', N'S7-200', N'6ES7222-1BF22-0XA0', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a1848f0a-1d4d-4e86-aaaa-712cc672f285', N'S7-1200', N'6ES7222-1BF30-0XB0', N'Total', CAST(213.22 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f98d7948-c902-4d1a-a36b-723fa9805d00', N'S7-1200', N'6ES7222-1HF30-0XB0', N'Total', CAST(216.36 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3cdf1352-364d-4a23-909e-73f135445b40', N'S7-1200', N'6ES7222-1BH30-0XB0', N'Total', CAST(338.64 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'54b8433e-b81d-4238-86a9-748fcadcb242', N'S7-200 CN', N'6ES7231-7PB22-0XA8', N'Total', CAST(305.38 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'19fbf7c6-c150-40dd-86f8-753dfcf9139f', N'V10', N'6S6SL3217-0CE25-5UA1', N'Capacitor board', CAST(1110.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4816f572-9a4d-4e6d-8d72-760e716d8f01', N'MP277 8" touch', N'6AV6643-0CB01-1AX1', N'LCD', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'af88fd36-528a-4d4e-9bfe-765b4de2dff4', N'KTP400/600', N'6AV6647-0AD11-3AX0', N'Total(More than 2 defects)', CAST(1761.78 AS Decimal(18, 2)), 0)
GO
print 'Processed 100 total records'
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9ce90eec-62fe-479f-8fd0-7ab71a9d5b5a', N'S7-1200', N'6ES7222-1HH30-0XB0', N'Total', CAST(344.92 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'7b06cfae-1ae4-4fec-81ad-7aea9223dd3d', N'S7-200 CN', N'6ES7221-1BF22-0XA8', N'Total', CAST(134.99 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'8580047b-4756-4add-ac7a-7cfa2f3eef43', N'KTP400/600', N'6AV6647-0AD11-3AX0', N'Exchange LCD', CAST(1410.85 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3709bf25-773c-41e6-94e1-7d85d80e9cab', N'MP277 8" touch', N'6AV6643-0CB01-1AX0', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1f17374e-e38f-478b-89ce-7e8cb3c7727c', N'KTP400/600', N'', N'', CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'243e1304-a6bd-4b19-992d-7ea0c072b82c', N'V60', N'6SL3210-5CC21-0UA0', N'control board', CAST(1460.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9d858e98-bd8f-4fa6-8247-814498b3ceea', N'MP277 8" touch', N'6AV6643-0CB01-1AX5', N'PCBA', CAST(2600.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'bc92a6a1-db25-4be8-afd5-826802cbb818', N'TP177 6" touch', N'6AV6640-0CA11-0AX0', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'458e2273-e06b-4546-85d9-834f9d3bbff4', N'TP177 6" touch', N'6AV6642-0AA11-0AX1', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'767039e9-8095-4c72-88c2-83ea3eb68329', N'TP177 6" touch', N'6AV6640-0CA11-0AX0', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9df2a244-7cbd-462e-8e6f-840d7c056c42', N'S7-200 CN', N'6ES7222-1HF22-0XA8', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'506caabd-be5c-4494-a2e2-87dc7df4daad', N'S7-200 CN', N'6ES7222-1BF22-0XA8', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1da81a4e-1c14-4131-b20c-8a247f0436f8', N'MP277 10" touch', N'6AV6643-0CD01-1AX5', N'LCD', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b9b11039-8a41-4314-a325-8aac1d827ff4', N'S7-200', N'6ES7222-1HF22-0XA0', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4e54081f-4b4d-4218-8679-8b853d396955', N'MP277 8" touch', N'6AV6643-0CB01-1AX5', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a52447b6-2c7b-4008-b75c-8c71998e4147', N'V10', N'6SL3217-0CE27-5UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'51330089-5720-4825-bf61-8e6caa608b7d', N'S7-200 CN', N'6ES7212-1AB23-0XB8', N'Total', CAST(360.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9c7e0a4e-2365-40ab-9e20-8f44f66a5f16', N'KTP400/600', N'6AV6647-0AB11-3AX0', N'Total(More than 2 defects)', CAST(1210.21 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4a3e1733-61e1-44a2-9b3c-8f4f0acc0fb2', N'TP277 6" touch', N'6AV6643-0AA01-1AX0', N'LCD', CAST(1800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'ab11a776-57bc-4e84-afc9-8f7bc672d4d8', N'V10', N'6SL3217-0CE31-1UA1', N'Power board+IGBT', CAST(1960.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'60cd3fd9-fc05-4370-87d6-906562370c54', N'S7-1200', N'6ES7223-1BH30-0XB0', N'Total', CAST(338.64 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'bc6ffc44-e8c3-4600-ae5f-90703a413c00', N'MP277 10" touch', N'6AV6643-0CD01-1AX5', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3a4ffa96-84a1-4d3d-934c-9249b9dd320c', N'V10', N'6SL3217-0CE31-5UA1', N'Plastic housing+Heatsink', CAST(1370.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'6aa61247-e9fb-429e-82cc-945c236afbfb', N'V10', N'6SL3217-0CE31-8UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'53f0956c-afa8-42dd-8fa1-9576ba440de7', N'TP177 6" touch', N'6AV6642-0AA11-0AX0', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1cfae87a-537c-4dd0-a3c8-9937532391f6', N'KTP400/600', N'6AV6647-0AC11-3AX0', N'Exchange PCB board', CAST(823.05 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'160fd607-6fd8-4393-9d72-99abcc6e3a6e', N'Panel', N'6AV6648-0AC11-3AX0', N'exchange fee', CAST(880.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'35f51dc1-fe13-4fa6-ad29-9a749829816d', N'S7-1200', N'6ES7223-1PH30-0XB0', N'Total', CAST(342.56 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'8aac1296-9f80-45cb-8b6b-9b30e33d1986', N'S7-200 CN', N'6ES7212-1BB23-0XB8', N'Total', CAST(378.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'dfa2993e-67f6-49d9-8fd9-9dd2d1a9e5b2', N'S7-200 CN', N'6ES7231-7PD22-0XA8', N'Total', CAST(275.70 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'52668d93-d128-41fa-9617-9de3263f5f78', N'V10', N'6S6SL3217-0CE25-5UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'7cfa5669-1f6a-416d-ad4f-9f41a8da6581', N'TP177 6" touch', N'6AV6642-0BA01-1AX1', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e45ef026-084f-4cc4-83a7-a096e3266955', N'MP277 8" touch', N'6AV6643-0CB01-1AX5', N'Inverter+Mounting sheet metal', CAST(560.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4809ab9d-3b5d-400b-9b54-a09b4dc167d2', N'KTP400/600', N'6AV6647-0AD11-3AX0', N'Exchange PCB board', CAST(723.66 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'68a57576-f57d-43b8-963e-a40742b1d050', N'MP277 8" touch', N'6AV6643-0CB01-1AX1', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3e3fc373-d302-4049-a136-a48ef242d9c5', N'V10', N'6SL3217-0CE31-5UA1', N'Power board+IGBT+Rectify', CAST(3240.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9a819057-a682-4cd9-98cc-a50873295528', N'S7-200', N'6ES7231-0HC22-0XA0', N'Total', CAST(315.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'7c9e4213-428d-40b2-aad5-a645b3bc85ef', N'V10', N'6SL3217-0CE31-5UA1', N'Plastic housing', CAST(880.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f46efeda-9e34-458f-be25-a9e80bd75d3b', N'S7-200', N'6ES7231-7PB22-0XA0', N'Total', CAST(270.97 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4d511831-8f04-4832-b433-a9f2cbbfb541', N'S7-1200', N'6ES7223-1BL30-0XB0', N'Total', CAST(539.32 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b51f1bda-9914-4c00-88fa-abb6aeb9950f', N'S7-200', N'6ES7231-7PD22-0XA0', N'Total', CAST(241.29 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'c6d516aa-7474-4263-9db5-ad01f3717013', N'S7-200 CN', N'6ES7232-0HB22-0XA8', N'Total', CAST(315.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'03171f54-5c35-4ea9-8ad5-aef88ff1bb44', N'S7-200 CN', N'6ES7235-0KD22-0XA8', N'Total', CAST(360.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'51fddcbd-ad28-4322-9db9-b04cc74f1c9e', N'V10', N'6SL3217-0CE32-2UA1', N'Capacitor board', CAST(1530.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'99831ec4-c479-46ec-b4da-b0a67ba4a77f', N'KTP178', N'6AV6640-0DA11-0AX0', N'Total', CAST(972.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'49682fe3-451d-4c5f-b32a-b2dd3c02adf9', N'S7-200 CN', N'6ES7223-1BF22-0XA8', N'Total', CAST(171.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4d77f8ac-aa08-408e-9636-b2e4517af639', N'S7-200', N'6ES7223-1BF22-0XA0', N'Total', CAST(171.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'60fb4ebe-fbb0-43d7-bdd8-b31fee0a864a', N'V10', N'6SL3217-0CE31-5UA1', N'Heatsink', CAST(1280.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'575688e5-489f-4961-87cf-b54d92d49630', N'V10', N'6SL3217-0CE31-8UA1', N'Power board+IGBT+Rectify', CAST(3250.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f8bec3be-7491-4e77-8906-b67a9ebd34fe', N'S7-200 CN', N'6ES7214-2AS23-0XB8', N'Total', CAST(304.13 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'414b93dd-150a-4eee-ab06-b8ef1c4fc842', N'S7-200', N'6ES7223-1HF22-0XA0', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'f2b508c9-323e-48b5-b18e-b965eac437d8', N'V10', N'6SL3217-0CE32-2UA1', N'Control board', CAST(990.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'daacd056-cad3-43de-b3a2-ba116e487a10', N'S7-1200', N'6ES7223-1PL30-0XB0', N'Total', CAST(543.24 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'475543f0-5125-48d3-bbf8-ba3f3aa0271d', N'KTP400/600', N'6AV6647-0AC11-3AX0', N'Exchange Top moulding', CAST(653.42 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'c14bf38d-4d06-405a-978a-baad769e87d2', N'V60', N'6SL3210-5CC21-0UA0', N'operation board,Heatsink & housing', CAST(1290.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a7997d84-2aab-46f7-8a49-bb1574ba37fe', N'V60', N'6SL3210-5CC14-0UA0', N'operation board,Heatsink & housing', CAST(1290.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e777572f-f375-48dc-9905-bef7e59df2c4', N'S7-200 CN', N'6ES7223-1HF22-0XA8', N'Total', CAST(180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'db54b82e-a289-401f-bdc8-c0a6a1a46323', N'S7-1200', N'6ES7223-0BD30-0XB0', N'Total', CAST(124.64 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'0a07d952-ea6c-4ffb-804e-c2c2ca4e9a3d', N'S7-1200', N'6ES7232-4HA30-0XB0', N'Total', CAST(188.14 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'17280041-c7d2-4740-9fac-c5135029e775', N'TP177 6" touch', N'6AV6642-0AA11-0AX0', N'LCD', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1f667dde-8579-430f-8382-c69feb877461', N'MP277 8" touch', N'6AV6643-0CB01-1AX1', N'Inverter+Mounting sheet metal', CAST(560.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'97e8fe3c-e51d-4ef7-85c1-c7145d8b20dc', N'S7-200', N'6ES7223-1BH22-0XA0', N'Total', CAST(225.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'00acdb33-9f22-44eb-867f-c7fcacbe9830', N'S7-1200', N'6ES7274-1XH30-0XA0', N'Total', CAST(277.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'bdd9dbc2-e9d4-445d-838d-c9dc80d00761', N'S7-1200', N'6ES7274-1XF30-0XA0', N'Total', CAST(202.25 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'edb393d2-2b9d-4f25-98b7-ca2c8069af4f', N'Panel', N'6AV6648-0AE11-3AX0', N'Total', CAST(2300.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'afe0143d-6b75-46f7-92a8-ca31afb85215', N'MP277 10" KEY', N'6AV6643-0DD01-1AX1', N'Inverter exchange', CAST(420.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e8aa5f5c-6c71-48f8-ab19-ca8340d54bfd', N'S7-200', N'6ES7223-1PH22-0XA0', N'Total', CAST(270.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b468e4ea-55f0-4611-b44e-cb7a48a27ce7', N'V10', N'6SL3217-0CE32-2UA1', N'Power board+IGBT+Rectify', CAST(3250.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'e8422ffa-2c03-44a6-93e8-cd54545811ef', N'S7-200 CN', N'6ES7223-1BH22-0XA8', N'Total', CAST(225.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'8a4e93ed-64a5-48d9-a760-cdffe9c8afac', N'V10', N'6SL3217-0CE27-5UA1', N'Power board+IGBT', CAST(1840.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4c22e694-3e52-44d6-85f7-cf3e138d65e5', N'MP277 10" touch', N'6AV6643-0CD01-1AX1', N'Top Moulding', CAST(1200.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4c8e34e0-e71f-41fe-9e3c-cfd7341e4c5c', N'V60', N'6SL3210-5CC17-0UA0', N'operation board,Heatsink & housing', CAST(1290.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd86fe6e2-be64-45c5-bc72-d087299e0322', N'S7-1200', N'6ES7241-1AH30-0XB0', N'Total', CAST(185.78 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a87b0923-d176-4cbb-af34-d0efa947baae', N'S7-200', N'6ES7223-1BL22-0XA0', N'Total', CAST(450.01 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a9d4db96-fe2e-4e0a-9a39-d5f6172efe33', N'S7-1200', N'6ES7241-1CH30-0XB0', N'Total', CAST(181.86 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9829078d-fa9c-4da7-b9bb-d7b32c12992d', N'V10', N'6SL3217-0CE31-1UA1', N'Capacitor board', CAST(1260.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1800907b-f30e-4603-a61e-da5cadfcb70c', N'V10', N'6SL3217-0CE31-8UA1', N'Capacitor board', CAST(1460.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4aa7025a-b0d7-497b-b3fe-dbbe2bae4095', N'S7-200 CN', N'6ES7223-1PH22-0XA8', N'Total', CAST(270.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'ff1978d1-6ec0-4d2c-b81d-ddd3ccf0f7d7', N'TP177 6" touch', N'6AV6642-0AA11-0AX0', N'PCBA', CAST(870.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a916c056-5719-4b4e-bb16-e0fb22de5bb4', N'V10', N'6SL3217-0CE31-1UA1', N'Heatsink', CAST(1160.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'26522548-9f67-4d8b-bff9-e265d2f35cb7', N'S7-1200', N'6ES7231-4HD30-0XB0', N'Total', CAST(438.98 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'3fd85f12-ce77-4e95-acc7-e2d731153273', N'MP277 10" touch', N'6AV6643-0CD01-1AX0', N'PCBA', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd65475a1-87e8-4470-990a-e3882dcd6a6b', N'S7-1200', N'6ES7231-5QD30-0XB0', N'Total', CAST(621.64 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b27f8cc8-d57a-49b6-8c83-e93e1c076b65', N'S7-1200', N'6ES7211-1AD30-0XB0', N'Total', CAST(534.62 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b95812b8-35e3-4266-9fa5-ea54aaca315b', N'KTP400/600', N'6AV6647-0AB11-3AX0', N'Exchange PCB board', CAST(711.48 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'288f9b54-886d-490c-bc44-ed40a0fb49c5', N'S7-200', N'6ES7223-1PL22-0XA0', N'Total', CAST(495.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'b62cb6b3-3521-4a0c-85be-eee2f2a1d559', N'S7-1200', N'6ES7232-4HB30-0XB0', N'Total', CAST(460.93 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'17e945c5-cd1d-4614-b1b1-f04a954e60af', N'MP277 10" touch', N'6AV6643-0CD01-1AX0', N'LCD', CAST(2800.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'9b9d4ec4-b010-4b97-ba2f-f2fc8fc8126e', N'S7-200 CN', N'6ES7223-1BL22-0XA8', N'Total', CAST(450.01 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'20e437c0-7978-45c3-a265-f45223e1dc8a', N'TP177 6" touch', N'6AV6642-0BA01-1AX0', N'Top Moulding', CAST(580.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'5ff04048-195d-4649-abbf-f48d772bd557', N'V10', N'6SL3217-0CE27-5UA1', N'Capacitor board', CAST(1180.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'edde97f3-c181-4e2b-9f9c-f63e10d46aa4', N'KTP400/600', N'6AV6647-0AB11-3AX0', N'Exchange Top moulding', CAST(653.42 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'1ffa685b-b6c6-466a-90fa-f697b433b551', N'V10', N'6S6SL3217-0CE25-5UA1', N'Power board+IGBT', CAST(1840.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'29c926b2-842d-4654-946f-f6f7d52bb61d', N'S7-1200', N'6ES7234-4HE30-0XB0', N'Total', CAST(631.82 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'a28d9f9b-612c-4056-80f3-f74817dd9b00', N'S7-200 CN', N'6ES7223-1PL22-0XA8', N'Total', CAST(495.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'2be25c12-6482-4d3d-85c5-f7d3b9775c51', N'TP277 6" touch', N'6AV6643-0AA01-1AX0', N'Top Moulding', CAST(950.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'4719e928-f801-42ae-83ba-f8b25f47a5af', N'V10', N'6SL3217-0CE31-5UA1', N'Capacitor board', CAST(1390.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'ebfa879f-a8e6-4cf5-a10c-fd375ee6cd1e', N'TP177 6" touch', N'6AV6642-0BA01-1AX0', N'LCD', CAST(1100.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'd6a77484-e860-44d6-b9f9-feef0bce70a3', N'S7-200', N'6ES7232-0HB22-0XA0', N'Total', CAST(315.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[SEWC_Basic_Quotation_Info] ([ID], [ProductType], [MLFB], [Component], [Amount], [OrderNo]) VALUES (N'159f7371-4cde-42d2-b4a7-ff6e2567c4b4', N'KTP400/600', N'6AV6647-0AD11-3AX0', N'Exchange Top moulding', CAST(653.42 AS Decimal(18, 2)), 0)
/****** Object:  Table [dbo].[SEWC_Basic_FailureCode_Info]    Script Date: 08/28/2013 09:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEWC_Basic_FailureCode_Info](
	[ID] [uniqueidentifier] NOT NULL,
	[FailureCodeI] [nvarchar](50) NOT NULL,
	[FailureCodeII] [nvarchar](50) NOT NULL,
	[FailureCodeIII] [nvarchar](50) NOT NULL,
	[IsDel] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_SEWC_Request_Info]    Script Date: 08/28/2013 09:53:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_Request_Info]
AS
SELECT     dbo.webInfo_ServiceRequest_Info.ID, dbo.webInfo_ServiceRequest_Info.RequestID, dbo.webInfo_ServiceRequest_Info.NotificationNo, 
                      dbo.webInfo_ServiceRequest_Info.CaseTime, dbo.webInfo_Servicerequest_Material_Info.MLFB, dbo.webInfo_Servicerequest_Material_Info.SerialNo, 
                      dbo.webInfo_ServiceRequest_Info.ServiceType, dbo.webInfo_ServiceRequest_Info.ProductName, dbo.webInfo_ServiceRequest_Info.ProductDesc, 
                      dbo.webInfo_ServiceRequest_Info.Area, dbo.webInfo_ServiceRequest_Info.ServiceProvider, dbo.webInfo_ServiceRequest_Info.CaseProperty, 
                      dbo.webInfo_ServiceRequest_Info.Sirot, dbo.webInfo_ServiceRequest_Info.TroubleDesc, dbo.webInfo_ServiceRequest_Info.AppCompanyName, 
                      dbo.webInfo_ServiceRequest_Info.AppSubOffice, dbo.webInfo_ServiceRequest_Info.AppCustomerID, dbo.webInfo_ServiceRequest_Info.AppProvince, 
                      dbo.webInfo_ServiceRequest_Info.AppCity, dbo.webInfo_ServiceRequest_Info.AppCustomerType, dbo.webInfo_ServiceRequest_Info.AppContactName, 
                      dbo.webInfo_ServiceRequest_Info.AppTel, dbo.webInfo_ServiceRequest_Info.AppMobile, dbo.webInfo_ServiceRequest_Info.AppFax, 
                      dbo.webInfo_ServiceRequest_Info.AppAddress, dbo.webInfo_ServiceRequest_Info.AppPostCode, dbo.webInfo_ServiceRequest_Info.AppEmail, 
                      dbo.webInfo_ServiceRequest_Info.AppCountry, dbo.webInfo_ServiceRequest_Info.AppBranch, dbo.webInfo_ServiceRequest_Info.EnduserCompanyName, 
                      dbo.webInfo_ServiceRequest_Info.EnduserSubOffice, dbo.webInfo_ServiceRequest_Info.EnduserCustomerID, dbo.webInfo_ServiceRequest_Info.EnduserProvince, 
                      dbo.webInfo_ServiceRequest_Info.EnduserCity, dbo.webInfo_ServiceRequest_Info.EnduserCustomerType, dbo.webInfo_ServiceRequest_Info.EnduserContactName, 
                      dbo.webInfo_ServiceRequest_Info.EnduserTel, dbo.webInfo_ServiceRequest_Info.EnduserMobile, dbo.webInfo_ServiceRequest_Info.EnduserFax, 
                      dbo.webInfo_ServiceRequest_Info.EnduserAddress, dbo.webInfo_ServiceRequest_Info.EnduserPostCode, dbo.webInfo_ServiceRequest_Info.EnduserCountry, 
                      dbo.webInfo_ServiceRequest_Info.EnduserBranch, dbo.webInfo_ServiceRequest_Info.EnduserEmail, dbo.webInfo_ServiceRequest_Info.EnduserMainOffice, 
                      dbo.webInfo_ServiceRequest_Info.Text, dbo.webInfo_ServiceRequest_Info.callagentComments, webInfo_loginInfo_1.EnUserName AS TransferUser, 
                      dbo.webInfo_ServiceRequest_Info.isRepair, webInfo_loginInfo_2.EnUserName AS CreateUser, dbo.webInfo_ServiceRequest_Info.SODate, 
                      dbo.webInfo_ServiceRequest_Info.WBSNO, dbo.webInfo_ServiceRequest_Info.SpecialOrderRemark, dbo.webInfo_ServiceRequest_Info.s39No, 
                      dbo.webInfo_ServiceRequest_Info.s39UpdateNo, dbo.webInfo_ServiceRequest_Info.MachineManufacturer, dbo.webInfo_ServiceRequest_Info.ControllerType, 
                      dbo.webInfo_ServiceRequest_Info.MachineSerialNo, dbo.webInfo_ServiceRequest_Info.TypeOfMachine, dbo.webInfo_ServiceRequest_Info.DriverType, 
                      dbo.webInfo_ServiceRequest_Info.SoftwareVersion, dbo.webInfo_ServiceRequest_Info.RSVNO, dbo.webInfo_ServiceRequest_Info.OrderType, 
                      dbo.webInfo_ServiceRequest_Info.Status, dbo.webInfo_ServiceRequest_Info.isUrgent, dbo.webInfo_ServiceRequest_Info.isSubmit, 
                      dbo.webInfo_ServiceRequest_Info.AppVIPID, dbo.webInfo_ServiceRequest_Info.EnduserVIPID, dbo.webInfo_loginInfo.EnUserName AS ModifyUser, 
                      dbo.webInfo_ServiceRequest_Info.IsFromSFAE, dbo.webInfo_Servicerequest_Material_Info.MaterialFault, 
                      dbo.webInfo_Servicerequest_Material_Info.MaterialProductName, dbo.webInfo_Servicerequest_Material_Info.MaterialProductDesc, 
                      dbo.webInfo_ServiceRequest_Info.Source, dbo.webInfo_ServiceRequest_Info.Distributors, dbo.webInfo_Servicerequest_Material_Info.Quantity, 
                      dbo.webInfo_Servicerequest_Material_Info.NewMLFB, dbo.webInfo_Servicerequest_Material_Info.NewSerialNo, 
                      dbo.webInfo_ServiceRequest_Info.SFAEIHR_Warranty, dbo.webInfo_ServiceRequest_Info.SFAEIHR_ServiceOrder, dbo.webInfo_ServiceRequest_Info.CreateDate, 
                      dbo.webInfo_ServiceRequest_Info.Warranty
FROM         dbo.webInfo_ServiceRequest_Info LEFT OUTER JOIN
                      dbo.webInfo_loginInfo ON dbo.webInfo_ServiceRequest_Info.ModifyUser = dbo.webInfo_loginInfo.ID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS webInfo_loginInfo_2 ON dbo.webInfo_ServiceRequest_Info.CreateUser = webInfo_loginInfo_2.ID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS webInfo_loginInfo_1 ON dbo.webInfo_ServiceRequest_Info.TransferUser = webInfo_loginInfo_1.ID LEFT OUTER JOIN
                      dbo.webInfo_Servicerequest_Material_Info ON dbo.webInfo_ServiceRequest_Info.ID = dbo.webInfo_Servicerequest_Material_Info.uRequestID
WHERE     (dbo.webInfo_ServiceRequest_Info.isDel = 0) AND (dbo.webInfo_ServiceRequest_Info.ServiceProvider = 'sewc') AND (dbo.webInfo_ServiceRequest_Info.isSubmit = 0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "webInfo_ServiceRequest_Info"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_loginInfo"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_loginInfo_2"
            Begin Extent = 
               Top = 126
               Left = 275
               Bottom = 245
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_loginInfo_1"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_Servicerequest_Material_Info"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 485
               Right = 297
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 83
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Request_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Request_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Request_Info'
GO
/****** Object:  View [dbo].[View_SEWC_Repair_Info]    Script Date: 08/28/2013 09:53:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_Repair_Info]
AS
SELECT     dbo.SEWC_IssueRepairOrder_Info.uRequestID, dbo.SEWC_IssueRepairOrder_Info.RequestID, dbo.SEWC_IssueRepairOrder_Info.MLFB, 
                      dbo.SEWC_IssueRepairOrder_Info.SerialNo, dbo.SEWC_IssueRepairOrder_Info.Warranty, dbo.SEWC_Repair_Info.WorkStationCode, 
                      dbo.SEWC_Repair_Info.CusomerName, dbo.SEWC_Repair_Info.[FuntinalState(original)], dbo.SEWC_Repair_Info.[FuntinalState(latest)], 
                      dbo.SEWC_Repair_Info.[Firmware(original)], dbo.SEWC_Repair_Info.[Firmware(latest)], dbo.SEWC_Repair_Info.ConfirmWarrantyDate, 
                      dbo.SEWC_Repair_Info.ServiceType, dbo.SEWC_Repair_Info.StartRepairDate, dbo.SEWC_Repair_Info.EndRepairDate, dbo.SEWC_Repair_Info.Engineer, 
                      dbo.SEWC_Repair_Info.RepairResult, dbo.SEWC_Repair_Info.Remarks, dbo.SEWC_Repair_Info.isSave, dbo.SEWC_Repair_Info.isSubmit, 
                      dbo.SEWC_Repair_Info.CreateDate, dbo.SEWC_Repair_Info.CreateUser, dbo.SEWC_IssueRepairOrder_Info.IssueRepairOrderDate, 
                      dbo.SEWC_GoodsReceipt_Info.SEWCNotificationNo, dbo.SEWC_IssueRepairOrder_Info.ConfirmCompleteDate, dbo.webInfo_ServiceRequest_Info.TroubleDesc, 
                      dbo.SEWC_GoodsReceipt_Info.IsReject
FROM         dbo.webInfo_ServiceRequest_Info RIGHT OUTER JOIN
                      dbo.SEWC_IssueRepairOrder_Info ON dbo.webInfo_ServiceRequest_Info.ID = dbo.SEWC_IssueRepairOrder_Info.uRequestID LEFT OUTER JOIN
                      dbo.SEWC_GoodsReceipt_Info ON dbo.SEWC_IssueRepairOrder_Info.uRequestID = dbo.SEWC_GoodsReceipt_Info.uRequestID LEFT OUTER JOIN
                      dbo.SEWC_Repair_Info ON dbo.SEWC_IssueRepairOrder_Info.uRequestID = dbo.SEWC_Repair_Info.uRequestID
WHERE     (dbo.SEWC_GoodsReceipt_Info.IsReject = 0) AND (dbo.SEWC_IssueRepairOrder_Info.isSubmit = 1) AND (dbo.SEWC_Repair_Info.isSubmit IS NULL OR
                      dbo.SEWC_Repair_Info.isSubmit = 0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "webInfo_ServiceRequest_Info"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SEWC_IssueRepairOrder_Info"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SEWC_GoodsReceipt_Info"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SEWC_Repair_Info"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 485
               Right = 233
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 28
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Repair_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Repair_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Repair_Info'
GO
/****** Object:  View [dbo].[View_SEWC_Reject_Info]    Script Date: 08/28/2013 09:53:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_Reject_Info]
AS
SELECT     uRequestID, RequestID, SEWCNotificationNo, ProductDesc, MLFB, SerialNo, Warranty, IsReject, RejectReason, RejectFile
FROM         dbo.SEWC_GoodsReceipt_Info
WHERE     (IsReject = 1)
GO
/****** Object:  View [dbo].[View_SEWC_IssueRepairOrder_Info]    Script Date: 08/28/2013 09:53:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_IssueRepairOrder_Info]
AS
SELECT     dbo.SEWC_GoodsReceipt_Info.uRequestID, dbo.SEWC_GoodsReceipt_Info.RequestID, dbo.SEWC_GoodsReceipt_Info.MLFB, 
                      dbo.SEWC_GoodsReceipt_Info.SerialNo, dbo.SEWC_GoodsReceipt_Info.Qty, dbo.SEWC_GoodsReceipt_Info.[ReceiveDefectiveDate(T3)], 
                      dbo.SEWC_GoodsReceipt_Info.Warranty, dbo.SEWC_IssueRepairOrder_Info.ReveiveBankReceipt, webInfo_loginInfo_1.EnUserName AS CreateUser, 
                      dbo.webInfo_loginInfo.EnUserName AS ModifyUser, dbo.SEWC_IssueRepairOrder_Info.CreateDate, dbo.SEWC_IssueRepairOrder_Info.ModifyDate, 
                      dbo.SEWC_IssueRepairOrder_Info.IssueRepairOrderDate, dbo.SEWC_GoodsReceipt_Info.IsReject, dbo.webInfo_ServiceRequest_Info.AppCompanyName, 
                      dbo.webInfo_ServiceRequest_Info.EnduserCompanyName
FROM         dbo.SEWC_GoodsReceipt_Info LEFT OUTER JOIN
                      dbo.webInfo_ServiceRequest_Info ON dbo.SEWC_GoodsReceipt_Info.uRequestID = dbo.webInfo_ServiceRequest_Info.ID LEFT OUTER JOIN
                      dbo.webInfo_loginInfo AS webInfo_loginInfo_1 RIGHT OUTER JOIN
                      dbo.SEWC_IssueRepairOrder_Info LEFT OUTER JOIN
                      dbo.webInfo_loginInfo ON dbo.SEWC_IssueRepairOrder_Info.ModifyUser = dbo.webInfo_loginInfo.ID ON 
                      webInfo_loginInfo_1.ID = dbo.SEWC_IssueRepairOrder_Info.CreateUser ON 
                      dbo.SEWC_GoodsReceipt_Info.uRequestID = dbo.SEWC_IssueRepairOrder_Info.uRequestID
WHERE     (dbo.SEWC_GoodsReceipt_Info.IsReject = 0) AND (dbo.SEWC_GoodsReceipt_Info.isSubmit = 1) AND (dbo.SEWC_IssueRepairOrder_Info.isSubmit IS NULL OR
                      dbo.SEWC_IssueRepairOrder_Info.isSubmit = 0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SEWC_GoodsReceipt_Info"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 192
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_loginInfo_1"
            Begin Extent = 
               Top = 126
               Left = 442
               Bottom = 245
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SEWC_IssueRepairOrder_Info"
            Begin Extent = 
               Top = 0
               Left = 501
               Bottom = 119
               Right = 717
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "webInfo_loginInfo"
            Begin Extent = 
               Top = 126
               Left = 275
               Bottom = 245
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_ServiceRequest_Info"
            Begin Extent = 
               Top = 0
               Left = 726
               Bottom = 196
               Right = 988
            End
            DisplayFlags = 280
            TopColumn = 25
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_IssueRepairOrder_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_IssueRepairOrder_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_IssueRepairOrder_Info'
GO
/****** Object:  View [dbo].[View_SEWC_GoodsReceipt_Info]    Script Date: 08/28/2013 09:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_GoodsReceipt_Info]
AS
SELECT     m.ID, m.RequestID, m.MLFBNo AS MLFB, m.SerialNo, m.ProductDesc, m.Warranty, m.ServiceType, m.ProductName AS ProductGroup, n.SEWCNotificationNo, n.Qty, 
                      n.[ReceiveDefectiveDate(T3)], n.IsReject, n.RejectReason, n.RejectFile, n.CreateDate, n.CreateUser, n.ModifyDate, n.ModifyUser, n.isSubmit, m.AppCompanyName, 
                      m.EnduserCompanyName
FROM         dbo.webInfo_ServiceRequest_Info AS m LEFT OUTER JOIN
                      dbo.SEWC_GoodsReceipt_Info AS n ON m.ID = n.uRequestID
WHERE     (m.ServiceProvider = 'SEWC') AND (m.isDel = 0) AND (n.IsReject = 0 OR
                      n.IsReject IS NULL) AND (m.isSubmit = 1) AND (n.isSubmit IS NULL OR
                      n.isSubmit = 0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[32] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "m"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 158
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 29
         End
         Begin Table = "n"
            Begin Extent = 
               Top = 32
               Left = 516
               Bottom = 151
               Right = 732
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_GoodsReceipt_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_GoodsReceipt_Info'
GO
/****** Object:  View [dbo].[View_SEWC_Finish_Info]    Script Date: 08/28/2013 09:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_Finish_Info]
AS
SELECT     dbo.SEWC_Delivery_Info.uRequestID, dbo.SEWC_Delivery_Info.RequestID, dbo.SEWC_Delivery_Info.MLFB, dbo.SEWC_Delivery_Info.SerialNo, 
                      dbo.SEWC_Delivery_Info.Warranty, dbo.SEWC_Delivery_Info.DeliveryDate, dbo.SEWC_Repair_Info.EndRepairDate, dbo.SEWC_Repair_Info.ServiceType, 
                      dbo.SEWC_Delivery_Info.Qty, dbo.SEWC_Delivery_Info.[Weight(Unit)], dbo.SEWC_GoodsReceipt_Info.SEWCNotificationNo, 
                      dbo.SEWC_GoodsReceipt_Info.IsReject
FROM         dbo.SEWC_Delivery_Info LEFT OUTER JOIN
                      dbo.SEWC_GoodsReceipt_Info ON dbo.SEWC_Delivery_Info.uRequestID = dbo.SEWC_GoodsReceipt_Info.uRequestID LEFT OUTER JOIN
                      dbo.SEWC_Repair_Info ON dbo.SEWC_Delivery_Info.uRequestID = dbo.SEWC_Repair_Info.uRequestID
WHERE     (dbo.SEWC_Delivery_Info.isSubmit = 1)
GO
/****** Object:  View [dbo].[View_SEWC_Delivery_Info]    Script Date: 08/28/2013 09:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_SEWC_Delivery_Info]
AS
SELECT     dbo.SEWC_Repair_Info.uRequestID, dbo.SEWC_Repair_Info.RequestID, dbo.SEWC_Repair_Info.MLFB, dbo.SEWC_Repair_Info.SerialNo, 
                      dbo.SEWC_Repair_Info.Warranty, dbo.SEWC_Delivery_Info.ModifyDate, dbo.webInfo_loginInfo.EnUserName AS ModifyUser, dbo.SEWC_Repair_Info.EndRepairDate, 
                      dbo.SEWC_Delivery_Info.DeliveryDate
FROM         dbo.SEWC_Delivery_Info LEFT OUTER JOIN
                      dbo.webInfo_loginInfo ON dbo.SEWC_Delivery_Info.ModifyUser = dbo.webInfo_loginInfo.ID RIGHT OUTER JOIN
                      dbo.SEWC_Repair_Info ON dbo.SEWC_Delivery_Info.uRequestID = dbo.SEWC_Repair_Info.uRequestID
WHERE     (dbo.SEWC_Repair_Info.isSubmit = 1) AND (dbo.SEWC_Delivery_Info.isSubmit IS NULL OR
                      dbo.SEWC_Delivery_Info.isSubmit = 0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SEWC_Delivery_Info"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "webInfo_loginInfo"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SEWC_Repair_Info"
            Begin Extent = 
               Top = 126
               Left = 275
               Bottom = 245
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Delivery_Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_SEWC_Delivery_Info'
GO
/****** Object:  Default [DF_SEWC_Basic_FailureCode_Info_ID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_FailureCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_FailureCode_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_Basic_FailureCode_Info_FailureCodeI]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_FailureCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_FailureCode_Info_FailureCodeI]  DEFAULT ('') FOR [FailureCodeI]
GO
/****** Object:  Default [DF_SEWC_Basic_FailureCode_Info_FailureCodeII]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_FailureCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_FailureCode_Info_FailureCodeII]  DEFAULT ('') FOR [FailureCodeII]
GO
/****** Object:  Default [DF_SEWC_Basic_FailureCode_Info_FailureCodeIII]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_FailureCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_FailureCode_Info_FailureCodeIII]  DEFAULT ('') FOR [FailureCodeIII]
GO
/****** Object:  Default [DF_SEWC_Basic_FailureCode_Info_IsDel]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_FailureCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_FailureCode_Info_IsDel]  DEFAULT ((0)) FOR [IsDel]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_ID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_ProductType]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_ProductType]  DEFAULT ('') FOR [ProductType]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_MLFB]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_MLFB]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_Component]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_Component]  DEFAULT ('') FOR [Component]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_Amount]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_SEWC_Basic_Quotation_Info_OrderNo]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Basic_Quotation_Info_OrderNo]  DEFAULT ((0)) FOR [OrderNo]
GO
/****** Object:  Default [DF_SEWC_Basic_WorkStationCode_Info_StationCode]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_WorkStationCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_WorkStationCode_Info_StationCode]  DEFAULT ('') FOR [StationCode]
GO
/****** Object:  Default [DF_SEWC_Basic_WorkStationCode_Info_IsDel]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Basic_WorkStationCode_Info] ADD  CONSTRAINT [DF_SEWC_Basic_WorkStationCode_Info_IsDel]  DEFAULT ((0)) FOR [IsDel]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_ID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_RequestID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_RequestID]  DEFAULT ('') FOR [RequestID]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_MLFB]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_MLFB]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_SerialNo]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_SerialNo]  DEFAULT ('') FOR [SerialNo]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_Qty]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_Weight(Unit)]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_Weight(Unit)]  DEFAULT ('') FOR [Weight(Unit)]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_Warranty]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_Warranty]  DEFAULT ('') FOR [Warranty]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_TrackingNo]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_TrackingNo]  DEFAULT ('') FOR [TrackingNo]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_CreateDate]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_CreateUser]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_CreateUser]  DEFAULT ((0)) FOR [CreateUser]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_DeliveryType]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_DeliveryType]  DEFAULT ('') FOR [DeliveryType]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_ReceiveCompany]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_ReceiveCompany]  DEFAULT ('') FOR [ReceiveCompany]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_Receiver]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_Receiver]  DEFAULT ('') FOR [Receiver]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_ReceiverTel]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_ReceiverTel]  DEFAULT ('') FOR [ReceiverTel]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_ReceiverAddress]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_ReceiverAddress]  DEFAULT ('') FOR [ReceiverAddress]
GO
/****** Object:  Default [DF_SEWC_Delivery_Info_isSubmit]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_Delivery_Info] ADD  CONSTRAINT [DF_SEWC_Delivery_Info_isSubmit]  DEFAULT ((0)) FOR [isSubmit]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_ID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_RequestID]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_RequestID]  DEFAULT ('') FOR [RequestID]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_SEWC NotificationNo]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_SEWC NotificationNo]  DEFAULT ('') FOR [SEWCNotificationNo]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_ProductDesc]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_ProductDesc]  DEFAULT ('') FOR [ProductDesc]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_MLFB]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_MLFB]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_SerialNo]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_SerialNo]  DEFAULT ('') FOR [SerialNo]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_Qty]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_Warranty]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_Warranty]  DEFAULT ('') FOR [Warranty]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_IsReject]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_IsReject]  DEFAULT ((0)) FOR [IsReject]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_RejectReason]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_RejectReason]  DEFAULT ('') FOR [RejectReason]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_RejectFile]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_RejectFile]  DEFAULT ('') FOR [RejectFile]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_CreateDate]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_CreateUser]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_CreateUser]  DEFAULT ((0)) FOR [CreateUser]
GO
/****** Object:  Default [DF_SEWC_GoodsReceipt_Info_isSubmit]    Script Date: 08/28/2013 09:53:46 ******/
ALTER TABLE [dbo].[SEWC_GoodsReceipt_Info] ADD  CONSTRAINT [DF_SEWC_GoodsReceipt_Info_isSubmit]  DEFAULT ((0)) FOR [isSubmit]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_ID]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_RequestID]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_RequestID]  DEFAULT ('') FOR [RequestID]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_MLFB]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_MLFB]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_SerialNo]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_SerialNo]  DEFAULT ('') FOR [SerialNo]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_Qty]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_Warranty]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_Warranty]  DEFAULT ('') FOR [Warranty]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_Repairble]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_Repairble]  DEFAULT ((0)) FOR [Repairble]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_ReveiveBankReceipt]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_ReveiveBankReceipt]  DEFAULT ((0)) FOR [ReveiveBankReceipt]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_IsGoodWill]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_IsGoodWill]  DEFAULT ((0)) FOR [IsGoodWill]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_GoodWillNo]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_GoodWillNo]  DEFAULT ('') FOR [GoodWillNo]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_CancelReason]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_CancelReason]  DEFAULT ('') FOR [CancelReason]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_CreateDate]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_CreateUser]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_CreateUser]  DEFAULT ((0)) FOR [CreateUser]
GO
/****** Object:  Default [DF_SEWC_IssueRepairOrder_Info_isSubmit]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_IssueRepairOrder_Info] ADD  CONSTRAINT [DF_SEWC_IssueRepairOrder_Info_isSubmit]  DEFAULT ((0)) FOR [isSubmit]
GO
/****** Object:  Default [DF_SEWC_Quotation_Info_ID_1]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Quotation_Info_ID_1]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_Quotation_Info_ProductType]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Quotation_Info_ProductType]  DEFAULT ('') FOR [ProductType]
GO
/****** Object:  Default [DF_SEWC_Quotation_Info_MLFB_1]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Quotation_Info_MLFB_1]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_SEWC_Quotation_Info_Component]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Quotation_Info_Component]  DEFAULT ('') FOR [Component]
GO
/****** Object:  Default [DF_SEWC_Quotation_Info_Amount]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Quotation_Info] ADD  CONSTRAINT [DF_SEWC_Quotation_Info_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_ID]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_RequestID]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_RequestID]  DEFAULT ('') FOR [RequestID]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_WorkStation Code]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_WorkStation Code]  DEFAULT ('') FOR [WorkStationCode]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_CusomerName]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_CusomerName]  DEFAULT ('') FOR [CusomerName]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_MLFB]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_MLFB]  DEFAULT ('') FOR [MLFB]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_SerialNo]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_SerialNo]  DEFAULT ('') FOR [SerialNo]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Qty]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Qty]  DEFAULT ((0)) FOR [Qty]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Funtinal State(original)]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Funtinal State(original)]  DEFAULT ('') FOR [FuntinalState(original)]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Funtinal State(latest)]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Funtinal State(latest)]  DEFAULT ('') FOR [FuntinalState(latest)]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Firmware(original)]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Firmware(original)]  DEFAULT ('') FOR [Firmware(original)]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Firmware(latest)]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Firmware(latest)]  DEFAULT ('') FOR [Firmware(latest)]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Warranty]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Warranty]  DEFAULT ('') FOR [Warranty]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_ServiceType]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_ServiceType]  DEFAULT ('') FOR [ServiceType]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Engineer]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Engineer]  DEFAULT ('') FOR [Engineer]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_RepairResult]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_RepairResult]  DEFAULT ('') FOR [RepairResult]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_Remarks]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_Remarks]  DEFAULT ('') FOR [Remarks]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_isSave]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_isSave]  DEFAULT ((0)) FOR [isSave]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_isSubmit]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_isSubmit]  DEFAULT ((0)) FOR [isSubmit]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_CreateDate]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_表SEWC_Repair_Info_CreateUser]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_Repair_Info] ADD  CONSTRAINT [DF_表SEWC_Repair_Info_CreateUser]  DEFAULT ((0)) FOR [CreateUser]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_ID]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_ID]  DEFAULT (newid()) FOR [ID]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_PCBA5ENo]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_PCBA5ENo]  DEFAULT ('') FOR [PCBA5ENo]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_ComponentLocation]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_ComponentLocation]  DEFAULT ('') FOR [ComponentLocation]
GO
/****** Object:  Default [DF_Table_1_RepairedComponent A5E]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_Table_1_RepairedComponent A5E]  DEFAULT ('') FOR [RepairedComponentA5E]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_FailureCodeI]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_FailureCodeI]  DEFAULT ('') FOR [FailureCodeI]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_FailureCodeII]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_FailureCodeII]  DEFAULT ('') FOR [FailureCodeII]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_FailureCodeIII]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_FailureCodeIII]  DEFAULT ('') FOR [FailureCodeIII]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_FailureType]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_FailureType]  DEFAULT ('') FOR [FailureType]
GO
/****** Object:  Default [DF_SEWC_RepairItem_Info_RepairAction]    Script Date: 08/28/2013 09:53:47 ******/
ALTER TABLE [dbo].[SEWC_RepairItem_Info] ADD  CONSTRAINT [DF_SEWC_RepairItem_Info_RepairAction]  DEFAULT ('') FOR [RepairAction]
GO
