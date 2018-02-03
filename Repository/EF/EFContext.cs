using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;
using YRD.Dao;
public partial class EFContext : DbContext
{
    #region OnConfiguring 设置连接字符串 
    public EFContext() : base("name=EFContext")
    {
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        #region 非ID 主键的映射
        modelBuilder.Entity<selshopdistributionaccount>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<selshopdistributiondetail>().HasKey(t => new { t.OrderNumber, t.Type }).Property(t => t.Type).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususerdetail>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<selshopjinbidetail>().HasKey(t => new { t.OrderNumber, t.Type }).Property(t => t.Type).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususer>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<selshopsmsdetail>().HasKey(t => new { t.OrderNumber, t.Type }).Property(t => t.Type).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<selshopdistribution>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<syspayhistory>().HasKey(t => new { t.OrderNumber });
        modelBuilder.Entity<selfreeshopid>().HasKey(t => new { t.ShopId });
        modelBuilder.Entity<cusfreeuserid>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususerjinbi>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususerscore>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<swhshopstock>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<selcardfreeid>().HasKey(t => new { t.CardID });
        modelBuilder.Entity<selcardaccount>().HasKey(t => new { t.CardID });
        modelBuilder.Entity<seltablestateversion>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<syssmstemplate>().HasKey(t => new { t.TemplateID }).Property(t => t.TemplateID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<selshopjinbiaccount>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<selshopsmsaccount>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<sysverificationcode>().HasKey(t => new { t.VerificationId });
        modelBuilder.Entity<selshoppaypassword>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<selshopsmsset>().HasKey(t => new { t.ShopID });
        modelBuilder.Entity<sysversion>().HasKey(t => new { t.VersionID }).Property(t => t.VersionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<swhstockaccount>().HasKey(t => new { t.MaterialID, t.WareHouseID });
        modelBuilder.Entity<swhstockdetail>().HasKey(t => new { t.OrderNumber, t.Type }).Property(t => t.Type).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        #region 2017-11-18
        modelBuilder.Entity<cuschainuser>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususerjinbidetail>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<cususerpaypassword>().HasKey(t => new { t.UserId }).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        #endregion
        #endregion

        #region 表名映射    
        #region 2017-11-18

        modelBuilder.Entity<cuschainuser>().Map(a => a.ToTable("cuschainuser"));
        modelBuilder.Entity<cuschainuserdetail>().Map(a => a.ToTable("cuschainuserdetail"));
        modelBuilder.Entity<cusorderdebt>().Map(a => a.ToTable("cusorderdebt"));
        modelBuilder.Entity<cuspaymenttype>().Map(a => a.ToTable("cuspaymenttype"));
        modelBuilder.Entity<cususercollectfood>().Map(a => a.ToTable("cususercollectfood"));
        modelBuilder.Entity<cususercollectshop>().Map(a => a.ToTable("cususercollectshop"));
        modelBuilder.Entity<cususerjinbidetail>().Map(a => a.ToTable("cususerjinbidetail"));
        modelBuilder.Entity<cususerpaypassword>().Map(a => a.ToTable("cususerpaypassword"));
        #endregion
        //Cuspaymentassociatedorders
        modelBuilder.Entity<cuspaymentassociatedorders>().Map(a => a.ToTable("cuspaymentassociatedorders"));
        modelBuilder.Entity<selshopdistributionopendetail>().Map(a => a.ToTable("selshopdistributionopendetail"));
        modelBuilder.Entity<selshopdistributionaccount>().Map(a => a.ToTable("selshopdistributionaccount"));
        modelBuilder.Entity<selshopdistributiondetail>().Map(a => a.ToTable("selshopdistributiondetail"));
        modelBuilder.Entity<cusaddress>().Map(a => a.ToTable("cusaddress"));
        //modelBuilder.Entity<cuscardtype>().Map(a => a.ToTable("cuscardtype"));
        modelBuilder.Entity<cuscritique>().Map(a => a.ToTable("cuscritique"));
        modelBuilder.Entity<cusfreeuserid>().Map(a => a.ToTable("cusfreeuserid"));
        modelBuilder.Entity<cusfriends>().Map(a => a.ToTable("cusfriends"));
        modelBuilder.Entity<cusintegralchange>().Map(a => a.ToTable("cusintegralchange"));
        modelBuilder.Entity<cusintegraltype>().Map(a => a.ToTable("cusintegraltype"));
        modelBuilder.Entity<cusloguserlevelchange>().Map(a => a.ToTable("cusloguserlevelchange"));
        modelBuilder.Entity<cusloguserlogin>().Map(a => a.ToTable("cusloguserlogin"));
        modelBuilder.Entity<cuslogusermoneychange>().Map(a => a.ToTable("cuslogusermoneychange"));
        modelBuilder.Entity<cusloguseroperation>().Map(a => a.ToTable("cusloguseroperation"));
        modelBuilder.Entity<cusorder>().Map(a => a.ToTable("cusorder"));
        //modelBuilder.Entity<cusordercus>().Map(a => a.ToTable("cusordercus"));
        modelBuilder.Entity<cusorderdetail>().Map(a => a.ToTable("cusorderdetail"));
        modelBuilder.Entity<cusorderfooddetail>().Map(a => a.ToTable("cusorderfooddetail"));
        //modelBuilder.Entity<cusorderpay>().Map(a => a.ToTable("cusorderpay"));
        //modelBuilder.Entity<cusorderpaydetail>().Map(a => a.ToTable("cusorderpaydetail"));
        modelBuilder.Entity<cusorderrabate>().Map(a => a.ToTable("cusorderrabate"));
        modelBuilder.Entity<cuspayment>().Map(a => a.ToTable("cuspayment"));
        modelBuilder.Entity<cuspaymentdetail>().Map(a => a.ToTable("cuspaymentdetail"));
        modelBuilder.Entity<cusrepayment>().Map(a => a.ToTable("cusrepayment"));
        modelBuilder.Entity<cusrepaymentdetail>().Map(a => a.ToTable("cusrepaymentdetail"));
        modelBuilder.Entity<cusreserve>().Map(a => a.ToTable("cusreserve"));
        modelBuilder.Entity<cususer>().Map(a => a.ToTable("cususer"));
        //modelBuilder.Entity<cususer_food>().Map(a => a.ToTable("cususer_food"));
        modelBuilder.Entity<cususer_level>().Map(a => a.ToTable("cususer_level"));
        //modelBuilder.Entity<cususer_shop>().Map(a => a.ToTable("cususer_shop"));
        modelBuilder.Entity<cususerdetail>().Map(a => a.ToTable("cususerdetail"));
        modelBuilder.Entity<cususerjinbi>().Map(a => a.ToTable("cususerjinbi"));
        modelBuilder.Entity<cususerleveltype>().Map(a => a.ToTable("cususerleveltype"));
        modelBuilder.Entity<cususerscore>().Map(a => a.ToTable("cususerscore"));
        //modelBuilder.Entity<Database>().Map(a => a.ToTable("Database"));
        modelBuilder.Entity<procompany>().Map(a => a.ToTable("procompany"));
        modelBuilder.Entity<procompany_area>().Map(a => a.ToTable("procompany_area"));
        modelBuilder.Entity<procompanyrabate>().Map(a => a.ToTable("procompanyrabate"));
        modelBuilder.Entity<prologmanagerlogin>().Map(a => a.ToTable("prologmanagerlogin"));
        modelBuilder.Entity<prologmanageroperate>().Map(a => a.ToTable("prologmanageroperate"));
        modelBuilder.Entity<promanager>().Map(a => a.ToTable("promanager"));
        modelBuilder.Entity<promanager_role>().Map(a => a.ToTable("promanager_role"));
        modelBuilder.Entity<promanager_selshop>().Map(a => a.ToTable("promanager_selshop"));
        modelBuilder.Entity<promanagerdetail>().Map(a => a.ToTable("promanagerdetail"));
        modelBuilder.Entity<propemit>().Map(a => a.ToTable("propemit"));
        modelBuilder.Entity<prorole>().Map(a => a.ToTable("prorole"));
        modelBuilder.Entity<prorole_pemit>().Map(a => a.ToTable("prorole_pemit"));
        modelBuilder.Entity<seladvertisement>().Map(a => a.ToTable("seladvertisement"));
        modelBuilder.Entity<selcardaccount>().Map(a => a.ToTable("selcardaccount"));
        modelBuilder.Entity<selcarddetail>().Map(a => a.ToTable("selcarddetail"));
        modelBuilder.Entity<selcardrecharge>().Map(a => a.ToTable("selcardrecharge"));
        modelBuilder.Entity<selcardfreeid>().Map(a => a.ToTable("selcardfreeid"));
        modelBuilder.Entity<selcardrule>().Map(a => a.ToTable("selcardrule"));
        modelBuilder.Entity<selcardrule_foodtype>().Map(a => a.ToTable("selcardrule_foodtype"));
        modelBuilder.Entity<selcardtype>().Map(a => a.ToTable("selcardtype"));
        modelBuilder.Entity<selcashier>().Map(a => a.ToTable("selcashier"));
        modelBuilder.Entity<selcashiersetting>().Map(a => a.ToTable("selcashiersetting"));
        modelBuilder.Entity<selcashier_department>().Map(a => a.ToTable("selcashier_department"));
        modelBuilder.Entity<selcontrolversion>().Map(a => a.ToTable("selcontrolversion"));
        modelBuilder.Entity<selcoupon>().Map(a => a.ToTable("selcoupon"));
        modelBuilder.Entity<selcouponimg>().Map(a => a.ToTable("selcouponimg"));
        modelBuilder.Entity<selcouponrule>().Map(a => a.ToTable("selcouponrule"));
        modelBuilder.Entity<seldepartment>().Map(a => a.ToTable("seldepartment"));
        modelBuilder.Entity<selexpenditure>().Map(a => a.ToTable("selexpenditure"));
        modelBuilder.Entity<selfixedcost>().Map(a => a.ToTable("selfixedcost"));
        modelBuilder.Entity<selflavor>().Map(a => a.ToTable("selflavor"));
        modelBuilder.Entity<selfood>().Map(a => a.ToTable("selfood"));
        modelBuilder.Entity<selfood_manager>().Map(a => a.ToTable("selfood_manager"));
        modelBuilder.Entity<selfoodattribute>().Map(a => a.ToTable("selfoodattribute"));
        modelBuilder.Entity<selfoodimg>().Map(a => a.ToTable("selfoodimg"));
        modelBuilder.Entity<selfoodmakelist>().Map(a => a.ToTable("selfoodmakelist"));
        modelBuilder.Entity<selfoodspecifications>().Map(a => a.ToTable("selfoodspecifications"));
        modelBuilder.Entity<selfoodtaste>().Map(a => a.ToTable("selfoodtaste"));
        modelBuilder.Entity<selfoodtype>().Map(a => a.ToTable("selfoodtype"));
        modelBuilder.Entity<selfoodunit>().Map(a => a.ToTable("selfoodunit"));
        modelBuilder.Entity<selfreeshopid>().Map(a => a.ToTable("selfreeshopid"));
        modelBuilder.Entity<sellevel>().Map(a => a.ToTable("sellevel"));
        modelBuilder.Entity<sellogmanagerlogin>().Map(a => a.ToTable("sellogmanagerlogin"));
        modelBuilder.Entity<sellogmanageroperate>().Map(a => a.ToTable("sellogmanageroperate"));
        modelBuilder.Entity<sellogshopmoney>().Map(a => a.ToTable("sellogshopmoney"));
        modelBuilder.Entity<selmanager>().Map(a => a.ToTable("selmanager"));
        modelBuilder.Entity<selmanager_role>().Map(a => a.ToTable("selmanager_role"));
        modelBuilder.Entity<selmanagerdetail>().Map(a => a.ToTable("selmanagerdetail"));
        modelBuilder.Entity<selnature>().Map(a => a.ToTable("selnature"));
        modelBuilder.Entity<selpackage>().Map(a => a.ToTable("selpackage"));
        modelBuilder.Entity<selpackage_food>().Map(a => a.ToTable("selpackage_food"));
        modelBuilder.Entity<selpackageimg>().Map(a => a.ToTable("selpackageimg"));
        modelBuilder.Entity<selpemit>().Map(a => a.ToTable("selpemit"));
        modelBuilder.Entity<selprinter>().Map(a => a.ToTable("selprinter"));
        modelBuilder.Entity<selprintertype>().Map(a => a.ToTable("selprintertype"));
        modelBuilder.Entity<selrefundpaylog>().Map(a => a.ToTable("selrefundpaylog"));
        modelBuilder.Entity<selrepaymentlog>().Map(a => a.ToTable("selrepaymentlog"));
        modelBuilder.Entity<selrole>().Map(a => a.ToTable("selrole"));
        modelBuilder.Entity<selrole_pemit>().Map(a => a.ToTable("selrole_pemit"));
        modelBuilder.Entity<selroom>().Map(a => a.ToTable("selroom"));
        modelBuilder.Entity<selroomtype>().Map(a => a.ToTable("selroomtype"));
        modelBuilder.Entity<selscale>().Map(a => a.ToTable("selscale"));
        modelBuilder.Entity<selshift>().Map(a => a.ToTable("selshift"));
        modelBuilder.Entity<selshop>().Map(a => a.ToTable("selshop"));
        modelBuilder.Entity<selshopdiscount>().Map(a => a.ToTable("selshopdiscount"));
        modelBuilder.Entity<selshopdistribution>().Map(a => a.ToTable("selshopdistribution"));
        modelBuilder.Entity<selshopimg>().Map(a => a.ToTable("selshopimg"));
        modelBuilder.Entity<selshopjinbiaccount>().Map(a => a.ToTable("selshopjinbiaccount"));
        modelBuilder.Entity<selshopjinbidetail>().Map(a => a.ToTable("selshopjinbidetail"));
        modelBuilder.Entity<selshopjinbirecharge>().Map(a => a.ToTable("selshopjinbirecharge"));
        modelBuilder.Entity<selshoppaypassword>().Map(a => a.ToTable("selshoppaypassword"));
        modelBuilder.Entity<selshopsmsaccount>().Map(a => a.ToTable("selshopsmsaccount"));
        modelBuilder.Entity<selshopsmschange>().Map(a => a.ToTable("selshopsmschange"));
        modelBuilder.Entity<selshopsmsdetail>().Map(a => a.ToTable("selshopsmsdetail"));
        modelBuilder.Entity<selshopsmsrecharge>().Map(a => a.ToTable("selshopsmsrecharge"));
        modelBuilder.Entity<selshopsmsset>().Map(a => a.ToTable("selshopsmsset"));
        modelBuilder.Entity<selshoptype>().Map(a => a.ToTable("selshoptype"));
        modelBuilder.Entity<selshopversion>().Map(a => a.ToTable("selshopversion"));
        modelBuilder.Entity<selshopvoice>().Map(a => a.ToTable("selshopvoice"));
        modelBuilder.Entity<seltable>().Map(a => a.ToTable("seltable"));
        modelBuilder.Entity<seltable_manager>().Map(a => a.ToTable("seltable_manager"));
        modelBuilder.Entity<seltablestate>().Map(a => a.ToTable("seltablestate"));
        modelBuilder.Entity<seltablestateversion>().Map(a => a.ToTable("seltablestateversion"));
        modelBuilder.Entity<seltabletype>().Map(a => a.ToTable("seltabletype"));
        modelBuilder.Entity<seltaboos>().Map(a => a.ToTable("seltaboos"));
        modelBuilder.Entity<seluserext>().Map(a => a.ToTable("seluserext"));
        modelBuilder.Entity<seluserextchange>().Map(a => a.ToTable("seluserextchange"));
        modelBuilder.Entity<seluserintegral>().Map(a => a.ToTable("seluserintegral"));
        modelBuilder.Entity<seluserintegralchange>().Map(a => a.ToTable("seluserintegralchange"));
        modelBuilder.Entity<seluserlevel>().Map(a => a.ToTable("seluserlevel"));
        modelBuilder.Entity<seluserlevelchange>().Map(a => a.ToTable("seluserlevelchange"));
        modelBuilder.Entity<swhfood_material>().Map(a => a.ToTable("swhfood_material"));
        modelBuilder.Entity<swhmaterial>().Map(a => a.ToTable("swhmaterial"));
        modelBuilder.Entity<swhmaterialbrand>().Map(a => a.ToTable("swhmaterialbrand"));
        modelBuilder.Entity<swhmaterialmainunit>().Map(a => a.ToTable("swhmaterialmainunit"));
        modelBuilder.Entity<swhmaterialtype>().Map(a => a.ToTable("swhmaterialtype"));
        modelBuilder.Entity<swhmaterialunit>().Map(a => a.ToTable("swhmaterialunit"));
        modelBuilder.Entity<swhorderapply>().Map(a => a.ToTable("swhorderapply"));
        modelBuilder.Entity<swhorderapplydetail>().Map(a => a.ToTable("swhorderapplydetail"));
        modelBuilder.Entity<swhorderautooutside>().Map(a => a.ToTable("swhorderautooutside"));
        modelBuilder.Entity<swhorderautooutsidefooddetail>().Map(a => a.ToTable("swhorderautooutsidefooddetail"));
        modelBuilder.Entity<swhorderautooutsidematerialdetail>().Map(a => a.ToTable("swhorderautooutsidematerialdetail"));
        modelBuilder.Entity<swhordercheck>().Map(a => a.ToTable("swhordercheck"));
        modelBuilder.Entity<swhordercheckdetail>().Map(a => a.ToTable("swhordercheckdetail"));
        modelBuilder.Entity<swhorderinitialstock>().Map(a => a.ToTable("swhorderinitialstock"));
        modelBuilder.Entity<swhorderinside>().Map(a => a.ToTable("swhorderinside"));
        modelBuilder.Entity<swhorderinsidedetail>().Map(a => a.ToTable("swhorderinsidedetail"));
        modelBuilder.Entity<swhorderlossrate>().Map(a => a.ToTable("swhorderlossrate"));
        modelBuilder.Entity<swhorderlossratedetail>().Map(a => a.ToTable("swhorderlossratedetail"));
        modelBuilder.Entity<swhorderrefunds>().Map(a => a.ToTable("swhorderrefunds"));
        modelBuilder.Entity<swhorderrefundsdetail>().Map(a => a.ToTable("swhorderrefundsdetail"));
        modelBuilder.Entity<swhorderrequisition>().Map(a => a.ToTable("swhorderrequisition"));
        modelBuilder.Entity<swhorderrequisitiondetail>().Map(a => a.ToTable("swhorderrequisitiondetail"));
        modelBuilder.Entity<swhorderstorage>().Map(a => a.ToTable("swhorderstorage"));
        modelBuilder.Entity<swhorderstoragedetail>().Map(a => a.ToTable("swhorderstoragedetail"));
        modelBuilder.Entity<swhshopstock>().Map(a => a.ToTable("swhshopstock"));
        modelBuilder.Entity<swhstockaccount>().Map(a => a.ToTable("swhstockaccount"));
        modelBuilder.Entity<swhstockdetail>().Map(a => a.ToTable("swhstockdetail"));
        modelBuilder.Entity<swhsupplier>().Map(a => a.ToTable("swhsupplier"));
        modelBuilder.Entity<swhsuppliermoneydetail>().Map(a => a.ToTable("swhsuppliermoneydetail"));
        modelBuilder.Entity<swhsupplierpayment>().Map(a => a.ToTable("swhsupplierpayment"));
        modelBuilder.Entity<swhsuppliertype>().Map(a => a.ToTable("swhsuppliertype"));
        modelBuilder.Entity<swhwarehouse>().Map(a => a.ToTable("swhwarehouse"));
        modelBuilder.Entity<sysad>().Map(a => a.ToTable("sysad"));
        modelBuilder.Entity<sysareabusiness>().Map(a => a.ToTable("sysareabusiness"));
        modelBuilder.Entity<sysareacity>().Map(a => a.ToTable("sysareacity"));
        modelBuilder.Entity<sysareacounty>().Map(a => a.ToTable("sysareacounty"));
        modelBuilder.Entity<sysareaprovince>().Map(a => a.ToTable("sysareaprovince"));
        modelBuilder.Entity<sysbase>().Map(a => a.ToTable("sysbase"));
        modelBuilder.Entity<sysbasemoneychange>().Map(a => a.ToTable("sysbasemoneychange"));
        modelBuilder.Entity<syschinaarea>().Map(a => a.ToTable("syschinaarea"));
        modelBuilder.Entity<sysfunctiontype>().Map(a => a.ToTable("sysfunctiontype"));
        modelBuilder.Entity<syslogmanagerlogin>().Map(a => a.ToTable("syslogmanagerlogin"));
        modelBuilder.Entity<syslogmanageroperate>().Map(a => a.ToTable("syslogmanageroperate"));
        modelBuilder.Entity<sysmanager>().Map(a => a.ToTable("sysmanager"));
        modelBuilder.Entity<sysmanager_role>().Map(a => a.ToTable("sysmanager_role"));
        modelBuilder.Entity<sysmanagerdetail>().Map(a => a.ToTable("sysmanagerdetail"));
        modelBuilder.Entity<sysnoticere>().Map(a => a.ToTable("sysnoticere"));
        modelBuilder.Entity<sysnoticesend>().Map(a => a.ToTable("sysnoticesend"));
        modelBuilder.Entity<syspayhistory>().Map(a => a.ToTable("syspayhistory"));
        modelBuilder.Entity<syspaymentmode>().Map(a => a.ToTable("syspaymentmode"));
        modelBuilder.Entity<syspemit>().Map(a => a.ToTable("syspemit"));
        modelBuilder.Entity<sysproxyapply>().Map(a => a.ToTable("sysproxyapply"));
        modelBuilder.Entity<sysproxyfeedback>().Map(a => a.ToTable("sysproxyfeedback"));
        modelBuilder.Entity<sysrole>().Map(a => a.ToTable("sysrole"));
        modelBuilder.Entity<sysrole_pemit>().Map(a => a.ToTable("sysrole_pemit"));
        modelBuilder.Entity<sysshopfeedback>().Map(a => a.ToTable("sysshopfeedback"));
        modelBuilder.Entity<syssms>().Map(a => a.ToTable("syssms"));
        modelBuilder.Entity<syssmsall>().Map(a => a.ToTable("syssmsall"));
        modelBuilder.Entity<syssmspackageprice>().Map(a => a.ToTable("syssmspackageprice"));
        modelBuilder.Entity<syssmstype>().Map(a => a.ToTable("syssmstype"));
        modelBuilder.Entity<syssmstemplate>().Map(a => a.ToTable("syssmstemplate"));
        modelBuilder.Entity<sysuserfeedback>().Map(a => a.ToTable("sysuserfeedback"));
        modelBuilder.Entity<sysverificationcode>().Map(a => a.ToTable("sysverificationcode"));
        modelBuilder.Entity<sysversion>().Map(a => a.ToTable("sysversion"));
        #endregion

        base.OnModelCreating(modelBuilder);
        //throw new Data.Entity.Infrastructure.UnintentionalCodeFirstException();
    }
    #endregion

    #region DbSet<T>
    public DbSet<selshopdistributionaccount> selshopdistributionaccount { get; set; }
    public DbSet<selshopdistributionopendetail> selshopdistributionopendetail { get; set; }
    public DbSet<selshopdistributiondetail> selshopdistributiondetail { get; set; }
    public virtual DbSet<swhorderstorage> swhorderstorage { get; set; }
    public virtual DbSet<swhorderstoragedetail> swhorderstoragedetail { get; set; }

    #region 2017-11-18
    public virtual DbSet<cuschainuser> cuschainuser { get; set; }
    public virtual DbSet<cuschainuserdetail> cuschainuserdetail { get; set; }
    public virtual DbSet<cusorderdebt> cusorderdebt { get; set; }
    public virtual DbSet<cuspaymenttype> cuspaymenttype { get; set; }
    public virtual DbSet<cususercollectfood> cususercollectfood { get; set; }
    public virtual DbSet<cususercollectshop> cususercollectshop { get; set; }
    public virtual DbSet<cususerjinbidetail> cususerjinbidetail { get; set; }
    public virtual DbSet<cususerpaypassword> cususerpaypassword { get; set; }
    #endregion

    #region 统计模块 新增
    public virtual DbSet<statisticscard> statisticscard { get; set; }
    public virtual DbSet<statisticscoupons> statisticscoupons { get; set; }
    public virtual DbSet<statisticsfood> statisticsfood { get; set; }
    public virtual DbSet<statisticsfoodtype> statisticsfoodtype { get; set; }
    public virtual DbSet<statisticspeople> statisticspeople { get; set; }
    public virtual DbSet<statisticstable> statisticstable { get; set; }
    #endregion

    public virtual DbSet<cusaddress> cusaddress { get; set; }
    //public virtual DbSet<cuscardtype> cuscardtype { get; set; }
    public virtual DbSet<cuscritique> cuscritique { get; set; }
    public virtual DbSet<cusfriends> cusfriends { get; set; }
    public virtual DbSet<cusintegralchange> cusintegralchange { get; set; }
    public virtual DbSet<cusintegraltype> cusintegraltype { get; set; }
    public virtual DbSet<cusloguserlevelchange> cusloguserlevelchange { get; set; }
    public virtual DbSet<cusloguserlogin> cusloguserlogin { get; set; }
    public virtual DbSet<cuslogusermoneychange> cuslogusermoneychange { get; set; }
    public virtual DbSet<cusloguseroperation> cusloguseroperation { get; set; }
    public virtual DbSet<cusorder> cusorder { get; set; }

    public DbSet<cusfreeuserid> cusfreeuserid { get; set; }
    //public virtual DbSet<cusorderpackagedetail> cusorderpackagedetail { get; set; }
    //public virtual DbSet<cusordercus> cusordercus { get; set; }
    public virtual DbSet<cusorderdetail> cusorderdetail { get; set; }
    public virtual DbSet<cusorderfooddetail> cusorderfooddetail { get; set; }
    //public virtual DbSet<cusorderpay> cusorderpay { get; set; }
    //public virtual DbSet<cusorderpaydetail> cusorderpaydetail { get; set; }
    public virtual DbSet<cusorderrabate> cusorderrabate { get; set; }
    public virtual DbSet<cusreserve> cusreserve { get; set; }
    public virtual DbSet<selcardfreeid> selcardfreeid { get; set; }
    public virtual DbSet<cususerscore> cususerscore { get; set; }
    public virtual DbSet<cususerjinbi> cususerjinbi { get; set; }
    public virtual DbSet<cususer> cususer { get; set; }
    //public virtual DbSet<cususer_food> cususer_food { get; set; }
    public virtual DbSet<cususer_level> cususer_level { get; set; }
    //public virtual DbSet<cususer_shop> cususer_shop { get; set; }
    public virtual DbSet<cususerdetail> cususerdetail { get; set; }
    public virtual DbSet<cususerleveltype> cususerleveltype { get; set; }
    public virtual DbSet<procompany> procompany { get; set; }
    public virtual DbSet<procompany_area> procompany_area { get; set; }
    public virtual DbSet<procompanyrabate> procompanyrabate { get; set; }
    public virtual DbSet<prologmanagerlogin> prologmanagerlogin { get; set; }
    public virtual DbSet<prologmanageroperate> prologmanageroperate { get; set; }
    public virtual DbSet<promanager> promanager { get; set; }
    public virtual DbSet<promanager_role> promanager_role { get; set; }
    public virtual DbSet<promanager_selshop> promanager_selshop { get; set; }
    public virtual DbSet<promanagerdetail> promanagerdetail { get; set; }
    public virtual DbSet<propemit> propemit { get; set; }
    public virtual DbSet<prorole> prorole { get; set; }
    public virtual DbSet<prorole_pemit> prorole_pemit { get; set; }
    public virtual DbSet<seladvertisement> seladvertisement { get; set; }
    public virtual DbSet<selcardaccount> selcardaccount { get; set; }

    public virtual DbSet<selcardrecharge> selcardrecharge { get; set; }
    public virtual DbSet<selcarddetail> selcarddetail { get; set; }
    public virtual DbSet<selcardrule> selcardrule { get; set; }
    public virtual DbSet<selcardtype> selcardtype { get; set; }
    public virtual DbSet<cuspayment> cuspayment { get; set; }

    public virtual DbSet<cuspaymentdetail> cuspaymentdetail { get; set; }
    public virtual DbSet<cusrepayment> cusrepayment { get; set; }

    public virtual DbSet<cusrepaymentdetail> cusrepaymentdetail { get; set; }
    public virtual DbSet<selcardrule_foodtype> selcardrule_foodtype { get; set; }
    public virtual DbSet<selcashier> selcashier { get; set; }
    public virtual DbSet<selcashiersetting> selcashiersetting { get; set; }

    public virtual DbSet<selcashier_department> selcashier_department { get; set; }
    public virtual DbSet<selcontrolversion> selcontrolversion { get; set; }
    public virtual DbSet<selcoupon> selcoupon { get; set; }
    public virtual DbSet<selcouponimg> selcouponimg { get; set; }
    public virtual DbSet<selcouponrule> selcouponrule { get; set; }
    public virtual DbSet<seldepartment> seldepartment { get; set; }
    public virtual DbSet<selexpenditure> selexpenditure { get; set; }
    public virtual DbSet<selfixedcost> selfixedcost { get; set; }
    public virtual DbSet<selfood> selfood { get; set; }
    public virtual DbSet<selfoodmakelist> selfoodmakelist { get; set; }
    public virtual DbSet<selfood_manager> selfood_manager { get; set; }
    public virtual DbSet<selfoodattribute> selfoodattribute { get; set; }
    public virtual DbSet<selfreeshopid> selfreeshopid { get; set; }
    public virtual DbSet<selfoodimg> selfoodimg { get; set; }
    public virtual DbSet<selfoodspecifications> selfoodspecifications { get; set; }
    public virtual DbSet<selfoodtype> selfoodtype { get; set; }
    public virtual DbSet<selfoodunit> selfoodunit { get; set; }
    public virtual DbSet<sellevel> sellevel { get; set; }
    public virtual DbSet<sellogmanagerlogin> sellogmanagerlogin { get; set; }
    public virtual DbSet<sellogmanageroperate> sellogmanageroperate { get; set; }
    public virtual DbSet<sellogshopmoney> sellogshopmoney { get; set; }
    public virtual DbSet<selmanager> selmanager { get; set; }
    public virtual DbSet<selmanager_role> selmanager_role { get; set; }
    public virtual DbSet<selmanagerdetail> selmanagerdetail { get; set; }
    public virtual DbSet<selnature> selnature { get; set; }
    public virtual DbSet<selpackage> selpackage { get; set; }
    public virtual DbSet<selpackage_food> selpackage_food { get; set; }
    public virtual DbSet<selpackageimg> selpackageimg { get; set; }
    public virtual DbSet<selpemit> selpemit { get; set; }
    public virtual DbSet<selprinter> selprinter { get; set; }
    public virtual DbSet<selprintertype> selprintertype { get; set; }
    public virtual DbSet<selrole> selrole { get; set; }
    public virtual DbSet<selrole_pemit> selrole_pemit { get; set; }
    public virtual DbSet<selroom> selroom { get; set; }
    public virtual DbSet<selroomtype> selroomtype { get; set; }
    public virtual DbSet<selscale> selscale { get; set; }
    public virtual DbSet<selshift> selshift { get; set; }
    public DbSet<selshop> selshop { get; set; }
    public DbSet<selshopdiscount> selshopdiscount { get; set; }
    public DbSet<selshopimg> selshopimg { get; set; }
    public DbSet<selshopjinbiaccount> selshopjinbiaccount { get; set; }
    public DbSet<selshopjinbidetail> selshopjinbidetail { get; set; }
    public DbSet<selshopjinbirecharge> selshopjinbirecharge { get; set; }
    public DbSet<selshopsmsaccount> selshopsmsaccount { get; set; }
    public DbSet<selshopsmschange> selshopsmschange { get; set; }
    public DbSet<selshopsmsdetail> selshopsmsdetail { get; set; }
    public DbSet<selshopsmsrecharge> selshopsmsrecharge { get; set; }
    public DbSet<selshopsmsset> selshopsmsset { get; set; }
    public DbSet<selshoptype> selshoptype { get; set; }
    public DbSet<selshopversion> selshopversion { get; set; }
    public DbSet<selshopvoice> selshopvoice { get; set; }
    public DbSet<selshopdistribution> selshopdistribution { get; set; }
    public virtual DbSet<seltable> seltable { get; set; }
    public virtual DbSet<seltable_manager> seltable_manager { get; set; }
    public virtual DbSet<seltabletype> seltabletype { get; set; }
    public virtual DbSet<seluserext> seluserext { get; set; }
    public virtual DbSet<seluserextchange> seluserextchange { get; set; }
    public virtual DbSet<seluserintegral> seluserintegral { get; set; }
    public virtual DbSet<seluserintegralchange> seluserintegralchange { get; set; }
    public virtual DbSet<seluserlevel> seluserlevel { get; set; }
    public virtual DbSet<seluserlevelchange> seluserlevelchange { get; set; }
    public DbSet<swhfood_material> swhfood_material { get; set; }
    public DbSet<swhmaterial> swhmaterial { get; set; }
    public DbSet<swhmaterialbrand> swhmaterialbrand { get; set; }
    public DbSet<swhmaterialmainunit> swhmaterialmainunit { get; set; }
    public DbSet<swhorderinitialstock> swhorderinitialstock { get; set; } 
    public DbSet<swhmaterialtype> swhmaterialtype { get; set; }
    public DbSet<swhmaterialunit> swhmaterialunit { get; set; }
    public DbSet<swhorderapply> swhorderapply { get; set; }
    public DbSet<swhorderapplydetail> swhorderapplydetail { get; set; }
    public DbSet<swhorderautooutside> swhorderautooutside { get; set; }
    public DbSet<swhorderautooutsidefooddetail> swhorderautooutsidefooddetail { get; set; }
    public DbSet<swhorderautooutsidematerialdetail> swhorderautooutsidematerialdetail { get; set; }
    public DbSet<swhordercheck> swhordercheck { get; set; }
    public DbSet<swhordercheckdetail> swhordercheckdetail { get; set; }
    public DbSet<swhorderinside> swhorderinside { get; set; }
    public DbSet<swhorderinsidedetail> swhorderinsidedetail { get; set; }
    public DbSet<swhorderlossrate> swhorderlossrate { get; set; }
    public DbSet<swhorderlossratedetail> swhorderlossratedetail { get; set; }
    public DbSet<swhorderrefunds> swhorderrefunds { get; set; }
    public DbSet<swhorderrefundsdetail> swhorderrefundsdetail { get; set; }
    public DbSet<swhorderrequisition> swhorderrequisition { get; set; }
    public DbSet<swhorderrequisitiondetail> swhorderrequisitiondetail { get; set; }
    public DbSet<swhshopstock> swhshopstock { get; set; }
    public DbSet<swhstockaccount> swhstockaccount { get; set; }
    public DbSet<swhstockdetail> swhstockdetail { get; set; }
    public DbSet<swhsupplier> swhsupplier { get; set; }
    public DbSet<swhsuppliertype> swhsuppliertype { get; set; }
    public DbSet<swhsupplierpayment> swhsupplierpayment { get; set; }
    public DbSet<swhsuppliermoneydetail> swhsuppliermoneydetail { get; set; }
    public DbSet<swhwarehouse> swhwarehouse { get; set; }
    public DbSet<sysad> sysad { get; set; }
    public DbSet<sysareabusiness> sysareabusiness { get; set; }
    public DbSet<sysareacity> sysareacity { get; set; }
    public DbSet<sysareacounty> sysareacounty { get; set; }
    public DbSet<sysareaprovince> sysareaprovince { get; set; }
    public DbSet<sysbase> sysbase { get; set; }
    public DbSet<sysbasemoneychange> sysbasemoneychange { get; set; }
    public DbSet<syschinaarea> syschinaarea { get; set; }
    public DbSet<sysfunctiontype> sysfunctiontype { get; set; }
    public DbSet<syslogmanagerlogin> syslogmanagerlogin { get; set; }
    public DbSet<syslogmanageroperate> syslogmanageroperate { get; set; }
    public DbSet<sysmanager> sysmanager { get; set; }
    public DbSet<sysmanager_role> sysmanager_role { get; set; }
    public DbSet<sysmanagerdetail> sysmanagerdetail { get; set; }
    public DbSet<sysnoticere> sysnoticere { get; set; }
    public DbSet<sysnoticesend> sysnoticesend { get; set; }
    public DbSet<syspayhistory> syspayhistory { get; set; }
    public DbSet<syspaymentmode> syspaymentmode { get; set; }
    public DbSet<syspemit> syspemit { get; set; }
    public DbSet<sysproxyapply> sysproxyapply { get; set; }
    public DbSet<sysproxyfeedback> sysproxyfeedback { get; set; }
    public DbSet<sysrole> sysrole { get; set; }
    public DbSet<sysrole_pemit> sysrole_pemit { get; set; }
    public DbSet<sysshopfeedback> sysshopfeedback { get; set; }
    public DbSet<syssms> syssms { get; set; }
    public DbSet<syssmsall> syssmsall { get; set; }
    public DbSet<syssmspackageprice> syssmspackageprice { get; set; }
    public DbSet<syssmstemplate> syssmstemplate { get; set; }
    public DbSet<syssmstype> syssmstype { get; set; }
    public DbSet<sysuserfeedback> sysuserfeedback { get; set; }
    public DbSet<sysverificationcode> sysverificationcode { get; set; }
    public DbSet<sysversion> sysversion { get; set; }
    public virtual DbSet<YRD.Dao.selflavor> selflavor { get; set; }
    public virtual DbSet<YRD.Dao.seltaboos> seltaboos { get; set; }

    public virtual DbSet<YRD.Dao.seltablestate> seltablestate { get; set; }
    public virtual DbSet<YRD.Dao.seltablestateversion> seltablestateversion { get; set; }
    /// <summary>
    /// 口味表
    /// </summary>
    public virtual DbSet<YRD.Dao.selfoodtaste> selfoodtaste { get; set; }

    public virtual DbSet<YRD.Dao.selrepaymentlog> selrepaymentlog { get; set; }
    public virtual DbSet<YRD.Dao.selrefundpaylog> selrefundpaylog { get; set; }
    public virtual DbSet<YRD.Dao.selshoppaypassword> selshoppaypassword { get; set; }
    public virtual DbSet<cuspaymentassociatedorders> cuspaymentassociatedorders { get; set; }

    #endregion

    #region Add

    public swhorderstorage Add(swhorderstorage model)
    {
        return this.swhorderstorage.Add(model);
    }
    public swhorderstoragedetail Add(swhorderstoragedetail model)
    {
        return this.swhorderstoragedetail.Add(model);
    }
    public cusaddress Add(cusaddress model)
    {
        return this.cusaddress.Add(model);
    }
    //public cuscardtype Add(cuscardtype model)
    //{
    //    return this.cuscardtype.Add(model);
    //}
    public cuscritique Add(cuscritique model)
    {
        return this.cuscritique.Add(model);
    }
    public cusfriends Add(cusfriends model)
    {
        return this.cusfriends.Add(model);
    }
    public cusintegralchange Add(cusintegralchange model)
    {
        return this.cusintegralchange.Add(model);
    }
    public cusintegraltype Add(cusintegraltype model)
    {
        return this.cusintegraltype.Add(model);
    }
    public cusloguserlevelchange Add(cusloguserlevelchange model)
    {
        return this.cusloguserlevelchange.Add(model);
    }
    public cusloguserlogin Add(cusloguserlogin model)
    {
        return this.cusloguserlogin.Add(model);
    }
    public cuslogusermoneychange Add(cuslogusermoneychange model)
    {
        return this.cuslogusermoneychange.Add(model);
    }
    public cusloguseroperation Add(cusloguseroperation model)
    {
        return this.cusloguseroperation.Add(model);
    }
    public cusorder Add(cusorder model)
    {
        return this.cusorder.Add(model);
    }
    public cusfreeuserid Add(cusfreeuserid model)
    {
        return this.cusfreeuserid.Add(model);
    }
    //public cusordercus Add(cusordercus model)
    //{
    //    return this.cusordercus.Add(model);
    //}
    public cusorderdetail Add(cusorderdetail model)
    {
        return this.cusorderdetail.Add(model);
    }
    public cusorderfooddetail Add(cusorderfooddetail model)
    {
        return this.cusorderfooddetail.Add(model);
    }
    //public cusorderpay Add(cusorderpay model)
    //{
    //    return this.cusorderpay.Add(model);
    //}
    //public cusorderpaydetail Add(cusorderpaydetail model)
    //{
    //    return this.cusorderpaydetail.Add(model);
    //}
    public cusorderrabate Add(cusorderrabate model)
    {
        return this.cusorderrabate.Add(model);
    }
    public cusreserve Add(cusreserve model)
    {
        return this.cusreserve.Add(model);
    }
    public selcardfreeid Add(selcardfreeid model)
    {
        return this.selcardfreeid.Add(model);
    }
    public cususerscore Add(cususerscore model)
    {
        return this.cususerscore.Add(model);
    }
    public cususerjinbi Add(cususerjinbi model)
    {
        return this.cususerjinbi.Add(model);
    }
    public cususer Add(cususer model)
    {
        return this.cususer.Add(model);
    }
    //public cususer_food Add(cususer_food model)
    //{
    //    return this.cususer_food.Add(model);
    //}
    public cususer_level Add(cususer_level model)
    {
        return this.cususer_level.Add(model);
    }
    //public cususer_shop Add(cususer_shop model)
    //{
    //    return this.cususer_shop.Add(model);
    //}
    public cususerdetail Add(cususerdetail model)
    {
        return this.cususerdetail.Add(model);
    }
    public cususerleveltype Add(cususerleveltype model)
    {
        return this.cususerleveltype.Add(model);
    }
    public procompany Add(procompany model)
    {
        return this.procompany.Add(model);
    }
    public procompany_area Add(procompany_area model)
    {
        return this.procompany_area.Add(model);
    }
    public procompanyrabate Add(procompanyrabate model)
    {
        return this.procompanyrabate.Add(model);
    }
    public prologmanagerlogin Add(prologmanagerlogin model)
    {
        return this.prologmanagerlogin.Add(model);
    }
    public prologmanageroperate Add(prologmanageroperate model)
    {
        return this.prologmanageroperate.Add(model);
    }
    public promanager Add(promanager model)
    {
        return this.promanager.Add(model);
    }
    public promanager_role Add(promanager_role model)
    {
        return this.promanager_role.Add(model);
    }
    public promanager_selshop Add(promanager_selshop model)
    {
        return this.promanager_selshop.Add(model);
    }
    public promanagerdetail Add(promanagerdetail model)
    {
        return this.promanagerdetail.Add(model);
    }
    public propemit Add(propemit model)
    {
        return this.propemit.Add(model);
    }
    public prorole Add(prorole model)
    {
        return this.prorole.Add(model);
    }
    public prorole_pemit Add(prorole_pemit model)
    {
        return this.prorole_pemit.Add(model);
    }
    public seladvertisement Add(seladvertisement model)
    {
        return this.seladvertisement.Add(model);
    }
    public selcardaccount Add(selcardaccount model)
    {
        return this.selcardaccount.Add(model);
    }
    public selcardrecharge Add(selcardrecharge model)
    {
        return this.selcardrecharge.Add(model);
    }
    public selcarddetail Add(selcarddetail model)
    {
        return this.selcarddetail.Add(model);
    }
    public selcardrule Add(selcardrule model)
    {
        return this.selcardrule.Add(model);
    }
    public selcardtype Add(selcardtype model)
    {
        return this.selcardtype.Add(model);
    }
    public cuspayment Add(cuspayment model)
    {
        return this.cuspayment.Add(model);
    }
    public cuspaymentdetail Add(cuspaymentdetail model)
    {
        return this.cuspaymentdetail.Add(model);
    }
    public cuspaymentassociatedorders Add(cuspaymentassociatedorders model)
    {
        return this.cuspaymentassociatedorders.Add(model);
    }
    public cusrepayment Add(cusrepayment model)
    {
        return this.cusrepayment.Add(model);
    }
    public cusrepaymentdetail Add(cusrepaymentdetail model)
    {
        return this.cusrepaymentdetail.Add(model);
    }
    public selcardrule_foodtype Add(selcardrule_foodtype model)
    {
        return this.selcardrule_foodtype.Add(model);
    }
    public selcashier Add(selcashier model)
    {
        return this.selcashier.Add(model);
    }
    public selcashiersetting Add(selcashiersetting model)
    {
        return this.selcashiersetting.Add(model);
    }
    public selcashier_department Add(selcashier_department model)
    {
        return this.selcashier_department.Add(model);
    }
    public selcontrolversion Add(selcontrolversion model)
    {
        return this.selcontrolversion.Add(model);
    }
    public selcoupon Add(selcoupon model)
    {
        return this.selcoupon.Add(model);
    }
    public selcouponimg Add(selcouponimg model)
    {
        return this.selcouponimg.Add(model);
    }

    public selcouponrule Add(selcouponrule model)
    {
        return this.selcouponrule.Add(model);
    }
    public seldepartment Add(seldepartment model)
    {
        return this.seldepartment.Add(model);
    }
    public selexpenditure Add(selexpenditure model)
    {
        return this.selexpenditure.Add(model);
    }
    public selfixedcost Add(selfixedcost model)
    {
        return this.selfixedcost.Add(model);
    }
    public selfood Add(selfood model)
    {
        return this.selfood.Add(model);
    }
    public selfoodmakelist Add(selfoodmakelist model)
    {
        return this.selfoodmakelist.Add(model);
    }
    public selfood_manager Add(selfood_manager model)
    {
        return this.selfood_manager.Add(model);
    }
    public selfoodattribute Add(selfoodattribute model)
    {
        return this.selfoodattribute.Add(model);
    }
    public selfreeshopid Add(selfreeshopid model)
    {
        return this.selfreeshopid.Add(model);
    }
    public selfoodimg Add(selfoodimg model)
    {
        return this.selfoodimg.Add(model);
    }
    public selfoodspecifications Add(selfoodspecifications model)
    {
        return this.selfoodspecifications.Add(model);
    }
    public selfoodtype Add(selfoodtype model)
    {
        return this.selfoodtype.Add(model);
    }
    public selfoodunit Add(selfoodunit model)
    {
        return this.selfoodunit.Add(model);
    }
    public sellevel Add(sellevel model)
    {
        return this.sellevel.Add(model);
    }
    public sellogmanagerlogin Add(sellogmanagerlogin model)
    {
        return this.sellogmanagerlogin.Add(model);
    }
    public sellogmanageroperate Add(sellogmanageroperate model)
    {
        return this.sellogmanageroperate.Add(model);
    }
    public sellogshopmoney Add(sellogshopmoney model)
    {
        return this.sellogshopmoney.Add(model);
    }
    public selmanager Add(selmanager model)
    {
        return this.selmanager.Add(model);
    }
    public selmanager_role Add(selmanager_role model)
    {
        return this.selmanager_role.Add(model);
    }
    public selmanagerdetail Add(selmanagerdetail model)
    {
        return this.selmanagerdetail.Add(model);
    }
    public selnature Add(selnature model)
    {
        return this.selnature.Add(model);
    }
    public selpackage Add(selpackage model)
    {
        return this.selpackage.Add(model);
    }
    public selpackage_food Add(selpackage_food model)
    {
        return this.selpackage_food.Add(model);
    }
    public selpackageimg Add(selpackageimg model)
    {
        return this.selpackageimg.Add(model);
    }
    public selpemit Add(selpemit model)
    {
        return this.selpemit.Add(model);
    }
    public selprinter Add(selprinter model)
    {
        return this.selprinter.Add(model);
    }
    public selprintertype Add(selprintertype model)
    {
        return this.selprintertype.Add(model);
    }
    public selrole Add(selrole model)
    {
        return this.selrole.Add(model);
    }
    public selrole_pemit Add(selrole_pemit model)
    {
        return this.selrole_pemit.Add(model);
    }
    public selroom Add(selroom model)
    {
        return this.selroom.Add(model);
    }
    public selroomtype Add(selroomtype model)
    {
        return this.selroomtype.Add(model);
    }
    public selscale Add(selscale model)
    {
        return this.selscale.Add(model);
    }
    public selshift Add(selshift model)
    {
        return this.selshift.Add(model);
    }
    public selshop Add(selshop model)
    {
        return this.selshop.Add(model);
    }
    public selshopdiscount Add(selshopdiscount model)
    {
        return this.selshopdiscount.Add(model);
    }
    public selshopimg Add(selshopimg model)
    {
        return this.selshopimg.Add(model);
    }
    public selshopjinbiaccount Add(selshopjinbiaccount model)
    {
        return this.selshopjinbiaccount.Add(model);
    }
    public selshopjinbidetail Add(selshopjinbidetail model)
    {
        return this.selshopjinbidetail.Add(model);
    }
    public selshopjinbirecharge Add(selshopjinbirecharge model)
    {
        return this.selshopjinbirecharge.Add(model);
    }
    public selshopsmsaccount Add(selshopsmsaccount model)
    {
        return this.selshopsmsaccount.Add(model);
    }
    public selshopsmschange Add(selshopsmschange model)
    {
        return this.selshopsmschange.Add(model);
    }
    public selshopsmsdetail Add(selshopsmsdetail model)
    {
        return this.selshopsmsdetail.Add(model);
    }
    public selshoptype Add(selshoptype model)
    {
        return this.selshoptype.Add(model);
    }
    public selshopversion Add(selshopversion model)
    {
        return this.selshopversion.Add(model);
    }
    public selshopvoice Add(selshopvoice model)
    {
        return this.selshopvoice.Add(model);
    }
    public selshopdistribution Add(selshopdistribution model)
    {
        return this.selshopdistribution.Add(model);
    }
    public seltable Add(seltable model)
    {
        return this.seltable.Add(model);
    }
    public seltable_manager Add(seltable_manager model)
    {
        return this.seltable_manager.Add(model);
    }
    public seltabletype Add(seltabletype model)
    {
        return this.seltabletype.Add(model);
    }
    public seluserext Add(seluserext model)
    {
        return this.seluserext.Add(model);
    }
    public seluserextchange Add(seluserextchange model)
    {
        return this.seluserextchange.Add(model);
    }
    public seluserintegral Add(seluserintegral model)
    {
        return this.seluserintegral.Add(model);
    }
    public seluserintegralchange Add(seluserintegralchange model)
    {
        return this.seluserintegralchange.Add(model);
    }
    public seluserlevel Add(seluserlevel model)
    {
        return this.seluserlevel.Add(model);
    }
    public seluserlevelchange Add(seluserlevelchange model)
    {
        return this.seluserlevelchange.Add(model);
    }
    public swhfood_material Add(swhfood_material model)
    {
        return this.swhfood_material.Add(model);
    }
    public swhmaterial Add(swhmaterial model)
    {
        return this.swhmaterial.Add(model);
    }
    public swhmaterialbrand Add(swhmaterialbrand model)
    {
        return this.swhmaterialbrand.Add(model);
    }    public swhmaterialmainunit Add(swhmaterialmainunit model)
    {
        return this.swhmaterialmainunit.Add(model);
    }
    public swhorderinitialstock Add(swhorderinitialstock model)
    {
        return this.swhorderinitialstock.Add(model);
    }
    public swhmaterialtype Add(swhmaterialtype model)
    {
        return this.swhmaterialtype.Add(model);
    }
    public swhmaterialunit Add(swhmaterialunit model)
    {
        return this.swhmaterialunit.Add(model);
    }
    public swhorderapply Add(swhorderapply model)
    {
        return this.swhorderapply.Add(model);
    }
    public swhorderapplydetail Add(swhorderapplydetail model)
    {
        return this.swhorderapplydetail.Add(model);
    }
    public swhorderautooutside Add(swhorderautooutside model)
    {
        return this.swhorderautooutside.Add(model);
    }
    public swhorderautooutsidefooddetail Add(swhorderautooutsidefooddetail model)
    {
        return this.swhorderautooutsidefooddetail.Add(model);
    }
    public swhorderautooutsidematerialdetail Add(swhorderautooutsidematerialdetail model)
    {
        return this.swhorderautooutsidematerialdetail.Add(model);
    }
    public swhordercheck Add(swhordercheck model)
    {
        return this.swhordercheck.Add(model);
    }
    public swhordercheckdetail Add(swhordercheckdetail model)
    {
        return this.swhordercheckdetail.Add(model);
    }
    public swhorderinside Add(swhorderinside model)
    {
        return this.swhorderinside.Add(model);
    }
    public swhorderinsidedetail Add(swhorderinsidedetail model)
    {
        return this.swhorderinsidedetail.Add(model);
    }
    public swhorderlossrate Add(swhorderlossrate model)
    {
        return this.swhorderlossrate.Add(model);
    }
    public swhorderlossratedetail Add(swhorderlossratedetail model)
    {
        return this.swhorderlossratedetail.Add(model);
    }
    public swhorderrefunds Add(swhorderrefunds model)
    {
        return this.swhorderrefunds.Add(model);
    }
    public swhorderrefundsdetail Add(swhorderrefundsdetail model)
    {
        return this.swhorderrefundsdetail.Add(model);
    }
    public swhorderrequisition Add(swhorderrequisition model)
    {
        return this.swhorderrequisition.Add(model);
    }
    public swhorderrequisitiondetail Add(swhorderrequisitiondetail model)
    {
        return this.swhorderrequisitiondetail.Add(model);
    }
    public swhshopstock Add(swhshopstock model)
    {
        return this.swhshopstock.Add(model);
    }
    public swhstockaccount Add(swhstockaccount model)
    {
        return this.swhstockaccount.Add(model);
    }
    public swhstockdetail Add(swhstockdetail model)
    {
        return this.swhstockdetail.Add(model);
    }
    public swhsupplier Add(swhsupplier model)
    {
        return this.swhsupplier.Add(model);
    }
    public swhsuppliertype Add(swhsuppliertype model)
    {
        return this.swhsuppliertype.Add(model);
    }
    public swhsupplierpayment Add(swhsupplierpayment model)
    {
        return this.swhsupplierpayment.Add(model);
    }
    public swhsuppliermoneydetail Add(swhsuppliermoneydetail model)
    {
        return this.swhsuppliermoneydetail.Add(model);
    }
    public swhwarehouse Add(swhwarehouse model)
    {
        return this.swhwarehouse.Add(model);
    }
    public sysad Add(sysad model)
    {
        return this.sysad.Add(model);
    }
    public sysareabusiness Add(sysareabusiness model)
    {
        return this.sysareabusiness.Add(model);
    }
    public sysareacity Add(sysareacity model)
    {
        return this.sysareacity.Add(model);
    }
    public sysareacounty Add(sysareacounty model)
    {
        return this.sysareacounty.Add(model);
    }
    public sysareaprovince Add(sysareaprovince model)
    {
        return this.sysareaprovince.Add(model);
    }
    public sysbasemoneychange Add(sysbasemoneychange model)
    {
        return this.sysbasemoneychange.Add(model);
    }
    public syschinaarea Add(syschinaarea model)
    {
        return this.syschinaarea.Add(model);
    }
    public sysfunctiontype Add(sysfunctiontype model)
    {
        return this.sysfunctiontype.Add(model);
    }
    public syslogmanagerlogin Add(syslogmanagerlogin model)
    {
        return this.syslogmanagerlogin.Add(model);
    }
    public syslogmanageroperate Add(syslogmanageroperate model)
    {
        return this.syslogmanageroperate.Add(model);
    }
    public sysmanager Add(sysmanager model)
    {
        return this.sysmanager.Add(model);
    }
    public sysmanager_role Add(sysmanager_role model)
    {
        return this.sysmanager_role.Add(model);
    }
    public sysmanagerdetail Add(sysmanagerdetail model)
    {
        return this.sysmanagerdetail.Add(model);
    }
    public sysnoticere Add(sysnoticere model)
    {
        return this.sysnoticere.Add(model);
    }
    public sysnoticesend Add(sysnoticesend model)
    {
        return this.sysnoticesend.Add(model);
    }
    public syspayhistory Add(syspayhistory model)
    {
        return this.syspayhistory.Add(model);
    }
    public syspaymentmode Add(syspaymentmode model)
    {
        return this.syspaymentmode.Add(model);
    }
    public syspemit Add(syspemit model)
    {
        return this.syspemit.Add(model);
    }
    public sysproxyapply Add(sysproxyapply model)
    {
        return this.sysproxyapply.Add(model);
    }
    public sysproxyfeedback Add(sysproxyfeedback model)
    {
        return this.sysproxyfeedback.Add(model);
    }
    public sysrole Add(sysrole model)
    {
        return this.sysrole.Add(model);
    }
    public sysrole_pemit Add(sysrole_pemit model)
    {
        return this.sysrole_pemit.Add(model);
    }
    public sysshopfeedback Add(sysshopfeedback model)
    {
        return this.sysshopfeedback.Add(model);
    }
    public syssms Add(syssms model)
    {
        return this.syssms.Add(model);
    }
    public syssmsall Add(syssmsall model)
    {
        return this.syssmsall.Add(model);
    }
    public syssmstype Add(syssmstype model)
    {
        return this.syssmstype.Add(model);
    }
    public syssmstemplate Add(syssmstemplate model)
    {
        return this.syssmstemplate.Add(model);
    }
    public sysuserfeedback Add(sysuserfeedback model)
    {
        return this.sysuserfeedback.Add(model);
    }
    public sysverificationcode Add(sysverificationcode model)
    {
        return this.sysverificationcode.Add(model);
    }
    public sysversion Add(sysversion model)
    {
        return this.sysversion.Add(model);
    }
    public selflavor Add(selflavor model)
    {
        return this.selflavor.Add(model);
    }
    public seltaboos Add(seltaboos model)
    {
        return this.seltaboos.Add(model);
    }
    public seltablestate Add(seltablestate model)
    {
        return this.seltablestate.Add(model);
    }
    public seltablestateversion Add(seltablestateversion model)
    {
        return this.seltablestateversion.Add(model);
    }
    public selfoodtaste Add(selfoodtaste model)
    {
        return this.selfoodtaste.Add(model);
    }
    public selrepaymentlog Add(selrepaymentlog model)
    {
        return this.selrepaymentlog.Add(model);
    }
    public selrefundpaylog Add(selrefundpaylog model)
    {
        return this.selrefundpaylog.Add(model);
    }
    public selshoppaypassword Add(selshoppaypassword model)
    {
        return this.selshoppaypassword.Add(model);
    }
    #endregion
}

