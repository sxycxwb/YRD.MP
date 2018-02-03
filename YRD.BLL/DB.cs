using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.BLL;
using YRD.BLL.Implementation1;

namespace System
{
    public class DB
    {
        #region 管理类 一期 sel开头的
        public static Lazy<seladvertisementImp> seladvertisement = new Lazy<seladvertisementImp>();  
        public static Lazy<selcardruleImp> selcardrule = new Lazy<selcardruleImp>();
        public static Lazy<selcardrule_foodtypeImp> selcardrule_foodtype = new Lazy<selcardrule_foodtypeImp>();
        public static Lazy<selcashierImp> selcashier = new Lazy<selcashierImp>();
        public static Lazy<selcashier_departmentImp> selcashier_department = new Lazy<selcashier_departmentImp>();
        public static Lazy<selcontrolversionImp> selcontrolversion = new Lazy<selcontrolversionImp>();
        public static Lazy<selcouponImp> selcoupon = new Lazy<selcouponImp>(); 
        public static Lazy<selcouponruleImp> selcouponrule = new Lazy<selcouponruleImp>();
        public static Lazy<seldepartmentImp> seldepartment = new Lazy<seldepartmentImp>();
        public static Lazy<selexpenditureImp> selexpenditure = new Lazy<selexpenditureImp>();
        public static Lazy<selfixedcostImp> selfixedcost = new Lazy<selfixedcostImp>();
        public static Lazy<selfoodImp> selfood = new Lazy<selfoodImp>();
        public static Lazy<selfoodmakelistImp> selfoodmakelist = new Lazy<selfoodmakelistImp>();
        public static Lazy<selfood_managerImp> selfood_manager = new Lazy<selfood_managerImp>();
        public static Lazy<selfoodattributeImp> selfoodattribute = new Lazy<selfoodattributeImp>();
        public static Lazy<selfoodimgImp> selfoodimg = new Lazy<selfoodimgImp>(); 
        public static Lazy<selfoodspecificationsImp> selfoodspecifications = new Lazy<selfoodspecificationsImp>();
        public static Lazy<selfoodtypeImp> selfoodtype = new Lazy<selfoodtypeImp>();
        public static Lazy<selfoodunitImp> selfoodunit = new Lazy<selfoodunitImp>();
        public static Lazy<sellevelImp> sellevel = new Lazy<sellevelImp>();
        public static Lazy<sellogmanagerloginImp> sellogmanagerlogin = new Lazy<sellogmanagerloginImp>();
        public static Lazy<sellogmanageroperateImp> sellogmanageroperate = new Lazy<sellogmanageroperateImp>();
        public static Lazy<sellogshopmoneyImp> sellogshopmoney = new Lazy<sellogshopmoneyImp>();
        public static Lazy<selmanagerImp> selmanager = new Lazy<selmanagerImp>();
        public static Lazy<selmanager_roleImp> selmanager_role = new Lazy<selmanager_roleImp>();
        public static Lazy<selmanagerdetailImp> selmanagerdetail = new Lazy<selmanagerdetailImp>();
        public static Lazy<selnatureImp> selnature = new Lazy<selnatureImp>();
        public static Lazy<selpackageImp> selpackage = new Lazy<selpackageImp>();
        public static Lazy<selpackage_foodImp> selpackage_food = new Lazy<selpackage_foodImp>();
        public static Lazy<selpackageimgImp> selpackageimg = new Lazy<selpackageimgImp>();
        public static Lazy<selpemitImp> selpemit = new Lazy<selpemitImp>();
        public static Lazy<selprinterImp> selprinter = new Lazy<selprinterImp>();
        public static Lazy<selprintertypeImp> selprintertype = new Lazy<selprintertypeImp>();
        public static Lazy<selroleImp> selrole = new Lazy<selroleImp>();
        public static Lazy<selrole_pemitImp> selrole_pemit = new Lazy<selrole_pemitImp>();
        public static Lazy<selroomImp> selroom = new Lazy<selroomImp>();
        public static Lazy<selroomtypeImp> selroomtype = new Lazy<selroomtypeImp>();
        public static Lazy<selscaleImp> selscale = new Lazy<selscaleImp>();
        public static Lazy<selshiftImp> selshift = new Lazy<selshiftImp>();
        public static Lazy<selshopImp> selshop = new Lazy<selshopImp>();
        public static Lazy<selfreeshopidImp> selshopid = new Lazy<selfreeshopidImp>();
        public static Lazy<selshopopenImp> selshopopen = new Lazy<selshopopenImp>();
        public static Lazy<selshopimgImp> selshopimg = new Lazy<selshopimgImp>(); 
        public static Lazy<selshopjinbirechargeImp> selshopjinbirecharge = new Lazy<selshopjinbirechargeImp>();
        public static Lazy<selshopsmschangeImp> selshopsmschange = new Lazy<selshopsmschangeImp>();
        public static Lazy<selshoptypeImp> selshoptype = new Lazy<selshoptypeImp>();
        public static Lazy<selshopversionImp> selshopversion = new Lazy<selshopversionImp>();
        public static Lazy<seltableImp> seltable = new Lazy<seltableImp>();
        public static Lazy<seltable_managerImp> seltable_manager = new Lazy<seltable_managerImp>();
        public static Lazy<seltabletypeImp> seltabletype = new Lazy<seltabletypeImp>();
        public static Lazy<seluserextImp> seluserext = new Lazy<seluserextImp>();
        public static Lazy<seluserextchangeImp> seluserextchange = new Lazy<seluserextchangeImp>();
        public static Lazy<seluserintegralImp> seluserintegral = new Lazy<seluserintegralImp>();
        public static Lazy<seluserintegralchangeImp> seluserintegralchange = new Lazy<seluserintegralchangeImp>();
        public static Lazy<seluserlevelImp> seluserlevel = new Lazy<seluserlevelImp>();
        public static Lazy<seluserlevelchangeImp> seluserlevelchange = new Lazy<seluserlevelchangeImp>();
        public static Lazy<selImp> selImp = new Lazy<selImp>();
        public static Lazy<selshopdiscountImp> selshopdiscount = new Lazy<selshopdiscountImp>();
        #endregion

