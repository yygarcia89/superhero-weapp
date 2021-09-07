using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperHero.Cache;
using System;

namespace SuperHero.Test
{
    [TestClass]
    public class RedisCacheTest
    {
        [TestMethod]
        public void Data_IsSaved_onCache()
        {
            // Arrange
            string key = $"{DateTime.Now}-temp-data";
            string plainJson = "{\"id\":\"547\",\"name\":\"Red Hulk\",\"powerstats\":{\"intelligence\":\"50\",\"strength\":\"100\",\"speed\":\"47\",\"durability\":\"85\",\"power\":\"82\",\"combat\":\"75\"},\"biography\":{\"full-name\":\"Thaddeus E. Ross\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Rulk\",\"Hulk\",\"Thunderbolt\",\"General Ross\"],\"place-of-birth\":\"-\",\"first-appearance\":\"Incredible Hulk #1 (May, 1962)(as General Ross), Hulk Vol 2 #1 (March, 2008) (as Red Hulk)\",\"publisher\":\"Marvel Comics\",\"alignment\":\"neutral\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human / Radiation\",\"height\":[\"7'0\",\"213 cm\"],\"weight\":[\"1400 lb\",\"630 kg\"],\"eye-color\":\"Yellow\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Lieutenant general in US Air Force\",\"base\":\"-\"},\"connections\":{\"group-affiliation\":\"Code Red, AIM; Formerly Offenders\",\"relatives\":\"-\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1342.jpg\"}}";
            CacheStrigsStack _cache = new CacheStrigsStack("superhero.redis.cache.windows.net:6380,password=YXrL8NS0nlf7fLlybyFl8Yu6bRRbVDQZoRLmpoQ3YqQ=,ssl=True,abortConnect=False");

            // Act
            _cache.SetStrings(key, plainJson, minutesTimeout: 1);
            bool isSaved = _cache.IsKeyExists(key);

            // Assert
            Assert.IsTrue(isSaved, "String was not saved on Cache");
        }

        [TestMethod]
        public void CachedData_IsEqualTo_OriginalData()
        {
            // Arrange
            string key = $"{DateTime.Now}-temp-data";
            string plainJson = "{\"id\":\"547\",\"name\":\"Red Hulk\",\"powerstats\":{\"intelligence\":\"50\",\"strength\":\"100\",\"speed\":\"47\",\"durability\":\"85\",\"power\":\"82\",\"combat\":\"75\"},\"biography\":{\"full-name\":\"Thaddeus E. Ross\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Rulk\",\"Hulk\",\"Thunderbolt\",\"General Ross\"],\"place-of-birth\":\"-\",\"first-appearance\":\"Incredible Hulk #1 (May, 1962)(as General Ross), Hulk Vol 2 #1 (March, 2008) (as Red Hulk)\",\"publisher\":\"Marvel Comics\",\"alignment\":\"neutral\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human / Radiation\",\"height\":[\"7'0\",\"213 cm\"],\"weight\":[\"1400 lb\",\"630 kg\"],\"eye-color\":\"Yellow\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Lieutenant general in US Air Force\",\"base\":\"-\"},\"connections\":{\"group-affiliation\":\"Code Red, AIM; Formerly Offenders\",\"relatives\":\"-\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1342.jpg\"}}";
            CacheStrigsStack _cache = new CacheStrigsStack("superhero.redis.cache.windows.net:6380,password=YXrL8NS0nlf7fLlybyFl8Yu6bRRbVDQZoRLmpoQ3YqQ=,ssl=True,abortConnect=False");

            // Act
            _cache.SetStrings(key, plainJson, minutesTimeout: 1);
            string dbItem = _cache.GetStrings(key);

            // Assert
            Assert.IsTrue(plainJson.Equals(dbItem), "String was corrupted during caching process");
        }
    }
}
