# Inheritance: Vehicle

A beginner-level task for practicing classes creating with inheritance relationship between them.

Estimated time to complete the task: 1 hour.

The task requires .NET 6 SDK installed.

## Task Description

- Create new classes: `Vehicle` and `Car`.  
- Add following fields to `Vehicle` class:  
	- `name`;  
	- `maxSpeed` (can be changed only via a constructor).  
	Fields should NOT be accessible from outside the class.
- Create a parametrized constructor with two parameters in order to initialize `Vehicle`.  
- Add following properties:  
	- `Name` (It must be accessible only in the current class and for inheritors. Property is available both for read and write operations);
	- `MaxSpeed` (It can be accessible for inheritors and outside of the class. Property is available only for reading).  
- Inherit `Car` class from `Vehicle` class.
- Implement a parametrized constructor for `Car` class and call a base class constructor.
- Implement the following methods in `Car` class:  
	- the first one would change the name of `Car`;  
	- the second one should NOT modify anything, but retrieve the name of `Car`.  
	Both methods must be accessible outside the class!
- Unit test requirements:
   - make sure there are unit tests for all methods   
   - check boundary conditions with Unit tests
   - use defensive coding and check input parameters
   - throw exceptions if some conditions or parameters are wrong

*Topics - classes, inheritance.*
