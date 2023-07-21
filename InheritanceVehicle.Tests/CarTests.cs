using System.Reflection;
using NUnit.Framework;

namespace InheritanceVehicle.Tests
{
    [TestFixture]
    public class CarTests
    {
        private const string CarClassName = "car";
        private const string VehicleClassName = "vehicle";
        private Type carType;

        [SetUp]
        public void Initialize()
        {
            var assembly = typeof(Stub).Assembly;
            this.carType = Array.Find(assembly.GetTypes(), t => t.Name.Equals(CarClassName, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void Car_Class_Is_Created()
        {
            Assert.IsNotNull(this.carType, "'Car' class is not created.");
        }

        [Test]
        public void Car_Inherits_Vehicle()
        {
            var carInstance = Activator.CreateInstance(this.carType, string.Empty, 0);
            var vehicleType = Array.Find(typeof(Stub).Assembly.GetTypes(), t => t.Name.Equals(VehicleClassName, StringComparison.OrdinalIgnoreCase));

            Assert.IsInstanceOf(vehicleType, carInstance, "'Car' type does NOT inherit 'Vehicle' type.");
        }

        [Test]
        public void Set_Name_Method_Is_Defined()
        {
            var method = Array.Find(
                this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly),
                m =>
                {
                    var parameters = m.GetParameters();
                    if (m.ReturnType == typeof(void) && parameters?.FirstOrDefault()?.ParameterType == typeof(string))
                    {
                        return true;
                    }

                    return false;
                });

            Assert.IsNotNull(method, "Method which changes 'Car' name is NOT define or it does NOT contain correct parameters.");
        }

        [Test]
        public void Get_Name_Method_Is_Defined()
        {
            var method = Array.Find(
                this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly),
                m =>
                {
                    if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
                    {
                        return true;
                    }

                    return false;
                });

            Assert.IsNotNull(method, "Method which retrieves 'Car' name is NOT define or it is's return type is NOT correct.");
        }

        [Test]
        public void Get_Car_Name()
        {
            var name = "Toyota";
            var newName = "BMW";
            var age = 5;
            var carInstance = Activator.CreateInstance(this.carType, name, age);

            var setNameMethod = Array.Find(
                this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly),
                m =>
                {
                    var parameters = m.GetParameters();
                    if (m.ReturnType == typeof(void) && parameters?.FirstOrDefault()?.ParameterType == typeof(string))
                    {
                        return true;
                    }

                    return false;
                });

            var getNameMethod = Array.Find(
                this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly),
                m =>
                {
                    if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
                    {
                        return true;
                    }

                    return false;
                });

            _ = setNameMethod.Invoke(carInstance, new[] { newName });

            var carName = getNameMethod.Invoke(carInstance, Array.Empty<object>());

            Assert.AreEqual(
                newName,
                carName,
                $"'{getNameMethod.Name}' method does NOT return correct value or '{setNameMethod.Name}' method does NOT change car name correctly.");
        }
    }
}