        #region 管理类， sel开头以外的
        public static Lazy<cusaddressImp> cusaddress = new Lazy<cusaddressImp>();
        public static Lazy<cuscardtypeImp> cuscardtype = new Lazy<cuscardtypeImp>();
        public static Lazy<cuscritiqueImp> cuscritique = new Lazy<cuscritiqueImp>();
        public static Lazy<cusfriendsImp> cusfriends = new Lazy<cusfriendsImp>();
        public static Lazy<cusintegralchangeImp> cusintegralchange = new Lazy<cusintegralchangeImp>();
        public static Lazy<cusintegraltypeImp> cusintegraltype = new Lazy<cusintegraltypeImp>();
        public static Lazy<cusloguserlevelchangeImp> cusloguserlevelchange = new Lazy<cusloguserlevelchangeImp>();
        public static Lazy<cusloguserloginImp> cusloguserlogin = new Lazy<cusloguserloginImp>();
        public static Lazy<cuslogusermoneychangeImp> cuslogusermoneychange = new Lazy<cuslogusermoneychangeImp>();
        public static Lazy<cusloguseroperationImp> cusloguseroperation = new Lazy<cusloguseroperationImp>();
        public static Lazy<cusorderImp> cusorder = new Lazy<cusorderImp>();
        public static Lazy<cusordercusImp> cusordercus = new Lazy<cusordercusImp>();
        public static Lazy<cusorderdetailImp> cusorderdetail = new Lazy<cusorderdetailImp>();
        public static Lazy<cusorderpayImp> cusorderpay = new Lazy<cusorderpayImp>();
        public static Lazy<cusorderpaydetailImp> cusorderpaydetail = new Lazy<cusorderpaydetailImp>();
        public static Lazy<cusorderrabateImp> cusorderrabate = new Lazy<cusorderrabateImp>();
        public static Lazy<cusreserveImp> cusreserve = new Lazy<cusreserveImp>();
        public static Lazy<cususerImp> cususer = new Lazy<cususerImp>();
        public static Lazy<cususer_foodImp> cususer_food = new Lazy<cususer_foodImp>();
        public static Lazy<cususer_levelImp> cususer_level = new Lazy<cususer_levelImp>();
        public static Lazy<cususer_shopImp> cususer_shop = new Lazy<cususer_shopImp>();
        public static Lazy<cususerdetailImp> cususerdetail = new Lazy<cususerdetailImp>();
        public static Lazy<cususerleveltypeImp> cususerleveltype = new Lazy<cususerleveltypeImp>();
        public static Lazy<procompanyImp> procompany = new Lazy<procompanyImp>();
        public static Lazy<procompany_areaImp> procompany_area = new Lazy<procompany_areaImp>();
        public static Lazy<procompanyrabateImp> procompanyrabate = new Lazy<procompanyrabateImp>();
        public static Lazy<prologmanagerloginImp> prologmanagerlogin = new Lazy<prologmanagerloginImp>();
        public static Lazy<prologmanageroperateImp> prologmanageroperate = new Lazy<prologmanageroperateImp>();
        public static Lazy<promanagerImp> promanager = new Lazy<promanagerImp>();
        public static Lazy<promanager_roleImp> promanager_role = new Lazy<promanager_roleImp>();
        public static Lazy<promanager_selshopImp> promanager_selshop = new Lazy<promanager_selshopImp>();
        public static Lazy<promanagerdetailImp> promanagerdetail = new Lazy<promanagerdetailImp>();
        public static Lazy<propemitImp> propemit = new Lazy<propemitImp>();
        public static Lazy<proroleImp> prorole = new Lazy<proroleImp>();
        public static Lazy<prorole_pemitImp> prorole_pemit = new Lazy<prorole_pemitImp>();

