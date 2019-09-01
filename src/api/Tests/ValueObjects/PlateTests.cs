using Exceptions;
using Model.ValueObjects;
using Xunit;

namespace Tests.ValueObjects
{
    public class PlateTests
    {
        #region Modelo Antigo

        [Theory]
        [InlineData("")]
        [InlineData("123assddf")]
        [InlineData("sadfsfdg.")]
        [InlineData("1235dsa")]
        [InlineData("asd1235")]
        public void DeveDarErroAoInserirPlacasInvalidasNoModeloAntigo(string placa)
        {
            Assert.Throws<InvalidPlateException>(() =>
            {
                var plate = new Plate(placa);
            });
        }

        [Theory]
        [InlineData("abc-1234")]
        [InlineData("XXX-1111")]
        public void NaoDeveDarErroNasPlacasDoModeloAntigo(string placa)
        {
            var plate = new Plate(placa);
            Assert.Equal(placa.ToUpper(), plate.Value);
        }

        #endregion


        #region Mercosul

        [Theory]
        [InlineData("")]
        [InlineData("sadfsfdg.")]
        [InlineData("1235-dsa")]
        [InlineData("asd1235")]
        public void DeveDarErroAoInserirPlacasInvalidasNoModeloMercosul(string placa)
        {
            Assert.Throws<InvalidPlateException>(() =>
            {
                var plate = new Plate(placa);
            });
        }

        [Theory]
        [InlineData("BRA3R52")]
        [InlineData("bra3r52")]
        [InlineData("pxl9d49")]
        [InlineData("AAA0A00")]
        public void NaoDeveDarErroNasPlacasDoModeloMercosul(string placa)
        {
            var plate = new Plate(placa);
            Assert.Equal(placa.ToUpper(), plate.Value);
        }
        
        #endregion
    }
}