using Demo_verificación.Entities;
using Demo_verificación.Services;
using Moq;
using System;
using Xunit;

namespace DemoVerificaciónTests
{
    public class MaquinaCafeTests
    {
        [Fact]
        void DevolverCambio_ShouldThrowsException_IfNoCoins()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            Action act = () => { maquinaCafe.DevolverCambio(400); };

            //Assert
            Assert.Throws<Exception>(act);
        }

        [Fact]
        void DevolverCambio_ShouldCallExpulsarMonedaWithDosEurosOnceWith2_IfReturnsIs400AndAnyCoinsAvailable()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(It.IsAny<TipoMoneda>())).Returns(20);
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            maquinaCafe.DevolverCambio(400);

            //Assert
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosEuros, 2), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.DosEuros), Times.Once);
            Mock.Get(cajaDeMonedas).VerifyNoOtherCalls();
        }

        [Fact]
        void DevolverCambio_ShouldCallExpulsarMonedaWithEveryTipoMonedaOnceWith2_IfReturnsIs388AndOnlyOneCoinOfEachTypeAvailable1()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(It.IsAny<TipoMoneda>())).Returns(1);
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            maquinaCafe.DevolverCambio(388);

            //Assert
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosEuros, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.DosEuros), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnEuro, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.UnEuro), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincuentaCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.CincuentaCent), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.VeinteCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.VeinteCent), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DiezCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.DiezCent), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincoCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.CincoCent), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.DosCent), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.CantidadMonedas(TipoMoneda.UnCent), Times.Once);
            Mock.Get(cajaDeMonedas).VerifyNoOtherCalls();
        }

        [Fact]
        void DevolverCambio_ShouldCallExpulsarMonedaWithEveryTipoMonedaOnceWith2_IfReturnsIs388AndOnlyOneCoinOfEachTypeAvailable2()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DosEuros)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.UnEuro)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.CincuentaCent)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.VeinteCent)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DiezCent)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.CincoCent)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DosCent)).Returns(1).Verifiable();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.UnCent)).Returns(1).Verifiable();
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            maquinaCafe.DevolverCambio(388);

            //Assert
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosEuros, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnEuro, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincuentaCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.VeinteCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DiezCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincoCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify();
            Mock.Get(cajaDeMonedas).VerifyNoOtherCalls();
        }

        [Fact]
        void DevolverCambio_ShouldCallExpulsarMonedaWithEveryTipoMonedaOnceWith2_IfReturnsIs388AndOnlyOneCoinOfEachTypeAvailable3()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DosEuros)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.UnEuro)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.CincuentaCent)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.VeinteCent)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DiezCent)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.CincoCent)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DosCent)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.UnCent)).Returns(1);
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            maquinaCafe.DevolverCambio(388);

            //Assert            
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosEuros, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnEuro, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincuentaCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.VeinteCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DiezCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.CincoCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.DosCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).Verify(caja => caja.ExpulsarMonedas(TipoMoneda.UnCent, 1), Times.Once);
            Mock.Get(cajaDeMonedas).VerifyAll();
            Mock.Get(cajaDeMonedas).VerifyNoOtherCalls();

        }

        [Fact]
        void DevolverCambio_ShouldCallExpulsarMonedaWithDosEurosOnceWith2_IfReturnsIs400AndAnyCoinsAvailable2()
        {
            //Arrange
            var cajaDeMonedas = Mock.Of<ICajaDeMonedas>();
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.DosEuros)).Returns(1);
            Mock.Get(cajaDeMonedas).Setup(caja => caja.CantidadMonedas(TipoMoneda.UnEuro)).Returns(2);
            var maquinaCafe = new MaquinaCafe(cajaDeMonedas);

            //Act
            maquinaCafe.DevolverCambio(400);

            //Assert
            Mock.VerifyAll(Mock.Get(cajaDeMonedas));
        }
    }
}
