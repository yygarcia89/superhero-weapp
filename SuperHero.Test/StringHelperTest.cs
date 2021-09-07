using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperHero.Common.Helpers;
using System.Text;

namespace SuperHero.Test
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void CompressedJson_IsShorterThan_PlainJson()
        {
            // Arrange
            string plainJson = "{\"id\":\"547\",\"name\":\"Red Hulk\",\"powerstats\":{\"intelligence\":\"50\",\"strength\":\"100\",\"speed\":\"47\",\"durability\":\"85\",\"power\":\"82\",\"combat\":\"75\"},\"biography\":{\"full-name\":\"Thaddeus E. Ross\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Rulk\",\"Hulk\",\"Thunderbolt\",\"General Ross\"],\"place-of-birth\":\"-\",\"first-appearance\":\"Incredible Hulk #1 (May, 1962)(as General Ross), Hulk Vol 2 #1 (March, 2008) (as Red Hulk)\",\"publisher\":\"Marvel Comics\",\"alignment\":\"neutral\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human / Radiation\",\"height\":[\"7'0\",\"213 cm\"],\"weight\":[\"1400 lb\",\"630 kg\"],\"eye-color\":\"Yellow\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Lieutenant general in US Air Force\",\"base\":\"-\"},\"connections\":{\"group-affiliation\":\"Code Red, AIM; Formerly Offenders\",\"relatives\":\"-\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1342.jpg\"}}";

            // Act
            byte[] plainJsonBytes = Encoding.ASCII.GetBytes(plainJson);
            byte[] zipJsonBytes = plainJson.CompressStringToBytes();            

            // Assert
            Assert.IsTrue(zipJsonBytes.Length < plainJsonBytes.Length, "String was not compressed corretly");
        }

        [TestMethod]
        public void CompressedString_IsShorterThan_PlainString()
        {
            // Arrange
            string plainJson = "{\"id\":\"547\",\"name\":\"Red Hulk\",\"powerstats\":{\"intelligence\":\"50\",\"strength\":\"100\",\"speed\":\"47\",\"durability\":\"85\",\"power\":\"82\",\"combat\":\"75\"},\"biography\":{\"full-name\":\"Thaddeus E. Ross\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Rulk\",\"Hulk\",\"Thunderbolt\",\"General Ross\"],\"place-of-birth\":\"-\",\"first-appearance\":\"Incredible Hulk #1 (May, 1962)(as General Ross), Hulk Vol 2 #1 (March, 2008) (as Red Hulk)\",\"publisher\":\"Marvel Comics\",\"alignment\":\"neutral\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human / Radiation\",\"height\":[\"7'0\",\"213 cm\"],\"weight\":[\"1400 lb\",\"630 kg\"],\"eye-color\":\"Yellow\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Lieutenant general in US Air Force\",\"base\":\"-\"},\"connections\":{\"group-affiliation\":\"Code Red, AIM; Formerly Offenders\",\"relatives\":\"-\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1342.jpg\"}}";

            // Act
            string zipJsonString = plainJson.CompressString();

            // Assert
            Assert.IsTrue(zipJsonString.Length < plainJson.Length, "String was not compressed corretly");
        }

        [TestMethod]
        public void DecompressedString_IsEqualTo_PlainString()
        {
            // Arrange
            string plainJson = "{\"id\":\"547\",\"name\":\"Red Hulk\",\"powerstats\":{\"intelligence\":\"50\",\"strength\":\"100\",\"speed\":\"47\",\"durability\":\"85\",\"power\":\"82\",\"combat\":\"75\"},\"biography\":{\"full-name\":\"Thaddeus E. Ross\",\"alter-egos\":\"No alter egos found.\",\"aliases\":[\"Rulk\",\"Hulk\",\"Thunderbolt\",\"General Ross\"],\"place-of-birth\":\"-\",\"first-appearance\":\"Incredible Hulk #1 (May, 1962)(as General Ross), Hulk Vol 2 #1 (March, 2008) (as Red Hulk)\",\"publisher\":\"Marvel Comics\",\"alignment\":\"neutral\"},\"appearance\":{\"gender\":\"Male\",\"race\":\"Human / Radiation\",\"height\":[\"7'0\",\"213 cm\"],\"weight\":[\"1400 lb\",\"630 kg\"],\"eye-color\":\"Yellow\",\"hair-color\":\"Black\"},\"work\":{\"occupation\":\"Lieutenant general in US Air Force\",\"base\":\"-\"},\"connections\":{\"group-affiliation\":\"Code Red, AIM; Formerly Offenders\",\"relatives\":\"-\"},\"image\":{\"url\":\"https://www.superherodb.com/pictures2/portraits/10/100/1342.jpg\"}}";

            // Act
            string zipJsonString = plainJson.CompressString();
            string unzipJsonString = zipJsonString.DecompressString();

            // Assert
            Assert.IsTrue(plainJson.Equals(unzipJsonString), "String was corrupted during compression/decompression process");
        }
    }
}
