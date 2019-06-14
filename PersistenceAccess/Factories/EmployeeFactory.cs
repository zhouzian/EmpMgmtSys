using LiteDB;
using PersistenceAccess.Entities;
using System;

namespace PersistenceAccess.Factories
{
	public class EmployeeFactory
	{
		public static Employee CreateEmployee(string firstName, string lastName, Gender gender, string email, Employee manager, Title title, Level level, decimal salary, decimal bonus, DateTime onboardDate)
		{
			Employee ret = null;
			try
			{
				var newEmployee = new Employee()
				{
					FirstName = firstName,
					LastName = lastName,
					Gender = gender,
					Email = email,
					OnboardDate = onboardDate,
				};
				PersistenceStore.Current.GetEmployeeStore().Insert(newEmployee);
				HistoryFactory.CreateHistory(newEmployee, manager, title, level, salary, bonus, ActionType.ONBOARD, newEmployee.OnboardDate);
				ret = newEmployee;
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to create new employee.", ex);
			}
			return ret;
		}

		public static void UpdateEmployeeInfo(Employee employee, string firstName, string lastName, Gender gender, string email, DateTime onboard)
		{
			if (employee.Id == Guid.Empty)
			{
				throw new Exception("Employee must be already persisted in db.");
			}
			try
			{
				employee.FirstName = firstName;
				employee.LastName = lastName;
				employee.Gender = gender;
				employee.Email = email;
				employee.OnboardDate = onboard;
				PersistenceStore.Current.GetEmployeeStore().Update(employee);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to update employee info.", ex);
			}
		}
	}
}
