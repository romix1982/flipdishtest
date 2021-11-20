using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using Flipdish.Recruiting.Core.Models;
using Flipdish.Recruiting.WebhookReceiver;

namespace Flipdish.Recruiting.UnitTest.WebhookReceiver
{
    [TestFixture]
    public class QueryInfoTest
    {
        private Mock<IQueryCollection> _queryCollection;

        [SetUp]
        public void SepUp()
        {
            _queryCollection = new Mock<IQueryCollection>();
        }

        [Test]
        public void DevEnvironment_should_be_not_null_if_query_collection_contain_param_test()
        {
            //Arrange
            _queryCollection.Setup(x => x["test"]).Returns("Test environment");

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.NotNull(queryInfo.DevEnvironment);
            Assert.IsNotEmpty(queryInfo.DevEnvironment);
        }

        [Test]
        public void DevEnvironment_should_be_null_if_query_collection_not_contain_param_test()
        {
            //Arrange
            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.Null(queryInfo.DevEnvironment);
        }

        [Test]
        public void DevEnvironment_should_be_empty_if_query_collection_contain_param_test_with_empty_value()
        {
            //Arrange
            _queryCollection.Setup(x => x["test"]).Returns("");

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.IsEmpty(queryInfo.DevEnvironment);
        }

        [Test]
        public void StoreIds_should_contain_only_int_values()
        {
            //Arrange
            _queryCollection.Setup(x => x["storeId"]).Returns(new StringValues(new string[] { "123", "hi" }));

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            CollectionAssert.IsNotEmpty(queryInfo.StoreIds);
            Assert.AreEqual(2, queryInfo.StoreIds.Count());
            Assert.True(queryInfo.StoreIds.Contains(0));
        }

        [Test]
        public void StoreIds_should_not_contain_values()
        {
            //Arrange
            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            CollectionAssert.IsEmpty(queryInfo.StoreIds);
            Assert.False(queryInfo.StoreIds.Contains(0));
        }

        [Test]
        public void Currency_should_be_EUR_if_param_is_invalid()
        {
            //Arrange
            _queryCollection.Setup(x => x["currency"]).Returns("Dollar");

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.AreEqual(Currency.EUR, queryInfo.Currency);
        }

        [TestCase(Currency.GBP)]
        [TestCase(Currency.HNL)]
        [TestCase(Currency.AED)]
        [TestCase(Currency.PEN)]
        [TestCase(Currency.BOB)]
        [TestCase(Currency.USD)]
        public void Currency_should_be_a_valid_currency(Currency currency)
        {
            //Arrange
            _queryCollection.Setup(x => x["currency"]).Returns(currency.ToString());

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.AreEqual(currency, queryInfo.Currency);
        }

        [Test]
        public void MetadataKey_should_be_eancode_if_value_is_empty()
        {
            //Arrange
            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.AreEqual("eancode", queryInfo.MetadataKey);
        }

        [TestCase("metadataKey 1")]
        [TestCase("metadataKey 2")]
        [TestCase("metadataKey 3")]
        public void MetadataKey_should_be_not_equal_to_eancode_if_value_is_not_empty(string metadata)
        {
            //Arrange
            _queryCollection.Setup(x => x["metadataKey"]).Returns(metadata);
            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            Assert.AreNotEqual("eancode", queryInfo.MetadataKey);
        }

        [Test]
        public void EmailsTo_should_not_be_empty()
        {
            //Arrange
            _queryCollection.Setup(x => x["to"]).Returns(new StringValues(new string[] { "john.doe@mail.com", "jane.doe@mail.com" }));

            //Act
            var queryInfo = new QueryInfo(_queryCollection.Object);

            //Assert
            CollectionAssert.IsNotEmpty(queryInfo.EmailsTo);
            Assert.AreEqual(2, queryInfo.EmailsTo.Count());
            Assert.True(queryInfo.EmailsTo.Contains("john.doe@mail.com"));
            Assert.True(queryInfo.EmailsTo.Contains("jane.doe@mail.com"));
        }

        [Test]
        public void EmailsTo_should_throw_exception_if_to_param_not_exist()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>new QueryInfo(_queryCollection.Object)); 
        }
    }
}
