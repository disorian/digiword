using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiWord.Business.Extensions;
using NUnit.Framework;

namespace DigiWord.Business.Test
{
    [TestFixture]
    public class NumberConverterExtensionTest
    {
        [Test]
        public void ToTextExtensionTest()
        {
            var number = 10_010_023ul;
            var expected = "ten million and ten thousand and twenty-three";

            var actual = number.ToText();

            Assert.AreEqual(expected, actual);
        }
    }
}
