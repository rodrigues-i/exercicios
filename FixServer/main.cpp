//#include "greet.h"
#include "quickfix/FileStore.h"
#include "quickfix/FileLog.h"
#include "quickfix/SocketAcceptor.h"
#include "quickfix/Session.h"
#include "quickfix/SessionSettings.h"
#include "Application.h"

int main(int argc, char** argv)
{
    try
    {
        if (argc < 2)
        {
            return 1;
        }
        std::string fileName = argv[1];

        FIX::SessionSettings settings(fileName);

        Application application;
        FIX::FileStoreFactory storeFactory(settings);
        FIX::FileLogFactory logFactory(settings);
        FIX::SocketAcceptor acceptor
        (application, storeFactory, settings, logFactory /*optional*/);
        acceptor.start();
        std::cout << "Press q key and then enter to stop\n";
        while(true)
        {
            std::string value;
            std::cin >> value;

            if (value == "q") {
                break;
            }
        }

        acceptor.stop();
        return 0;
    }
    catch (FIX::ConfigError& e)
    {
        std::cout << e.what();
        return 1;
    }
}