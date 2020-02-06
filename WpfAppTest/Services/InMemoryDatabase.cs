using NHibernate.Cfg;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using WpfAppTest.Models;
using System.Data;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace WpfAppTest.Services
{
    class InMemoryDatabase : IDatabase
    {
        private ObservableCollection<Cardholder> _cardholderTable;
        ISessionFactory sessionFactory;
        public InMemoryDatabase()
        {
            var config = new Configuration()
                  .SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close")
                  .SetProperty(NHibernate.Cfg.Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                  .SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                  .SetProperty(NHibernate.Cfg.Environment.ConnectionString, "Data Source =Demo.db3; FailIfMissing = false;PRAGMA synchronous=off;PRAGMA journal_mode = MEMORY;DateTimeKind=Utc")
                  .SetProperty(NHibernate.Cfg.Environment.ShowSql, "false")
                  .SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            config.AddAssembly(typeof(App).Assembly);

            SchemaUpdate update = new SchemaUpdate(config);
            update.Execute(useStdOut: true, doUpdate: true);

            sessionFactory = config.BuildSessionFactory();

            
            Cardholder cardholder1 = new Cardholder { Birthday = DateTime.Now, Company = "AKKA", Firstname = "Mohamed", Lastname = "Zekhnini" };
            Cardholder cardholder2 = new Cardholder { Birthday = DateTime.Now, Company = "VINCI", Firstname = "Abdel", Lastname = "Seghrouchni" };
            _cardholderTable = new ObservableCollection<Cardholder>();
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var cardholders = session.Query<CardholderOrm>().ToArray();
                foreach (var cardholder in cardholders)
                {
                    CardholderTable.Add(new Cardholder { Firstname = cardholder.Firstname, Lastname = cardholder.Lastname, Birthday = cardholder.Birthday, Company = cardholder.Company,Id=cardholder.Id });
                }
            }
        }

        public ObservableCollection<Cardholder> CardholderTable { get { return _cardholderTable; } set { _cardholderTable = value; } }

        public void AddCardHolder(Cardholder cardholder)
        {
            
        }

        public void DeleteCardHolder(Cardholder cardholder)
        {
            Contract.Requires(CardholderTable.Contains(cardholder));
            Contract.Ensures(!CardholderTable.Contains(cardholder));
            CardholderTable.Remove(cardholder);
        }

        public ObservableCollection<Cardholder> GetCardholders()
        {
            return CardholderTable;
        }

        public void Update(Cardholder cardholder)
        {
            //Cardholder cardholderToUpdate = CardholderTable.Where(c => c.Firstname == cardholder.Firstname).FirstOrDefault();
            //cardholderToUpdate = cardholder;
            Contract.Requires(cardholder != null);
            //Contract.Ensures(CardholderTable.Contains(cardholder));
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var cardholderorm = session.Query<CardholderOrm>().Where(a => a.Id == cardholder.Id.Value).FirstOrDefault();
                cardholderorm.Firstname = cardholder.Firstname;
                cardholderorm.Lastname = cardholder.Lastname;
                cardholderorm.Birthday = cardholder.Birthday;
                cardholderorm.Company = cardholder.Company;
                //var cardholderOrm = new CardholderOrm()
                //{
                //    Firstname = cardholder.Firstname,
                //    Lastname = cardholder.Lastname,
                //    Birthday= cardholder.Birthday,
                //    Company = cardholder.Company
                //};
                session.SaveOrUpdate(cardholderorm);
                transaction.Commit();
                //session.Save(cardholderOrm);
                //transaction.Commit();
            }
        }
        
    }

   
}
