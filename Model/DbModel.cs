namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbModel : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Model”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Model.Model”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Model”
        //连接字符串。
        public DbModel()
            : base("name=SFOMSDB")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Order> Orders { get; set; }
    }

    public class QueryInfo
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int MaxPageIndex
        {
            get
            {
                return (int)Math.Ceiling(TotalCount * 1.0 / PageSize);
            }
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}