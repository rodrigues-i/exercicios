#ifndef FIX50_NEWORDERLIST_H
#define FIX50_NEWORDERLIST_H

#include "Message.h"

namespace FIX50
{

  class NewOrderList : public Message
  {
  public:
    NewOrderList() : Message(MsgType()) {}
    NewOrderList(const FIX::Message& m) : Message(m) {}
    NewOrderList(const Message& m) : Message(m) {}
    NewOrderList(const NewOrderList& m) : Message(m) {}
    static FIX::MsgType MsgType() { return FIX::MsgType("E"); }

    NewOrderList(
      const FIX::ListID& aListID,
      const FIX::BidType& aBidType,
      const FIX::TotNoOrders& aTotNoOrders )
    : Message(MsgType())
    {
      set(aListID);
      set(aBidType);
      set(aTotNoOrders);
    }

    FIELD_SET(*this, FIX::ListID);
    FIELD_SET(*this, FIX::BidID);
    FIELD_SET(*this, FIX::ClientBidID);
    FIELD_SET(*this, FIX::ProgRptReqs);
    FIELD_SET(*this, FIX::BidType);
    FIELD_SET(*this, FIX::ProgPeriodInterval);
    FIELD_SET(*this, FIX::CancellationRights);
    FIELD_SET(*this, FIX::MoneyLaunderingStatus);
    FIELD_SET(*this, FIX::RegistID);
    FIELD_SET(*this, FIX::ListExecInstType);
    FIELD_SET(*this, FIX::ListExecInst);
    FIELD_SET(*this, FIX::EncodedListExecInstLen);
    FIELD_SET(*this, FIX::EncodedListExecInst);
    FIELD_SET(*this, FIX::AllowableOneSidednessPct);
    FIELD_SET(*this, FIX::AllowableOneSidednessValue);
    FIELD_SET(*this, FIX::AllowableOneSidednessCurr);
    FIELD_SET(*this, FIX::TotNoOrders);
    FIELD_SET(*this, FIX::LastFragment);
    FIELD_SET(*this, FIX::NoRootPartyIDs);
    class NoRootPartyIDs: public FIX::Group
    {
    public:
    NoRootPartyIDs() : FIX::Group(1116,1117,FIX::message_order(1117,1118,1119,1120,0)) {}
      FIELD_SET(*this, FIX::RootPartyID);
      FIELD_SET(*this, FIX::RootPartyIDSource);
      FIELD_SET(*this, FIX::RootPartyRole);
      FIELD_SET(*this, FIX::NoRootPartySubIDs);
      class NoRootPartySubIDs: public FIX::Group
      {
      public:
      NoRootPartySubIDs() : FIX::Group(1120,1121,FIX::message_order(1121,1122,0)) {}
        FIELD_SET(*this, FIX::RootPartySubID);
        FIELD_SET(*this, FIX::RootPartySubIDType);
      };
    };
    FIELD_SET(*this, FIX::NoOrders);
    class NoOrders: public FIX::Group
    {
    public:
    NoOrders() : FIX::Group(73,11,FIX::message_order(11,526,67,583,160,453,229,75,1,660,581,589,590,70,591,78,63,64,544,635,21,18,110,1089,1090,1138,1082,1083,1084,1085,1086,1087,1088,111,100,1133,386,81,55,65,48,22,460,461,167,762,200,541,1079,201,966,1049,965,224,225,239,226,227,228,255,543,470,471,472,240,202,947,967,968,206,231,969,996,997,223,207,970,971,106,348,349,107,350,351,691,667,875,876,873,874,711,140,54,401,114,60,232,854,38,152,516,468,469,40,423,44,1092,99,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,218,220,221,222,662,663,699,761,235,236,701,696,697,698,15,376,377,23,117,1080,1081,59,168,432,126,427,12,13,479,497,528,529,1091,582,121,120,775,58,354,355,193,192,640,77,203,210,211,1094,835,836,837,838,840,1096,1097,1098,1099,388,389,841,842,843,844,846,847,957,848,849,494,0)) {}
      FIELD_SET(*this, FIX::ClOrdID);
      FIELD_SET(*this, FIX::SecondaryClOrdID);
      FIELD_SET(*this, FIX::ListSeqNo);
      FIELD_SET(*this, FIX::ClOrdLinkID);
      FIELD_SET(*this, FIX::SettlInstMode);
      FIELD_SET(*this, FIX::NoPartyIDs);
      class NoPartyIDs: public FIX::Group
      {
      public:
      NoPartyIDs() : FIX::Group(453,448,FIX::message_order(448,447,452,802,0)) {}
        FIELD_SET(*this, FIX::PartyID);
        FIELD_SET(*this, FIX::PartyIDSource);
        FIELD_SET(*this, FIX::PartyRole);
        FIELD_SET(*this, FIX::NoPartySubIDs);
        class NoPartySubIDs: public FIX::Group
        {
        public:
        NoPartySubIDs() : FIX::Group(802,523,FIX::message_order(523,803,0)) {}
          FIELD_SET(*this, FIX::PartySubID);
          FIELD_SET(*this, FIX::PartySubIDType);
        };
      };
      FIELD_SET(*this, FIX::TradeOriginationDate);
      FIELD_SET(*this, FIX::TradeDate);
      FIELD_SET(*this, FIX::Account);
      FIELD_SET(*this, FIX::AcctIDSource);
      FIELD_SET(*this, FIX::AccountType);
      FIELD_SET(*this, FIX::DayBookingInst);
      FIELD_SET(*this, FIX::BookingUnit);
      FIELD_SET(*this, FIX::AllocID);
      FIELD_SET(*this, FIX::PreallocMethod);
      FIELD_SET(*this, FIX::NoAllocs);
      class NoAllocs: public FIX::Group
      {
      public:
      NoAllocs() : FIX::Group(78,79,FIX::message_order(79,661,736,467,539,80,0)) {}
        FIELD_SET(*this, FIX::AllocAccount);
        FIELD_SET(*this, FIX::AllocAcctIDSource);
        FIELD_SET(*this, FIX::AllocSettlCurrency);
        FIELD_SET(*this, FIX::IndividualAllocID);
        FIELD_SET(*this, FIX::NoNestedPartyIDs);
        class NoNestedPartyIDs: public FIX::Group
        {
        public:
        NoNestedPartyIDs() : FIX::Group(539,524,FIX::message_order(524,525,538,804,0)) {}
          FIELD_SET(*this, FIX::NestedPartyID);
          FIELD_SET(*this, FIX::NestedPartyIDSource);
          FIELD_SET(*this, FIX::NestedPartyRole);
          FIELD_SET(*this, FIX::NoNestedPartySubIDs);
          class NoNestedPartySubIDs: public FIX::Group
          {
          public:
          NoNestedPartySubIDs() : FIX::Group(804,545,FIX::message_order(545,805,0)) {}
            FIELD_SET(*this, FIX::NestedPartySubID);
            FIELD_SET(*this, FIX::NestedPartySubIDType);
          };
        };
        FIELD_SET(*this, FIX::AllocQty);
      };
      FIELD_SET(*this, FIX::SettlType);
      FIELD_SET(*this, FIX::SettlDate);
      FIELD_SET(*this, FIX::CashMargin);
      FIELD_SET(*this, FIX::ClearingFeeIndicator);
      FIELD_SET(*this, FIX::HandlInst);
      FIELD_SET(*this, FIX::ExecInst);
      FIELD_SET(*this, FIX::MinQty);
      FIELD_SET(*this, FIX::MatchIncrement);
      FIELD_SET(*this, FIX::MaxPriceLevels);
      FIELD_SET(*this, FIX::DisplayQty);
      FIELD_SET(*this, FIX::SecondaryDisplayQty);
      FIELD_SET(*this, FIX::DisplayWhen);
      FIELD_SET(*this, FIX::DisplayMethod);
      FIELD_SET(*this, FIX::DisplayLowQty);
      FIELD_SET(*this, FIX::DisplayHighQty);
      FIELD_SET(*this, FIX::DisplayMinIncr);
      FIELD_SET(*this, FIX::RefreshQty);
      FIELD_SET(*this, FIX::MaxFloor);
      FIELD_SET(*this, FIX::ExDestination);
      FIELD_SET(*this, FIX::ExDestinationIDSource);
      FIELD_SET(*this, FIX::NoTradingSessions);
      class NoTradingSessions: public FIX::Group
      {
      public:
      NoTradingSessions() : FIX::Group(386,336,FIX::message_order(336,625,0)) {}
        FIELD_SET(*this, FIX::TradingSessionID);
        FIELD_SET(*this, FIX::TradingSessionSubID);
      };
      FIELD_SET(*this, FIX::ProcessCode);
      FIELD_SET(*this, FIX::Symbol);
      FIELD_SET(*this, FIX::SymbolSfx);
      FIELD_SET(*this, FIX::SecurityID);
      FIELD_SET(*this, FIX::SecurityIDSource);
      FIELD_SET(*this, FIX::NoSecurityAltID);
      class NoSecurityAltID: public FIX::Group
      {
      public:
      NoSecurityAltID() : FIX::Group(454,455,FIX::message_order(455,456,0)) {}
        FIELD_SET(*this, FIX::SecurityAltID);
        FIELD_SET(*this, FIX::SecurityAltIDSource);
      };
      FIELD_SET(*this, FIX::Product);
      FIELD_SET(*this, FIX::CFICode);
      FIELD_SET(*this, FIX::SecurityType);
      FIELD_SET(*this, FIX::SecuritySubType);
      FIELD_SET(*this, FIX::MaturityMonthYear);
      FIELD_SET(*this, FIX::MaturityDate);
      FIELD_SET(*this, FIX::MaturityTime);
      FIELD_SET(*this, FIX::PutOrCall);
      FIELD_SET(*this, FIX::SettleOnOpenFlag);
      FIELD_SET(*this, FIX::InstrmtAssignmentMethod);
      FIELD_SET(*this, FIX::SecurityStatus);
      FIELD_SET(*this, FIX::CouponPaymentDate);
      FIELD_SET(*this, FIX::IssueDate);
      FIELD_SET(*this, FIX::RepoCollateralSecurityType);
      FIELD_SET(*this, FIX::RepurchaseTerm);
      FIELD_SET(*this, FIX::RepurchaseRate);
      FIELD_SET(*this, FIX::Factor);
      FIELD_SET(*this, FIX::CreditRating);
      FIELD_SET(*this, FIX::InstrRegistry);
      FIELD_SET(*this, FIX::CountryOfIssue);
      FIELD_SET(*this, FIX::StateOrProvinceOfIssue);
      FIELD_SET(*this, FIX::LocaleOfIssue);
      FIELD_SET(*this, FIX::RedemptionDate);
      FIELD_SET(*this, FIX::StrikePrice);
      FIELD_SET(*this, FIX::StrikeCurrency);
      FIELD_SET(*this, FIX::StrikeMultiplier);
      FIELD_SET(*this, FIX::StrikeValue);
      FIELD_SET(*this, FIX::OptAttribute);
      FIELD_SET(*this, FIX::ContractMultiplier);
      FIELD_SET(*this, FIX::MinPriceIncrement);
      FIELD_SET(*this, FIX::UnitOfMeasure);
      FIELD_SET(*this, FIX::TimeUnit);
      FIELD_SET(*this, FIX::CouponRate);
      FIELD_SET(*this, FIX::SecurityExchange);
      FIELD_SET(*this, FIX::PositionLimit);
      FIELD_SET(*this, FIX::NTPositionLimit);
      FIELD_SET(*this, FIX::Issuer);
      FIELD_SET(*this, FIX::EncodedIssuerLen);
      FIELD_SET(*this, FIX::EncodedIssuer);
      FIELD_SET(*this, FIX::SecurityDesc);
      FIELD_SET(*this, FIX::EncodedSecurityDescLen);
      FIELD_SET(*this, FIX::EncodedSecurityDesc);
      FIELD_SET(*this, FIX::Pool);
      FIELD_SET(*this, FIX::ContractSettlMonth);
      FIELD_SET(*this, FIX::CPProgram);
      FIELD_SET(*this, FIX::CPRegType);
      FIELD_SET(*this, FIX::NoEvents);
      class NoEvents: public FIX::Group
      {
      public:
      NoEvents() : FIX::Group(864,865,FIX::message_order(865,866,867,868,0)) {}
        FIELD_SET(*this, FIX::EventType);
        FIELD_SET(*this, FIX::EventDate);
        FIELD_SET(*this, FIX::EventPx);
        FIELD_SET(*this, FIX::EventText);
      };
      FIELD_SET(*this, FIX::DatedDate);
      FIELD_SET(*this, FIX::InterestAccrualDate);
      FIELD_SET(*this, FIX::NoInstrumentParties);
      class NoInstrumentParties: public FIX::Group
      {
      public:
      NoInstrumentParties() : FIX::Group(1018,1019,FIX::message_order(1019,1050,1051,1052,0)) {}
        FIELD_SET(*this, FIX::InstrumentPartyID);
        FIELD_SET(*this, FIX::InstrumentPartyIDSource);
        FIELD_SET(*this, FIX::InstrumentPartyRole);
        FIELD_SET(*this, FIX::NoInstrumentPartySubIDs);
        class NoInstrumentPartySubIDs: public FIX::Group
        {
        public:
        NoInstrumentPartySubIDs() : FIX::Group(1052,1053,FIX::message_order(1053,1054,0)) {}
          FIELD_SET(*this, FIX::InstrumentPartySubID);
          FIELD_SET(*this, FIX::InstrumentPartySubIDType);
        };
      };
      FIELD_SET(*this, FIX::NoUnderlyings);
      class NoUnderlyings: public FIX::Group
      {
      public:
      NoUnderlyings() : FIX::Group(711,311,FIX::message_order(311,312,309,305,462,463,310,763,313,542,315,241,242,243,244,245,246,256,595,592,593,594,247,316,941,317,436,998,1000,435,308,306,362,363,307,364,365,877,878,972,318,879,975,973,974,810,882,883,884,885,886,1044,1045,1046,1038,1039,0)) {}
        FIELD_SET(*this, FIX::UnderlyingSymbol);
        FIELD_SET(*this, FIX::UnderlyingSymbolSfx);
        FIELD_SET(*this, FIX::UnderlyingSecurityID);
        FIELD_SET(*this, FIX::UnderlyingSecurityIDSource);
        FIELD_SET(*this, FIX::NoUnderlyingSecurityAltID);
        class NoUnderlyingSecurityAltID: public FIX::Group
        {
        public:
        NoUnderlyingSecurityAltID() : FIX::Group(457,458,FIX::message_order(458,459,0)) {}
          FIELD_SET(*this, FIX::UnderlyingSecurityAltID);
          FIELD_SET(*this, FIX::UnderlyingSecurityAltIDSource);
        };
        FIELD_SET(*this, FIX::UnderlyingProduct);
        FIELD_SET(*this, FIX::UnderlyingCFICode);
        FIELD_SET(*this, FIX::UnderlyingSecurityType);
        FIELD_SET(*this, FIX::UnderlyingSecuritySubType);
        FIELD_SET(*this, FIX::UnderlyingMaturityMonthYear);
        FIELD_SET(*this, FIX::UnderlyingMaturityDate);
        FIELD_SET(*this, FIX::UnderlyingPutOrCall);
        FIELD_SET(*this, FIX::UnderlyingCouponPaymentDate);
        FIELD_SET(*this, FIX::UnderlyingIssueDate);
        FIELD_SET(*this, FIX::UnderlyingRepoCollateralSecurityType);
        FIELD_SET(*this, FIX::UnderlyingRepurchaseTerm);
        FIELD_SET(*this, FIX::UnderlyingRepurchaseRate);
        FIELD_SET(*this, FIX::UnderlyingFactor);
        FIELD_SET(*this, FIX::UnderlyingCreditRating);
        FIELD_SET(*this, FIX::UnderlyingInstrRegistry);
        FIELD_SET(*this, FIX::UnderlyingCountryOfIssue);
        FIELD_SET(*this, FIX::UnderlyingStateOrProvinceOfIssue);
        FIELD_SET(*this, FIX::UnderlyingLocaleOfIssue);
        FIELD_SET(*this, FIX::UnderlyingRedemptionDate);
        FIELD_SET(*this, FIX::UnderlyingStrikePrice);
        FIELD_SET(*this, FIX::UnderlyingStrikeCurrency);
        FIELD_SET(*this, FIX::UnderlyingOptAttribute);
        FIELD_SET(*this, FIX::UnderlyingContractMultiplier);
        FIELD_SET(*this, FIX::UnderlyingUnitOfMeasure);
        FIELD_SET(*this, FIX::UnderlyingTimeUnit);
        FIELD_SET(*this, FIX::UnderlyingCouponRate);
        FIELD_SET(*this, FIX::UnderlyingSecurityExchange);
        FIELD_SET(*this, FIX::UnderlyingIssuer);
        FIELD_SET(*this, FIX::EncodedUnderlyingIssuerLen);
        FIELD_SET(*this, FIX::EncodedUnderlyingIssuer);
        FIELD_SET(*this, FIX::UnderlyingSecurityDesc);
        FIELD_SET(*this, FIX::EncodedUnderlyingSecurityDescLen);
        FIELD_SET(*this, FIX::EncodedUnderlyingSecurityDesc);
        FIELD_SET(*this, FIX::UnderlyingCPProgram);
        FIELD_SET(*this, FIX::UnderlyingCPRegType);
        FIELD_SET(*this, FIX::UnderlyingAllocationPercent);
        FIELD_SET(*this, FIX::UnderlyingCurrency);
        FIELD_SET(*this, FIX::UnderlyingQty);
        FIELD_SET(*this, FIX::UnderlyingSettlementType);
        FIELD_SET(*this, FIX::UnderlyingCashAmount);
        FIELD_SET(*this, FIX::UnderlyingCashType);
        FIELD_SET(*this, FIX::UnderlyingPx);
        FIELD_SET(*this, FIX::UnderlyingDirtyPrice);
        FIELD_SET(*this, FIX::UnderlyingEndPrice);
        FIELD_SET(*this, FIX::UnderlyingStartValue);
        FIELD_SET(*this, FIX::UnderlyingCurrentValue);
        FIELD_SET(*this, FIX::UnderlyingEndValue);
        FIELD_SET(*this, FIX::NoUnderlyingStips);
        class NoUnderlyingStips: public FIX::Group
        {
        public:
        NoUnderlyingStips() : FIX::Group(887,888,FIX::message_order(888,889,0)) {}
          FIELD_SET(*this, FIX::UnderlyingStipType);
          FIELD_SET(*this, FIX::UnderlyingStipValue);
        };
        FIELD_SET(*this, FIX::UnderlyingAdjustedQuantity);
        FIELD_SET(*this, FIX::UnderlyingFXRate);
        FIELD_SET(*this, FIX::UnderlyingFXRateCalc);
        FIELD_SET(*this, FIX::UnderlyingCapValue);
        FIELD_SET(*this, FIX::NoUndlyInstrumentParties);
        class NoUndlyInstrumentParties: public FIX::Group
        {
        public:
        NoUndlyInstrumentParties() : FIX::Group(1058,1059,FIX::message_order(1059,1060,1061,1062,0)) {}
          FIELD_SET(*this, FIX::UndlyInstrumentPartyID);
          FIELD_SET(*this, FIX::UndlyInstrumentPartyIDSource);
          FIELD_SET(*this, FIX::UndlyInstrumentPartyRole);
          FIELD_SET(*this, FIX::NoUndlyInstrumentPartySubIDs);
          class NoUndlyInstrumentPartySubIDs: public FIX::Group
          {
          public:
          NoUndlyInstrumentPartySubIDs() : FIX::Group(1062,1063,FIX::message_order(1063,1064,0)) {}
            FIELD_SET(*this, FIX::UndlyInstrumentPartySubID);
            FIELD_SET(*this, FIX::UndlyInstrumentPartySubIDType);
          };
        };
        FIELD_SET(*this, FIX::UnderlyingSettlMethod);
      };
      FIELD_SET(*this, FIX::PrevClosePx);
      FIELD_SET(*this, FIX::Side);
      FIELD_SET(*this, FIX::SideValueInd);
      FIELD_SET(*this, FIX::LocateReqd);
      FIELD_SET(*this, FIX::TransactTime);
      FIELD_SET(*this, FIX::NoStipulations);
      class NoStipulations: public FIX::Group
      {
      public:
      NoStipulations() : FIX::Group(232,233,FIX::message_order(233,234,0)) {}
        FIELD_SET(*this, FIX::StipulationType);
        FIELD_SET(*this, FIX::StipulationValue);
      };
      FIELD_SET(*this, FIX::QtyType);
      FIELD_SET(*this, FIX::OrderQty);
      FIELD_SET(*this, FIX::CashOrderQty);
      FIELD_SET(*this, FIX::OrderPercent);
      FIELD_SET(*this, FIX::RoundingDirection);
      FIELD_SET(*this, FIX::RoundingModulus);
      FIELD_SET(*this, FIX::OrdType);
      FIELD_SET(*this, FIX::PriceType);
      FIELD_SET(*this, FIX::Price);
      FIELD_SET(*this, FIX::PriceProtectionScope);
      FIELD_SET(*this, FIX::StopPx);
      FIELD_SET(*this, FIX::TriggerType);
      FIELD_SET(*this, FIX::TriggerAction);
      FIELD_SET(*this, FIX::TriggerPrice);
      FIELD_SET(*this, FIX::TriggerSymbol);
      FIELD_SET(*this, FIX::TriggerSecurityID);
      FIELD_SET(*this, FIX::TriggerSecurityIDSource);
      FIELD_SET(*this, FIX::TriggerSecurityDesc);
      FIELD_SET(*this, FIX::TriggerPriceType);
      FIELD_SET(*this, FIX::TriggerPriceTypeScope);
      FIELD_SET(*this, FIX::TriggerPriceDirection);
      FIELD_SET(*this, FIX::TriggerNewPrice);
      FIELD_SET(*this, FIX::TriggerOrderType);
      FIELD_SET(*this, FIX::TriggerNewQty);
      FIELD_SET(*this, FIX::TriggerTradingSessionID);
      FIELD_SET(*this, FIX::TriggerTradingSessionSubID);
      FIELD_SET(*this, FIX::Spread);
      FIELD_SET(*this, FIX::BenchmarkCurveCurrency);
      FIELD_SET(*this, FIX::BenchmarkCurveName);
      FIELD_SET(*this, FIX::BenchmarkCurvePoint);
      FIELD_SET(*this, FIX::BenchmarkPrice);
      FIELD_SET(*this, FIX::BenchmarkPriceType);
      FIELD_SET(*this, FIX::BenchmarkSecurityID);
      FIELD_SET(*this, FIX::BenchmarkSecurityIDSource);
      FIELD_SET(*this, FIX::YieldType);
      FIELD_SET(*this, FIX::Yield);
      FIELD_SET(*this, FIX::YieldCalcDate);
      FIELD_SET(*this, FIX::YieldRedemptionDate);
      FIELD_SET(*this, FIX::YieldRedemptionPrice);
      FIELD_SET(*this, FIX::YieldRedemptionPriceType);
      FIELD_SET(*this, FIX::Currency);
      FIELD_SET(*this, FIX::ComplianceID);
      FIELD_SET(*this, FIX::SolicitedFlag);
      FIELD_SET(*this, FIX::IOIID);
      FIELD_SET(*this, FIX::QuoteID);
      FIELD_SET(*this, FIX::RefOrderID);
      FIELD_SET(*this, FIX::RefOrderIDSource);
      FIELD_SET(*this, FIX::TimeInForce);
      FIELD_SET(*this, FIX::EffectiveTime);
      FIELD_SET(*this, FIX::ExpireDate);
      FIELD_SET(*this, FIX::ExpireTime);
      FIELD_SET(*this, FIX::GTBookingInst);
      FIELD_SET(*this, FIX::Commission);
      FIELD_SET(*this, FIX::CommType);
      FIELD_SET(*this, FIX::CommCurrency);
      FIELD_SET(*this, FIX::FundRenewWaiv);
      FIELD_SET(*this, FIX::OrderCapacity);
      FIELD_SET(*this, FIX::OrderRestrictions);
      FIELD_SET(*this, FIX::PreTradeAnonymity);
      FIELD_SET(*this, FIX::CustOrderCapacity);
      FIELD_SET(*this, FIX::ForexReq);
      FIELD_SET(*this, FIX::SettlCurrency);
      FIELD_SET(*this, FIX::BookingType);
      FIELD_SET(*this, FIX::Text);
      FIELD_SET(*this, FIX::EncodedTextLen);
      FIELD_SET(*this, FIX::EncodedText);
      FIELD_SET(*this, FIX::SettlDate2);
      FIELD_SET(*this, FIX::OrderQty2);
      FIELD_SET(*this, FIX::Price2);
      FIELD_SET(*this, FIX::PositionEffect);
      FIELD_SET(*this, FIX::CoveredOrUncovered);
      FIELD_SET(*this, FIX::MaxShow);
      FIELD_SET(*this, FIX::PegOffsetValue);
      FIELD_SET(*this, FIX::PegPriceType);
      FIELD_SET(*this, FIX::PegMoveType);
      FIELD_SET(*this, FIX::PegOffsetType);
      FIELD_SET(*this, FIX::PegLimitType);
      FIELD_SET(*this, FIX::PegRoundDirection);
      FIELD_SET(*this, FIX::PegScope);
      FIELD_SET(*this, FIX::PegSecurityIDSource);
      FIELD_SET(*this, FIX::PegSecurityID);
      FIELD_SET(*this, FIX::PegSymbol);
      FIELD_SET(*this, FIX::PegSecurityDesc);
      FIELD_SET(*this, FIX::DiscretionInst);
      FIELD_SET(*this, FIX::DiscretionOffsetValue);
      FIELD_SET(*this, FIX::DiscretionMoveType);
      FIELD_SET(*this, FIX::DiscretionOffsetType);
      FIELD_SET(*this, FIX::DiscretionLimitType);
      FIELD_SET(*this, FIX::DiscretionRoundDirection);
      FIELD_SET(*this, FIX::DiscretionScope);
      FIELD_SET(*this, FIX::TargetStrategy);
      FIELD_SET(*this, FIX::NoStrategyParameters);
      class NoStrategyParameters: public FIX::Group
      {
      public:
      NoStrategyParameters() : FIX::Group(957,958,FIX::message_order(958,959,960,0)) {}
        FIELD_SET(*this, FIX::StrategyParameterName);
        FIELD_SET(*this, FIX::StrategyParameterType);
        FIELD_SET(*this, FIX::StrategyParameterValue);
      };
      FIELD_SET(*this, FIX::TargetStrategyParameters);
      FIELD_SET(*this, FIX::ParticipationRate);
      FIELD_SET(*this, FIX::Designation);
    };
  };

}

#endif
