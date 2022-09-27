#include <iostream>
#include "Application.h"
#include "quickfix/Session.h"




// Application overloads
void Application::onCreate(const FIX::SessionID&)
{
	std::cout << "A new session has been initiated" << '\n';
}

void Application::onLogon(const FIX::SessionID& sessionID)
{
	std::cout << "The onLogon method was called\n";

}
void Application::onLogout(const FIX::SessionID& sessionID)
{
	std::cout << "The onLogout method was called\n";

}

void Application::toAdmin(FIX::Message&, const FIX::SessionID&)
{}

void Application::toApp(FIX::Message&, const FIX::SessionID&)
throw(FIX::DoNotSend) {}

void Application::fromAdmin(const FIX::Message&, const FIX::SessionID&)
throw(FIX::FieldNotFound, FIX::IncorrectDataFormat, FIX::IncorrectTagValue, FIX::RejectLogon)
{}

void Application::fromApp(const FIX::Message& message,
						  const FIX::SessionID& sessionID)
throw(FIX::FieldNotFound, FIX::IncorrectDataFormat, FIX::IncorrectTagValue, FIX::UnsupportedMessageType)
{
	std::cout << "The fromApp method was called\n";
	std::cout << message;

    crack(message, sessionID);
}

void Application::onMessage(const FIX44::NewOrderSingle& message, const FIX::SessionID&)
{
	std::cout << "The onMessage method was called\n";

}