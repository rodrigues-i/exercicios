#pragma once

#include "quickfix/Application.h"
#include "quickfix/MessageCracker.h"
#include "quickfix/fix44/NewOrderSingle.h"


class Application
    : public FIX::Application,
      public FIX::MessageCracker
{
    // Application overloads
	void onCreate(const FIX::SessionID&);

    void onLogon(const FIX::SessionID& sessionID);

    void onLogout(const FIX::SessionID& sessionID);

    void toAdmin(FIX::Message&,
        const FIX::SessionID&);

    void toApp(FIX::Message&,
        const FIX::SessionID&)
        throw(FIX::DoNotSend);

    void fromAdmin(const FIX::Message&,
        const FIX::SessionID&)
        throw(FIX::FieldNotFound,
            FIX::IncorrectDataFormat,
            FIX::IncorrectTagValue,
            FIX::RejectLogon);

    void fromApp(const FIX::Message& message,
        const FIX::SessionID& sessionID)
        throw(FIX::FieldNotFound,
            FIX::IncorrectDataFormat,
            FIX::IncorrectTagValue,
            FIX::UnsupportedMessageType);

    // MessageCracker overloads
    void onMessage(const FIX44::NewOrderSingle&, const FIX::SessionID&);
};