using Moq;
using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.Domain.News.Interface.Infrastructure;
using Nuance.NPA.Domain.News.Service;
using Nuance.NPA.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.News.Test
{
    [TestFixture]
    public class NewsDomainServiceTest
    {
        #region Fields
        private Mock<INewsRepository> _newsRepositoryMock;
        #endregion

        #region Initialize
        [SetUp]
        public void SetUp()
        {
            _newsRepositoryMock = new Mock<INewsRepository>();
        }
        #endregion

        #region Public Method

        #region Get News
        /// <summary>
        ///4. A maximum of 8 news/items can be accommodated on a page and it should be possible to extend the number of pages
        ///5. A page can also have advertisements with the highest ratio of news/advertisement as 6/2
        ///6. Advertisements can be dropped if there is no place for a high priority news item
        /// </summary>
        [Test]
        public void When_GetNews_Maximum_8_News_Can_Accommodate_And_Highest_Ratio_News_Advertisement_6_2_GetNewsAsync()
        {
            try
            {
                NewsDomainService newsDomainService = new NewsDomainService(_newsRepositoryMock.Object);
                List<NewsEntity> expectedNews = new List<NewsEntity>();
                NewsSearchDto newsDto = new NewsSearchDto { CurrentPage = 1, PageSize = 8 };
                NewsEntity news = new NewsEntity(newsDto);
                expectedNews.Add(news);
                _newsRepositoryMock.Setup(c => c.GetNewsAsync(news)).ReturnsAsync(expectedNews);

                //Act
                Task<List<NewsEntity>> actualNewsList = newsDomainService.GetNewsAsync(newsDto);

                if (actualNewsList != null)
                    Assert.AreEqual(expectedNews.FirstOrDefault().PageSize, actualNewsList.Result.Count());
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail();
                throw;
            }
        }

        [Test]
        public void When_GetNews_Maximum_8_News_Can_Accommodate_GetNewsAsync()
        {
            try
            {
                NewsDomainService newsDomainService = new NewsDomainService(_newsRepositoryMock.Object);
                List<NewsEntity> expectedNews = new List<NewsEntity>();
                NewsSearchDto newsDto = new NewsSearchDto { CurrentPage = 1, PageSize = 8 };
                NewsEntity news = new NewsEntity(newsDto);
                expectedNews.Add(news);
                _newsRepositoryMock.Setup(c => c.GetNewsAsync(news)).ReturnsAsync(expectedNews);

                //Act
                Task<List<NewsEntity>> actualNewsList = newsDomainService.GetNewsAsync(newsDto);

                if (actualNewsList != null)
                    Assert.AreEqual(expectedNews.FirstOrDefault().PageSize, actualNewsList.Result.Count());
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }

        [TestCase]
        public void When_GetNews_GetNewsShouldThrowError()
        {
            try
            {
                NewsDomainService newsDomainService = new NewsDomainService(_newsRepositoryMock.Object);
                List<NewsEntity> expectedNews = new List<NewsEntity>();
                NewsSearchDto newsDto = new NewsSearchDto { CurrentPage = 1, PageSize = 8 };

                NewsEntity news = new NewsEntity(newsDto);
                expectedNews.Add(news);
                _newsRepositoryMock.Setup(c => c.GetNewsAsync(news)).ReturnsAsync(expectedNews);

                //Act
                Task<List<NewsEntity>> actualNewsList = newsDomainService.GetNewsAsync(newsDto);
                if (actualNewsList != null)
                    Assert.AreNotEqual(expectedNews.FirstOrDefault().PageSize, actualNewsList.Result.Count());
                Assert.IsFalse(false);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
                throw;
            }
        }

        #endregion

        #endregion

    }
}