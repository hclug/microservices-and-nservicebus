using FireOnWheels.Messages;
using FireOnWheels.Saga;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NServiceBus.Testing;

namespace FireOnWheels.Tests
{
    [TestClass]
    public class SagaTest
    {
        [TestMethod]
        public void ProcessOrderSaga_SendProcessOrderCommand_WhenPlanOrderCommandSent()
        {
            Test.Initialize();
            Test.Saga<ProcessOrderSaga>()
                    .ExpectSend<PlanOrderCommand>()
                .When(s => s.Handle(new ProcessOrderCommand()));
        }

        [TestMethod]
        public void ProcessOrderSaga_SendDispatchOrderCommand_WhenOrderDispatchedMessageReceived()
        {
            Test.Initialize();
            Test.Saga<ProcessOrderSaga>()
                    .ExpectReplyToOriginator<OrderProcessedMessage>()
                .WhenHandling<IOrderDispatchedMessage>()
                    .AssertSagaCompletionIs(true);
        }
    }
}
