/*---------------------------------------------------------------------------------------------
 *  Copyright (c) applicationbuildersalmanac.com. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Moq;

using NUnit.Framework;

namespace App.Bld.Mapping.Practises.Tests
{
    [TestFixture]
    public class MapperExtensionsTest
    {
#pragma warning disable CS8618

        private Mock<IMapper<Source, Target>> _mapper;

#pragma warning restore

        [SetUp]
        public void SetUp()
        {
            _mapper = new Mock<IMapper<Source, Target>>();

            _mapper
                .Setup(m => m.Map(It.IsAny<Source>()))
                .Returns(CheckMapInvocation);
        }

        private Target CheckMapInvocation()
        {
            Assert.That(
                MappingContext.Current,
                Is.Not.Null);

            return new Target();
        }

        [Test]
        public void RootMapShouldCallMapWithinMappingContext()
        {
            using (MappingContext.Create())
            {
                var target = _mapper.Object.MapRoot(new Source());

                Assert.That(
                    target,
                    Is.Not.Null);
            }
        }

        #region Helpers

        public class Source
        {
        }

        public class Target
        {
        }

        #endregion
    }
}
