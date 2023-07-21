using System.Reflection;
using NUnit.Framework;

namespace InheritanceVehicle.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        private const string VehicleClassName = "vehicle";
        private const int ConstructorParamsCount = 2;
        private readonly string[] fields = { "name", "maxspeed" };
        private Type vehicleType;

        [SetUp]
        public void Initialize()
        {
            var assembly = typeof(Stub).Assembly;
            this.vehicleType = Array.Find(assembly.GetTypes(), t => t.Name.Equals(VehicleClassName, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void Vehicle_Class_Is_Created()
        {
            Assert.IsNotNull(this.vehicleType, "'Vehicle' class is not created.");
        }

        [Test]
        public void All_Fields_Are_Defined()
        {
            var notDefinedFields = new List<string>();
            var vehicleFields = this.vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (var field in this.fields)
            {
                var vField = Array.Find(vehicleFields, f => f.Name.ToLowerInvariant().Contains(field, StringComparison.InvariantCultureIgnoreCase));
                if (vField is null)
                {
                    notDefinedFields.Add(field);
                }
            }

            if (notDefinedFields.Count == 0)
            {
                notDefinedFields = null;
            }

            Assert.IsNull(
                notDefinedFields,
                $"Some field(s) is(are) not define: {notDefinedFields?.Aggregate((previous, next) => $"'{previous}', '{next}'")}");
        }

        [Test]
        public void MaxSpeed_Field_Is_Type_Of_Integer()
        {
            var vehicleFields = this.vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            var field = Array.Find(vehicleFields, f => f.Name.ToLowerInvariant().Contains(this.fields[1], StringComparison.InvariantCultureIgnoreCase));

            Assert.True(field.FieldType == typeof(int), $"'{field.Name}' field must be a type of INT.");
        }

        [Test]
        public void Name_Field_Is_Type_Of_String()
        {
            var vehicleFields = this.vehicleType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            var field = Array.Find(vehicleFields, f => f.Name.ToLowerInvariant().Contains(this.fields[0], StringComparison.InvariantCultureIgnoreCase));

            Assert.True(field.FieldType == typeof(string), $"'{field.Name}' field must be a type of STRING.");
        }

        [Test]
        public void Parametrized_Vehicle_Constructor_Is_Created()
        {
            var paramsConstructor = Array.Find(
                this.vehicleType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly),
                c =>
                {
                    var parameters = c.GetParameters();
                    if (parameters.Length == ConstructorParamsCount)
                    {
                        if ((parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(int)) ||
                            (parameters[0].ParameterType == typeof(int) && parameters[1].ParameterType == typeof(string)))
                        {
                            return true;
                        }

                        return false;
                    }

                    return false;
                });

            Assert.IsNotNull(paramsConstructor, "'Vehicle' parametrized constructor is not defined or it does NOT contain appropriate parameters.");
        }

        [Test]
        public void All_Properties_Are_Defined()
        {
            var notDefinedProperties = new List<string>();
            var vehicleProperties = this.vehicleType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (var field in this.fields)
            {
                var property = Array.Find(vehicleProperties, f => f.Name.ToLowerInvariant().Contains(field, StringComparison.InvariantCultureIgnoreCase));
                if (property is null)
                {
                    notDefinedProperties.Add(field);
                }
            }

            if (notDefinedProperties.Count == 0)
            {
                notDefinedProperties = null;
            }

            Assert.IsNull(
                notDefinedProperties,
                $"Some property(ies) is(are) not define: {notDefinedProperties?.Aggregate((previous, next) => $"'{previous}', '{next}'")}");
        }

        [Test]
        public void Name_Property_Is_Type_Of_String()
        {
            var nonPublicProperties = this.vehicleType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            var property = Array.Find(nonPublicProperties, p => p.Name.ToLowerInvariant().Contains(this.fields[0], StringComparison.InvariantCultureIgnoreCase));

            Assert.True(property.PropertyType == typeof(string), $"'{property.Name}' property must be a type of STRING.");
        }

        [Test]
        public void MaxSpeed_Property_Is_Type_Of_Integer()
        {
            var publicProperties = this.vehicleType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            var property = Array.Find(publicProperties, p => p.Name.ToLowerInvariant().Contains(this.fields[1], StringComparison.InvariantCultureIgnoreCase));

            Assert.True(property.PropertyType == typeof(int), $"'{property.Name}' property must be a type of INT.");
        }
    }
}
