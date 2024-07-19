using System;
using System.Collections.Generic;
using System.IO;
using HospitalReservation.Models;
using Newtonsoft.Json;

namespace HospitalReservation
{
    class Program
    {
        static List<Department> departments = new List<Department>();
        static List<Reservation> reservations = new List<Reservation>();

        static void Main(string[] args)
        {
            LoadData();
            while (true)
            {
                User user = GetUserDetails();
                MakeReservation(user);
            }
        }

        static void LoadData()
        {
            if (!File.Exists("departments.json"))
            {
                departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Pediatrics",
                        Doctors = new List<Doctor>
                        {
                            new Doctor { Name = "Oqtay", Surname = "Huseynov", Experience = 10 },
                            new Doctor { Name = "Xedice", Surname = "Ismayilova", Experience = 8 },
                            new Doctor { Name = "Cemil", Surname = "Aliyev", Experience = 12 }
                        }
                    },
                    new Department
                    {
                        Name = "Traumatology",
                        Doctors = new List<Doctor>
                        {
                            new Doctor { Name = "Said", Surname = "Alirza", Experience = 15 },
                            new Doctor { Name = "Rza", Surname = "Quliyev", Experience = 7 }
                        }
                    },
                    new Department
                    {
                        Name = "Stomatology",
                        Doctors = new List<Doctor>
                        {
                            new Doctor { Name = "Nigar", Surname = "Suleymanova", Experience = 5 },
                            new Doctor { Name = "Qulu", Surname = "Heybetov", Experience = 9 },
                            new Doctor { Name = "Ilqar", Surname = "Yamanov", Experience = 4 },
                            new Doctor { Name = "Polad", Surname = "Aslanov", Experience = 6 }
                        }
                    }
                };
                SaveData();
            }
            else
            {
                departments = JsonConvert.DeserializeObject<List<Department>>(File.ReadAllText("departments.json"));
            }

            if (File.Exists("reservations.json"))
            {
                reservations = JsonConvert.DeserializeObject<List<Reservation>>(File.ReadAllText("reservations.json"));
            }
        }

        static void SaveData()
        {
            File.WriteAllText("departments.json", JsonConvert.SerializeObject(departments, Formatting.Indented));
            File.WriteAllText("reservations.json", JsonConvert.SerializeObject(reservations, Formatting.Indented));
        }

        static User GetUserDetails()
        {
            User user = new User();
            Console.WriteLine("Enter your name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter your surname:");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your phone:");
            user.Phone = Console.ReadLine();
            return user;
        }

        static void MakeReservation(User user)
        {
            Console.WriteLine("Choose a department:");
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {departments[i].Name}");
            }

            int departmentChoice;
            try
            {
                departmentChoice = int.Parse(Console.ReadLine()) - 1;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                MakeReservation(user);
                return;
            }

            if (departmentChoice < 0 || departmentChoice >= departments.Count)
            {
                Console.WriteLine("Invalid choice. Please choose a valid department.");
                MakeReservation(user);
                return;
            }

            Department selectedDepartment = departments[departmentChoice];

            Console.WriteLine($"Doctors in {selectedDepartment.Name} department:");
            for (int i = 0; i < selectedDepartment.Doctors.Count; i++)
            {
                Doctor doctor = selectedDepartment.Doctors[i];
                Console.WriteLine($"{i + 1}. Dr. {doctor.Name} {doctor.Surname} ({doctor.Experience} years of experience)");
            }

            int doctorChoice;
            try
            {
                doctorChoice = int.Parse(Console.ReadLine()) - 1;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                MakeReservation(user);
                return;
            }

            if (doctorChoice < 0 || doctorChoice >= selectedDepartment.Doctors.Count)
            {
                Console.WriteLine("Invalid choice. Please choose a valid doctor.");
                MakeReservation(user);
                return;
            }

            Doctor selectedDoctor = selectedDepartment.Doctors[doctorChoice];

            while (true)
            {
                Console.WriteLine("Choose a time slot:");
                foreach (var slot in selectedDoctor.AppointmentSlots)
                {
                    string status = slot.Value ? "reserved" : "unreserved";
                    Console.WriteLine($"{slot.Key} - {status}");
                }

                string timeSlot = Console.ReadLine();
                if (selectedDoctor.AppointmentSlots.ContainsKey(timeSlot) && !selectedDoctor.AppointmentSlots[timeSlot])
                {
                    selectedDoctor.AppointmentSlots[timeSlot] = true;
                    reservations.Add(new Reservation { User = user, Department = selectedDepartment.Name, Doctor = selectedDoctor.Name, TimeSlot = timeSlot });
                    SaveData();
                    Console.WriteLine($"Thank you {user.Name} {user.Surname}, you have an appointment with Dr. {selectedDoctor.Name} at {timeSlot}.");
                    break;
                }
                else if (!selectedDoctor.AppointmentSlots.ContainsKey(timeSlot))
                {
                    Console.WriteLine("Please enter correct time!");
                }
                else
                {
                    Console.WriteLine("This time is already reserved, please choose another time.");
                }
            }
        }
    }
}



