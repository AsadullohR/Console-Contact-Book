using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ContactBook
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();

            int userChoice;
            do
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Birthdays");
                Console.WriteLine("5. Search Contact");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        AddContact(contacts);
                        break;
                    case 2:
                        EditContact(contacts);
                        break;
                    case 3:
                        DeleteContact(contacts);
                        break;
                    case 4:
                        DisplayBirthdays(contacts);
                        break;
                    case 5:
                        SearchContact(contacts);
                        break;
                }
            } while (userChoice != 6);
        }

        static void AddContact(List<Contact> contacts)
        {
            Contact contact = new Contact();
            Console.Write("Enter Name: ");
            contact.Name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            contact.Surname = Console.ReadLine();
            Console.Write("Enter Telephone Number: ");
            contact.TelephoneNumber = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            contact.EmailAddress = Console.ReadLine();
            Console.Write("Enter Date of Birth (dd/mm/yyyy): ");
            contact.DateOfBirth = DateTime.Parse(Console.ReadLine());
            contacts.Add(contact);
            Console.WriteLine("Contact Added!");
        }

        static void EditContact(List<Contact> contacts)
        {
            Console.Write("Enter Contact Name to Edit: ");
            string name = Console.ReadLine();
            Contact contactToEdit = FindContactByName(contacts, name);
            if (contactToEdit == null)
            {
                Console.WriteLine("Contact Not Found");
                return;
            }
            Console.Write("Enter New Name: ");
            contactToEdit.Name = Console.ReadLine();
            Console.Write("Enter New Surname: ");
            contactToEdit.Surname = Console.ReadLine();
            Console.Write("Enter New Telephone Number: ");
            contactToEdit.TelephoneNumber = Console.ReadLine();
            Console.Write("Enter New Email Address: ");
            contactToEdit.EmailAddress = Console.ReadLine();
            Console.Write("Enter New Date of Birth (dd/mm/yyyy): ");
            contactToEdit.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Contact Edited!");
        }

        static void DeleteContact(List<Contact> contacts)
        {
            Console.Write("Enter Contact Name to Delete: ");
            string name = Console.ReadLine();
            Contact contactToDelete = FindContactByName(contacts, name);
            if (contactToDelete == null)
            {
                Console.WriteLine("Contact Not Found");
                return;
            }
            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact Deleted!");
        }

        static void DisplayBirthdays(List<Contact> contacts)
        {
            Console.WriteLine("Contacts with birthdays this week:");
            foreach (Contact contact in contacts)
            {
                if (contact.DateOfBirth.Month == DateTime.Now.Month &&
                    contact.DateOfBirth.Day >= DateTime.Now.Day &&
                    contact.DateOfBirth.Day < DateTime.Now.Day + 7)
                {
                    Console.WriteLine(contact.Name + " " + contact.Surname + " " + contact.DateOfBirth.ToString("dd/MM/yyyy"));
                }
            }
        }

        static void SearchContact(List<Contact> contacts)
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            Console.WriteLine("Search results:");
            foreach (Contact contact in contacts)
            {
                if (contact.Name.Contains(searchTerm) ||
                    contact.Surname.Contains(searchTerm) ||
                    contact.TelephoneNumber.Contains(searchTerm) ||
                    contact.EmailAddress.Contains(searchTerm) ||
                    contact.DateOfBirth.ToString().Contains(searchTerm))
                {
                    Console.WriteLine(contact.Name + " " + contact.Surname + " " + contact.TelephoneNumber + " " + contact.EmailAddress + " " + contact.DateOfBirth.ToString("dd/MM/yyyy"));
                }
            }
        }

        static Contact FindContactByName(List<Contact> contacts, string name)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.Name == name)
                {
                    return contact;
                }
            }
            return null;
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}