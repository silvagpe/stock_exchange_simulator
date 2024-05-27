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



Order Entry FIX - Documentos com a interface de ordens para o PUMA Trading System, baseada em FIX 4.4
https://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-desenvolvedores-e-vendors/entrypoint-entrada-de-ofertas/


EntryPoint Message Speficication
https://www.b3.com.br/data/files/FB/25/28/3E/B8AAF8105391B9F8AC094EA8/EntryPointMessageSpecs2.34.pdf

EntryPoint Roteamento de Ordem
https://www.b3.com.br/data/files/BD/A0/D5/37/4381B71027085EA7AC094EA8/Roteiro_de_certificacao_EntryPoint_Derivativos_Acoes_v4.9.pdf

EntryPoint Message Specs
https://www.b3.com.br/data/files/FB/25/28/3E/B8AAF8105391B9F8AC094EA8/EntryPointMessageSpecs2.34.pdf


Exemplos de mensagens Fix
https://www.fixsim.com/sample-fix-messages


OnixS - Fields by Tags - FIX Dictionary
https://www.onixs.biz/fix-dictionary/4.4/fields_by_tag.html

QuickFixN - Github
https://github.com/connamara/quickfixn/blob/master/QuickFIXn/ThreadedSocketAcceptor.cs


Visualizador de Fix Messages
https://fixparser.targetcompid.com/

QuickFixN - Documentation
https://quickfixn.org/tutorial/creating-an-application.html




