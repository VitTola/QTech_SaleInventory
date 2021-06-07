namespace QTech.Component
{
    //public enum LocationLevel
    //{
    //    Country = 1,
    //    Province = 2,
    //    District = 3,
    //    Commune = 4,
    //    Village = 5
    //}
    public enum LocationType
    {
        Address,
        Location,
        Point
    }

    public enum DialogProcess
    {
        Save,
        ViewChangeLog,
        Close
    }

    public enum PageReport
    {
        View,
        Find,
        DownloadCsv
    }

    public enum Pagination
    {
        Next,
        Previous,
        ShowAll
    }

    public enum FeedBackSearchType
    {
        Customer,
        CaseNo
    }

    public enum MeterSearchType
    {
        Meter,
        InstallationCode
    }

    public enum PrintReadingProcess
    {
        NoDatasToPrint,
        GettingDatas,
        Waiting,
        GenerateReport,
        Printing,
        Ready,
        Error
    }

    public enum PrintInvoiceProcess
    {
        Waiting = 1,
        DownloadingInvoice,
        PreparingInvoice,
        SendingToPrinter,
        Ready,
        Error,
    }

    public enum CounterSessionReport
    {
        CounterSessionSumaryReport = 1,
        CounterSessionDetailReport = 2,
        ReceiptTotalByCashierReport = 3,
        ReceiptTotalCancelByCashierReport = 4,
        CounterSessionCashNoteReport = 5,
        CounterSessionCashNoteSumaryReport = 6,
        BondChargeAndConnectionFeeReport = 7
    }

    public enum CashierReportTemplate
    {
        General = 1,
        ByPaymentMethod = 2
    }

    public enum CashCollectionReportTemplate
    {
        CashCollection = 1,
        CancelCashCollection = 2,
    }

    public enum CounterSessionDetailReport
    {
        Detail = 1,
        DetailByPaymentMethod = 2,
    }

    public enum CashCollectionTotalByCounterReportTemplate
    {
        GeneralTemplate = 1,
        ByPaymentMethodTemplate = 2
    }
    public enum CancelCashCollectionTotalByCounterReportTemplate
    {
        GeneralTemplate = 1,
        ByPaymentMethodTemplate = 2
    }


    public enum ReceiptDetailReport
    {
        GeneralTemplate = 1,
        WithGroupTemplate = 2
    }

    public enum TotalCounterSessionCashNoteReportTemplate
    {
        GroupByBranch = 1,
        GroupByCounterSession = 2,
        SumaryByCounterSession = 3,
    }

    public enum InterCompanyReportTemplate
    {
        OutGoingDetail = 1,
        IncomingDetail = 2,
        CollectionSumary = 3
    }

    public enum AdjustmentReport
    {
        ConsumptionReportTemplate = 1,
        ReadingReportTemplate = 2
    }

    public enum ReceiptTemplate
    {
        POSReceiptSlip = 0,
        POSReceipt = 1,
        POSCheque = 2,
        A4Receipt = 3,
        //FullReceipt = 3
    }
    public enum MiscIncomeReceiptType
    {
        POSReceipt = 0,
        Normal = 1,
        Cheque = 2,
    }

    public enum ReadingListTemplates
    {
        ReadingListTemplate1,
        ReadingListTemplate2
    }

    public enum EditListTemplates
    {
        EditListDetail,
        EditListSummary
    }

    // Using For View Consumser Debt History
    public enum ConsumerDebtHistory
    {
        Detail = 1,
        Peding,
    }

    public enum BondSummaryReportType
    {
        ByConnectionTypeReport = 1,
        ByCustomerTypeReport = 2
    }

    public enum ConnectionFeeSummaryTemplate
    {
        ConnectionFeeDetail  = 1,
        ByConnectionTypeReport = 2,
        ByCustomerTypeReport = 3
    }

    public enum InstallationConsumptionHistoryTemplate
    {
        Template6Months = 1,
        Template12Months = 2,
        Template24Months = 3
    }

    public enum BondDetailReportStaus
    {
        Detail = 1,
        UnPaid = 2,
    }

    public enum PowerStatisticSumaryTemplate
    {
        Tariff = 1,
        ConnectionType = 2,
        CustomerType = 3,
        Transformer = 4
    }

    public enum AccrualTemplate
    {
        Summary = 1,
        SummaryByTariff,
        SummaryByConnectionType,
        SummaryByCustomerType,
        SummaryByTransformer,
        Detail,
        DetailByInstallation 
    }

    public enum PowerGenerationTemplate
    {
        Detail =1,
        Transformer = 2,
        TransformerTariff = 3,
        Tariff = 4,

    }

    public enum MonitorReportTemplate
    {
        AgentSchedule = 1,
        ReportRun
    }
    public enum MonitorReportStatus
    {
        Success = 1,
        Fail = 0
    }

    public enum PowerLossesTemplate
    {
        Summary = 1,
        YTD = 2,
    }
    public enum PowerBreakDownTemplate
    {
        Transformer = 1,
        ConnectionType =2,
        CustomerType = 3
    }

    public enum CreditControlTemplate
    {
        CreditControl = 1,
        CreditControlSumary = 2,
    }

    public enum InstallationActivateMeterTemplate
    {

        InstallationActivateMeter = 1,
        UATInstallationActivateMeter =2
    }

    public enum InstallationCurrentTemplate
    { 
        InstallationCurrent = 1,
        InstallationCurrentFixedCharge = 2,
        InstallationConnect = 3,
        InstallationConnectMeter = 4,
        /*ព័ត៌មានទីតាំងប្រើប្រាស់ចរន្តសង្ខេប*/
        InstallationCurrentSummary = 5
    }
    public enum BondDetailTemplate
    {
        BondDetail = 1,
        BondDetailByConsumer = 2
    }

    public enum UATReceiptDetailTemplate
    {
        ReceiptDetail = 1,
        CancelReceiptDetail = 2
    }
    public enum UATReceiptSummaryTemplate
    {
        ReceiptSummary = 1,
        CancelReceiptSummary = 2
    }

    public enum ReceiptDetailByCounterTemplate
    {
        ReceiptDetail = 1,
        CancelReceiptDetail = 2
    }


    public enum AgeDebtTemplate
    {
        ConsumerDetail,
        Detail,
        SummaryByConnectionType,
        SummaryByCustomerType
    }

    public enum AgeDebtReportTemplate
    {
        General = 1,
        NewTemplate = 2,
    }

    public enum AgeDebtCachingKey
    {
        ConsumerDetail,
        Detail,
        SummaryByConnectionType,
        SummaryByCustomerType,
        SummaryByConnectionType_NewTemplate,
        SummaryByCustomerType_NewTemplate,
    }

    public enum ConsolidateAgeDebtTemplate
    {
        Summary,
        SummaryByConnectionType,
        SummaryByCustomerType
    }

    public enum ConsolidateAgeDebtCachingKey
    {
        Summary,
        SummaryByConnectionType,
        SummaryByCustomerType,
        Summary_NewTemplate,
        SummaryByConnectionType_NewTemplate,
        SummaryByCustomerType_NewTemplate,
    }

    public enum ConsolidatePowerStatisticTemplate
    {
        Summary,
        SummaryByTariff,
        SummaryByCustomerType
    }

    public enum ConsolidateCashCollectionTemplate
    {
        General,
        ByPaymentMethod
    }

    public enum ConsolidateBondTemplate
    {
        Summary = 0,
        SummaryByConnectionType = 1,
        SummaryByCustomerType = 2
    }



    public enum ConsolidateConnectionFeeTemplate
    {
        Summary = 3,
        SummaryByConnectionType = 4,
        SummaryByCustomerType = 5
    }
    
    public enum ConsolidateBondAndConnectionFeeReport
    {
        Bond,
        ConnectionFee
    }

    public enum GeneralLedgerTemplate
    {
        Daily,
        Monthly,
        Yearly,
        MonthlyGenernal,
        MonthlyByCurrency,
        YearlyGenernal,
        YearlyByCurrency 
    }

    public enum ConsolidateGeneralLedgerTemplate
    {
        Daily
    }

    public enum GeneralLedgerGroupTemplate
    {
        GenernalTemplate = 1,
        ByCurrencyTemplate = 2,
    }

    public enum PeriodSearchType
    {
        Year = 1,   // value equal to 12 months
        Years,      // value equal to 24 months
        All,         // show all reading log.
        Custom
    }

    public enum CreditControlType
    {
        Ignored = 1,
        UnIgnored
    }
    public enum ConnectionFeeTemplate
    {
        ConnectionFeeDetail =1 ,
        SummaryByConnectionType = 2,
        SummaryByCustomerType = 3
    }

    public enum BoxTemplate
    {
        BoxDetail = 1,
        BoxSummary = 2,
        BoxSummaryByTransformer =3,
    }

    public enum CustomerChangeNameTariffTemplate
    {
        CustomerChangeNameTariffDetail = 1,
        CustomerChangeNameTariffByDay = 2,
    }

    public enum InstallationStatusTemplate
    {
        InstallationChageStatus = 1,
        DisconnectReconnect = 2,
    }

    public enum TransformerTemplate
    {
        TransformerDetail = 1,
        TransformerSummary = 2,
    }

    public enum CustomerChangeInfoTemplate
    {
        ChangeName = 1,
        ChangeCustomerType = 2,
        ChangeTariff = 3,
        ChangeFixedCharge = 4
    }

    public enum AuditTemplate
    {
        Tariff = 1,
        FixedCharge = 2,
    }

    public enum DummyReportTemplate
    {
        Template = 1
    }




    public enum InProfileUsageSearchPeriod
    {
        Month12 = 1,   // value equal to 12 months
        Month24,      // value equal to 24 months
        Custom
    }

    public enum InProfileDebtSearchPeriod
    {
        Month6 = 1,   // value equal to 06 months
        Month12,      // value equal to 12 months
        Month24,      // value equal to 24 months
        Custom
    }

    public enum MeterAgeReportTemplate
    {
        MeterAgeReport = 1
    }

    public enum ReportTemplate
    {
        General
    }

    public enum ChannelStatus
    {
        Work = 1,
        NotWork
    }

    public enum ConsumerCodeConvertType
    {
        ApplyPrefix = 1,
        NewCode = 2,
    }
}
