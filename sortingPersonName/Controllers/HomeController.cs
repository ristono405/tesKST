using sortingPersonName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace sortingPersonName.Controllers
{
    public class HomeController : Controller
    {
        string unsortedFile;
        string sortedFile;
        public ActionResult Index()
        {
            unsortedFile = Server.MapPath(".") + @"\data\unsorted_name_list.txt";
            sortedFile = Server.MapPath("/data/sorted_name_list.txt");

            var persons = new List<Person>();

            //GET DATA FROM unsorted_name_list.txt
            using (StreamReader sr = new StreamReader(unsortedFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int index = line.LastIndexOf(" ");
                    if (index > 0)// last name last is exist 
                    {
                        //get first & last name per line
                        string firstName = line.Substring(0, index);
                        string lastName = line.Substring(index + 1);

                        var person = new Person(firstName, lastName);
                        persons.Add(person);
                    }
                    else // last name last doesn't exist
                    {
                        var person = new Person(line, "");
                        persons.Add(person);
                    }
                }
            }
            return View(persons);
        }
        public ActionResult onSorted()
        {
            unsortedFile = Server.MapPath("/data/unsorted_name_list.txt"); ;
            sortedFile = Server.MapPath("/data/sorted_name_list.txt");

            var persons = new List<Person>();
            //GET DATA FROM unsorted_name_list.txt
            using (StreamReader sr = new StreamReader(unsortedFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int index = line.LastIndexOf(" ");
                    if (index > 0)// last name last is exist 
                    {
                        //get first & last name per line
                        string firstName = line.Substring(0, index);
                        string lastName = line.Substring(index + 1);

                        var person = new Person(firstName, lastName);
                        persons.Add(person);
                    }
                    else // last name last doesn't exist
                    {
                        var person = new Person(line, "");
                        persons.Add(person);
                    }
                }
            }
            var sortedPersons = persons.OrderBy(s => s.lastName).ThenBy(s => s.firstName);

            //create file unsorted_name_list.txt to save data after sorting
            FileInfo info = new FileInfo(sortedFile);
            if (info.Exists)
            {
                info.Delete();
            }
          
                using (StreamWriter writer = info.CreateText())
                {
                    
                    foreach (var item in sortedPersons)
                    {
                        writer.WriteLine(item.firstName + ' ' + item.lastName );
                    }

                 }
           //remove all item from person object
            persons.Clear();

            //GET DATA FROM sorted_name_list.txt
            using (StreamReader sr = new StreamReader(sortedFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int index = line.LastIndexOf(" ");
                    if (index > 0)// last name last is exist 
                    {
                        //get first & last name per line
                        string firstName = line.Substring(0, index);
                        string lastName = line.Substring(index + 1);

                        var person = new Person(firstName, lastName);
                        persons.Add(person);
                    }
                    else // last name last doesn't exist
                    {
                        var person = new Person(line, "");
                        persons.Add(person);
                    }
                }
            }

            return View(sortedPersons);
        }
    }
}