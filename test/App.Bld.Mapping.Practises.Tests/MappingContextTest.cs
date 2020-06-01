/*---------------------------------------------------------------------------------------------
 *  Copyright (c) applicationbuildersalmanac.com. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using NUnit.Framework;

namespace App.Bld.Mapping.Practises.Tests
{
    [TestFixture]
    public class MappingContextTest
    {
        [Test]
        public void ShouldCacheMappings()
        {
            using var context = MappingContext.Create();

            var source = new object();

            var target = new object();

            context.AddMapping(
                source,
                target);

            Assert.That(
                context.TryGetMapping(
                    source,
                    out var checkTarget),
                Is.True);

            Assert.That(
                checkTarget,
                Is.SameAs(target));
        }
    }
}
