using System;
using System.Collections;

namespace Collections
{
    public class Program
    {
        static void Main(string[] args)
        {
            //System.Collections.ObjectModel.ObservableCollection<Member> members = new System.Collections.ObjectModel.ObservableCollection<Member>();
            //members.CollectionChanged += Members_CollectionChanged;
            //members.Add(new Member
            //{
            //    Id = 1,
            //    Fname = "Payam",
            //    Lname = "Boroumand"
            //});

            //System.Collections.Stack memberStack = new System.Collections.Stack();
            //memberStack.Push(new Member{ Id = 1, Fname = "Payam", Lname= "Boroumand"});
            //memberStack.Push(new Member{ Id = 2, Fname = "Mehrdad", Lname= "ALiMohammadi"});

            //object firstElement = memberStack.Pop();
            //Console.WriteLine(((Member)firstElement).ToString());

            //memberStack.Push(new Member{ Id = 1, Fname = "Milad", Lname= "Karimi"});

            //firstElement = memberStack.Pop();
            //Console.WriteLine(((Member)firstElement).ToString());


            //System.Collections.Queue membersQueue = new System.Collections.Queue();
            //membersQueue.Enqueue(new Member{ Id = 1, Fname = "Payam", Lname= "Boroumand"});
            //membersQueue.Enqueue(new Member{ Id = 1, Fname = "Mehrdad", Lname= "ALi Mohammadi"});

            //object firstElement = membersQueue.Dequeue();
            //Console.WriteLine(((Member)firstElement).ToString());
            //firstElement = membersQueue.Dequeue();
            //Console.WriteLine(((Member)firstElement).ToString());

            PrintMenu();

            System.Collections.Generic.SortedSet<Member> sortedMembersList = new System.Collections.Generic.SortedSet<Member>();
            sortedMembersList.Add(new Member { Id = 3, Fname = "Mehrdad", Lname = "ALi Mohammadi" });
            sortedMembersList.Add(new Member { Id = 2, Fname = "Alireza", Lname = "Boroumand" });
            sortedMembersList.Add(new Member { Id = 1, Fname = "Payam", Lname = "Boroumand" });
            sortedMembersList.Add(new Member { Id = 5, Fname = "Milad", Lname = "Karimi" });
            sortedMembersList.Add(new Member { Id = 4, Fname = "Amir", Lname = "Mohammadi" });

            foreach (var member in sortedMembersList)
            {
                Console.WriteLine(member.ToString());
            }

            Main(null);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Select sorting mode members list:");
            Console.WriteLine("1- Sorting By Id");
            Console.WriteLine("2- Sorting By Fname");
            Console.WriteLine("3- Sorting By Lname");
            Console.WriteLine("4- Queit");
            string sort = Console.ReadLine();
            Member.SortMode = !string.IsNullOrWhiteSpace(sort) ? int.TryParse(sort, out int setSortMode) ? int.Parse(sort) : setSortMode : 1;
        }

        private static void Members_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine($"Add new item to members list");
                foreach (var member in e.NewItems)
                {
                    Console.WriteLine(member.ToString());
                }
            }
        }
    }

    public class Member : IComparer, IComparable
    {
        public int Id { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public static int SortMode { get; set; }

        public int Compare(object x, object y)
        {
            if (x is Member firstMember && y is Member secondMember)
            {
                if (firstMember.Id > secondMember.Id) return 1;
                else if (firstMember.Id < secondMember.Id) return -1;
                else return 0;
            }
            else
            {
                throw new ArgumentException("Arguments to Compare not Member type");
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Member member)
            {
                switch (SortMode)
                {
                    case 0:
                    case 1:
                        if (this.Id > member.Id) return 1;
                        else if (this.Id < member.Id) return -1;
                        else return 0;

                    case 2:
                        return string.Compare(this.Fname, member.Fname, StringComparison.CurrentCultureIgnoreCase);

                    case 3:
                        return string.Compare(this.Lname, member.Lname, StringComparison.CurrentCultureIgnoreCase);

                    case 4:
                        System.Environment.Exit(0);
                        break;

                    default:
                        if (this.Id > member.Id) return 1;
                        else if (this.Id < member.Id) return -1;
                        else return 0;
                }
            }
            throw new ArgumentException("Arguments to Compare not Member type");
        }

        public override string ToString()
        {
            return $" {Id}- {Fname} {Lname}\n";
        }
    }
}
