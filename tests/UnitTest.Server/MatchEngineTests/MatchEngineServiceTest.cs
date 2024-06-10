using Microsoft.Extensions.Logging;
using Moq;
using QuickFix;
using server.FixServer.Observer;
using server.MatchEngine;

namespace UnitTest.Server.MatchEngineTests;

public class MatchEngineServiceTest
{
    [Fact]
    public void Test1()
    {        
        var subject = new Mock<IApplicationSubject>();

        var logMatchEngineService = new Mock<ILogger<MatchEngineService>>();
        var service = new MatchEngineService(logMatchEngineService.Object, subject.Object);
    }
}