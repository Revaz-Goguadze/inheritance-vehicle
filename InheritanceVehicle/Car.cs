namespace InheritanceVehicle
{
    /// <summary>
    /// Represents a <see cref="Car"/> that inherits from a <see cref="Vehicle"/>.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with the specified name and maximum speed.
        /// </summary>
        /// <param name="name">The name of the car.</param>
        /// <param name="maxSpeed">The maximum speed of the car.</param>
        public Car(string name, int maxSpeed)
            : base(name, maxSpeed)
        {
            this.IsStarted = false;
            this.IsDriving = false;
            this.Speed = 0;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="IsStarted"/>.
        /// </summary>
        public bool IsStarted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether <see cref="IsDriving"/>.
        /// </summary>
        public bool IsDriving { get; private set; }

        /// <summary>
        /// Gets the  <see cref="Speed"/>.
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Changes the name of the car.
        /// </summary>
        /// <param name="newName">The new name of the car.</param>
        public void ChangeCarName(string newName) => this.Name = newName;

        /// <summary>
        /// Gets the name of the car.
        /// </summary>
        /// <returns>The name of the car.</returns>
#pragma warning disable CA1024
        public string GetCarName() => this.Name;
#pragma warning restore CA1024

        /// <summary>
        /// Starts the car.
        /// </summary>
        public virtual void CarStart()
        {
            Console.WriteLine("Car started.");
            this.IsStarted = true;
        }

        /// <summary>
        /// Stops the car.
        /// </summary>
        public virtual void CarStop()
        {
            Console.WriteLine("Car stopped.");
            this.Speed = 0;
            this.IsStarted = false;
            this.IsDriving = false;
        }

        /// <summary>
        /// Drives the car.
        /// </summary>
        public virtual void CarDrive()
        {
            if (this.IsStarted)
            {
                Console.WriteLine("Car is being driven.");
                this.IsDriving = true;
            }
            else
            {
                Console.WriteLine("Car is not started. Please start the car before driving.");
            }
        }

        /// <summary>
        /// Accelerates the car's speed.
        /// </summary>
        public virtual void CarAccelerate()
        {
            if (this.IsStarted && this.IsDriving)
            {
                if (this.Speed < this.MaxSpeed)
                {
                    this.Speed += 10;
                    Console.WriteLine("Car is accelerating. Current speed: " + this.Speed);
                }
                else
                {
                    Console.WriteLine("Maximum speed reached: " + this.MaxSpeed);
                }
            }
            else
            {
                Console.WriteLine("Car is not started or not in driving mode. Please start the car and begin driving before accelerating.");
            }
        }

        /// <summary>
        /// Decelerates the car's speed.
        /// </summary>
        public virtual void CarDecelerate()
        {
            if (this.IsStarted && this.IsDriving)
            {
                if (this.Speed > 0)
                {
                    this.Speed -= 10;
                    Console.WriteLine("Car is decelerating. Current speed: " + this.Speed);
                }
                else
                {
                    Console.WriteLine("Car has already stopped.");
                }
            }
            else
            {
                Console.WriteLine("Car is not started or not in driving mode. Please start the car and begin driving before decelerating.");
            }
        }
    }
}
