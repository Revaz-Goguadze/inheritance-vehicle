namespace InheritanceVehicle
{
    /// <summary>
    /// Represents a base Vehicle class.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="name">The name of the vehicle.</param>
        /// <param name="maxSpeed">The maximum speed of the vehicle.</param>
        public Vehicle(string name, int maxSpeed) => (this.Name, this.MaxSpeed) = (name, maxSpeed);

        /// <summary>
        /// Gets the maximum speed of the vehicle.
        /// </summary>
        public int MaxSpeed { get; }

        /// <summary>
        /// Gets or sets the name of the vehicle.
        /// </summary>
        protected string Name { get; set; }
    }
}
