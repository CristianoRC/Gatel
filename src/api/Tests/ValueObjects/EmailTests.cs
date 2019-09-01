using Exceptions;
using Model.ValueObjects;
using Xunit;

namespace Tests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("sadfsfdg")]
        [InlineData("sadfsfdg.")]
        [InlineData("sadfsfdg@")]
        [InlineData("sadfsfdg@sadas")]
        [InlineData("sadfsfdg@sadas.")]
        [InlineData("sadfs@fdg@sadas")]
        public void DeveDarErroNaValidacaoDoEmail(string address)
        {
            Assert.Throws<InvalidEmailException>(() =>
            {
                var email = new Email(address);
            });
        }

        [Theory]
        [InlineData("seanq@att.net")]
        [InlineData("srour@outlook.com")]
        [InlineData("rsteiner@hotmail.com")]
        [InlineData("jbryan@comcast.net")]
        [InlineData("jbryan@comcast.com.br")]
        public void NaoDarErroNaValidacaoDoEmail(string address)
        {
            var email = new Email(address);

            Assert.Equal(address, email.Address);
        }
    }
}