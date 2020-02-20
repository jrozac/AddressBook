namespace TestAssignment.AddressBook.Repositories
{
    public class PhoneDbContextCfg
    {

        /// <summary>
        /// Database type
        /// </summary>
        public enum EnumDatabaseType
        {
            Sql,
            InMemory
        }

        public EnumDatabaseType DatabaseType { get; set; }

        public string ConnectionString { get; set; }

    }
}
