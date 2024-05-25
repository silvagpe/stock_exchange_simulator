# Stock Exchange Simulator

## Ref
https://quickfixn.org/tutorial/creating-an-application.html
https://github.com/quickfix/quickfix/blob/master/spec/FIX44.xml

## Acceptor

```
C#
[DEFAULT]
ConnectionType=acceptor
SocketAcceptPort=5001
SocketReuseAddress=Y
StartTime=00:00:00
EndTime=00:00:00
FileLogPath=log
FileStorePath=c:\fixfiles
[SESSION]
BeginString=FIX.4.4
SenderCompID=EXECUTOR
TargetCompID=CLIENT1
DataDictionary=c:\user\nek\Code\FIX test App\data Dictionary\FIX44.xml
```

Connection type tells this application will run as Acceptor which is server.
SocketAcceptPort: listening port.
Session tag: is having configuration for creating session between client application (initiator) and acceptor.
BegingString: This sets session will work on which Fix Message specification.
SenderCompID: Id of server which will listen and send messages.
TargetCompID=Id of client to which server will send messages.
DataDictionary: Path of data dictionary file which is XML format, this file has message specifications according to various specifications versions.