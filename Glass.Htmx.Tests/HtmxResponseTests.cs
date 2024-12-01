using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Glass.Htmx.Tests
{
    public class HtmxResponseTests
    {
        HtmxResponseBuilder _sut;
        HttpResponse _httpResponse;
        public HtmxResponseTests() { 

            _httpResponse = Substitute.For<HttpResponse>();
            _httpResponse.Headers.Returns(new HeaderDictionary());
            _sut = new HtmxResponseBuilder(_httpResponse);
        }

        [Fact]
        public void WithTrigger_TriggerWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger\":{}}";
            _sut.WithTrigger("trigger");

            //Assert
            var header = _sut.Triggers;

            //Assert
            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTrigger_MultipleTriggersWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger1\":{},\"trigger2\":{}}";
            _sut.WithTrigger("trigger1");
            _sut.WithTrigger("trigger2");

            //Assert
            var header = _sut.Triggers;

            //Assert
            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTrigger_MultipleTriggersWithTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger1\":{\"target\":\"target1\"},\"trigger2\":{\"target\":\"target2\"}}";
            _sut.WithTrigger("trigger1", x => x.Target("target1"));
            _sut.WithTrigger("trigger2", x => x.Target("target2"));

            //Assert
            var header = _sut.Triggers;

            //Assert
            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTriggerAfterSettle_TriggerWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger\":{}}";
            _sut.WithTriggerAfterSettle("trigger");

            //Assert
            var header = _sut.TriggerAfterSettle;

            //Assert
            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTriggerAfterSettle_MultipleTriggersWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger1\":{},\"trigger2\":{}}";

            //Act
            _sut.WithTriggerAfterSettle("trigger1");
            _sut.WithTriggerAfterSettle("trigger2");

            //Assert
            var header = _sut.TriggerAfterSettle;

            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTriggerAfterSettle_MultipleTriggersWithTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger1\":{\"target\":\"target1\"},\"trigger2\":{\"target\":\"target2\"}}";

            //Act
            _sut.WithTriggerAfterSettle("trigger1", x => x.Target("target1"));
            _sut.WithTriggerAfterSettle("trigger2", x => x.Target("target2"));

            //Assert
            var header = _sut.TriggerAfterSettle;

            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTriggerAfterSwap_TriggerWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger\":{}}";

            //Act
            _sut.WithTriggerAfterSwap("trigger");

            //Assert
            var header = _sut.TriggerAfterSwap;

            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithTriggerAfterSwap_MultipleTriggersWithoutTarget_SetHeader()
        {
            //Arrange
            string expected = "{\"trigger1\":{},\"trigger2\":{}}";

            //Act
            _sut.WithTriggerAfterSwap("trigger1");
            _sut.WithTriggerAfterSwap("trigger2");

            //Assert
            var header = _sut.TriggerAfterSwap;

            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

        [Fact]
        public void WithLocation_PathOnly_SetHeader()
        {
            //Arrange
            string expected = "/test";
            _sut.WithLocation("/test");

            //Assert
            var header = _sut.Location;

            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }


        [Fact]
        public void WithLocationAndTarget_PathOnly_SetHeader()
        {
            //Arrange
            string expected = "{\"path\":\"/test\",\"target\":\"#example\"}";
            _sut.WithLocation("/test", x=>x.Target("#example"));

            //Assert
            var header = _sut.Location;

            //Assert
            Assert.NotNull(header);
            Assert.Equal(expected, header);
        }

    }
}
