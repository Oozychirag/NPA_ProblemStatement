using Moq;
using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.Source.Entities;
using Nuance.NPA.Domain.Source.Interface.Infrastructure;
using Nuance.NPA.Domain.Source.Service;
using Nuance.NPA.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.Source.Test
{
    public class SourceDomainServiceTest
    {
        #region Fields
        private Mock<ISourceRepository> _sourceRepositoryMock;
        #endregion

        #region Initialize
        [SetUp]
        public void SetUp()
        {
            _sourceRepositoryMock = new Mock<ISourceRepository>();
        }
        #endregion

        #region Public Method

        #region Get Source
        [Test]
        public void When_Get_Generated_Source_Return_List_OF_Source()
        {
            try
            {
                SourceDomainService sourceDomainService = new Service.SourceDomainService(_sourceRepositoryMock.Object);
                List<SourceEntity> expectedSource = new List<SourceEntity>();
                SourceDto sourceDto = new SourceDto();
                SourceEntity source = new SourceEntity(sourceDto);
                expectedSource.Add(source);
                _sourceRepositoryMock.Setup(c => c.GetSourceAsync(source)).ReturnsAsync(expectedSource);

                //Act
                Task<List<SourceEntity>> actualSourceList = sourceDomainService.GetSoruceAsync(sourceDto);
                if (actualSourceList != null)
                    //Assert.
                    Assert.AreEqual(expectedSource.Count, actualSourceList.Result.Count);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }
        #endregion

        #region Generat Source

        [Test]
        public async Task When_GenerateSource_Return_BoolAsync()
        {
            try
            {
                SourceDomainService sourceDomainService = new Service.SourceDomainService(_sourceRepositoryMock.Object);
                List<SourceEntity> expectedSource = new List<SourceEntity>();
                SourceDto sourceDto = new SourceDto { SourceID = 4, SourceName = "Press Trust of India", SourceURL = "https://www.presstrustofindia.com", RegistrationDate = DateTime.Now, SourceType = SourceType.External, IsActive = true };
                SourceEntity source = new SourceEntity(sourceDto);
                expectedSource.Add(source);
                _sourceRepositoryMock.Setup(c => c.GetSourceAsync(source)).ReturnsAsync(expectedSource);

                //Act
                bool actualSourceList = await sourceDomainService.RegistrationAsync(sourceDto);

                //Assert.
                Assert.Equals(true, actualSourceList);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }

        public async Task When_GenerateSource_Return_Bool_ThrowExceptionAsync()
        {
            try
            {
                SourceDomainService sourceDomainService = new Service.SourceDomainService(_sourceRepositoryMock.Object);
                List<SourceEntity> expectedSource = new List<SourceEntity>();
                SourceDto sourceDto = new SourceDto { SourceID = 4, SourceName = "Press Trust of India", SourceURL = "https://www.presstrustofindia.com", RegistrationDate = DateTime.Now, SourceType = SourceType.External, IsActive = true };
                SourceEntity source = new SourceEntity(sourceDto);
                expectedSource.Add(source);
                _sourceRepositoryMock.Setup(c => c.GetSourceAsync(source)).ReturnsAsync(expectedSource);

                //Act
                bool actualSourceList = await sourceDomainService.RegistrationAsync(sourceDto);

                //Assert.
                Assert.Equals(true, actualSourceList);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }


        #endregion

        #endregion
    }
}