        public static Lazy<swhfood_materialImp> swhfood_material = new Lazy<swhfood_materialImp>();
        public static Lazy<swhmaterialImp> swhmaterial = new Lazy<swhmaterialImp>();
        public static Lazy<swhmaterialbrandImp> swhmaterialbrand = new Lazy<swhmaterialbrandImp>();
        public static Lazy<swhmaterialtypeImp> swhmaterialtype = new Lazy<swhmaterialtypeImp>();
        public static Lazy<swhmaterialunitImp> swhmaterialunit = new Lazy<swhmaterialunitImp>();
        public static Lazy<swhorderapplyImp> swhorderapply = new Lazy<swhorderapplyImp>();
        public static Lazy<swhorderapplydetailImp> swhorderapplydetail = new Lazy<swhorderapplydetailImp>();
        public static Lazy<swhordercheckImp> swhordercheck = new Lazy<swhordercheckImp>();
        public static Lazy<swhordercheckdetailImp> swhordercheckdetail = new Lazy<swhordercheckdetailImp>();
        public static Lazy<swhorderinsideImp> swhorderinside = new Lazy<swhorderinsideImp>();
        public static Lazy<swhorderinsidedetailImp> swhorderinsidedetail = new Lazy<swhorderinsidedetailImp>();
        public static Lazy<swhorderlossrateImp> swhorderlossrate = new Lazy<swhorderlossrateImp>();
        public static Lazy<swhorderlossratedetailImp> swhorderlossratedetail = new Lazy<swhorderlossratedetailImp>();
        public static Lazy<swhorderrefundsImp> swhorderrefunds = new Lazy<swhorderrefundsImp>();
        public static Lazy<swhorderrefundsdetailImp> swhorderrefundsdetail = new Lazy<swhorderrefundsdetailImp>();
        public static Lazy<swhorderrequisitionImp> swhorderrequisition = new Lazy<swhorderrequisitionImp>();
        public static Lazy<swhorderrequisitiondetailImp> swhorderrequisitiondetail = new Lazy<swhorderrequisitiondetailImp>();
        public static Lazy<swhsupplierImp> swhsupplier = new Lazy<swhsupplierImp>(); 
        public static Lazy<swhwarehouseImp> swhwarehouse = new Lazy<swhwarehouseImp>();
        public static Lazy<sysadImp> sysad = new Lazy<sysadImp>();
        public static Lazy<syspayhistoryImp> syspayhistory = new Lazy<syspayhistoryImp>();
        //public static Lazy<sysareaImp> sysarea = new Lazy<sysareaImp>();
        public static Lazy<sysbaseImp> sysbase = new Lazy<sysbaseImp>();
        public static Lazy<syschinaareaImp> syschinaarea = new Lazy<syschinaareaImp>();
        //public static Lazy<syscityImp> syscity = new Lazy<syscityImp>();
        //public static Lazy<syscountyImp> syscounty = new Lazy<syscountyImp>();
        public static Lazy<sysfunctiontypeImp> sysfunctiontype = new Lazy<sysfunctiontypeImp>();
        public static Lazy<syslogmanagerloginImp> syslogmanagerlogin = new Lazy<syslogmanagerloginImp>();
        public static Lazy<syslogmanageroperateImp> syslogmanageroperate = new Lazy<syslogmanageroperateImp>();
        public static Lazy<sysmanagerImp> sysmanager = new Lazy<sysmanagerImp>();
        public static Lazy<sysmanager_roleImp> sysmanager_role = new Lazy<sysmanager_roleImp>();
        public static Lazy<sysmanagerdetailImp> sysmanagerdetail = new Lazy<sysmanagerdetailImp>();
        public static Lazy<sysnoticereImp> sysnoticere = new Lazy<sysnoticereImp>();
        public static Lazy<sysnoticesendImp> sysnoticesend = new Lazy<sysnoticesendImp>();
        public static Lazy<syspemitImp> syspemit = new Lazy<syspemitImp>();
        //public static Lazy<sysprovinceImp> sysprovince = new Lazy<sysprovinceImp>();
        public static Lazy<sysproxyapplyImp> sysproxyapply = new Lazy<sysproxyapplyImp>();
        public static Lazy<sysproxyfeedbackImp> sysproxyfeedback = new Lazy<sysproxyfeedbackImp>();
        public static Lazy<sysroleImp> sysrole = new Lazy<sysroleImp>();
        public static Lazy<sysrole_pemitImp> sysrole_pemit = new Lazy<sysrole_pemitImp>();
        public static Lazy<sysshopfeedbackImp> sysshopfeedback = new Lazy<sysshopfeedbackImp>();
        public static Lazy<syssmsImp> syssms = new Lazy<syssmsImp>();
        public static Lazy<syssmstemplateImp> syssmstemplate = new Lazy<syssmstemplateImp>();

        public static Lazy<sysuserfeedbackImp> sysuserfeedback = new Lazy<sysuserfeedbackImp>();
        public static Lazy<sysversionImp> sysversion = new Lazy<sysversionImp>();

        #endregion

        #region 管理类， swh开头的库存
        public static Lazy<swhsuppliertypeimp> swhsuppliertype = new Lazy<swhsuppliertypeimp>(); 
        public static Lazy<swhorderautooutsideImp> swhorderautooutside = new Lazy<swhorderautooutsideImp>();
        public static Lazy<swhorderautooutsidefooddetailImp> swhorderautooutsidefooddetail = new Lazy<swhorderautooutsidefooddetailImp>();
        public static Lazy<swhorderautooutsidematerialdetailImp> swhorderautooutsidematerialdetail = new Lazy<swhorderautooutsidematerialdetailImp>();
        #endregion
    }
}
