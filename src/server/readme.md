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




O "Match Engine" (motor de correspondência) da Bolsa de Valores B3 (Brasil, Bolsa, Balcão) é o componente central do sistema de negociação que processa ordens de compra e venda de ativos, correspondendo essas ordens de acordo com regras predefinidas. Ele desempenha um papel crucial para garantir a eficiência, transparência e integridade do mercado. Aqui estão os principais aspectos de como funciona um Match Engine, com foco na B3:

1. Recebimento de Ordens
Ordens de Compra e Venda: O Match Engine recebe ordens de compra e venda de diferentes participantes do mercado (corretoras, investidores institucionais, traders individuais, etc.).
Tipos de Ordens: As ordens podem ser de diferentes tipos, incluindo ordens de mercado, ordens limitadas, ordens stop, entre outras.
2. Livro de Ofertas (Order Book)
Order Book: As ordens recebidas são armazenadas em um livro de ofertas eletrônico (order book), que mantém todas as ordens pendentes de execução.
Níveis de Preço: O livro de ofertas é organizado por níveis de preço, com as ordens de compra e venda ordenadas por preço e, em caso de preços iguais, por ordem cronológica de chegada.
3. Regras de Priorização
Prioridade de Preço: Ordens com melhores preços (preço de compra mais alto e preço de venda mais baixo) têm prioridade.
Prioridade Temporal: Em caso de preços iguais, a prioridade é dada às ordens que chegaram primeiro (FIFO - First In, First Out).
4. Processo de Correspondência
Matching: O Match Engine compara as ordens de compra com as ordens de venda para encontrar correspondências.
Execução: Quando uma correspondência é encontrada, a ordem é executada ao preço da ordem que estava no livro de ofertas.
5. Execução de Ordens
Parcial e Total: Ordens podem ser executadas parcialmente se não houver quantidade suficiente na contraparte.
Confirmação: Após a execução, as confirmações são enviadas para os participantes relevantes, informando sobre a execução.
6. Gerenciamento de Riscos
Validação: Antes de aceitar uma ordem, o Match Engine pode validar a ordem contra limites de crédito e outras regras de compliance.
Monitoramento: O sistema monitora a atividade de negociação em tempo real para identificar e mitigar riscos, como atividades suspeitas ou manipulação de mercado.
7. Transparência e Relatórios
Informação de Mercado: O Match Engine fornece atualizações contínuas sobre preços e volumes negociados, oferecendo transparência ao mercado.
Relatórios de Negociação: Gera relatórios detalhados sobre as negociações realizadas, que são enviados para os reguladores e os participantes do mercado.
8. Características Específicas da B3
PUMA Trading System: A B3 utiliza o sistema de negociação PUMA, desenvolvido em parceria com a CME Group, que é conhecido por sua alta performance e baixa latência.
Ações, Derivativos e Renda Fixa: O Match Engine da B3 processa uma variedade de ativos, incluindo ações, derivativos, títulos de renda fixa, entre outros.
Multimercado: O sistema é capaz de suportar negociações em múltiplos mercados e produtos simultaneamente.
Exemplo Simplificado de Correspondência
Vamos considerar um exemplo simples para ilustrar o funcionamento do Match Engine:

Ordens de Compra no Livro de Ofertas:

Ordem 1: Comprar 100 ações a R$10,00
Ordem 2: Comprar 50 ações a R$9,50
Ordens de Venda no Livro de Ofertas:

Ordem 1: Vender 100 ações a R$10,00
Ordem 2: Vender 50 ações a R$10,50
Quando uma nova ordem de venda é inserida:

Nova Ordem de Venda: Vender 100 ações a R$9,75
O Match Engine verificará que a nova ordem de venda tem um preço inferior à melhor ordem de compra (R$10,00). Portanto, a nova ordem de venda será correspondida imediatamente com a melhor ordem de compra, resultando na execução da negociação.

Benefícios de um Match Engine Eficiente
Alta Performance: Processa milhares de ordens por segundo, garantindo que o mercado funcione sem interrupções.
Transparência: Proporciona visibilidade contínua sobre as atividades de negociação.
Equidade: Garante que as ordens sejam correspondidas de acordo com regras claras e justas.
O Match Engine é um componente fundamental para o funcionamento eficiente dos mercados financeiros, proporcionando a infraestrutura necessária para a negociação de ativos financeiros de forma rápida, justa e transparente.