using System;
using FluentAssertions;
using NUnit.Framework;
using SimpleORM.Core.Mapping;
using TestModel.Basic;

namespace SimpleORM.Core.Test
{
    [TestFixture]
    public class MappingFixture
    {

        /// <summary>
        /// Test that mapper maps correctly a simple class mapping only its properties.
        /// </summary>
        [Test]
        public void TestMapClassProperties()
        {
            Type theType = typeof (BasicEntity);

            ClassMapper mapper = new ClassMapper();
            ClassMap map = mapper.Map(theType);

            map.Should().NotBeNull();

            map.Properties.Should().NotBeNull();
            map.Properties.Should().NotBeEmpty();
            map.Properties.Should().HaveCount(3);

            PropertyMap propertyMap = map.Properties[0];
            propertyMap.Name.Should().BeEquivalentTo("MyPropertyA");
            propertyMap.Type.Should().Be<string>();
        }

        /// <summary>
        /// Test that mapper maps correctly a simple class mapping only its properties.
        /// </summary>
        [Test]
        [ExpectedException(typeof(MappingException), ExpectedMessage = "Entity does not contain an identifier [Id].")]
        public void TestMapClassNoId()
        {
            Type theType = typeof(EntityNoId);

            ClassMapper mapper = new ClassMapper();
            mapper.Map(theType);
        }

        /// <summary>
        /// Mapped Class must have properties
        /// </summary>
        [Test]
        [ExpectedException(typeof(MappingException), ExpectedMessage = "An entity must have properties to map")]
        public void TestMapEmptyClass()
        {
            ClassMapper mapper = new ClassMapper();
            mapper.Map(typeof(EmptyEntity));
        }
    }
}
